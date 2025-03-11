using AutoMapper;
using Flurl.Http;
using OfficeEatsBackendApi.Dtos;
using OfficeEatsBackendApi.Interfaces.Repository;
using OfficeEatsBackendApi.Interfaces.Services;
using OfficeEatsBackendApi.Models;

namespace OfficeEatsBackendApi.Services
{
    public class PaymentGateWayService : IPaymentGateWayService
    {
        #region Fields
        //clientId: 59d8733e18911df59b05feb23c480d
        //clientSecret: hstZHNA52IgHAm1AoJJZ3tBfcvBSkA6yHljOUSKAsg4JJB6O54KPf9emhOvV1Tjq4YW9NHDUXsb42DVXUagP4g==
        // MerchantId: 91a45253ec364407b1ea127f94b2e2d1
        // EntityId: 8ac7a4c99244efc501924717cb5e021c

        private readonly IPaymentGateWayRepository _repository;
        private const string BaseUrl = "https://sandbox-dashboard.peachpayments.com";
        private const string BaseUrlTestSecure = "https://testsecure.peachpayments.com";

        //private const string BaseUrl = "https://dashboard.peachpayments.com";
        //private const string BaseUrlTestSecure = "https://secure.peachpayments.com";
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors

        public PaymentGateWayService( IPaymentGateWayRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }


        #endregion Public Constructors

        private string BuildUrl(string endpoint)
        {
            return $"{BaseUrl}/{endpoint}";
        }

        private string BuildUrlTestSecure(string endpoint)
        {
            return $"{BaseUrlTestSecure}/{endpoint}";
        }

        public async Task<object> GetAuthTokenAsync()
        {
            var payload = new PaymentAuthRequestDto
            {
                clientId = "59d8733e18911df59b05feb23c480d",
                clientSecret = "hstZHNA52IgHAm1AoJJZ3tBfcvBSkA6yHljOUSKAsg4JJB6O54KPf9emhOvV1Tjq4YW9NHDUXsb42DVXUagP4g==",
                merchantId = "91a45253ec364407b1ea127f94b2e2d1"
            };

            var authServiceUrl = BuildUrl("api/oauth/token");
            var response = await authServiceUrl.AllowAnyHttpStatus()
                      .PostJsonAsync(payload)
                      .ReceiveJson<object>();

            return response;
        }

