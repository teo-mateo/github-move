using System;

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
