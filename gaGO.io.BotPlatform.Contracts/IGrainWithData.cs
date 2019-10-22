using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orleans;

namespace gaGO.io.BotPlatform
{
    public interface IGrainWithData : IGrainWithIntegerKey
    {
        Task SetName(string name);

        Task<string> GetName();
    }
}
