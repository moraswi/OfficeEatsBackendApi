using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Repository
{
    public class OfficesRepository : IOfficesRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public OfficesRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Public Constructors

        public async Task<Offices> AddOfficeAsync(Offices offices)
        {
            await _context.Offices.AddAsync(offices);
            await _context.SaveChangesAsync();
            return offices;
        }

        public async Task<IEnumerable<Offices>> GetAllOfficesAsync()
        {
            var results = await _context.Offices.ToListAsync();
            return results;
        }
     
    }
}
