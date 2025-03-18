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
            string accessToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IjIwMjEtMDktMDYifQ.eyJlbnRpdHlJRCI6IjkxYTQ1MjUzZWMzNjQ0MDdiMWVhMTI3Zjk0YjJlMmQxIiwicGFydG5lciI6ZmFsc2UsInNpZCI6Ijc3OTBlM2E1NGI2YThhYjBmMjNhIiwibWVyY2hhbnRJZCI6IjkxYTQ1MjUzZWMzNjQ0MDdiMWVhMTI3Zjk0YjJlMmQxIiwiaWF0IjoxNzQxODA0MzQ1LCJuYmYiOjE3NDE4MDQzNDUsImV4cCI6MTc0MTgxODc0NSwiYXVkIjoiaHR0cHM6Ly9tMm0ucGVhY2hwYXltZW50cy5jb20iLCJpc3MiOiJodHRwczovL3NhbmRib3gtc2VydmljZXMucHBheS5pby8iLCJzdWIiOiI1OWQ4NzMzZTE4OTExZGY1OWIwNWZlYjIzYzQ4MGQifQ.bmVeWI-WgpEGNP7m7OMIl4LxqkmFWiv_Yo1quPWVhZhGFyuZGwtUuY3eOcFWm9TwNz5lhk16uxB07f7H2qnq8-ABTzosiU8bm7kujOSDKLNRzL30pxWYazl4pbqg3ILLiGpG43WHzuRXeOLvu1PX0455SV12d-tZb1J1YNHqw8t59UmAvkvRIC3duURyhlAVoqGthpp5X9Z4RJZdrp8ojp2LF4vxtR8XgeaCJs_OAiIh83IGVVZC9ti391kfcB-P1XGyg6-aDRVC_fC7SjKAxII0NZ5Jkak-aFswRCbQnqQtrH4N_dc_XU9Ku8quZoGlgNC8XtyBFJOC-J9NGVvPZjWyUfkvyqX3L4U-RqfEK8C8fMUBHdLNBRp7-qOOwn1h7tj76ztXDgiSQrK4onc_duSGxO88WCQG6Qda2dlyt7tONmCEFHyixJXLEjnlDliC_9-ZPkWz3sWj9hvJsQWVf77K4Sb3s-1RWDZCrQsMn3Wli54MV4CMJT2wTtwg0vrZp3iPEFl7t5WpGd6uQZ1WrQUN2Px-iXu3x1NJ1xY3ir-bKsgP6scJY7ayzFP-BdVx8aXrBfPXlb4KI9CefMViDz-GRAw4Mz9KwqDEM_khweQMKR8vPE6MGob9hOj782NBM60iNDa4H3MJYSdqMHwm6yQnsKol5HRIOFkbxcZSp8M";
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

        public async Task<StoreBankingDetails> GetBankingDetailsByStoreIdAsync(int storeId)
        {
            return await _repository.GetBankingDetailsByStoreIdAsync(storeId);
        }
    }
}
