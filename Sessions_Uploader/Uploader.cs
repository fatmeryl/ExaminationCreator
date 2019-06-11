﻿using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Sessions_Uploader
{
    public class Uploader
    {
        public static string NewExaminationId;
        private string InExaminationPath;
        private string OutExaminationPath;
        private TimeSpan Interval;

        public Uploader(DateTime newExaminationTime, string inExaminationPath, string outExaminationPath)
        {
            var examinationId = Path.GetFileName(Path.GetDirectoryName(inExaminationPath));
            var examinationDateString = examinationId.Substring(0, 14);
            var examinationDate = DateTime.ParseExact(examinationDateString, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None).ToUniversalTime();

            InExaminationPath = inExaminationPath;         
            Interval = newExaminationTime - examinationDate;

            NewExaminationId = newExaminationTime.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture) + examinationId.Substring(14);

            OutExaminationPath = outExaminationPath + NewExaminationId + @"\";            
        }

        public void UploadToServer(String serverPath)
        {
            Directory.CreateDirectory(OutExaminationPath);

            var files = Directory.GetFiles(InExaminationPath, "*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fileDate = Path.GetFileNameWithoutExtension(file);
                var matches = new Regex(@"(20\d+)").Matches(fileDate);
                string outFile;
                if (matches.Count == 1)
                {
                    var oldFileDate = matches[0].Value;
                    string newFileDate;
                    if (oldFileDate.Length == 14)
                    {
                        newFileDate = ShiftDate(oldFileDate, "yyyyMMddHHmmss", Interval);
                    }
                    else
                    {
                        newFileDate = ShiftDate(oldFileDate, "yyyyMMddHHmmssfff", Interval);
                    }
                    outFile = OutExaminationPath + Path.GetFileName(file).Replace(oldFileDate, newFileDate);
                }
                else
                {
                    outFile = OutExaminationPath + Path.GetFileName(file);
                }
                var extension = Path.GetExtension(file);
                if (extension.EndsWith("msg") || extension.EndsWith("rtl"))
                {
                    ShiftDates(file, outFile, Interval);
                }
                else
                {
                    File.Copy(file, outFile);
                }
            }

            CreateFolder(serverPath);
            UploadStudy(serverPath);
        }

        private string ShiftDate(string date, string format, TimeSpan interval)
        {
            var oldDate = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture).ToUniversalTime();
            var newDate = oldDate + interval;
            var dateChanged = newDate.ToString(format, CultureInfo.InvariantCulture);
            return dateChanged;
        }

        private void ShiftDates(string xmlFilePath, string outPath, TimeSpan interval)
        {
            var doc = XDocument.Load(xmlFilePath);
             
            var timeNodes = new string[] { "starttime", "endtime", "last_modified_time", "log_time" }.SelectMany(tag => doc.Descendants(tag));

            foreach (var node in timeNodes)
            {
                var dateChanged = ShiftDate(node.Value, "yyyy/MM/ddUHH:mm:ss.fff", Interval);
                node.Value = dateChanged;
            }
            
            foreach (var node in new string[] { "from", "stoprec" }.SelectMany(tag => doc.Descendants(tag)))
            {
                node.Value = NewExaminationId;
            }
            
            foreach (var node in doc.Descendants("name"))
            {
                var msgName = Path.GetFileName(outPath);
                var suffix = node.Value.Substring(node.Value.Length - 4);
                node.Value = msgName.Substring(0, node.Value.Length - 4) + suffix;
            }

            doc.Save(outPath);
        }
        
        public void CreateFolder(String ServerPath)
        {
            string network_path = ServerPath + @"\" + NewExaminationId;

            if (!Directory.Exists(network_path))
                Directory.CreateDirectory(network_path);
        }

        public void UploadStudy(String ServerPath)
        {
            uploadManyFiles("*rtl", ServerPath);
            uploadManyFiles("*rdl", ServerPath);
            uploadManyFiles("*ann", ServerPath);
            uploadManyFiles("*msg", ServerPath);
        }
        public void uploadManyFiles(string typeOfFiles, String ServerPath)//ototot
        {
            DirectoryInfo directory = new DirectoryInfo(OutExaminationPath);
            foreach (var file in directory.GetFiles(typeOfFiles))
            {
                UploadFile(ServerPath, file.Name);
            }
        }
        public void UploadFile(String ServerPath, string fileName)
        {
            string targetPath = ServerPath + @"\" + NewExaminationId;
            string sourcePath = OutExaminationPath;
            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);
            File.Copy(sourceFile, destFile, true);
        }
    }
}
