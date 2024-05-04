using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserMeasure.Entities
{
    public class AppStat : IElapsedTime
    {
        //  app name (window title)
        public string AppName { get; set; } = string.Empty;
    }
}
