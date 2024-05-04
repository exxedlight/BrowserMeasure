using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserMeasure.Entities
{
    public abstract class IElapsedTime
    {
        //  enter and leave time points
        public DateTime? enterTime { get; set; } = null;
        public DateTime? leaveTime { get; set; } = null;

        //  elapsed from enter to leave
        public TimeSpan elapsedTime { get; set; } = TimeSpan.Zero;


        //  calc time from enter to leave
        public void calculateElapsed()
        {

            if (enterTime == null || leaveTime == null)
                return;

            elapsedTime += (((DateTime)leaveTime).Subtract((DateTime)enterTime));

            enterTime = leaveTime = null;
        }
    }
}
