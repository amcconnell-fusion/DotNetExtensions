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
            _request = WebRequest.Create("http://www.fusionalliance.com");
            _response = _request.GetResponse();
        }

        private WebRequest _request;
        private WebResponse _response;
        private byte[] _responseBytes;
        private string _responseString;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _response.Dispose();
            }
        }

        [Test]
        public void ReadResponseStreamToBytes_can_return_a_buffer()
        {
            _responseBytes = _response.ReadResponseStreamToBytes();
            Assert.Greater(_responseBytes.Length, 0);
        }

        [Test]
        public void ReadResponseStreamToString_can_return_a_string()
        {
            _responseString = _response.ReadResponseStreamToString();
            StringAssert.IsMatch(@"\<!doctype html\>", _responseString);
        }
    }
}