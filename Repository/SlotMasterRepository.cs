using AppoinmentServices.Data;
using AppoinmentServices.Entity;
using Microsoft.EntityFrameworkCore;
using AppoinmentServices.Repository.IRepository;
using System.Data;


namespace AppoinmentServices.Repository
{
    public class SlotMasterRepository : ISlotMasterRepository
    {
        private readonly AppoinmentServicesDbContext _context;
        

        public SlotMasterRepository(AppoinmentServicesDbContext context)
        {
            _context = context;
            
        }
        public async Task<Boolean> CreateSlotAsync(TimeOnly start_time, TimeOnly end_time)
        {
            var slotEntry = new SlotMaster
            {
                StartTime = start_time,
                EndTime = end_time
            };

            _context.SlotMasters.Add(slotEntry);
            int changes = await _context.SaveChangesAsync();
            return (changes > 0);
        }

        
        public async Task<SlotMaster> GetSlotByIdAsync(long Id)
        {
            return await _context.SlotMasters.FindAsync(Id);
        }
        public async Task<IEnumerable<SlotMaster>> GetAllSlotsAsync()
        {
            return await _context.SlotMasters.ToListAsync();
        }
        public async Task<Boolean> DisableSlotByIdAsync(long Id)
        {
            var slot = await _context.SlotMasters.FirstOrDefaultAsync(s => s.Id == Id);
            if (slot == null)
            {
                return false;
            }

            slot.IsActive = false;
            _context.SlotMasters.Update(slot);
            int changes = await _context.SaveChangesAsync();
            return (changes > 0);
            //await _context.SaveChangesAsync();
            //return true;
        }
        public async Task<Boolean> EnableSlotByIdAsync(long Id)
        {
            var slot = await _context.SlotMasters.FindAsync(Id);
            if (slot == null)
            {
                return false;
            }

            slot.IsActive = true;
            _context.SlotMasters.Update(slot);
            int changes = await _context.SaveChangesAsync();
            return (changes > 0);

            // var result = await _context.SaveChangesAsync();
            // return result > 0;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }

}










