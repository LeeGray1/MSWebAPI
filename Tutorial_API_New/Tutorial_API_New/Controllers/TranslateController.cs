using LanguageService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;


namespace Tutorial_API_New.Controllers
{
    public class TranslateController : ApiController
    {
        const string blobConnectionString = "DefaultEndpointsProtocol=https;AccountName=mstranslation;AccountKey=DhlfSrT66vg/I5CwpD0WrpeviWp5jrv/eyPaSTt7Pe8I0rv1PJnD3j8I7gGyc8oP0Jxs1+OpaL0U8Ku7kjFlFQ==;EndpointSuffix=core.windows.net";
        const string containerName = "xsltstorage";
        // GET: api/Language
       
        // GET: api/Language/5
        //public async Task<string> Post(string word)
        //{
        //    string textToTranslate = word;
        //    string toLanguage = "German";
        //    string fromLanguage = "English";
        //    string translation = await new LanguageClass(blobConnectionString, containerName).translate(textToTranslate, toLanguage, fromLanguage);

        //    return translation;

        //}

        // POST: api/Language
        //public async Task<string> Post([FromBody]string word)
        //{
        //    //string textToTranslate = "Hello world";
        //    string toLanguage = "German";
        //    string fromLanguage = "English";
        //    string translation = await new LanguageClass(blobConnectionString, containerName).translate(word, toLanguage, fromLanguage);

        //    return translation;
        //}

        //// PUT: api/Language/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Language/5
        //public void Delete(int id)
        //{
        //}

        [Route("api/translate/text")]
        public async Task<HttpResponseMessage> Post([FromBody] ToTranslate text2Translate)
        {
            HttpResponseMessage response;
            Translation translation = new Translation();
            translation.TranslatedText = await new LanguageClass(blobConnectionString, containerName).translate(text2Translate.TextToTranslate, text2Translate.ToLanguage, text2Translate.FromLanguage);
            // call the trans service get resp
            translation.Language = text2Translate.ToLanguage;
            response = Request.CreateResponse(HttpStatusCode.OK, translation);
            return response;
        }

        [HttpPost]
        [Route("api/detectlanguage/text")]
        public HttpResponseMessage DectectPost([FromBody] ToTranslate toTranslate)
        {
            HttpResponseMessage response;
            try
            {
                Translation translation = new Translation();
                string languageCode = new LanguageClass(blobConnectionString, containerName).DetectLanguage(toTranslate.TextToTranslate);
                translation.Language = new LanguageClass(blobConnectionString, containerName).GetLanguageFromCode(languageCode);

                response = Request.CreateResponse(HttpStatusCode.OK, translation);
                return response;
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(e.Message, Encoding.UTF8, "text/plain");
                return response;
            }

        }
    }
}
