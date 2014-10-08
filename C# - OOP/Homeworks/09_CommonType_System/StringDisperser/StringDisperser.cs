using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable
    {
        private string[] words;

        public StringDisperser(params string[] words)
        {
            this.Words = words;
        }

        public string[] Words 
        {
            get { return this.words; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Parameters can not be null.");
                }
                if (value.Length == 0)
                {
                    throw new ArgumentException("You should have at least one parameter in the constructor");
                }
                foreach (var word in value)
                {
                    if (string.IsNullOrEmpty(word))
                    {
                        throw new ArgumentException("Parameters can not be empty strings.");
                    }
                }
                this.words = value;
            }
        }

        public override bool Equals(object obj)
        {
            StringDisperser other = obj as StringDisperser;
            if (other == null)
            {
                return false;
            }
            if (this.words.Length != other.words.Length)
            {
                return false;
            }
            for (int i = 0; i < this.words.Length; i++)
            {
                if (this.words[i] != other.words[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
           return string.Join(" ", this.words);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (var word in this.words)
            {
                hashCode ^= word.GetHashCode();
            }
            return hashCode;
        }

        public static bool operator == (StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            return StringDisperser.Equals(firstDisperser, secondDisperser);
        }

        public static bool operator !=(StringDisperser firstDisperser, StringDisperser secondDisperser)
        {
            return !StringDisperser.Equals(firstDisperser, secondDisperser);
        }

        public object Clone()
        {
            string[] wordsClone = new string[this.words.Length];
            for (int i = 0; i < this.words.Length; i++)
            {
                string currentWord = this.words[i];
                wordsClone[i] = currentWord;
            }

            StringDisperser dispersrerClone = new StringDisperser(wordsClone);

            return dispersrerClone as StringDisperser;
        }

        public int CompareTo(StringDisperser other)
        {
            if (this.ToString() != other.ToString())
            {
                return this.ToString().CompareTo(other.ToString());
            }
            return 0;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var word in this.words)
            {
                foreach (var letter in word)
                {
                    yield return letter;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
