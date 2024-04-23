using System.Drawing;

namespace CoffeeMaker
{
    public class CoffeeType
    {
        public string Name { get; set; } = "Coffee Name"; // Default value "Coffee Name"
        public Color Color { get; set; } = Color.LimeGreen; // Default value Color.Black
        public int MakeTime { get; set; } = 1000; // Default value 1000
    }
}