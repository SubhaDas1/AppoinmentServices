using Microsoft.AspNetCore.Mvc;
using AppoinmentServices.Helper;
using AppoinmentServices.Entity;
using AppoinmentServices.Services;
using AppoinmentServices.Enum;
using AppoinmentServices.Services.IServices;

namespace AppoinmentServices.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SlotMasterController : ControllerBase
    {
        private readonly ISlotMasterService _slotMasterService;

        public SlotMasterController(ISlotMasterService slotMasterService)
        {
            _slotMasterService = slotMasterService;
        }

        [HttpPost("V1/CreateSlot")]
        public async Task<Response<Boolean>> CreateSlot(string start_time, string end_time)
        {
            var _response = new Response<Boolean>();
            try
            {
                bool status = await _slotMasterService.CreateSlotAsync(start_time, end_time);
                if (status == true)
                {
                    _response.status = APIResponseStatus.Created;
                    _response.result = status;
                    _response.message = "Slot created successfully";

                }
                else
                {
                    _response.status = APIResponseStatus.NotFound;
                    _response.result = status;
                    _response.message = "Slot not created";

                }
            }
            catch (Exception ex)
            {
                _response.status = APIResponseStatus.Error;
                _response.result = false;
                _response.message = ex.Message;
            }

            return _response;
        }
        [HttpPost("V1/GetSlotById/{Id}")]
        public async Task<Response<SlotMaster>> GetSlotById(long Id)
        {
            var _response = new Response<SlotMaster>();

            try
            {
                SlotMaster slot = await _slotMasterService.GetSlotByIdAsync(Id);
                if (slot == null)
                {
                    _response.status = APIResponseStatus.NotFound;
                    _response.result = slot;
                    _response.message = "No Slot";
                }
                else
                {
                    _response.status = APIResponseStatus.Success;
                    _response.result = slot;
                    _response.message = " Show Slot by id";
                }

            }
            catch (Exception ex)
            {
                _response.status = APIResponseStatus.Error;
                _response.result = null;
                _response.message = ex.Message;
            }
            return _response;
        }
        [HttpPost("V1/GetAllSlots")]
        public async Task<Response<IEnumerable<SlotMaster>>> GetAllSlots()
        {
            var _response = new Response<IEnumerable<SlotMaster>>();

            try
            {
                var allslot = await _slotMasterService.GetAllSlotsAsync();
                if (allslot == null)
                {
                    _response.status = APIResponseStatus.NoContent;
                    _response.result = allslot;
                    _response.message = "No Slot";
                }
                else
                {
                    _response.status = APIResponseStatus.Success;
                    _response.result = allslot ;
                    _response.message = "Show all slot";
                }

            }
            catch (Exception ex)
            {
                _response.status = APIResponseStatus.Error;
                _response.result = null;
                _response.message = ex.Message;
            }
            return _response;
        }
        [HttpPost("V1/DisableSlotById/{Id}")]
        public async Task<Response<Boolean>> DisableSlot(long Id)
        {
            var _response = new Response<Boolean>();
            try
            {
                bool status = await _slotMasterService.DisableSlotByIdAsync(Id);
                if (status == true)
                {
                    _response.status = APIResponseStatus.Success;
                    _response.result = status;
                    _response.message = "Slot disable successfully";

                }
                else
                {
                    _response.status = APIResponseStatus.NotFound;
                    _response.result = status;
                    _response.message = "Slot not disabled";

                }
            }
            catch (Exception ex)
            {
                _response.status = APIResponseStatus.Error;
                _response.result = false;
                _response.message = ex.Message;
            }

            return _response;
        }
        [HttpPost("V1/EnableSlotById/{Id}")]
        public async Task<Response<Boolean>> EnableSlot(long Id)
        {
            var _response = new Response<Boolean>();
            try
            {
                bool status = await _slotMasterService.EnableSlotByIdAsync(Id);
                if (status == true)
                {
                    _response.status = APIResponseStatus.Success;
                    _response.result = status;
                    _response.message = "Slot enable successfully";

                }
                else
                {
                    _response.status = APIResponseStatus.NotFound;
                    _response.result = status;
                    _response.message = "Slot not enabled";

                }
            }
            catch (Exception ex)
            {
                _response.status = APIResponseStatus.Error;
                _response.result = false;
                _response.message = ex.Message;
            }

            return _response;
        }



    }

}
    
