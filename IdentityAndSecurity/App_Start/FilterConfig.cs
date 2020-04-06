using System.Web;
using System.Web.Mvc;

namespace IdentityAndSecurity
{
    public class FilterConfig
    {
        // Định nghĩa globle object filters, áp dụng cho all class.
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
