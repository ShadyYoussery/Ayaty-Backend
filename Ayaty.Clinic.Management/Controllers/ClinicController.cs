using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ayaty.Clinic.Management.Bll.Interfaces;
using Ayaty.Clinic.Management.Dtos.Clinic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ayaty.Shared.Bll.Interfaces;
using Ayaty.Shared.Dto;

namespace Ayaty.Clinic.Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        #region Fields

        private readonly IClinic _clinic;
        private readonly IMessageResponse _messageResponse;

        #endregion Fields

        #region Ctor

        public ClinicController(IClinic clinic, IMessageResponse messageResponse)
        {
            _clinic = clinic;
            _messageResponse = messageResponse;
        }

        #endregion Ctor

        [HttpPost("add")]
        public async Task< MessageResponse<ClinicDto>> Add(ClinicDto dto)
        {
            try
            {
                return _messageResponse.Response(await _clinic.Add(dto));
            }
            catch (Exception e)
            {
                return new MessageResponse<ClinicDto>(e);
            }
        }
    }
}