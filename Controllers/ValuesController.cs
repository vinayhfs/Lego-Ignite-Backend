using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
namespace LegoApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private ConcurrentDictionary<string, HybridTechnologies> _techs = new ConcurrentDictionary<string, HybridTechnologies>();
        // GET api/values
        public ValuesController()
        {
            HybridTechnologies techs = new HybridTechnologies();
            techs.Names = new List<string>() { "Xamrin", "NativeScript", "PhoneGap" };
            _techs[Guid.NewGuid().ToString()] = techs;
        }

        [HttpGet]
        public IEnumerable<HybridTechnologies> Get()
        {
            return _techs.Values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string pageContent = string.Empty;
            switch (id)
            {
            case 1:
                pageContent = "Open lego box and pick up manual";
                break;
            case 2:
                pageContent = "Study instructions and observer step wise images";
                break;
            case 3:
                pageContent = "Start building lego. Best of luck !";
                break;
            default:
                pageContent = "Best of luck !";
                break;
            }
            
            return pageContent;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
     public class HybridTechnologies
    {
        public List<string> Names { get; set; }
    }
}
