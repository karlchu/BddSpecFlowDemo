using System.Web;

namespace BddSpecFlowDemo.Simulation
{
    public class HttpContextWrapper : IHttpContext
    {
        public string CurrentIpAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
    }
}