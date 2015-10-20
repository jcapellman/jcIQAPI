using System.Collections.Generic;
using System.Web.Http;

using jcIQAPI.Universal.Library.Transports;

namespace jcIQAPI.Server.Library {
    public class ServerController : ApiController {
        public List<QueryResponseItem> GET(string query) {
            return new List<QueryResponseItem>();
        } 
    }
}