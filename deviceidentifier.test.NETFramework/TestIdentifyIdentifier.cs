using NUnit.Framework;

using Reincubate.DeviceIdentifier;
using Reincubate.DeviceIdentifier.Util;

namespace deviceidentifier.test.NETFramework
{
    [TestFixture]
    public class TestIdentifyIdentifier
    {
        [Test]
        public void TestAuth()
        {
            // Will the API fail if we provide the wrong token?
            var api = new Api("bad_token");
            Assert.Throws<InvalidTokenException>(() => api.IdentifyIdentifier( "iPhone5,3" ));

            api = new Api("yneektgqk98bercl4w5a92wb7kkxe3rh");
            Assert.Throws<ExpiredTokenException>(() => api.IdentifyIdentifier( "iPhone5,3" ));
        }

        [Test]
        public void TestCalls()
        {
            var api = new Api();
            var response = api.IdentifyIdentifier( "iPhone5,3" );

            Assert.IsNotNull(response);
        }
    }
}
