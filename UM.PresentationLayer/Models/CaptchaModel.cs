using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UM.PresentationLayer.Models
{
    public class CaptchaModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }

    }
}