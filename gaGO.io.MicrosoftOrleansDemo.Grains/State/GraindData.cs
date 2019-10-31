using System;
using System.Collections.Generic;
using System.Text;

namespace gaGO.io.MicrosoftOrleansDemo.State
{
    public class GraindData
    {
        public string Name { get; set; }

        public List<GraindDataSub> Data { get; set; } = new List<GraindDataSub>();
    }


    public class GraindDataSub
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
