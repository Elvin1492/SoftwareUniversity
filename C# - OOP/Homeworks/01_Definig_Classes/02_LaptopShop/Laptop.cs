using System;
using System.Text;

namespace LaptopShop
{
    //defining the Laptop class
    public class Laptop
    {
        //define fields
        private string model;
        private string manufacturer;
        private string processor;
        private int ram;
        private string graphicCard;
        private int hdd;
        private float screen;
        private Battery battery;
        private decimal price;

        //define Model property with validation
        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(this.model, "Model must be a non-empty string!");
                this.model = value;
            }
        }
        //define Manufacturer property with validation
        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value != null && value == String.Empty) throw new ArgumentException("Manufacturer must be a non-empty string!");
                this.manufacturer = value;
            }
        }
        //define Processor property with validation
        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (value != null && value == String.Empty) throw new ArgumentException("Processor must be a non-empty string!");
                this.processor = value;
            }
        }
        //define Ram property with validation
        public int Ram
        {
            get { return this.ram; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(Convert.ToString(this.ram),
                    "Ram must be a positive integer number!");
                this.ram = value;
            }
        }
        //define GraphicCard property with validation
        public string GraphicCard
        {
            get { return this.graphicCard; }
            set
            {
                if (value != null && value == String.Empty) throw new ArgumentException("GraphicCard must be a non-empty string!");
                this.graphicCard = value;
            }
        }
        //define Hdd property with validation
        public int Hdd
        {
            get { return this.hdd; }
            set
            {
                if (value != 0 && value < 0) throw new ArgumentOutOfRangeException(Convert.ToString(this.hdd),
                    "HDD must be a positive integer number!");
                this.hdd = value;
            }
        }
        //define Screen property with validation
        public float Screen
        {
            get { return this.screen; }
            set
            {
                if (value < 0.00f) throw new ArgumentOutOfRangeException(Convert.ToString(this.screen),
                    "Screen must be a positive floating-point number!");
                this.screen = value;
            }
        }
        //define Pice property with validation 
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0.00M) throw new ArgumentOutOfRangeException(Convert.ToString(this.price),
                   "Price must be a positive decimal number!");
                this.price = value;
            }
        }
        //define the object Battery as property
        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        //define a cosructor with all properties assigning default values to the optional parameters
        public Laptop(string model, decimal price, string manufacturer = null, string processor = null, int ram = 0,
            string graphicCard = null, int hdd = 0, float screen = 0.0f, Battery battery = null)
        {
            this.Model = model;
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicCard = graphicCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = battery;
        }

        //Implement the ToString() method to enable printing battery inforamtion at the console
        public override string ToString()
        {
            StringBuilder laptopInfo = new StringBuilder();
            laptopInfo.Append("Model: " + this.model + " Price: " + this.price + " BGN");
            if (this.manufacturer != null) laptopInfo.Append(", Manufacturer: " + this.manufacturer);
            if (this.processor != null) laptopInfo.Append(", Processor: " + this.processor);
            if (this.ram != 0) laptopInfo.Append(", RAM : " + this.ram + " GB");
            if (this.graphicCard != null) laptopInfo.Append(", Graphic Card: " + this.graphicCard);
            if (this.hdd != 0) laptopInfo.Append(", HDD : " + this.hdd + " GB SSD");
            if (this.screen != 0.0f) laptopInfo.Append(", Screen : " + this.screen + " inch ");
            if (this.Battery != null) laptopInfo.Append(this.Battery.ToString());
            return laptopInfo.ToString();
        }

    }
}
