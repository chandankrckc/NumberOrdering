using System.IO;
using Microsoft.AspNetCore.Mvc;
using NumberOrdering.Data;
using System.Text.Json;
using System.Collections.Generic;
using System.Web;
using NumberOrdering.Models;


namespace NumberOrdering.Controllers
{
    [ApiController]
    public class NumbersController : Controller
    {
        private IDataService _numberData;
        public NumbersController(IDataService numberData)
        {
            _numberData = numberData;
        }

        [HttpGet]
        [Route("api/numbers")]
        public IActionResult GetTextFile()
        {
            return Ok(_numberData.GetTextFile());
        }

        [HttpPost]
        [Route("api/numbers")]
        public ActionResult PostNumbers(Numbers num)
        {
            _numberData.PostArrayData(num);
            return Created("path", num);
        }
    }
}
