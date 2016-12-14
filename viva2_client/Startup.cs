using Microsoft.Owin;
using Owin;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(viva2_client.Startup))]
namespace viva2_client
{
    
    public class UserDetails
    {
        public static string Email { get; set; } = "";
        public static string FirstName { get; set; } = "";
        public static string LastName { get; set; } = "";

    }


    public partial class Startup {
        public string username_in_title = "dasdad";

        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
