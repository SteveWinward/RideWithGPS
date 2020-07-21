using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace RideWithGPS
{
    public class RideWithGPSConnectionInfo
    {
        public const string BASE_URL = "https://ridewithgps.com";

        public string Version { get; protected set; } = "2";

        public string ApiKey { get; set; }

        public string Email { get; set; }

        public SecureString Password { get; set; }

        public string BaseUrl { get; set; } = BASE_URL;
    }
}
