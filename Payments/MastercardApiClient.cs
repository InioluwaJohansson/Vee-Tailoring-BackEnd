using Mastercard.Developer.OAuth1Signer.RestSharpV2.Signers;
using RestSharp.Portable;
using System.Security.Cryptography;

namespace Vee_Tailoring.Payments;
// 1. Create a new file (for instance, MastercardApiClient.cs) with the following class
partial class ApiClient
{
    private readonly Uri _basePath;
    private readonly RestSharpSigner _signer;

    /// <summary>
    /// Construct an ApiClient which will automatically sign requests
    /// </summary>
    public ApiClient(RSA signingKey, string basePath, string consumerKey)
    {
        //_baseUrl = basePath;
        _basePath = new Uri(basePath);
        _signer = new RestSharpSigner(consumerKey, signingKey);
    }

    private void InterceptRequest(IRestRequest request)
    {
        _signer.Sign(_basePath, (RestSharp.RestRequest)request);
    }
}

// 2. Load the signing key
/*
var signingKey = AuthenticationUtils.LoadSigningKey("./path/to/your/signing-key.p12",
    "keyalias",
    "keystorepassword",
    X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable
);

// 3. Configure the API client
const string basePath = "https://sandbox.api.mastercard.com/mdes";
const string consumerKey = "000000000000000000000000000000000000000000000000!000000000000000000000000000000000000000000000000";
var client = new ApiClient(signingKey, basePath, consumerKey);

*/