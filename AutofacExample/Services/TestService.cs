using System.Threading.Tasks;

namespace AutofacExample.Services
{
    public class TestService
    {
        public async Task<string> GetPing()
        {
            return "PONG!!!";
        }
    }
}