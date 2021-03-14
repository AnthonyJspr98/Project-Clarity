using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clarity.Presentation.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        private IMediator mediator;
        
        private DbContext writeOnlyDbContext;

        internal IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    
        internal DbContext WriteOnlyDbContext => writeOnlyDbContext ??= HttpContext.RequestServices.GetService<DbContext>();
    }
}