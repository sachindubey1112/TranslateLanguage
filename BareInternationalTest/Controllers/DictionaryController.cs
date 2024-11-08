using BareInternationalTest.BL;
using BareInternationalTest.MODEL;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace BareInternationalTest.Controllers
{
    public class DictionaryController : Controller
    {

        private readonly DictionaryService dictionaryService;
        private static readonly Logger Logger = LogManager.GetLogger("mycustomLog");

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
            TranslateModelViewModel response = new TranslateModelViewModel();
            try
            {
                response = dictionaryService.ConvertLanguage(ts);
                Logger.Info("This is an info log for request {0} and response {1}",response?.translate?.requestText??string.Empty,response?.translate?.responseText??string.Empty);
                return Json(response);
            }
            catch(Exception ex)
            {
                Logger.Error(ex, "This is an error log for {0}", ex.Message);
                response.translateModel = new TranslateModel();
                response.translateModel.status = "error";
                response.translateModel.errorMsg = ex.Message;
                response.translateModel.statusCode= 500;
                return Json(response);
            }
            //return Json(ts);
        }
    }
}
