using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Orleans.Services;

namespace gaGO.io.BotPlatform.Internals
{
    public interface ISystemInfoGrain: IGrainWithIntegerKey
    {
        Task<OperatingSystem> GetOSInfo();

        Task<DateTime> GetTime();

        Task<DateTime> ThrowException();
    }
}
