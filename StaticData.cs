using BrowserMeasure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BrowserMeasure
{
    public static class StaticData
    {
        //  enter-leave statistisc for (applications) and (URLs)
        public static List<AppStat> appStats = new List<AppStat>();
        public static List<URLStat> URLStats = new List<URLStat>();

        //  in file saved statistics for (browsers) and (URLs)
        public static List<InstanseTotal> browsersTotal = new List<InstanseTotal>();
        public static List<InstanseTotal> urlsTotal = new List<InstanseTotal>();

    }
}
