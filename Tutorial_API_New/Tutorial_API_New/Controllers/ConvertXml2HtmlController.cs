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
    public class ConvertXml2HtmlController : ApiController
    {
        const string blobConnectionString = "DefaultEndpointsProtocol=https;AccountName=mstranslation;AccountKey=DhlfSrT66vg/I5CwpD0WrpeviWp5jrv/eyPaSTt7Pe8I0rv1PJnD3j8I7gGyc8oP0Jxs1+OpaL0U8Ku7kjFlFQ==;EndpointSuffix=core.windows.net";
        const string containerName = "xsltstorage";

        [Route("api/convertxml2html")]
        public HttpResponseMessage Post([FromBody] ToTranslate toTranslate)
        {
            HttpResponseMessage response;
            try
            {
                Task<string> HTMLstring = new LanguageClass(blobConnectionString, containerName).ConvertXml2Html(toTranslate.TextToTranslate, toTranslate.ToLanguage/*, Path.GetFileName(openFileDialog.FileName)*/);
                HTMLstring.Wait();
                response = Request.CreateResponse(HttpStatusCode.OK, HTMLstring.Result);
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
