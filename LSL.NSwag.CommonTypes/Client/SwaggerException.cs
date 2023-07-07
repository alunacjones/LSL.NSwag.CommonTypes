namespace LSL.NSwag.CommonTypes.Client
{
    /// <summary>
    /// The common exception type for NSwag generated clients
    /// </summary>
    public partial class SwaggerException : System.Exception
    {
        /// <summary>
        /// Status code returned by the erroneous call
        /// </summary>
        /// <value></value>
        public int StatusCode { get; private set; }

        /// <summary>
        /// A string representation of the error response
        /// </summary>
        /// <value></value>
        public string Response { get; private set; }

        /// <summary>
        /// The headers that were returned in the erroneous call
        /// </summary>
        /// <value></value>
        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        /// <summary>
        /// NSwag-based constructor for the erroneous call
        /// </summary>
        /// <param name="message">The message from the client implementation</param>
        /// <param name="statusCode">The status code that was returned by the API</param>
        /// <param name="response">The response from the API</param>
        /// <param name="headers">The headers that were returned in the erroneous call</param>
        /// <param name="innerException">Any inner exception</param>
        public SwaggerException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        /// <summary>
        /// The string representation of the error
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }
}
