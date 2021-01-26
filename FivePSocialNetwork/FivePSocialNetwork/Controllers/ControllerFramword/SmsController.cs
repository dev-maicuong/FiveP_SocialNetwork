using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace FivePSocialNetwork.Controllers.ControllerFramword
{
    public class SmsController : TwilioController
    {
        // GET: Sms
        public ActionResult SMS()
        {
            var accountSid = Environment.GetEnvironmentVariable("AC50dec42d48ae8b908ec2ec1f11d4af56");
            var authToken = Environment.GetEnvironmentVariable("146ee3e972dc6bc29d3b56ec79522011");

            TwilioClient.Init("AC50dec42d48ae8b908ec2ec1f11d4af56", "146ee3e972dc6bc29d3b56ec79522011");

            var from = new PhoneNumber("+17202880938");
            var to = new PhoneNumber("+84377416055");
            var message = MessageResource.Create(
                from: from,
                to: to,
                body: "Hi there!"
            );
            return Content(message.Sid);
        }
    }
}