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
    public class RevenueOfficeController : ApiController
    {
        public class Office
        {
            public string RevenueOfficeID
            {
                get; set;
            }
            public string RevenueOfficeName
            {
                get; set;
            }
        }

        public IHttpActionResult Get()
        {
            var options = Request.GetQueryNameValuePairs()
                .ToDictionary(x => x.Key, x => JsonConvert.DeserializeObject(x.Value));

            var db = new Database(ConfigurationManager.ConnectionStrings["Registration2ConnectionString"].ConnectionString, "System.Data.SqlClient");

            var agents = db.From<Office>("vwRevenueOffice");
            var agentFilterd = agents;
            //.FilterByOptions(options, out bool isFiltered)   //filtering
            //.SortByOptions(options)     //sorting
            //.PageByOptions(options);    //paging
            var data = agentFilterd.ToList();
            int totalCount = agents.Count();/*isFiltered ? data.Count : agents.Count();*/
            var response = new AgentsController.DataGridResult<Office>
            {
                Data = data,
                TotalCount = totalCount
            };
            return Ok(response);
        }
    }
}