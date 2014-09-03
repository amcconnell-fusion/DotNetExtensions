using System;
using System.Net;
using FusionAlliance.DotNetExtensions.Common.Net;
using NUnit.Framework;

namespace FusionAlliance.DotNetExtensions.Common.Tests.Net
{
    [TestFixture, Category("Network")]
    public class WebResponseExtensionTests : IDisposable
    {
        [SetUp]
        public void Before_each_test()
        {
            request = WebRequest.Create("http://www.fusionalliance.com");
            response = request.GetResponse();
        }

        private WebRequest request;
        private WebResponse response;
        private byte[] responseBytes;
        private string responseString;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                response.Dispose();
            }
        }

        [Test]
        public void ReadResponseStreamToBytes_can_return_a_buffer()
        {
            responseBytes = response.ReadResponseStreamToBytes();
            Assert.Greater(responseBytes.Length, 0);
        }

        [Test]
        public void ReadResponseStreamToString_can_return_a_string()
        {
            responseString = response.ReadResponseStreamToString();
            StringAssert.IsMatch(@"\<!doctype html\>", responseString);
        }
    }
}