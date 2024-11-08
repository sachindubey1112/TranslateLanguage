using BareInternationalTest.DL;
using BareInternationalTest.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BareInternationalTest.BL
{
    public class DictionaryService
    {
        private readonly DictionaryRepository dictionaryRepository;
        public DictionaryService(DictionaryRepository dictionaryRepository)
        {
            this.dictionaryRepository = dictionaryRepository;
        }

        public TranslateModelViewModel ConvertLanguage(Translate request)
        {
            TranslateModelViewModel model=new TranslateModelViewModel();
            try
            {
                model = dictionaryRepository.ConvertLanguage(request);
            }
            catch(Exception ex)
            {
                model.translateModel = new TranslateModel();
                model.translateModel.status = "error";
                model.translateModel.errorMsg = ex.Message;
                model.translateModel.statusCode = 0;
            }
            
            return model;
        }
    }
}
