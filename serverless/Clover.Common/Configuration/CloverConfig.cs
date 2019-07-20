using System;
using System.Collections.Generic;
using System.Text;

namespace Clover.Common.Configuration
{
    public class CloverConfig : ICloverConfig
    {
        public string Get(CloverConfigEnum key)
        {
            var value = Environment.GetEnvironmentVariable(key.ToString());
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("missing configuration");
            }
            return value;
        }
    }
}
