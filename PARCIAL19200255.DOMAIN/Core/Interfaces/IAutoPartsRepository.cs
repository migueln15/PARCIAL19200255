using PARCIAL19200255.DOMAIN.Core.Entities;

namespace PARCIAL19200255.DOMAIN.Core.Interfaces
{
    public interface IAutoPartsRepository
    {
        Task<int> CreateAutoPart(AutoParts autoPart);
        Task<bool> DeleteAutoPart(int id);
        Task<AutoParts> GetAutoPartById(int id);
        Task<IEnumerable<AutoParts>> GetAutoParts();
        Task<bool> UpdateAutoPart(AutoParts autoPart);
    }
}