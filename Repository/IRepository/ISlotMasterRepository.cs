using AppoinmentServices.Entity;

namespace AppoinmentServices.Repository.IRepository
{
    public interface ISlotMasterRepository
    {
        public Task<Boolean> CreateSlotAsync(TimeOnly start_time, TimeOnly end_time);
        public Task<SlotMaster> GetSlotByIdAsync(long Id);
        public Task<IEnumerable<SlotMaster>> GetAllSlotsAsync();
        public Task<Boolean> DisableSlotByIdAsync(long Id);
        public Task<Boolean> EnableSlotByIdAsync(long Id);
        public Task<int> SaveAsync();





    }
}
