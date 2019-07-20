using System;
using System.Collections.Generic;
using System.Text;

namespace Clover.Common.Configuration
{
    public enum CloverConfigEnum
    {
        CLOVER_STORAGE_ACCOUNT,
        CLOVER_STORAGE_KEY
    }
    public interface ICloverConfig
    {
        string Get(CloverConfigEnum key);
    }
}
