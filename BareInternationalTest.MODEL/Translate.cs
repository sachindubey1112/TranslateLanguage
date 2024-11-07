using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BareInternationalTest.MODEL
{
    public class Translate
    {
        public string requestText { get; set; }
        public string responseText { get; set; } 

    }

    public class TranslateModel
    {
        public string status { get; set; }
        public string errorMsg { get; set; }
        
    }

    public class TranslateModelViewModel
    {
        public TranslateModel translateModel { get; set; }
        public Translate translate { get; set; }

    }

}
