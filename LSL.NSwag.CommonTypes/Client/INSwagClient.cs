namespace LSL.NSwag.CommonTypes.Client
{
    /// <summary>
    /// The base interface for an NSwag generated client
    /// </summary>
    public interface INSwagClient
    {
        /// <summary>
        /// The BaseUrl of the API to connect to
        /// </summary>
        /// <value></value>
        string BaseUrl { get; set; }
    }
}
