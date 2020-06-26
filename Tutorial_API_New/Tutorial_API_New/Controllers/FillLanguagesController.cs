using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using LanguageService;

namespace Tutorial_API_New.Controllers
{
    public class FillLanguagesController : ApiController
    {
        const string blobConnectionString = "DefaultEndpointsProtocol=https;AccountName=mstranslation;AccountKey=DhlfSrT66vg/I5CwpD0WrpeviWp5jrv/eyPaSTt7Pe8I0rv1PJnD3j8I7gGyc8oP0Jxs1+OpaL0U8Ku7kjFlFQ==;EndpointSuffix=core.windows.net";
        const string containerName = "xsltstorage";

        [Route("api/filllanguages")]
        //public HttpResponseMessage Get(List<string> getlanguages)
        //{
        //    HttpResponseMessage response;
        //    try
        //    {                
        //        List<string> languages = new LanguageClass(blobConnectionString, containerName).FillLanguages();

        //        response = Request.CreateResponse(HttpStatusCode.OK);
        //        response.Content = new StringContent(languages, Encoding.UTF8, "application/xml");
        //        return response;
        //    }
        //    catch (Exception e)
        //    {
        //        response = Request.CreateResponse(HttpStatusCode.BadRequest);
        //        response.Content = new StringContent(e.Message, Encoding.UTF8, "text/plain");
        //        return response;
        //    }
        //}

        public HttpResponseMessage Post([FromBody] List<string> getLanguages)
        {
            HttpResponseMessage response;
            try
            {
                getLanguages = new LanguageClass(blobConnectionString, containerName).FillLanguages();

                response = Request.CreateResponse(HttpStatusCode.OK, getLanguages);
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
