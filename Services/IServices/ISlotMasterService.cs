using AppoinmentServices.Entity;

namespace AppoinmentServices.Services.IServices
{
    public interface ISlotMasterService
    {
        public Task<bool> CreateSlotAsync(string start_time, string end_time);
        public Task<SlotMaster> GetSlotByIdAsync(long Id);
        public Task<IEnumerable<SlotMaster>> GetAllSlotsAsync();
        public Task<bool> DisableSlotByIdAsync(long Id);
        public Task<bool> EnableSlotByIdAsync(long Id);

    }
}
