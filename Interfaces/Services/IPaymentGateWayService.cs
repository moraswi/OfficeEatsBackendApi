using OfficeEatsBackendApi.Dtos;
using OfficeEatsBackendApi.Models;

namespace OfficeEatsBackendApi.Interfaces.Services
{
    public interface IPaymentGateWayService
    {
        Task<object> GetAuthTokenAsync();
        Task<CheckoutResponseDto> CreateCheckoutAsync(CheckoutRequestDto request);
        Task<AddPaymentEventsDto> AddPaymentEvents(AddPaymentEventsDto request);
        Task<Payments> UpdatePaymentAsync(UpdatePaymentDto request);
    }
}
