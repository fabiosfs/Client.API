using Client.Domain.SharedContext;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Client.API.Controllers
{
    public class BaseController : ControllerBase
    {
        //[NonAction]
        protected ActionResult Return(ReturnBase returnBase)
        {
            return returnBase.ResponseCode switch
            {
                HttpStatusCode.OK => Ok(returnBase.Data),
                HttpStatusCode.Created => Created("", returnBase.Data),
                HttpStatusCode.NoContent => NoContent(),
                HttpStatusCode.NotFound => NotFound(returnBase.Data),
                HttpStatusCode.UnprocessableEntity => UnprocessableEntity(returnBase.Data),
                HttpStatusCode.InternalServerError => Problem(returnBase.Message),
                _ => Problem(returnBase.Message),
            };
        }
    }
}
