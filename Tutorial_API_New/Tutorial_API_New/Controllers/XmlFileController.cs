using LanguageService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Tutorial_API_New.Controllers
{
    public class XmlFileController : ApiController
    {
        const string blobConnectionString = "DefaultEndpointsProtocol=https;AccountName=mstranslation;AccountKey=DhlfSrT66vg/I5CwpD0WrpeviWp5jrv/eyPaSTt7Pe8I0rv1PJnD3j8I7gGyc8oP0Jxs1+OpaL0U8Ku7kjFlFQ==;EndpointSuffix=core.windows.net";
        const string containerName = "xsltstorage";
        [Route("api/xmlfile/{fileName}")]
        public string Get(string fileName)
        {
            try
            {
                string xmlFile = fileName + "TranslatedFile.xml";
                string fileContents = new LanguageClass(blobConnectionString, containerName).DownloadFileFromBlob(xmlFile);
                return fileContents;
            }
            catch (Exception e)
            {               
                throw e;
            }
           
        }       
    }
}
