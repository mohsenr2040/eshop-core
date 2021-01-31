using System;
using System.Collections.Generic;
using System.Text;

namespace eshop.Common.Share
{
    public interface IShareService
    {
       string Share(string Url);
    }

    public class ShareInInstagram : IShareService
    {
        public string Share(string url)
        {
            return "در تلگرام به اشتراک گذاشته شد";
        }
    }
    public class ShareInWhatsApp : IShareService
    {
        public string Share(string url)
        {
            return "در واتس اپ به اشتراک گذاشته شد";
        }
    }
}
