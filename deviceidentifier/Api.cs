using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Reincubate.DeviceIdentifier.Util;

using RestSharp;
using RestSharp.Authenticators;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Reincubate.DeviceIdentifier
{
    public class Identifiers
    {
        public Identifiers( String _apple_anumber = null, String _apple_identifier = null,
                            String _apple_idfa = null, String _apple_internal_name = null,
                            String _apple_model = null, String _apple_serial = null,
                            String _apple_udid = null,
                            String _cdma_meid = null,
                            String _gsma_imei = null, String _gsma_iccid = null,
                            String _gsma_tac = null )
        {
            apple_anumber = _apple_anumber;
            apple_identifier = _apple_identifier;
            apple_idfa = _apple_idfa;
            apple_internal_name = _apple_internal_name;
            apple_model = _apple_model;
            apple_serial = _apple_serial;
            apple_udid = _apple_udid;

            cdma_meid = _cdma_meid;

            gsma_imei = _gsma_imei;
            gsma_iccid = _gsma_iccid;
            gsma_tac = _gsma_tac;
        }

        public String apple_anumber;
        public String apple_identifier;
        public String apple_idfa;
        public String apple_internal_name;
        public String apple_model;
        public String apple_serial;
        public String apple_udid;

        public String cdma_meid;

        public String gsma_imei;
        public String gsma_iccid;
        public String gsma_tac;
    }

    public class Api
    {
        public const String TYPE_APPLE_ANUMBER = "apple-anumbers";
        public const String TYPE_APPLE_IDENTIFIER = "apple-identifiers";
        public const String TYPE_APPLE_IDFA = "apple-idfas";
        public const String TYPE_APPLE_INTERNAL_NAME = "apple-internal-names";
        public const String TYPE_APPLE_MODEL = "apple-models";
        public const String TYPE_APPLE_SERIAL = "apple-serials";
        public const String TYPE_APPLE_UDID = "apple-udids";
        public const String TYPE_CDMA_MEID = "cdma-meids";
        public const String TYPE_GSMA_ICCID = "gsma-iccids";
        public const String TYPE_GSMA_IMEI = "gsma-imeis";
        public const String TYPE_GSMA_TAC = "gsma-tacs";

        class ApiAuthenticator : IAuthenticator
        {
            readonly String token;

            public ApiAuthenticator(String token)
            {
                this.token = token;
            }

            public void Authenticate(IRestClient client, IRestRequest request)
            {
                if ( token != null )
                    request.AddHeader("Authorization", String.Format("Token {0}", token));
            }
        }

        readonly RestClient client;

        public Api(String token=null)
        { // Allows anonymous access.
            client = new RestClient("https://di-api.reincubate.com/");
            client.Authenticator = new ApiAuthenticator(token);
        }

        public Object Lookup( String type, String identifier )
        {
            var request = new RestRequest( String.Format( "v1/{0}/{1}/", new object[] { type, identifier } ), Method.GET );
            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
                switch( errorResponse.type ) {
                    case "invalid_identifier":
                        throw new InvalidIdentifierException( errorResponse.message );
                    case "invalid_token":
                        throw new InvalidTokenException( errorResponse.message );
                    case "expired_token":
                        throw new ExpiredTokenException( errorResponse.message );
                    case "bad_request":
                        throw new BadRequestException( errorResponse.message );
                    case "unhandled_error":
                        throw new UnhandledException( errorResponse.message );
                }
            }

            switch( type ) {
                case Api.TYPE_APPLE_ANUMBER:
                    return JsonConvert.DeserializeObject<AppleANumber>(response.Content);
                case Api.TYPE_APPLE_IDENTIFIER:
                    return JsonConvert.DeserializeObject<AppleIdentifier>(response.Content);
                case Api.TYPE_APPLE_IDFA:
                    return JsonConvert.DeserializeObject<AppleIdfa>(response.Content);
                case Api.TYPE_APPLE_INTERNAL_NAME:
                    return JsonConvert.DeserializeObject<AppleInternalName>(response.Content);
                case Api.TYPE_APPLE_MODEL:
                    return JsonConvert.DeserializeObject<AppleModel>(response.Content);
                case Api.TYPE_APPLE_SERIAL:
                    return JsonConvert.DeserializeObject<AppleSerial>(response.Content);
                case Api.TYPE_APPLE_UDID:
                    return JsonConvert.DeserializeObject<AppleUdid>(response.Content);
                case Api.TYPE_CDMA_MEID:
                    return JsonConvert.DeserializeObject<CdmaMeid>(response.Content);
                case Api.TYPE_GSMA_ICCID:
                    return JsonConvert.DeserializeObject<GsmaIccid>(response.Content);
                case Api.TYPE_GSMA_IMEI:
                    return JsonConvert.DeserializeObject<GsmaImei>(response.Content);
                case Api.TYPE_GSMA_TAC:
                    return JsonConvert.DeserializeObject<GsmaTac>(response.Content);
            }

            throw new BadRequestException( "Didn't know how to interpret server's response" );
        }

        public IList<String> IdentifyIdentifier(String identifier)
        {
            var request = new RestRequest( String.Format( "v1/identify-identifier/{0}/", identifier ), Method.GET );
            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
                switch( errorResponse.type ) {
                    case "invalid_identifier":
                        throw new InvalidIdentifierException( errorResponse.message );
                    case "invalid_token":
                        throw new InvalidTokenException( errorResponse.message );
                    case "expired_token":
                        throw new ExpiredTokenException( errorResponse.message );
                    case "bad_request":
                        throw new BadRequestException( errorResponse.message );
                    case "unhandled_error":
                        throw new UnhandledException( errorResponse.message );
                }
            }

            var json = JObject.Parse(response.Content);

            IList<String> types = json.SelectToken(String.Format("{0}", identifier)).Select(s => (String)s).ToList();

            return types;
        }

        public Response EnhanceMetadata(Identifiers identifiers)
        {
            RestRequest request = new RestRequest("v1/enhance-metadata/", Method.POST);

            request.AddJsonBody(new { identifiers = identifiers });

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
                switch( errorResponse.type ) {
                    case "invalid_identifier":
                        throw new InvalidIdentifierException( errorResponse.message );
                    case "invalid_token":
                        throw new InvalidTokenException( errorResponse.message );
                    case "expired_token":
                        throw new ExpiredTokenException( errorResponse.message );
                    case "bad_request":
                        throw new BadRequestException( errorResponse.message );
                    case "unhandled_error":
                        throw new UnhandledException( errorResponse.message );
                }
            }

            var settings = new JsonSerializerSettings();
#if DEBUG
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            settings.ContractResolver = new RequireObjectPropertiesContractResolver();
#endif

            var deserialised = JsonConvert.DeserializeObject<Response>(response.Content, settings);
            return deserialised;
        }
    }

    class RequireObjectPropertiesContractResolver : DefaultContractResolver
    {
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            contract.ItemRequired = Required.AllowNull;
            return contract;
        }
    }
}
