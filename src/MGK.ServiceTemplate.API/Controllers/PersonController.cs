using MGK.ServiceBase.API;
using MGK.ServiceBase.IWEManager.Models;
using MGK.ServiceBase.SeedWork;
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
using System.Threading;
using System.Threading.Tasks;

namespace MGK.ServiceTemplate.API.Controllers
{
    [Route(CoreConstants.ContextPath + "[controller]")]
    [ApiController]
    public class PersonController : ApiControllerBase<PersonController>, IControllerService
    {
        public PersonController(
            IControllerInternalServices<PersonController> internalServices)
            : base(internalServices)
        {
        }

		/// <summary>
		/// Adds a person.
		/// </summary>
		/// <param name="request">Request with the person's information.</param>
		/// <param name="cancellationToken">Cancellation Token in case the user cancels the process.</param>
		/// <returns>The person information.</returns>
		[HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(PersonViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> AddPersonAsync([FromBody]AddPersonRequest request, CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(Mapper.Map<AddPersonCommand>(request), cancellationToken);
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
            var results = await Mediator.Send(new GetAllPersonsQuery());
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
            var result = await Mediator.Send(new GetPersonQuery { PersonId = personId });
            return Ok(result);
        }

        /// <summary>
        /// Removes the information of a person.
        /// </summary>
        /// <param name="personId">The identification of the person.</param>
		/// <param name="cancellationToken">Cancellation Token in case the user cancels the process.</param>
        /// <returns>Information of the person removed.</returns>
        [HttpDelete]
        [Route("{personId}")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemovePersonAsync(Guid personId, CancellationToken cancellationToken = default)
        {
            var result = await Mediator.Send(new RemovePersonCommand { PersonId = personId }, cancellationToken);
            return Ok(result);
        }

        /// <summary>
        /// Updates the person's information.
        /// </summary>
        /// <param name="personId">The identification of the person.</param>
        /// <param name="request">The requested data to update.</param>
		/// <param name="cancellationToken">Cancellation Token in case the user cancels the process.</param>
        /// <returns>The updated information of the person.</returns>
        [HttpPut]
        [Route("{personId}")]
        [ProducesResponseType(typeof(PersonViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorDetails), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> UpdatePersonAsync(Guid personId, [FromBody]UpdatePersonRequest request, CancellationToken cancellationToken = default)
        {
            var command = new UpdatePersonCommand { PersonId = personId };
            Mapper.Map(request, command);
            var result = await Mediator.Send(command, cancellationToken);
            return Ok(result);
        }
    }
}
