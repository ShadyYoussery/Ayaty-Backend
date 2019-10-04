using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ayaty.Setup.Bll.Interfaces;
using Ayaty.Setup.Dtos.City;
using Shared.Bll.Interfaces;
using Shared.Dto;

namespace Ayaty.Setup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        #region Fields

        private readonly ICity _City;
        private readonly IMessageResponse _messageResponse;

        #endregion Fields

        #region Ctor

        public CityController(ICity City, IMessageResponse messageResponse)
        {
            _City = City;
            _messageResponse = messageResponse;
        }

        #endregion Ctor

        /// <summary>
        /// Add new City with each language
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<MessageResponse<CityAddEditDto>> Add(CityAddEditDto dto)
        {
            try
            {
                return _messageResponse.Response(await _City.Add(dto));
            }
            catch (Exception e)
            {
                return new MessageResponse<CityAddEditDto>(e);
            }
        }

        /// <summary>
        /// Edit City Data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("edit")]
        public async Task<MessageResponse<CityAddEditDto>> Edit(CityAddEditDto dto)
        {
            try
            {
                return _messageResponse.Response(await _City.Edit(dto));
            }
            catch (Exception e)
            {
                return new MessageResponse<CityAddEditDto>(e);
            }
        }
    }
}