        public async Task<CheckoutResponseDto> CreateCheckoutAsync(CheckoutRequestDto request)
        {
            var tokenResponse = await GetAuthTokenAsync();
            dynamic tokenData = tokenResponse;
            //Console.WriteLine(tokenData.Access_token);

            //string accessToken = tokenData.access_token;
            string accessToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjIwMjEtMDktMDYifQ.eyJlbnRpdHlJRCI6IjkxYTQ1MjUzZWMzNjQ0MDdiMWVhMTI3Zjk0YjJlMmQxIiwicGFydG5lciI6ZmFsc2UsInNpZCI6ImNhNDEyNWY1N2ZlNzk2MzNlOWE0IiwibWVyY2hhbnRJZCI6IjkxYTQ1MjUzZWMzNjQ0MDdiMWVhMTI3Zjk0YjJlMmQxIiwiaWF0IjoxNzQxNzIyNDc1LCJuYmYiOjE3NDE3MjI0NzUsImV4cCI6MTc0MTczNjg3NSwiYXVkIjoiaHR0cHM6Ly9tMm0ucGVhY2hwYXltZW50cy5jb20iLCJpc3MiOiJodHRwczovL3NhbmRib3gtc2VydmljZXMucHBheS5pby8iLCJzdWIiOiI1OWQ4NzMzZTE4OTExZGY1OWIwNWZlYjIzYzQ4MGQifQ.d6Sf2do-VjkZSDaVcmyqtjUzTr2dtZvhxAx95kehhkmAvIWusxyHNB6lKVV4q3wRj6U3YxZre24JBmbEbuCdLD3iCqNiXLohdJb4ILM0kMVAmgznd-cE4VRgfHJJFNqK4x3sBCjh-G1aBMR0WcKIAksPTA-1y6KSbii4ZIo_Kvgf0dLfSiPdgzNimvXBwFCYLJQs4v-s1hEMzH9G88w70R9TZsYW2s1DJDHw8CSSCsTvXnF20JhO3_zFryuoQezieT91tgvyFJzozNtC7WBB0b4Q7PK-rAjaYYde0KitH4fIa9pkGsJjf7zn-Gq7eHwaWwG1SgSW508WdyR7930NkX6BrZniKuIANVd1H2jWBZkYK2PUrRGNSCwJEdcr4QQ7hdGdJl2S9TTSIrY9JwwHjCjA4UdiO11JW3RSMv93_KyE3WrWogCWVv5K2SHMy8n2-nH1xsNlXWg6xLsBjKuDUc3Sba8znL5ZQY6appBU6AbTMcziegZQVatmuxZnj4oMImzc-acEDMrNxtoQRE2IBgs5gCQ9zXSsKf3qlpzWZ4JhZQvK4aD7lGY_s4iGeqoosbe68FVix3z88603plku2-2GcyQJOKAIuz_F0vWHdbGzIDL4qyU_2pKXFwaRngy8bQFAGFi3eoAbN0HZT1nA9KB9qw8IUb5tptaHhWREmIo";
            var authServiceUrl = BuildUrlTestSecure("v2/checkout");
            //Guid guid = Guid.NewGuid().ToString("N");
            //string guidWithoutHyphens = guid;

            //string GuidMerchantTransactionId = guid.Substring(0, 9);

            string guid = Guid.NewGuid().ToString("N");
            string GuidMerchantTransactionId = guid.Substring(0, 16);
            //string GuidMerchantTransactionId = "123456Abc";


            string entityId = "8ac7a4ca9244f53c01924718313b0230";

            var payload = new Dictionary<string, object> {
                { "authentication.entityId", entityId },
                { "merchantTransactionId", GuidMerchantTransactionId },
                { "amount", request.amount },
                { "currency", "ZAR" },
                { "nonce", guid },
                { "shopperResultUrl", "https://lime24.co.za/dashboard/signing-loan-agreement/" },
                {"notificationUrl","https://46f1-41-10-52-218.ngrok-free.app/api/ping" }
            };
            var response = await authServiceUrl.AllowAnyHttpStatus()
                   .WithHeader("Authorization", $"Bearer {accessToken}")
                   .WithHeader("Origin", "https://lime24.co.za/")
                   .WithHeader("Referer", "https://lime24.co.za/")
                   .PostJsonAsync(payload)
                   .ReceiveJson<Dictionary<string, object>>();

            //var payment = new Payments
            //{
            //    IdNumber = request.idNumber,
            //    Amount = request.amount,
            //    Status = "Pending",
            //    MerchantTransactionId = GuidMerchantTransactionId,
            //    Nonce = guid,
            //    Currency = "ZAR"
            //};

            //await _repository.AddPayment(payment);
            // Map the response to the DTO
            var checkoutResponse = new CheckoutResponseDto
            {
                CheckoutId = response.ContainsKey("checkoutId") ? response["checkoutId"].ToString() : null,
                EntityId = entityId,
                MerchantTransactionId = GuidMerchantTransactionId,
            };

            return checkoutResponse;
        }


        public async Task<Payments> UpdatePaymentAsync(UpdatePaymentDto request)
        {
            var existingPayment = await _repository.GetPaymentByTransactionIdAsync(request.MerchantTransactionId);

            if (existingPayment != null)
            {
                existingPayment.MerchantTransactionId = request.MerchantTransactionId;
                existingPayment.Status = request.Status;

                var updatedPayment = await _repository.UpdatePaymentAsync(existingPayment);

                return updatedPayment;
            }

            return new Payments();
        }

        public async Task<AddPaymentEventsDto> AddPaymentEvents(AddPaymentEventsDto request)
        {
            var paymentEvent = _mapper.Map<PaymentEvents>(request);

            var savedEvent = await _repository.AddPaymentEvents(paymentEvent);

            if (savedEvent != null)
            {
                var updateRequest = new UpdatePaymentDto
                {
                    MerchantTransactionId = request.MerchantTransactionId,
                    Status = request.Result.Description
                };

                await UpdatePaymentAsync(updateRequest);
            }

            return _mapper.Map<AddPaymentEventsDto>(savedEvent);
        }

    }
}
