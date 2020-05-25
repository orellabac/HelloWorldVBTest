namespace Mobilize.Helpers
{
    /// <summary>
    /// Indicates which condition should the application to shut down.
    /// </summary>
    public enum ShutdownMode
    {
        /// <summary>
        /// Shut down when the main form closes.
        /// </summary>
        AfterMainFormCloses = 0,

        /// <summary>
        /// Shut down only after the last form closes.
        /// </summary>
        AfterAllFormsClose = 1
    }
}