using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EvalTechnique.Server.UnitTest
{
    [TestClass]
    public class VideoDbServiceTest
    {
        private readonly bool serverStarted = false;

        private const string URL_SERVICE = "http://localhost:36990/IVideoDataBaseService";
        private readonly IBusiness.IVideoDataBaseService service;

        public VideoDbServiceTest()
        {
            try
            {
                serverStarted = ServerHelper.StartService<IBusiness.IVideoDataBaseService>();
                service = Client.ClientHelper.GetService<IBusiness.IVideoDataBaseService>(URL_SERVICE);
            }
            catch (Exception ex)
            {
                throw new InternalTestFailureException("Serveur off !", ex);
            }
        }

        [TestMethod]
        public void GetItemsTest()
        {
            if (!serverStarted || service == null) throw new InternalTestFailureException("Serveur off !");

            var result = service.GetItems();

            Assert.IsTrue(result?.Count > 0);
        }
    }
}
