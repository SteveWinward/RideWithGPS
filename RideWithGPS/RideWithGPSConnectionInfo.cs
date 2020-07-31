using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace RideWithGPS
{
    /// <summary>
    /// Encapsulates the RideWithGPS API Connection details
    /// </summary>
    public class RideWithGPSConnectionInfo
    {
        public const string BASE_URL = "https://ridewithgps.com";

        /// <summary>
        /// The current api version is 2
        /// </summary>
        public string Version { get; protected set; } = "2";

        /// <summary>
        /// The API key for your application
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// The email to authenticate with
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The password associated with the email account
        /// </summary>
        public SecureString Password { get; set; }

        /// <summary>
        /// The base url of the RideWithGPS API
        /// </summary>
        public string BaseUrl { get; protected set; } = BASE_URL;
    }
}
