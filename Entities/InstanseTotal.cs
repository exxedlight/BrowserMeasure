using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserMeasure.Entities
{
    public class InstanseTotal
    {
        //  app/site title
        public string Name { get; set; } = "";

        //  total time spended
        public TimeSpan totalTime { get; set; } = TimeSpan.Zero;
    }
}
