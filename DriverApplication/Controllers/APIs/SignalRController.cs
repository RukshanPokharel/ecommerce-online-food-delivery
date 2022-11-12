using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DriverApplication.Controllers.APIs
{
    public class SignalRController : ApiController
    {
        /// <summary>
        /// link for signalr connection is  " http://ec2-3-19-79-9.us-east-2.compute.amazonaws.com:7070/DriverApplication/pushNotification/hubs " 
        /// </summary>
        /// <param name="value">
        /// use this link for signalr connection " http://ec2-3-19-79-9.us-east-2.compute.amazonaws.com:7070/DriverApplication/pushNotification/hubs "
        /// </param>
        public void SignalR_Connection_Link([FromBody]string value)
        {
        }
    }
}
