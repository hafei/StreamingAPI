using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StreamingAPI.Controllers
{
    public class StreamController : Controller
    {
        // this method works fine
        // GET: Stream
        public ActionResult Index()
        {
            Response.Buffer = false;
            Response.ContentType = "text/event-stream";
            Response.Write("data: Welcome to the Event Stream\n\n");
            Response.Flush();

            var rnd = new Random();

            for (var i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(1000);

                var message = $"data: This is event {i + 1}\n\n";
                Response.Write(message);
                Response.Write("\n");
                Response.Flush();
            }

            return new EmptyResult();
        }
    }
}