using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tutorial_API_New;
using LanguageService;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        const string baseUri = "https://localhost:44330";

        #region Web API unit tests
        [TestMethod]
        public void TestDownloadXmlFromWebAPI()
        {
            string uri = "https://localhost:44330/api/";
            string action = "fileapi/gettranslatedxml/";
            string parameter = "?language=French";
            Task<bool> res = new CallWebApi().CallGetWebAPI(uri, action, parameter);
            res.Wait();
            Assert.IsTrue(res.Result);
        }

        [TestMethod]
        public void TestUploadFileToWebAPI()
        {
            string uri = baseUri;
            string route = "/api/fileapi/postfile/";
            string requestBody = "{\"FileName\": \"Test3.txt\", \"FileContents\": \"This is another test\"}";
            Task<bool> res = new CallWebApi().CallPostWebAPI(uri, route, requestBody);
            res.Wait();
            Assert.IsTrue(res.Result);
        }

        [TestMethod]
        public void TestTranslateFileFromWebAPI()
        {
            string uri = baseUri;
            string route = "/api/translate/";
            string requestBody = "{\"ToLanguage\": \"French\", \"FromLanguage\": \"English\", \"TextToTranslate\": \"Hello\"}";
            Task<bool> res = new CallWebApi().CallPostWebAPI(uri, route, requestBody);
            res.Wait();
            Assert.IsTrue(res.Result);
        }

        #endregion
    }
}
