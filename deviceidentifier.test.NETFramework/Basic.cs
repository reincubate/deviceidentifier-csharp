using NUnit.Framework;

using Reincubate.DeviceIdentifier;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace deviceidentifier.test.NETFramework
{
    [TestFixture]
    public class Basic
    {
        [Test]
        public void DoesItRun()
        {
            var api = new Api("2b2471807be846bb824286f88f3adb02");

            var identifiers = new Identifiers
            (
                _apple_model: null,
                _apple_serial: "F4LPW1R7G5MN",
                _apple_identifier: "iPhone7,2",
                _gsma_imei: "352031078910204",
                _gsma_iccid: "8940101608230954908",
                _cdma_meid: "35203107891020"
            );

            Response response = api.EnhanceMetadata(identifiers);

            Assert.IsNotNull(response);

        }
    }
}
