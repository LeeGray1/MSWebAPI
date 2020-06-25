using LanguageService;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Tutorial_API_New.Controllers
{
    public class FileApiController : ApiController
    {

        const string blobConnectionString = "DefaultEndpointsProtocol=https;AccountName=mstranslation;AccountKey=DhlfSrT66vg/I5CwpD0WrpeviWp5jrv/eyPaSTt7Pe8I0rv1PJnD3j8I7gGyc8oP0Jxs1+OpaL0U8Ku7kjFlFQ==;EndpointSuffix=core.windows.net";
        const string containerName = "xsltstorage";
        #region All files Get and Post
        /// <summary>
        /// call this using https://localhost:44330/api/GetFile/?fileName=FrenchTranslation.xml
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/fileapi/getfile")]
        public HttpResponseMessage GetFile(string fileName)
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            // now get the file
            string fileContents = new LanguageService.LanguageClass(blobConnectionString, containerName).DownloadFileFromBlob(fileName);            

            response.Content = new StringContent(fileContents);
            return response;
        }

        [Route("api/fileapi/postfile")]
        public HttpResponseMessage Post([FromBody] FileSave fileSave)
        {
            new LanguageService.LanguageClass(blobConnectionString, containerName).UploadFileToBlob(fileSave.FileName, fileSave.FileContents);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }
        #endregion

        #region Get Xml Files 
        [Route("api/fileapi/gettranslatedxml")]

        public HttpResponseMessage Get(string language)
        {
            HttpResponseMessage response;
            try
            {
                string xmlFile = language + "TranslatedFile.xml";
                string fileContents = new LanguageClass(blobConnectionString, containerName).DownloadFileFromBlob(xmlFile);

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(fileContents, Encoding.UTF8, "application/xml");
                return response;
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(e.Message, Encoding.UTF8, "text/plain");
                return response;
            }

        }
        #endregion

        #region Get Xslt files
        [HttpGet]
        [Route("api/fileapi/xsltfile")]
        public HttpResponseMessage XsltGet(string language)
        {
            HttpResponseMessage response;
            try
            {
                string fileName = language + "-stylesheet-ubl.xslt";
                string fileContents = new LanguageClass(blobConnectionString, containerName).DownloadFileFromBlob(fileName);

                response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent(fileContents, Encoding.UTF8, "application/xml");
                return response;
            }
            catch (Exception e)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.Content = new StringContent(e.Message);
                return response;
            }
        }
        #endregion
    }
}
