using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using OfficeEatsBackendApi.Dtos;
using OfficeEatsBackendApi.Interfaces.Services;
using OfficeEatsBackendApi.Models;

namespace OfficeEatsBackendApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PaymentGateWayController : ControllerBase
    {
        #region Fields

        private readonly IPaymentGateWayService _paymentGateWayService;

        #endregion Fields

        #region Public Constructors

        public PaymentGateWayController(IPaymentGateWayService paymentGateWayService)
        {
            _paymentGateWayService = paymentGateWayService;
        }

        #endregion Public Constructors



        //[HttpPost("token")]
        //public async Task<object> GetAuthToken()
        //{
        //    var result = await _paymentGateWayService.GetAuthTokenAsync();
        //    return StatusCode(200, result);
        //}

        //[HttpPost("create-checkout")]
        //public async Task<IActionResult> CreateCheckout(CheckoutRequestDto request)
        //{
        //    var checkoutResponse = await _paymentGateWayService.CreateCheckoutAsync(request);
        //    return StatusCode(200, checkoutResponse);
        //}

        //[HttpPut("payment")]
        //public async Task<IActionResult> UpdatePayment(UpdatePaymentDto request)
        //{
        //    var response = await _paymentGateWayService.UpdatePaymentAsync(request);
        //    return StatusCode(200, response);
        //}


        //[HttpPost("payment-events")]
        //public async Task<IActionResult> PaymentEvents()
        //{
        //    AddPaymentEventsDto request;

        //    if (Request.ContentType != null && Request.ContentType.Contains("application/json"))
        //    {
        //        // Parse JSON request body
        //        using (var reader = new StreamReader(Request.Body))
        //        {
        //            var body = await reader.ReadToEndAsync();
        //            request = JsonConvert.DeserializeObject<AddPaymentEventsDto>(body);
        //        }
        //    }
        //    else if (Request.ContentType != null && Request.ContentType.Contains("application/x-www-form-urlencoded"))
        //    {
        //        // Parse form-urlencoded data
        //        var form = await Request.ReadFormAsync();
        //        request = new AddPaymentEventsDto
        //        {
        //            Id = form["id"],
        //            Amount = form["amount"],
        //            Currency = form["currency"],
        //            PaymentBrand = form["paymentBrand"],
        //            PaymentType = form["paymentType"],
        //            MerchantTransactionId = form["merchantTransactionId"],
        //            Timestamp = form["timestamp"],
        //            Card = new CardDto
        //            {
        //                Bin = form["card.bin"],
        //                ExpiryMonth = form["card.expiryMonth"],
        //                ExpiryYear = form["card.expiryYear"],
        //                Holder = form["card.holder"],
        //                Last4Digits = form["card.last4Digits"]
        //            },
        //            Recon = new ReconDto
        //            {
        //                AuthCode = form["recon.authCode"],
        //                ResultCode = form["recon.resultCode"],
        //                Rrn = form["recon.rrn"],
        //                Stan = form["recon.stan"]
        //            },
        //            Result = new ResultDto
        //            {
        //                Code = form["result.code"],
        //                Description = form["result.description"]
        //            },
        //            ResultDetails = new ResultDetailsDto
        //            {
        //                AcquirerResponse = form["resultDetails.AcquirerResponse"],
        //                ExtendedDescription = form["resultDetails.ExtendedDescription"]
        //            }
        //        };
        //    }
        //    else
        //    {
        //        return StatusCode(400, new { message = "Unsupported content type" });
        //    }

        //    // Validate request
        //    if (request == null || IsEmptyRequest(request))
        //    {
        //        return StatusCode(200, new { message = "No valid data provided" });
        //    }

        //    var result = await _paymentGateWayService.AddPaymentEvents(request);
        //    return StatusCode(200, result);
        //}

        // Helper method to check if all properties in request are null or empty
        //private bool IsEmptyRequest(AddPaymentEventsDto request)
        //{
        //    return typeof(AddPaymentEventsDto)
        //        .GetProperties()
        //        .All(prop => prop.GetValue(request) == null ||
        //                     (prop.PropertyType == typeof(string) && string.IsNullOrWhiteSpace((string)prop.GetValue(request))));
        //}

        //[HttpGet("{checkoutId}")]
        //public IActionResult RenderCheckout(string checkoutId)
        //{
        //    Response.Headers["Permissions-Policy"] = "payment self 'src'";

        //    return Content($@"
        //        <!DOCTYPE html>
        //        <html lang='en'>
        //          <head>
        //            <meta charset='UTF-8' />
        //            <meta name='viewport' content='width=device-width, initial-scale=1, maximum-scale=1.0, user-scalable=no' />
        //            <title>Complete your payment</title>
        //            <script src='https://sandbox-checkout.peachpayments.com/js/checkout.js'></script>
        //          </head>
        //          <body>
        //            <div id='payment-form'></div>
        //            <script>
        //              const checkout = Checkout.initiate({{
        //                checkoutId: '{checkoutId}',
        //                key: '{Environment.GetEnvironmentVariable("PEACH_PAYMENTS_ENTITY_ID")}',
        //                events: {{
        //                  onCompleted: (event) => {{
        //                    console.log(event);
        //                    checkout.unmount();
        //                    document.getElementById('payment-form').innerText = 'Paid!';
        //                  }},
        //                  onCancelled: (event) => {{
        //                    console.log(event);
        //                    checkout.unmount();
        //                    document.getElementById('payment-form').innerText = 'Cancelled!';
        //                  }},
        //                  onExpired: (event) => {{
        //                    console.log(event);
        //                    checkout.unmount();
        //                    document.getElementById('payment-form').innerText = 'Expired!';
        //                  }}
        //                }}
        //              }});
        //              checkout.render('#payment-form');
        //            </script>
        //          </body>
        //        </html>", "text/html");
        //}


        [HttpGet("store-banking-details/{storeId}")]
        public async Task<ActionResult<StoreBankingDetails>> StoreBankingDetails(int storeId)
        {
            var results = await _paymentGateWayService.GetBankingDetailsByStoreIdAsync(storeId);
            if (results == null)
            {
                return NotFound("Banking details not found for the specified store.");
            }
            return StatusCode(200, results);
        }

    }
}
