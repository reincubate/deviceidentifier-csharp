# deviceidentifier

Utils to manipulate and learn from assorted device identifier formats via Reincubate's DeviceIdentifier API.

## Getting started

Try these:

```bash
$ nuget install deviceidentifier
```

Access is authenticated using an authentication token. This must be passed into API calls as the `token` parameter.

## Requesting an access token

Authentication to ricloud is performed using a token provided by Reincubate, which can be obtained by contacting [enterprise@reincubate.com](mailto:enterprise@reincubate.com).

## Usage

### Enhancing metadata

```csharp
using Reincubate.DeviceIdentifier;

var token = "api-authentication-token";

var identifiers = new Identifiers(
  _apple_model: "PC605B",
  _apple_serial: "5K35426NDZZ",
  _apple_identifier: "iPhone5,3",
  _gsma_imei: "352023069365968",
  _gsma_iccid: "8964380812102311146"
);

Response response = Api.EnhanceMetadata(
  token, identifiers
);

Console.WriteLine( response.identifiers.apple_model.region );
```

```
Ireland, UK, or replacement unit
```


### Identifying an identifier

```csharp
using Reincubate.DeviceIdentifier;

var token = "api-authentication-token";

IList<String> types = Api.IdentifyIdentifier(
  token, "5K35426NDZZ"
);

Console.WriteLine( types.First() );
```

```
apple_serial
```

## API client implementations

Check out the Open Source libraries for working with the API:

* [Python](https://github.com/reincubate/deviceidentifier-py)
* [C# / .NET](https://github.com/reincubate/deviceidentifier-csharp)

## Troubleshooting

See the [support & service status](https://docs.reincubate.com/ricloud/status/?utm_source=github&utm_medium=deviceidentifier-csharp&utm_campaign=deviceidentifier) page.

## <a name="more"></a>Need more functionality?

Reincubate's vision is to provide data access, extraction and recovery technology for all app platforms - be they mobile, desktop, web, appliance or in-vehicle.

The company was founded in 2008 and was first to market with both iOS and iCloud data extraction technology. With over half a decade's experience helping law enforcement and security organisations access iOS data, Reincubate has licensed software to government, child protection and corporate clients around the world.

The company can help users with:

* iCloud access and data recovery
* Recovery of data deleted from SQLite databases
* Bulk iOS data recovery
* Forensic examination of iOS data
* Passcode, password, keybag and keychain analysis
* Custom iOS app data extraction
* Advanced PList, TypedStream and Mbdb manipulation

Contact [Reincubate](https://www.reincubate.com/?utm_source=github&utm_medium=deviceidentifier-csharp&utm_campaign=deviceidentifier) for more information.

## Terms & license

See the `LICENSE` file for details on this implementation's license. Users must not use the API in any way that is unlawful, illegal, fraudulent or harmful; or in connection with any unlawful, illegal, fraudulent or harmful purpose or activity.
