using Microsoft.AspNetCore.Mvc;
using DAL;

namespace form.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentTypeController : CrudBaseContorller<DocumentType, int>
{

    public DocumentTypeController(
        ILogger<DocumentTypeController> logger,
        ApplicationDBContext context
        ) : base(logger, context)
    {
    }
}
