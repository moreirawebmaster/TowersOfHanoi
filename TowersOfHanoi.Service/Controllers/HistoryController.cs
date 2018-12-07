using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TowersOfHanoi.Application.Histories.Queries;

namespace TowersOfHanoi.Service.Controllers
{
    [RoutePrefix("history")]
    public class HistoryController : ApiController
    {
        private readonly IGetHistoryListQuery _historyListQuery;

        public HistoryController(IGetHistoryListQuery historyListQuery)
        {
            _historyListQuery = historyListQuery;
        }


        [Route("user/{userId:int}/histories")]
        public async Task<IHttpActionResult> Get(int userId)
        {
            var result = await _historyListQuery.Execute(new HistoryListRequestDto {UserId = userId});
            return Ok(result);
        }
    }
}