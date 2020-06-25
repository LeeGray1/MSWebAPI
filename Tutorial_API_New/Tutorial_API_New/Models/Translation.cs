using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Tutorial_API_New
{
    public class Translation
    {
        public string TranslatedText { get; set; }
        public string Language { get; set; }
    }

    public class ToTranslate
    {
        public string ToLanguage { get; set; }
        public string FromLanguage { get; set; }
        public string TextToTranslate { get; set; }
    }
}