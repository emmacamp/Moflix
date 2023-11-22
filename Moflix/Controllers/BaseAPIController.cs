﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Moflix.Controllers
{
        [ApiController]
        [Route("api/v{version:apiVersion}/[controller]")]
        public abstract class BaseAPIController : ControllerBase 
        {
            private IMediator _mediator;
            protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        }
    }

