using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClass
{
    // define a delegate for the PropertyChanged event
    public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs eventArgs);

    // define a class Student
    public class Student
    {
        //define properties
        private string name;
        private int age;
        private PropertyChangedEventArgs changedArgs;

        // define an event for the ProepertyChange
        public event PropertyChangedEventHandler PropertyChanged;

        // define a constructor
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        //define properties 
        public string Name
        {
            get { return this.name;}
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name should be at lest two characters");
                }
                 
                this.changedArgs = new PropertyChangedEventArgs("Name", this.Name, value); 
                this.name = value;
                this.OnPropertyChanged(this, changedArgs);
            }
        }

        public int Age 
        {
            get { return this.age;}
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("Age shoul be a number in the range [0....150]");
                }

                this.changedArgs = new PropertyChangedEventArgs("Age", this.Age.ToString(),value.ToString());
                this.age = value;
                this.OnPropertyChanged(this, changedArgs);                
            }
        }

        // define a method to fire the PropertyChanged event
        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs changedArgs)
        {
            // check if we have subscribers for the event
            if (PropertyChanged != null)
            {
                // trigger the event
                PropertyChanged(this, changedArgs);
            }
        }
    }
}
