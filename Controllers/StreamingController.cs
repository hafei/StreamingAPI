using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace StreamingAPI.Controllers
{
    public class StreamingController : ApiController
    {
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}

        // get api/Streaming/streaming
        [HttpGet]
        public async Task Streaming()
        {
            Console.WriteLine("Streaming started");
            try
            {
                var response = System.Web.HttpContext.Current.Response;
                response.Headers.Add("Content-Type", "text/event-stream");

                var tables = new List<string> { "Table1", "Table2", "Table3" };

                response.Flush();

                foreach (var table in tables)
                {
                    if (response.IsClientConnected)
                    {
                        var result = await GetDataFromTable(table);

                        response.Write(result + "\n");
                        response.Flush();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private async Task<string> GetDataFromTable(string tableName)
        {
            // 模拟数据库查询
            await Task.Delay(2000);

            return $"Data from {tableName}";
        }
    }
}