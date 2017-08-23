using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Reincubate.DeviceIdentifier.Util;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Reincubate.DeviceIdentifier {

    public class Identifiers {

        public Identifiers( String _apple_model=null,
                            String _apple_serial=null, String _apple_identifier=null,
                            String _gsma_imei=null, String _gsma_iccid=null,
                            String _cdma_meid=null ) {
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

    public class Api {

        public static IList<String> IdentifyIdentifier( String token, String identifier ) {

            if ( token == null )
                throw new MissingTokenException( "Token not specified; must be provided to authenticate with the API" );

            RestSharp.RestClient client = new RestSharp.RestClient( "https://di-api.reincubate.com/" );
            RestSharp.RestRequest request = new RestSharp.RestRequest( "identify-identifier/", RestSharp.Method.POST );

            request.AddJsonBody( new {
                client = new { token = token },
                identifiers = new { unknown = identifier }
            } );

            var response = client.Execute( request ); 
            
            //if ( response.status_code != 200 )
            //  throw new Exception( "API call not successful, response code %s:\n%s" % ( response.status_code, response.content ) )

            var json = JObject.Parse( response.Content );

            IList<String> types = json.SelectToken( String.Format( "identifiers.{0}", identifier ) ).Select( s => (String) s ).ToList();

            return types;
        }

        public static Response EnhanceMetadata( String token, Identifiers identifiers ) {

            if ( token == null )
                throw new MissingTokenException( "Token not specified; must be provided to authenticate with the API" );

            RestSharp.RestClient client = new RestSharp.RestClient( "https://di-api.reincubate.com/" );
            RestSharp.RestRequest request = new RestSharp.RestRequest( "enhance-metadata/", RestSharp.Method.POST );

            request.AddJsonBody( new {
                client = new { token = token },
                identifiers = identifiers
            } );

            var response = client.Execute( request );

            //if ( response.status_code != 200 )
            //  throw new Exception( "API call not successful, response code %s:\n%s" % ( response.status_code, response.content ) )

            var deserialised = JsonConvert.DeserializeObject<Response>( response.Content );
            return deserialised;
        }
    }
}
