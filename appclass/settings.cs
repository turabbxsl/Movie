using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Filmsayt.appclass
{
    public class settings
    {
        public static Size Filmkicikboyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["Filmkicikwidth"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["Filmkicikheight"]);
                return sz;
            }
        }
        public static Size KullaniciBoyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["KW"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["KH"]);
                return sz;
            }
        }
        public static Size Filmortaboyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["Filmortawidth"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["Filmortaheight"]);
                return sz;
            }
        }

        public static Size Filmboyukboyut
        {
            get
            {
                Size sz = new Size();
                sz.Width = Convert.ToInt32(ConfigurationManager.AppSettings["Filmboyukwidth"]);
                sz.Height = Convert.ToInt32(ConfigurationManager.AppSettings["Filmboyukheight"]);
                return sz;
            }
        }
    }
}