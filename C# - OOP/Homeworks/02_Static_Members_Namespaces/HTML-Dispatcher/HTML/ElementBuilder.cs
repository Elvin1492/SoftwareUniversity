
namespace HTML
{
    using System;

    //define class ElementBuilder
    class ElementBuilder
    {
        private string result;
        private string element;
        private string attribute;
        private string value;
        private string content;

        //define propertires
        private string  Element 
        {
            get { return  this.element;}
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(this.element, "Tag can not be empty");
                }
                this.element = value;
            }
        }

        private string Attribute
        {
            get { return this.attribute; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(this.attribute, "Attribute can not be empty");
                }
                this.attribute = value;
            }
        }

        private string Value
        {
            get { return this.value; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(this.value, "Attribute value can not be empty");
                }
                this.value = value;
            }
        }

        private string Content
        {
            get { return this.content; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(this.content, "Content can not not be empty");
                }
                this.content = value;
            }
        }


        //define a constructor which takes an element
        public ElementBuilder(string element)
        {
            this.Element = element;
            this.result += String.Format("<{0}",this.element);
        }

        //define a method for adding attributes
        public void AddAtribute(string attribute, string value)
        {
            this.Attribute = attribute;
            this.Value = value;
            this.result += String.Format(" {0}=\"{1}\"",this.attribute,this.value);
        }

        //define a method for adding content
        public void AddConent(string input)
        {   
            this.Content = input;
            this.content += this.content;
        }

        //overload the * operator for multiplying elements
        public static string operator *(ElementBuilder tag, int count)
        {
            return Multiply(tag,count);
        }

        private static string Multiply(ElementBuilder tag, int count)
        {
            string multiplied = "";
            for (int i = 0; i < count; i++)
            {
                multiplied += tag.ToString();
            }
            return multiplied;
            
        }

        //implement the ToString() method for printing elements to the console
        public override string ToString()
        {
            if (this.element == "a" || this.element == "img" || this.element == "input" )
            {
                return this.result += ">";
            }
           return this.result += String.Format(">{0}</{1}>", this.content, this.element);
        }
    }
}
