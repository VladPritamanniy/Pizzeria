namespace Pizzeria.Core.Exceptions
{
    public class PizzaNotCreatedException : Exception
    {
        public PizzaNotCreatedException() : base("Pizza not created.")
        {
        }

        public PizzaNotCreatedException(string message) : base(message)
        {
        }
    }
}
