using System.Runtime.CompilerServices;

namespace reisiegel_CoffeeMaker
{
    public class CoffeeMaker : IDisposable
    {
        /// <summary>
        /// List of coffee types
        /// </summary>
        private List<CoffeeType> _coffeeTypes;
        public List<CoffeeType> CoffeeTypes
        {
            get { return _coffeeTypes; }
            protected set { _coffeeTypes = value; }
        }
        /// <summary>
        /// Selected coffee type
        /// </summary>
        private CoffeeType _coffeeType;
        public CoffeeType SelectedCoffeeType
        {
            get { return _coffeeType; }
            protected set { _coffeeType = value; }
        }
        /// <summary>
        /// Maker status
        /// </summary>
        private string _makerStatus;
        public string MakerStatus
        {
            get { return _makerStatus; }
            protected set { _makerStatus = value; }
        }
        /// <summary>
        /// Maker state
        /// </summary>
        private MakerStates _makerState;
        public MakerStates MakerState
        {
            get { return _makerState; }
            protected set { _makerState = value; }
        }
        /// <summary>
        /// Thread for making coffee
        /// </summary>
        private Thread _thread = new Thread(new ParameterizedThreadStart(ThreadProcedure));

        private static void ThreadProcedure(object sender)
        {
            var coffeeMaker = (CoffeeMaker)sender;
            if (!coffeeMaker.CoffeeTypes.Contains(coffeeMaker.SelectedCoffeeType))
            {
                coffeeMaker.MakerStatus = "Coffee type not found!";
                Thread.CurrentThread.Suspend();
            }
        }

        public void MakeCoffee(CoffeeType coffeeType)
        {
            _thread.Start(this);
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
            try
            {
                _thread.Interrupt();
                _thread.Join();
            }
            catch (Exception e)
            {
                MakerStatus = "Maker cannot be disposed!";
            }
        }
    }
}
