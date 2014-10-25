using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTypeSystem_HW
{
    class StringDisperser : IEnumerable, ICloneable, IComparable
    {
        public string[] arguments {get; set;}

        public StringDisperser(params string[] args)
        {
            this.arguments = args;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var arg in arguments)
            {
                if (arg == null)
                {
                    break;
                }

                yield return arg;
            }
        }

        public override bool Equals(object obj)
        {
            StringDisperser secondDisperser = obj as StringDisperser;

            if (secondDisperser == null)
            {
                return false;
            }

            if (arguments.Equals(secondDisperser))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.arguments.GetHashCode();
        }

        public override string ToString()
        {
            string str = "";

            foreach (var st in arguments)
            {
                str += st + " ";
            }

            return str;
        }

        public object Clone()
        {
            string[] newTextArray = new string[this.arguments.Length];
            for (int i = 0; i < newTextArray.Length; i++)
            {
                newTextArray[i] = this.arguments[i];
            }

            return new StringDisperser(newTextArray);
        }

        public static bool operator ==(StringDisperser a, StringDisperser b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(StringDisperser a, StringDisperser b)
        {
            return !a.Equals(b);
        }

        public int CompareTo(object obj)
        {
            StringDisperser secondDisp = obj as StringDisperser;

            return ConcatenateString(new StringDisperser(arguments)).CompareTo(ConcatenateString(secondDisp));
        }

        public string ConcatenateString(StringDisperser inputStr)
        {
            string str = "";

            foreach (var st in inputStr)
            {
                str += st + " ";    
            }

            return str;
        }
    }

    class TestClass
    {
        static void Main()
        {
            StringDisperser disp = new StringDisperser("asd", "dsa", "aaa");

            StringDisperser secondDisp = (StringDisperser)disp.Clone();


        }
    }
}
