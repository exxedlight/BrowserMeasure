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
        public static List<URLStat> siteStats = new List<URLStat>();


        //  in file saved statistics for (browsers) and (URLs)
        public static List<InstanseTotal> browsersTotal = new List<InstanseTotal>();
        public static List<InstanseTotal> urlsTotal = new List<InstanseTotal>();


        //  titles of current app and site
        private static string? previosApp = null;
        private static string? previosSite = null;


        //  datetimes of entering
        private static DateTime? app_enterTime = null;
        private static DateTime? app_leaveTime = null;

        //  datetimes of leaving
        private static DateTime? site_enterTime = null;
        private static DateTime? site_leaveTime = null;


        public static TimeSpan getAllBrowserTime()
        {
            TimeSpan totalTime = TimeSpan.Zero;

            foreach(AppStat stat in appStats)
            {
                totalTime += stat.elapsedTime;
            }

            return totalTime;
        }

        public static void pushApplication(string appname)
        {
            if (previosApp == null)
            {   //  no previos application - remember this

                previosApp = appname;
                app_enterTime = DateTime.Now;   //  remember enter time
                return;
            }

            if (previosApp == appname)
            {   //  nothing to do if previos = current

                return;
            }

            if (previosApp != appname)
            {   //  application changed

                fixAppTimeInList(appname);
            }
        }
        public static void pushUrl(string url)
        {
            string site;
            
            try { site = url.Split('/').ElementAt(2); }
            catch { return; }

            if (string.IsNullOrEmpty(site)) site = "Not handled";

            if (previosSite == null)
            {
                previosSite = site;
                site_enterTime = DateTime.Now;
                return;
            }

            if(previosSite == site)
            {
                return;
            }

            if (previosSite != site)
            {
                fixSiteTimeInList(site, false);
            }
        }

        public static void BrowserFinished()
        {

            if (previosApp == null) return;
            if (previosSite == null) return;

            fixAppTimeInList(null);
            if(previosSite != null) fixSiteTimeInList(previosSite, true);
        }

        /*private static void fixSiteOnFinishBrowser()
        {
            site_leaveTime
        }*/

        private static void fixAppTimeInList(string? appname)
        {
            app_leaveTime = DateTime.Now;   //  fixate leave time

            //  find current app in app list
            AppStat? currentAppStat = appStats.FirstOrDefault(x => x.AppName == previosApp);

            if (currentAppStat == null)
            {   //  if app dont finded

                //  add app to list

                AppStat newAppStat = new AppStat();

                newAppStat.AppName = previosApp;
                newAppStat.enterTime = app_enterTime;
                newAppStat.leaveTime = app_leaveTime;
                
                newAppStat.calculateElapsed();

                appStats.Add(newAppStat);
            }
            else
            {   //  app exist in list

                //  replace enter and leave times, add calculate elapsed to exist
                currentAppStat.enterTime = app_enterTime;
                currentAppStat.leaveTime = app_leaveTime;
                currentAppStat.calculateElapsed();

                //  replace object in list (remove, then add)
                appStats.Remove(appStats.First(x => currentAppStat.AppName == x.AppName));
                appStats.Add(currentAppStat);
            }

            //  remember new application name and its ender time 
            previosApp = appname;
            app_enterTime = DateTime.Now;
        }
        private static void fixSiteTimeInList(string? site, bool clearPrev)
        {

            site_leaveTime = DateTime.Now;

            //find current site in list
            URLStat? currentUrlStat = siteStats.FirstOrDefault(x => x.site == site);

            if (currentUrlStat == null)
            {
                URLStat newUrlStat = new URLStat();

                //newUrlStat.fullURL = url;
                newUrlStat.site = site;
                newUrlStat.enterTime = site_enterTime;
                newUrlStat.leaveTime = site_leaveTime;

                newUrlStat.calculateElapsed();

                siteStats.Add(newUrlStat);
            }
            else
            {
                currentUrlStat.enterTime = site_enterTime;
                currentUrlStat.leaveTime = site_leaveTime;
                currentUrlStat.calculateElapsed();

                siteStats.Remove(siteStats.First(x => x.site == site));
                siteStats.Add(currentUrlStat);
            }

            if (clearPrev) previosSite = null;
            else previosSite = site;
            
            site_enterTime = DateTime.Now;
        }


    }
}
