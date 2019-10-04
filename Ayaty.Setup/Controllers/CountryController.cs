using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ayaty.Setup.Bll.Interfaces;
using Ayaty.Setup.Dtos.Country;
using Shared.Bll.Interfaces;
using Shared.Dto;

namespace Ayaty.Setup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region Fields

        private readonly ICountry _country;
        private readonly IMessageResponse _messageResponse;

        #endregion Fields

        #region Ctor

        public CountryController(ICountry country, IMessageResponse messageResponse)
        {
            _country = country;
            _messageResponse = messageResponse;
        }

        #endregion Ctor

        /// <summary>
        /// Add new Country with each language
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<MessageResponse<CountryAddEditDto>> Add(CountryAddEditDto dto)
        {
            try
            {
                return _messageResponse.Response(await _country.Add(dto));
            }
            catch (Exception e)
            {
                return new MessageResponse<CountryAddEditDto>(e);
            }
        }

        /// <summary>
        /// Edit Country Data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("edit")]
        public async Task<MessageResponse<CountryAddEditDto>> Edit(CountryAddEditDto dto)
        {
            try
            {
                return _messageResponse.Response(await _country.Edit(dto));
            }
            catch (Exception e)
            {
                return new MessageResponse<CountryAddEditDto>(e);
            }
        }

        /// <summary>
        /// Get list of Countries based on current language
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<MessageListResponse<CountryDto>> List(CountrySearchDto dto)
        {
            try
            {
                return _messageResponse.Response(await _country.List(dto));
            }
            catch (Exception e)
            {
                return new MessageListResponse<CountryDto>(e);
            }
        }

        /// <summary>
        /// delete Country Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<MessageResponse<bool>> Delete(int id)
        {
            try
            {
                return _messageResponse.Response(await _country.Delete(id));
            }
            catch (Exception e)
            {
                return new MessageResponse<bool>(e);
            }
        }

        /// <summary>
        /// Get Country by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageResponse<CountryAddEditDto>> GetById(int id)
        {
            try
            {
                return _messageResponse.Response(await _country.GetById(id));
            }
            catch (Exception e)
            {
                return new MessageResponse<CountryAddEditDto>(e);
            }
        }
    }
}