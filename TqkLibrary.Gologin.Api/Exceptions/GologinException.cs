using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TqkLibrary.Gologin.Api.Exceptions
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
            GologinError = gologinError;
        }

        /// <inheritdoc/>
        public override string Message => GologinError?.Message ?? string.Empty;
    }
}
