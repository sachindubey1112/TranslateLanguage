﻿using BareInternationalTest.DL;
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
            TranslateModelViewModel model = dictionaryRepository.ConvertLanguage(request);
            return model;
        }
    }
}