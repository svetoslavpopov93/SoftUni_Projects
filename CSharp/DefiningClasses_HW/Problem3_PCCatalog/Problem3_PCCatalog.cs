using System;
using System.Collections.Generic;

namespace Problem3_PCCatalog
{
    class Computer
    {
        private string name;
        private Component[] components;

        public Computer(string name, Component[] components)
        {
            this.name = name;
            this.components = components;
        }

        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    throw new ArgumentNullException("Invalid input.");
                }
                else
                {
                    return this.name;
                }
            }
            set
            {
                name = value;
            }
        }

        public Component[] Components
        {
            get
            {
                if (this.components.Length == 0)
                {
                    throw new ArgumentException("Invalid input. The computer must have components.");
                }
                else
                {
                    return this.components;
                }
            }
            set
            {
                components = value; ;
            }
        }

        public double SumOfComponentPrices()
        {
            double total = 0;

            foreach (var comp in components)
            {
                total += comp.Price;
            }

            return total;
        }

        public override string ToString()
        {
            string str = string.Format("Name: {0}\r\nComponents:\r\n", this.name);

            foreach (var comp in components)
            {
                str += comp + "\r\n";
            }

            str += string.Format("Price: {0} BGN\r\n", SumOfComponentPrices());

            return str;
        }
    }

    class Component
    {
        private string name;
        private string details;
        private double price;

        public Component(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public Component(string name, string details, double price)
        {
            this.name = name;
            this.details = details;
            this.price = price;
        }

        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    throw new ArgumentNullException("Invalid input.");
                }
                else
                {
                    return this.name;
                }
            }
            set
            {
                name = value;
            }
        }

        public string Details
        {
            get
            {
                if (this.details == null)
                {
                    throw new ArgumentNullException("Invalid input.");
                }
                else
                {
                    return this.details;
                }
            }
            set
            {
                details = value;
            }
        }

        public double Price
        {
            get
            {
                if (this.price < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid input.");
                }
                else
                {
                    return this.price;
                }
            }
            set
            {
                price = value;
            }
        }

        public override string ToString()
        {
            if (this.details != null)
            {
                return string.Format("Name: {0}, Details:\"{1}\", Price: {2} BGN", this.name, this.details, this.price);
            }
            else
            {
                return string.Format("Name: {0}, Price: {1} BGN", this.name, this.price);
            }
        }
    }

    class Problem3_PCCatalog
    {
        static void Main()
        {
            Component ram = new Component("Ram", "ddr3", 40);
            Component cpu = new Component("CPU", "554mHz", 240);
            Component cable = new Component("Cable", 5);

            Computer myPc = new Computer("Snejeto", new Component[]{ram, cpu, cable});
            Console.WriteLine(myPc);
        }
    }
}
