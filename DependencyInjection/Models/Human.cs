using DependencyInjection.Interfaces;

namespace DependencyInjection.Models
{
    public class Human
    {
        private readonly IDress _dress;

        public Human(IDress dress)
        {
            _dress = dress;
        }

        public string DressUp()
        {
            return _dress.Do();
        }
    }
}
