using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;

using Reincubate.DeviceIdentifier;
using Reincubate.DeviceIdentifier.Util;

namespace deviceidentifier.test.NETFramework
{
    [TestFixture]
    public class TestEnhanceMetadata
    {
        [Test]
        public void TestAuth()
        {
            // Will the API fail if we provide the wrong token?
            var api = new Api("bad_token");
            var identifiers = new Identifiers
            (
                _apple_identifier: "iPhone5,3"
            );
            Assert.Throws<InvalidTokenException>(() => api.EnhanceMetadata(identifiers) );

            api = new Api("yneektgqk98bercl4w5a92wb7kkxe3rh");
            identifiers = new Identifiers
            (
                _apple_identifier: "iPhone5,3"
            );
            Assert.Throws<ExpiredTokenException>(() => api.EnhanceMetadata(identifiers) );
        }

        [Test]
        public void TestMisformed()
        {
            var api = new Api();
            var identifiers = new Identifiers
            (
                _apple_serial: "XXBADSERIALXX"
            );
            Assert.Throws<InvalidIdentifierException>(() => api.EnhanceMetadata(identifiers) );
        }

        [Test]
        public void TestCalls()
        {
            var api = new Api();
            var identifiers = new Identifiers
            (
                _apple_anumber: "A1784", _apple_identifier: "iPhone5,3", _apple_idfa: "002ebf12-a125-5ddf-a739-67c3c5d20177",
                _apple_internal_name: "N92AP", _apple_model: "MC605FD/A", _apple_serial: "C8QH6T96DPNG",
                _apple_udid: "db72cb76a00cb81675f19907d4ac2b298628d83c",
                _cdma_meid: "354403064522046",
                _gsma_imei: "013554006297015", _gsma_iccid: "8965880812100011146", _gsma_tac: "01326300",
                _additional: new Dictionary<String, String>() { { "deviceColor", "#e1e4e3" } }
            );

            try
            {
                Response response = api.EnhanceMetadata(identifiers);
                Assert.IsNotNull(response);
                Assert.IsNotNull(response.apple_internal_name.appleIdentifier);
            }
            catch(JsonSerializationException e)
            {
                Assert.Warn(e.Message);
            }
        }
    }
}
