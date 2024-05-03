using Cgs.Techinical.Challenge.Domain.Shared.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Cgs.Technical.Challenge.HttpApi
{
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(HttpResponseError), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(HttpResponseError), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(HttpResponseError), StatusCodes.Status500InternalServerError)]

    [Route("api/[controller]")]
    [ApiController]
    public class CgsController : ControllerBase
    {
    }
}
