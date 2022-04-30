using Microsoft.AspNetCore.Http;

namespace Eticaret.Presentation.Areas.Admin.Helpers
{
    public interface IAdminChecker
    {
        bool Check(HttpRequest request);
    }
}