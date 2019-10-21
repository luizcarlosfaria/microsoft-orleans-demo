using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gaGO.io.BotPlatform.Internals
{
    public class SystemInfoGrain : Orleans.Grain, ISystemInfoGrain
    {
        public Task<OperatingSystem> GetOSInfo()
        {
            return Task.FromResult(System.Environment.OSVersion);
        }

        public Task<DateTime> GetTime()
        {
            return Task.FromResult(DateTime.Now);
        }


        public Task<DateTime> ThrowException()
        {
            throw new InvalidOperationException("Test Exception");
        }

    }
}
