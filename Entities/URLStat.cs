using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserMeasure.Entities
{
    public class URLStat : IElapsedTime
    {
        //  full web URL
        public string fullURL { get; set; } = "";
        
        //  short site name, f.e. www.youtube.com
        public string site { get; set; } = "";



        //  automatic mading site title from full URL
        public void makeSiteFromURL()
        {
            if (string.IsNullOrWhiteSpace(fullURL))
                return;

            try
            {
                site = fullURL.Split('/')[2];
            }
            catch { }
        }
    }
}
