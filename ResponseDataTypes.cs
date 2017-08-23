using Newtonsoft.Json;

using System;

namespace Reincubate.DeviceIdentifier {
        
    // Response objects.

    public class Response {
        public IdentifierResponse identifiers { get; set; } 
        public System system { get; set; }
    }

    public class System {
        public String message { get; set; }
        public String code  { get; set; }
    }

    public class IdentifierResponse {
        public AppleModel apple_model { get; set; }
        public AppleSerial apple_serial { get; set; }
        public AppleIdentifier apple_identifier { get; set; }
        public CdmaMeid cdma_meid { get; set; }
        public GsmaImei gsma_imei { get; set; }
        public GsmaIccid gsma_iccid { get; set; }
    }

    public class AppleModel {
        public String region { get; set; }
        public String code { get; set; }
        public String type { get; set; }
    }

    public class AppleSerial {
        public String manufactureDate { get; set; }
        public ConfigurationCode configurationCode { get; set; }
        public UniqueId uniqueId { get; set; }
        public String coverageUrl { get; set; }
        public Configuration configuration { get; set; }
        public String serialType { get; set; }
        public String manufacturer { get; set; }
    }

    public class AppleIdentifier {
        public String sku { get; set; }
    }

    public class CdmaMeid {
        public String checksum { get; set; }
        public String region { get; set; }
        public String serial { get; set; }
        public String pESN { get; set; }
        public String manufacturer { get; set; }
    }

    public class GsmaImei {
        public String svn { get; set; }
        public String checksum { get; set; }
        public String serial { get; set; }
        public String type { get; set; }
        public String tac { get; set; }
    }

    public class GsmaIccid {
        public String atiiccid { get; set; }
        public String simNumber { get; set; }
        public MajorIndustry majorIndustry { get; set; }
        public String checksum { get; set; }
        public String year { get; set; }
        public String month { get; set; }

        [JsonProperty("switch")]
        public String switchProperty { get; set; }
        public String country { get; set; }
        public GsmaIssuer issuer { get; set; }
    }

    // Supporting objects.

    public class UniqueId {
        public String productionNo { get; set; }
        public String value { get; set; }
    }

    public class ConfigurationCode {
        public String colour { get; set; }
        public String code { get; set; }
        public String size  { get; set; }
    }

    public class Configuration {
        public String sku { get; set; }
        public Image image { get; set; }
    }

    public class Image {
        public String url { get; set; }
        public String x { get; set; }
        public String y { get; set; }
    }

    public class MajorIndustry {
        public String industry { get; set; }
        public String code { get; set; }
        public String type { get; set; }
    }

    public class GsmaIssuer {
        public String code { get; set; }
        public String name { get; set; }
    }

}
