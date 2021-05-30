using AutoMapper;
using MediatR;
using MGK.Acceptance;
using MGK.ServiceBase.IWEManager.Models;
using MGK.ServiceTemplate.API.Application.Commands.ProofOfConcept;
using MGK.ServiceTemplate.API.Application.Queries.ProofOfConcept;
using MGK.ServiceTemplate.API.Application.Requests.ProofOfConcept;
using MGK.ServiceTemplate.API.Constants;
using MGK.ServiceTemplate.API.Models;
using MGK.ServiceTemplate.API.Models.ProofOfConcept;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.API.Controllers
{
    [Route(CoreConstants.ContextPath + "[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PersonController(IMediator mediator, IMapper mapper)
        {
            Ensure.Parameter.IsNotNull(mediator, nameof(mediator));
            Ensure.Parameter.IsNotNull(mapper, nameof(mapper));

            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds a person.
        /// </summary>
        /// <param name="request">Request with the person's information.</param>
        /// <returns>The person information.</returns>
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(PersonViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> AddPersonAsync([FromBody]AddPersonRequest request)
        {
            var result = await _mediator.Send(_mapper.Map<AddPersonCommand>(request));
            return Ok(result);
        }

        /// <summary>
        /// Get all persons.
        /// </summary>
        /// <returns>The information of all persons.</returns>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(IEnumerable<PersonViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllPersonsAsync()
        {
            var results = await _mediator.Send(new GetAllPersonsQuery());
            return Ok(results);
        }

        /// <summary>
        /// Gets the information of one person.
        /// </summary>
        /// <param name="personId">The identification of the person.</param>
        /// <returns>The person information.</returns>
        [HttpGet]
        [Route("{personId}")]
        [ProducesResponseType(typeof(PersonViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetPersonAsync(Guid personId)
        {
            var result = await _mediator.Send(new GetPersonQuery(personId));
            return Ok(result);
        }

        /// <summary>
        /// Removes the information of a person.
        /// </summary>
        /// <param name="personId">The identification of the person.</param>
        /// <returns>Information of the person removed.</returns>
        [HttpDelete]
        [Route("{personId}")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemovePersonAsync(Guid personId)
        {
            var result = await _mediator.Send(new RemovePersonCommand(personId));
            return Ok(result);
        }

        /// <summary>
        /// Updates the person's information.
        /// </summary>
        /// <param name="personId">The identification of the person.</param>
        /// <param name="request">The requested data to update.</param>
        /// <returns>The updated information of the person.</returns>
        [HttpPut]
        [Route("{personId}")]
        [ProducesResponseType(typeof(PersonViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdatePersonAsync(Guid personId, [FromBody]UpdatePersonRequest request)
        {
            var command = _mapper.Map<UpdatePersonCommand>(request);
            command.PersonId = personId;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
