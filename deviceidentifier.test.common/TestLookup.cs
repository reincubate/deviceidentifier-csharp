using NUnit.Framework;

using Reincubate.DeviceIdentifier;
using Reincubate.DeviceIdentifier.Util;

namespace deviceidentifier.test.NETFramework
{
    [TestFixture]
    public class TestLookup
    {
        [Test]
        public void TestAuth()
        {
            // Will the API fail if we provide the wrong token?
            var api = new Api("bad_token");
            Assert.Throws<InvalidTokenException>(() => api.Lookup<AppleIdentifier>("iPhone5,3"));

            api = new Api("yneektgqk98bercl4w5a92wb7kkxe3rh");
            Assert.Throws<ExpiredTokenException>(() => api.Lookup<AppleIdentifier>("iPhone5,3"));
        }

        [Test]
        public void TestMisformed()
        {
            var api = new Api();
            Assert.Throws<InvalidIdentifierException>(() => api.Lookup<AppleSerial>("XXBADSERIALXX"));
        }

        [Test]
        public void TestCalls()
        {
            var api = new Api();
            Assert.IsNotNull(api.Lookup<AppleANumber>("A1784"));
            Assert.IsNotNull(api.Lookup<AppleIdentifier>("iPhone5,3"));
            Assert.IsNotNull(api.Lookup<AppleIdfa>("002ebf12-a125-5ddf-a739-67c3c5d20177"));
            Assert.IsNotNull(api.Lookup<AppleInternalName>("N92AP"));
            Assert.IsNotNull(api.Lookup<AppleModel>("MC605FD/A"));
            Assert.IsNotNull(api.Lookup<AppleSerial>("C8QH6T96DPNG"));
            Assert.IsNotNull(api.Lookup<AppleUdid>("db72cb76a00cb81675f19907d4ac2b298628d83c"));
            Assert.IsNotNull(api.Lookup<CdmaMeid>("354403064522046"));
            Assert.IsNotNull(api.Lookup<GsmaIccid>("8965880812100011146"));
            Assert.IsNotNull(api.Lookup<GsmaImei>("013554006297015"));
            Assert.IsNotNull(api.Lookup<GsmaTac>("01326300"));
        }
    }
}
