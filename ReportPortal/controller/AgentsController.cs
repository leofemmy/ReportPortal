using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DbExtensions;
using Newtonsoft.Json;

namespace ReportPortal.controller
{
    public class AgentsController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var options = Request.GetQueryNameValuePairs()
                .ToDictionary(x => x.Key, x => JsonConvert.DeserializeObject(x.Value));

            var db = new Database(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString, "System.Data.SqlClient");

            var agents = db.From<Agents>("vwAgents");
            var agentFilterd = agents;
            //.FilterByOptions(options, out bool isFiltered)   //filtering
            //.SortByOptions(options)     //sorting
            //.PageByOptions(options);    //paging
            var data = agentFilterd.ToList();
            int totalCount = agents.Count();/*isFiltered ? data.Count : agents.Count();*/
            var response = new DataGridResult<Agents>
            {
                Data = data,
                TotalCount = totalCount
            };
            return Ok(response);

            //return new string[] { "value1", "value2" };
        }

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

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
        public class Agents
        {
            public string TaxAgentUtin
            {
                get; set;
            }
            public string TaxAgentName
            {
                get; set;
            }
        }

        public class DataGridResult<TObject> where TObject : class
        {
            public DataGridResult()
            {
                Data = new List<TObject>();
            }
            [JsonProperty("data")]
            public List<TObject> Data { get; set; }
            [JsonProperty("totalCount")]
            public int TotalCount { get; set; }
            //public List<int> Summary { get; set; }
        }
    }
}