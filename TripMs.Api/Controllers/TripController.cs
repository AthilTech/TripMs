using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TripMs.Domain.Commands;
using TripMs.Domain.Models;
using TripMs.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripMs.Api;

namespace TripMs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        public readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TripController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        #region Standard WebMethods
        // GET: api/Trip
        [HttpGet]
        public IEnumerable<TripDTO> Get()
        {
            return _mediator.Send(new GetListQuery<Trip>())
                .Result.Select(comp => _mapper.Map<TripDTO>(comp));
        }


        [HttpGet("{id}")]
        public TripDTO Ge(Guid id)
        {
            Trip Trip = _mediator.Send(new GetQuery<Trip>(condition: c => c.TripId == id)).Result;
            return _mapper.Map<TripDTO>(Trip);
        }


        [HttpPost]
        public async Task<string> Post(Trip Trip)
        {
             await _mediator.Send(new PostCommand<Trip>(Trip));
            return Trip.TripId.ToString();
        }


        [HttpPut]
        public async Task<string> Put(Trip Trip)
        {
            return await _mediator.Send(new PutCommand<Trip>(Trip));
        }


        [HttpDelete]
        public async Task<string> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteCommand<Trip>(id));
        }
        #endregion

        #region Custom Web Methods


        #endregion
    }
}
