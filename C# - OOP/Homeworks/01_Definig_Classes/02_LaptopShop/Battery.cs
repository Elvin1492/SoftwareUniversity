using System;

//defining the Battery class
namespace LaptopShop
{

    public class Battery
    {
        //defining fields
        private string model;
        private float life;

        //defining a Model property with validation
        public string Model
        {
            get { return this.model; }
            set
            {
                if (value != null && value == String.Empty) throw new ArgumentException("Battery model can not be an empty string");
                this.model = value;
            }
        }
        //defining a Life property with validation
        public float Life
        {
            get { return this.life; }
            set
            {
                if (value < 0.00F) throw new ArgumentOutOfRangeException(Convert.ToString(this.life),
                    "Battery life can not be a negative number");
                this.life = value;
            }
        }

        //defining a constructor with default values so thath a new instance of the class can be created with none or some parameters
        public Battery(string model = null, float life = 0.00F)
        {
            this.Model = model;
            this.Life = life;
        }
        public Battery(float life) : this(null, life) { }

        //Implement the ToString() method to enable printing battery inforamtion at the console
        public override string ToString()
        {
            //if the object has benn created without any of its properties display a "N/A" message
            return string.Format(" Battery Model:{0}, Battery life: {1}",
                this.model ?? "(N/A)", this.life == 0.00F ? "(N/A)" : Convert.ToString(this.life) + " hours");
        }
    }
}