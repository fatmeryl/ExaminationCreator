namespace ExaminationCreator
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
