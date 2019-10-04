using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ayaty.Setup.Bll.Interfaces;
using Ayaty.Setup.Dtos.State;
using Shared.Bll.Interfaces;
using Shared.Dto;

namespace Ayaty.Setup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        #region Fields

        private readonly IState _State;
        private readonly IMessageResponse _messageResponse;

        #endregion Fields

        #region Ctor

        public StateController(IState State, IMessageResponse messageResponse)
        {
            _State = State;
            _messageResponse = messageResponse;
        }

        #endregion Ctor

        /// <summary>
        /// Add new State with each language
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<MessageResponse<StateAddEditDto>> Add(StateAddEditDto dto)
        {
            try
            {
                return _messageResponse.Response(await _State.Add(dto));
            }
            catch (Exception e)
            {
                return new MessageResponse<StateAddEditDto>(e);
            }
        }

        /// <summary>
        /// Edit State Data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("edit")]
        public async Task<MessageResponse<StateAddEditDto>> Edit(StateAddEditDto dto)
        {
            try
            {
                return _messageResponse.Response(await _State.Edit(dto));
            }
            catch (Exception e)
            {
                return new MessageResponse<StateAddEditDto>(e);
            }
        }

        /// <summary>
        /// Get list of States based on current language
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<MessageListResponse<StateDto>> List(StateSearchDto dto)
        {
            try
            {
                return _messageResponse.Response(await _State.List(dto));
            }
            catch (Exception e)
            {
                return new MessageListResponse<StateDto>(e);
            }
        }

        /// <summary>
        /// delete State Data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<MessageResponse<bool>> Delete(int id)
        {
            try
            {
                return _messageResponse.Response(await _State.Delete(id));
            }
            catch (Exception e)
            {
                return new MessageResponse<bool>(e);
            }
        }

        /// <summary>
        /// Get State by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<MessageResponse<StateAddEditDto>> GetById(int id)
        {
            try
            {
                return _messageResponse.Response(await _State.GetById(id));
            }
            catch (Exception e)
            {
                return new MessageResponse<StateAddEditDto>(e);
            }
        }
    }
}