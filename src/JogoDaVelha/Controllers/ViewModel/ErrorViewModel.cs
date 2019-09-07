using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoDaVelha.Controllers.ViewModel
{
    public class ErrorViewModel
    {
        [JsonProperty("error")]
        public ErrorDetail Error { get; set; }

        public ErrorViewModel(string code, string message)
        {
            Error = new ErrorDetail()
            {
                Code = code,
                Message = message
            };
        }

        public ErrorViewModel(string code, string message, ErrorDetail[] details)
        {
            Error = new ErrorDetail()
            {
                Code = code,
                Message = message,
                Details = details
            };
        }

        public ErrorViewModel(string code, string message, string target) : this(code, message)
        {
            Error.Target = target;
        }

        public class ErrorDetail
        {
            [JsonProperty("code")]
            public string Code { get; set; }
            [JsonProperty("message")]
            public string Message { get; set; }
            [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
            public string Target { get; set; }
            [JsonProperty("details", NullValueHandling = NullValueHandling.Ignore)]
            public ErrorDetail[] Details { get; set; }
        }
    }
}
