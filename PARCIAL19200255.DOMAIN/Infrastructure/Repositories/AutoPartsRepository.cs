using Microsoft.EntityFrameworkCore;
using PARCIAL19200255.DOMAIN.Core.Entities;
using PARCIAL19200255.DOMAIN.Core.Interfaces;
using PARCIAL19200255.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARCIAL19200255.DOMAIN.Infrastructure.Repositories
{
    public class AutoPartsRepository : IAutoPartsRepository
    {
        private readonly Parcial20240219200255DbContext _dbContext;

        public AutoPartsRepository(Parcial20240219200255DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AutoParts>> GetAutoParts()
        {
            var autoParts = await _dbContext.AutoParts.ToListAsync();
            return autoParts;
        }

        public async Task<AutoParts> GetAutoPartById(int id)
        {
            var autoPart = await _dbContext
                            .AutoParts
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
            return autoPart;
        }

        public async Task<int> CreateAutoPart(AutoParts autoPart)
        {
            await _dbContext.AutoParts.AddAsync(autoPart);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? autoPart.Id : -1;
        }

        public async Task<bool> UpdateAutoPart(AutoParts autoPart)
        {
            _dbContext.AutoParts.Update(autoPart);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteAutoPart(int id)
        {
            var autoPart = await GetAutoPartById(id);
            if (autoPart == null) return false;

            _dbContext.AutoParts.Remove(autoPart);
            int rows = await _dbContext.SaveChangesAsync();

            return rows > 0;
        }
    }
}
