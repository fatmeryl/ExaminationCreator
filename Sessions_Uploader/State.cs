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
        LessThan2AnnFiles,
        NoConfigFile,
        Ok,
    }
}
