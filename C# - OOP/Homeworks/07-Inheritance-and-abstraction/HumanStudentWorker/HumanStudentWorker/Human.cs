
namespace HumanStudentWorker
{
    using System;

    // define an abstract class Human
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName 
        {
            get { return this.firstName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new AggregateException("First name can not be less than three charachers.");
                }

                this.firstName = value;
            }
        }

        public string LastName 
        {
            get { return this.lastName; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name can not be less than 3 charachtes.");
                }

                this.lastName = value;
            }
        }

        // override the ToString method
        public override string ToString()
        {
            return String.Format("{0} {1}",this.firstName, this.lastName);
        }
    }
}
