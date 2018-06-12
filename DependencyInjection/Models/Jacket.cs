using DependencyInjection.Interfaces;

namespace DependencyInjection.Models
{
    public class Jacket : IDress
    {
        public string Do()
        {
            return "Jacket dressing...";
        }
    }
}
