using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    private ISender _mediator;

    // Lazy injection to avoid duplicate injection in child controllers
    protected ISender Mediator =>
        _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}