using CorePush.Google;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.BussinessLogics
{
    public class FcmLogic
    {
        


    }

    public class GoogleNotification
    {
        public class DataPayload
        {
            // Add your custom properties as needed
            [JsonProperty("message")]
            public string Message { get; set; }
        }

        [JsonProperty("priority")]
        public string Priority { get; set; } = "high";

        [JsonProperty("data")]
        public DataPayload Data { get; set; }
    }

    public class AppleNotification
    {
        public class ApsPayload
        {
            [JsonProperty("alert")]
            public string AlertBody { get; set; }
        }

        // Your custom properties as needed

        [JsonProperty("aps")]
        public ApsPayload Aps { get; set; }
    }
}
