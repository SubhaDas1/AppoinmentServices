using AppoinmentServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppoinmentServices.Helper;
using AppoinmentServices.Entity;
using System.Data;
using System;
using AppoinmentServices.Services.IServices;
using AppoinmentServices.Repository.IRepository;

namespace AppoinmentServices.Services
{
    public class SlotMasterService : ISlotMasterService
    {
        private readonly ISlotMasterRepository _slotMasterRepository;

        public SlotMasterService(ISlotMasterRepository slotMasterRepository)
        {
            _slotMasterRepository = slotMasterRepository;
        }

        public async Task<Boolean> CreateSlotAsync(string start_time, string end_time)
        {
            if (end_time == null || start_time == null)
            {
                return false;
            }
            TimeOnly startTime = TimeOnly.Parse(start_time);
            TimeOnly endTime = TimeOnly.Parse(end_time);

            return await _slotMasterRepository.CreateSlotAsync(startTime, endTime);
        }

        //public async Task<Boolean> UpdateSlotById(long slotId, TimeOnly slot_start, TimeOnly slot_end)
        //{
        //    return await _slotMasterRepository.UpdateSlotById(slotId, slot_start, slot_end);
        //}

        public async Task<SlotMaster> GetSlotByIdAsync(long Id)
        {
            return await _slotMasterRepository.GetSlotByIdAsync(Id);
        }
        public async Task<IEnumerable<SlotMaster>> GetAllSlotsAsync()
        {
            return await _slotMasterRepository.GetAllSlotsAsync();
        }
        public async Task<Boolean> DisableSlotByIdAsync(long Id)
        {
            return await _slotMasterRepository.DisableSlotByIdAsync(Id);
        }
        public async Task<Boolean> EnableSlotByIdAsync(long Id)
        {
            return await _slotMasterRepository.EnableSlotByIdAsync(Id);
        }



    }
}
