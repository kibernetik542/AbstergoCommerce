using System;
using System.Configuration;
using System.Drawing;

namespace AbstergoCommerce.WebUI.App_Class
{
    public static class Settings
    {
        public static Size ProductMediumSize
        {
            get
            {
                Size sz = new Size
                {
                    Width = Convert.ToInt32(ConfigurationManager.AppSettings["ProductMedWidth"]),
                    Height = Convert.ToInt32(ConfigurationManager.AppSettings["ProductMedHeight"])
                };
                return sz;
            }

        }

        public static Size ProductBigSize
        {
            get
            {
                Size sz = new Size
                {
                    Width = Convert.ToInt32(ConfigurationManager.AppSettings["ProductBigWidth"]),
                    Height = Convert.ToInt32(ConfigurationManager.AppSettings["ProductBigHeigth"])
                };
                return sz;
            }

        }
    }
}