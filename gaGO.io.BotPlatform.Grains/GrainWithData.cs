using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using gaGO.io.BotPlatform.State;
using Orleans;

namespace gaGO.io.BotPlatform
{
    public class GrainWithData : Grain<GraindData>, IGrainWithData
    {
        public async Task SetName(string name)
        {
            this.State.Name = name;

            if (this.State.Data == null)
                this.State.Data = new List<GraindDataSub>();

            await base.WriteStateAsync();
            //return Task.CompletedTask;
        }

        public Task<string> GetName() => Task.FromResult(this.State.Name);

    }
}
