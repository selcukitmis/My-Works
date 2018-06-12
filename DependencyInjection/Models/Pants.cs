using DependencyInjection.Interfaces;

namespace DependencyInjection.Models
{
    public class Pants : IDress
    {
        public string Do()
        {
            return "Pants dressing...";
        }
    }
}
