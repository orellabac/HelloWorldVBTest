namespace Mobilize.Helpers
{
    /// <summary>
    /// Indicates how a application authenticates the user for the My.User
    ///     object.
    /// </summary>
    public enum AuthenticationMode
    {
        /// <summary>
        /// initializes the principal for the application's main thread with
        ///     the current user's Windows user information.
        /// </summary>
        Windows = 0,
        /// <summary>
        ///  The application needs to initialize the principal for the application's main
        //     thread.
        /// </summary>
        ApplicationDefined = 1
    }
}