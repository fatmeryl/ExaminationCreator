namespace Sessions_Uploader
{
    enum State
    {
        NotValidSourceDir,
        NoAnnFiles,
        NoServerSelected,
        ServerConnectionProblem,
        SourceDirEqualsOutputDir,
        NotValidOutputDir,
        TempDirNotExist,
        SuccesfulUpload,
        LessThan2AnnFiles,
        NoConfigFile
    }
}
