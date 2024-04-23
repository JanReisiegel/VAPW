namespace CoffeeMaker
{
    public class CoffeeMaker : IDisposable
    {
        private List<CoffeeType> _coffeeTypes;
        public List<CoffeeType> CoffeeTypes
        {
            get { return _coffeeTypes; }
            set { _coffeeTypes = value; }
        }
        public CoffeeMaker()
        {
            _coffeeTypes = new List<CoffeeType>();
        }
        public CoffeeMaker(List<CoffeeType> coffeeTypes) : this()
        {
            coffeeTypes.ForEach(ct => _coffeeTypes.Add(ct));
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
