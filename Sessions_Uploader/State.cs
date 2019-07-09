namespace Sessions_Uploader
{
    public enum State
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
