using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StreamingAPI.Controllers
{
    public class EventStreamController : Controller
    {
        //GET: EventStream
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task EventStream()
        {
            //var response = Response;
            //response.Headers.Add("Content-Type", "text/event-stream");

            //for (var i = 0; true; i++)
            //{
            //    using (var writer = new StreamWriter(response.OutputStream))
            //    {
            //        await writer.WriteAsync(string.Format("data: {0}\n\n", i));
            //        await writer.FlushAsync();
            //    }

            //    await Task.Delay(5000);
            //}

            //not working
            //StringBuilder sb = new StringBuilder();
            //for (var i = 0; true; i++)
            //{
            //    sb.AppendFormat("data: {0}\n\n", i);
            //    await Task.Delay(5000);
            //}

            //return Content(sb.ToString(), "text/event-stream");


            Response.ContentType = "text/event-stream";

            for (var i = 0; true; i++)
            {
                using (StreamWriter writer = new StreamWriter(Response.OutputStream, Encoding.Default))
                {
                    await writer.WriteAsync($"data: {i}\n\n");
                    await writer.FlushAsync();
                }

                await Task.Delay(1000);
            }
        }
    }
}