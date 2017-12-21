using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Reincubate.DeviceIdentifier.Util;

using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Reincubate.DeviceIdentifier
{
    public class Identifiers
    {
        public Identifiers(String _apple_model = null,
                            String _apple_serial = null, String _apple_identifier = null,
                            String _gsma_imei = null, String _gsma_iccid = null,
                            String _cdma_meid = null)
        {
            apple_model = _apple_model;
            apple_serial = _apple_serial;
            apple_identifier = _apple_identifier;
            gsma_imei = _gsma_imei;
            gsma_iccid = _gsma_iccid;
            cdma_meid = _cdma_meid;
        }

        public String apple_model;
        public String apple_serial;
        public String apple_identifier;
        public String gsma_imei;
        public String gsma_iccid;
        public String cdma_meid;
    }

    public class Api
    {
        class ApiAuthenticator : IAuthenticator
        {
            readonly String token;
            public ApiAuthenticator(String token)
            {
                if (token == null)
                    throw new MissingTokenException("Token not specified; must be provided to authenticate with the API");
                this.token = token;
            }
            public void Authenticate(IRestClient client, IRestRequest request)
            {
                request.AddHeader("Authorization", String.Format("Token {0}", token));
            }
        }

        readonly RestClient client;
        public Api(String token)
        {
            client = new RestClient("https://di-api.reincubate.com/");
            client.Authenticator = new ApiAuthenticator(token);
        }

        public IList<String> IdentifyIdentifier(String identifier)
        {

            var request = new RestRequest("identify-identifier/", Method.POST);

            request.AddJsonBody(new
            {
                data = new
                {
                    identifiers = new
                    {
                        unknown = identifier
                    }
                }
            });

            var response = client.Execute(request);


            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
                //  throw new Exception( "API call not successful, response code %s:\n%s" % ( response.status_code, response.content ) )
            }

            var json = JObject.Parse(response.Content);

            IList<String> types = json.SelectToken(String.Format("identifiers.{0}", identifier)).Select(s => (String)s).ToList();

            return types;
        }

        public Response EnhanceMetadata(Identifiers identifiers)
        {
            RestRequest request = new RestRequest("enhance-metadata/", Method.POST);

            request.AddJsonBody(new
            {
                data = new
                {
                    identifiers = identifiers
                },
            });

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
                //  throw new Exception( "API call not successful, response code %s:\n%s" % ( response.status_code, response.content ) )
            }

            var deserialised = JsonConvert.DeserializeObject<Response>(response.Content);
            return deserialised;
        }
    }
}
