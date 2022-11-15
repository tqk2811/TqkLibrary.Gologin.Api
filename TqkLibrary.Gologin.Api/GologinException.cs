using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TqkLibrary.Gologin.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class GologinException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public GologinError GologinError { get; }
        internal GologinException(GologinError gologinError)
        {
            this.GologinError = gologinError;
        }

        /// <inheritdoc/>
        public override string Message => GologinError?.Message;
    }


    public class GologinError
    {
        public int StatusCode { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        public string Message { get; set; }
    }
    public class Error
    {
        public string Property { get; set; }
        public Dictionary<string, string> Messages { get; set; }

        public override string ToString()
        {
            return $"Path: {Property}, Message: {string.Join(", ", Messages.Select(x => x.Value))}";
        }
    }

}
