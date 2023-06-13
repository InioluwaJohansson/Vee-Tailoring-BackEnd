using Mastercard.Developer.ClientEncryption.Core.Encryption;
using Mastercard.Developer.ClientEncryption.Core.Utils;
using Mastercard.Developer.ClientEncryption.RestSharpV2.Interceptors;
using Mastercard.Developer.OAuth1Signer.Core.Signers;
using Mastercard.Developer.OAuth1Signer.Core.Utils;
using Mastercard.Developer.OAuth1Signer.RestSharpV2.Signers;
using RestSharp.Portable;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using static Mastercard.Developer.ClientEncryption.Core.Encryption.FieldLevelEncryptionConfig;

namespace Vee_Tailoring.Payments;
//var baseUri = new Uri("https://api.mastercard.com/");
//var httpClient = new HttpClient(new RequestSignerHandler(consumerKey, signingKey)) { BaseAddress = baseUri };
//var postTask = httpClient.PostAsync(new Uri("/service", UriKind.Relative), new StringContent("{\"foo\":\"bår\"}");
// (…)

internal class RequestSignerHandler : HttpClientHandler
{
    private readonly NetHttpClientSigner signer;

    public RequestSignerHandler(string consumerKey, RSA signingKey)
    {
        signer = new NetHttpClientSigner(consumerKey, signingKey);
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        signer.Sign(request);
        return base.SendAsync(request, cancellationToken);
    }
}
/* 1. Update the previously created file (for instance, MastercardApiClient.cs) by adding the
//    interceptor responsible for encrypting requests and decrypting responses
partial class ApiClients
{
    private readonly Uri _basePath;
    private readonly RestSharpSigner _signer;
    private readonly RestSharpEncryptionInterceptor _encryptionInterceptor;

    /// <summary>
    /// Construct an ApiClient which will automatically:
    /// - Sign requests
    /// - Encrypt/decrypt requests and responses
    /// </summary>
    public ApiClients(RSA signingKey, string basePath, string consumerKey, EncryptionConfig config)
    {
        //_baseUrl = basePath;
        _basePath = new Uri(basePath);
        _signer = new RestSharpSigner(consumerKey, signingKey);
        _encryptionInterceptor = RestSharpEncryptionInterceptor.From(config);
    }

    private void InterceptRequest(IRestRequest request)
    {
        _encryptionInterceptor.InterceptRequest((RestSharp.RestRequest)request);
        _signer.Sign(_basePath, (RestSharp.RestRequest)request);
    }
    public void JustKeep()
    {
                // 2. Load the signing key
        
        var signingKey = AuthenticationUtils.LoadSigningKey("./path/to/your/signing-key.p12",
            "keyalias",
            "keystorepassword",
            X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable
        );

        // 3. Configure the API client
        const string basePath = "https://sandbox.api.mastercard.com/mdes";
        const string consumerKey = "000000000000000000000000000000000000000000000000!000000000000000000000000000000000000000000000000";
        var client = new ApiClient(signingKey, basePath, consumerKey);

        var config = FieldLevelEncryptionConfigBuilder.AFieldLevelEncryptionConfig()
    .WithEncryptionPath("$.fundingAccountInfo.encryptedPayload.encryptedData", "$.fundingAccountInfo.encryptedPayload")
    .WithEncryptionPath("$.encryptedPayload.encryptedData", "$.encryptedPayload")
    .WithDecryptionPath("$.tokenDetail", "$.tokenDetail.encryptedData")
    .WithDecryptionPath("$.encryptedPayload", "$.encryptedPayload.encryptedData")
    .WithEncryptionCertificate(EncryptionUtils.LoadEncryptionCertificate("./path/to/your/encryption.crt"))
    .WithDecryptionKey(EncryptionUtils.LoadDecryptionKey("./path/to/your/private.key"))
    .WithOaepPaddingDigestAlgorithm("SHA-512")
    .WithEncryptedValueFieldName("encryptedData")
    .WithEncryptedKeyFieldName("encryptedKey")
    .WithIvFieldName("iv")
    .WithOaepPaddingDigestAlgorithmFieldName("oaepHashingAlgorithm")
    .WithEncryptionCertificateFingerprintFieldName("publicKeyFingerprint")
    .WithValueEncoding(FieldValueEncoding.Hex)
    .Build();

    // 2. Update the way the API client is instantiated 
    var client2 = new ApiClients(signingKey, basePath, consumerKey, config);

        var api = new TokenizeApi() { Client = client };
        var request = BuildTokenizeRequestSchema();
        var response = api.CreateTokenize(request);


    }
}*/


