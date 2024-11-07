using BareInternationalTest.BL;
using BareInternationalTest.MODEL;
using Microsoft.AspNetCore.Mvc;

namespace BareInternationalTest.Controllers
{
    public class DictionaryController : Controller
    {

        private readonly DictionaryService dictionaryService;
        
        public DictionaryController(DictionaryService dictionaryService) 
        {
            this.dictionaryService = dictionaryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("api/v1/Converter")]
        [HttpPost]
        public IActionResult ConvertLanguage([FromBody] Translate ts)
        {
            return Json(dictionaryService.ConvertLanguage(ts));
            //return Json(ts);
        }
    }
}
