using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace eshop.Application.Services.Authentication
{
    public class SmsService
    {
        public void Send(string PhoneNumber,string Code)
        {
            var client = new WebClient();
            //------------------------------------------apikey is yours
            string Url = $"http://panel.kavenegar.com/v1/apikey/verify/lookup.json?receptor={PhoneNumber}&token={Code}&template=VerifyBugetoAccount";
            var content= client.DownloadString(Url);
        }
    }
}
