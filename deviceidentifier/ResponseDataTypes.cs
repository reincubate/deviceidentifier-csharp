using Newtonsoft.Json;

using System;

namespace Reincubate.DeviceIdentifier {

    // Response objects.

    public class ErrorResponse {
        public String type  { get; set; }
        public String message { get; set; }
    }

    public class Response {
      public AppleANumber apple_anumber { get; set; }
      public AppleIdentifier apple_identifier { get; set; }
      public AppleIdfa apple_idfa { get; set; }
      public AppleInternalName apple_internal_name { get; set; }
      public AppleModel apple_model { get; set; }
      public AppleSerial apple_serial { get; set; }
      public AppleUdid apple_udid { get; set; }

      public CdmaMeid cdma_meid { get; set; }

      public GsmaImei gsma_imei { get; set; }
      public GsmaIccid gsma_iccid { get; set; }
      public GsmaTac gsma_tac { get; set; }
    }

    public class AppleANumber {
        public AppleIdentifier apple_identifier { get; set; }
    }

    public class AppleIdfa {
        public String anonymised { get; set; }
        public String formatted { get; set; }
    }

    public class AppleUdid {
        public String anonymised { get; set; }
        public String formatted { get; set; }
        public bool compromised { get; set; }
    }

    public class AppleInternalName {
        public AppleIdentifier apple_identifier { get; set; }
    }

    public class AppleModel {
        public String id { get; set; }
        public String anonymised { get; set; }
        public AppleIdentifier appleIdentifer { get; set; }
        public ModelRegion region { get; set; }
        public ModelSpecification code { get; set; }
        public String type { get; set; }
    }

    public class AppleSerial {
        public String id { get; set; }
        public String anonymised { get; set; }
        public ConfigurationCode configurationCode { get; set; }
        public UniqueId uniqueId { get; set; }
        public String coverageUrl { get; set; }
        public String serialType { get; set; }
        public Manufacturer manufacturer { get; set; }
    }

    public class AppleIdentifier {
        public String id { get; set; }
        public Image image { get; set; }
        public AppleProduct product { get; set; }
        public String variant { get; set; }
    }

    public class CdmaMeid {
        public String id { get; set; }
        public String anonymised { get; set; }
        public String checksum { get; set; }
        public String manufacturer { get; set; }
        public ReportingBodyIdentifier regionCode{ get; set; }
    }

    public class GsmaImei {
        public String id { get; set; }
        public String anonymised { get; set; }
        public String svn { get; set; }
        public String checksum { get; set; }
        public String serial { get; set; }
        public ReportingBodyIdentifier reportingBodyIdentifier { get; set; }
        public GsmaTac tac { get; set; }
        public Gsx gsx { get; set; }
        public String type { get; set; }
    }

    public class GsmaIccid {
        public String anonymised { get; set; }
        public String atiiccid { get; set; }
        public String simNumber { get; set; }
        public MajorIndustry majorIndustry { get; set; }
        public String checksum { get; set; }
        public String year { get; set; }
        public String month { get; set; }

        [JsonProperty("switch")]
        public String switchProperty { get; set; }
        public GsmaIssuer issuer { get; set; }
    }

    public class GsmaTac {
        public AppleModel appleModel { get; set; }
        public String id { get; set; }
        public String manufacturer { get; set; }
        public AppleProduct product { get; set; }
    }

    // Supporting objects.

    public class Manufacturer {
        public String city { get; set; }
        public String company { get; set; }
        public String country { get; set; }
        public String date { get; set; }
        public String flag { get; set; }
        public String id { get; set; }
    }

    public class ModelRegion {
        public String flags { get; set; }
        public String name { get; set; }
    }

    public class ModelSpecification {
        public String case_size { get; set; }
        public String colour { get; set; }
        public String material { get; set; }
        public String storage { get; set; }
    }

    public class AppleProduct {
        public String line { get; set; }
        public String sku { get; set; }
    }

    public class GsxSale {
        public String estimatedPurchaseDate { get; set; }
        public String initialCarrier { get; set; }
        public String realPurchaseDate { get; set; }
        public String saleRegion { get; set; }
        public String saleRegionFlag { get; set; }
        public String seller { get; set; }
    }

    public class GsxStatus {
        public String appleId { get; set; }
        public String coverage { get; set; }
        public String sim { get; set; }
    }

    public class Gsx {
        public AppleSerial appleSerial { get; set; }
        public GsxSale sale { get; set; }
        public String skuHint { get; set; }
        public String[] specifications { get; set; }
        public GsxStatus status { get; set; }
    }

    public class ReportingBodyIdentifier {
        public String code { get; set; }
        public String group { get; set; }
        public String origin { get; set; }
    }

    public class UniqueId {
        public String productionNo { get; set; }
        public String value { get; set; }
    }

    public class ConfigurationCode {
        public String skuHint { get; set; }
        public String code { get; set; }
        public Image image  { get; set; }
    }

    public class Image {
        public String url { get; set; }
        public String width { get; set; }
        public String height { get; set; }
    }

    public class MajorIndustry {
        public String industry { get; set; }
        public String code { get; set; }
        public String type { get; set; }
    }

    public class GsmaIssuer {
        public String code { get; set; }
        public String name { get; set; }
        public IsoCountry country { get; set; }
    }

    public class IsoCountry {
        public String code { get; set; }
        public String name { get; set; }
        public String flag { get; set; }
    }
}
