using System;

namespace Problem2_LaptopShop
{
    class Battery
    {
        private string batteryName;
        private double batteryLife;

        public Battery(string batteryName, double batteryLife)
        {
            this.batteryName = batteryName;
            this.batteryLife = batteryLife;
        }

        public string Name
        {
            get
            {
                if (this.batteryName == null)
                {
                    throw new NullReferenceException("Invalid Battery Name.");
                }
                else
                {
                    return this.batteryName;
                }
            }
            set
            {
                batteryName = value;
            }
        }

        public double Life 
        { 
            get
            {
                if (this.batteryLife < 0)
                {
                    throw new ArgumentOutOfRangeException("The Battery Life value must be greater than ZERO.");
                }
                else
                {
                    return batteryLife;
                }
            }

            set
            {
                batteryLife = value;
            }
        }

    }

    //model, manufacturer, processor, RAM, graphics card, HDD, screen, battery, battery life in hours and price.
    class Laptop
    {
        private string model;
        private double price;
        private string manufacturer;
        private string processor;
        private string ram;
        private string graphics;
        private string hdd;
        private string screen;
        private Battery battery;

        public Laptop(string model, double price)
        {
            this.model = model;
            this.price = price;
        }//
        public Laptop(string model, double price, string manufacturer)
        {
            this.model = model;
            this.price = price;
            this.manufacturer = manufacturer;
        }//
        public Laptop(string model, double price, string manufacturer, string processor, string ram, string graphics, string hdd, string screen)
        {
            this.model = model;
            this.price = price;
            this.manufacturer = manufacturer;
            this.processor = processor;
            this.ram = ram;
            this.graphics = graphics;
            this.hdd = hdd;
            this.screen = screen;
        }
        public Laptop(string model, double price, string manufacturer, string processor, string ram, string graphics, string hdd, string screen, Battery battery)
        {
            this.model = model;
            this.price = price;
            this.manufacturer = manufacturer;
            this.processor = processor;
            this.ram = ram;
            this.graphics = graphics;
            this.hdd = hdd;
            this.screen = screen;
            this.battery = battery;
        }

        public string Model
        {
            get
            {
                if (this.model == null)
                {
                    throw new NullReferenceException("Model could not be null.");
                }
                else
                {
                    return this.model;
                }
            }
            set
            {
                model = value;
            }
        }
        public double Price
        {
            get
            {
                if (this.price < 0)
                {
                    throw new ArgumentOutOfRangeException("Price must be greater than ZERO.");
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
        public string Manufacturer
        {
            get
            {
                if (this.manufacturer == null)
                {
                    throw new NullReferenceException("Manufacturer could not be null.");
                }
                else
                {
                    return this.manufacturer;
                }
            }
            set
            {
                manufacturer = value;
            }
        }
        public string Processor
        {
            get
            {
                if (this.processor == null)
                {
                    throw new NullReferenceException("Processor could not be null.");
                }
                else
                {
                    return this.processor;
                }
            }
            set
            {
                processor = value;
            }
        }
        public string Ram
        {
            get
            {
                if (this.ram == null)
                {
                    throw new NullReferenceException("Ram could not be null.");
                }
                else
                {
                    return this.ram;
                }
            }
            set
            {
                ram = value;
            }
        }
        public string Graphics
        {
            get
            {
                if (this.graphics == null)
                {
                    throw new NullReferenceException("Graphics could not be null.");
                }
                else
                {
                    return this.graphics;
                }
            }
            set
            {
                graphics = value;
            }
        }
        public string Hdd
        {
            get
            {
                if (this.hdd == null)
                {
                    throw new NullReferenceException("HDD could not be null.");
                }
                else
                {
                    return this.hdd;
                }
            }
            set
            {
                hdd = value;
            }
        }
        public string Screen
        {
            get
            {
                if (this.screen == null)
                {
                    throw new NullReferenceException("Screen could not be null.");
                }
                else
                {
                    return this.screen;
                }
            }
            set
            {
                screen = value;
            }
        }
        public Battery Battery
        {
            get
            {
                if (this.battery.Name == null)
                {
                    throw new NullReferenceException("Battery could not be null.");
                }
                else if (this.battery.Life < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery life must be greater than ZERO.");
                }
                else
                {
                    return this.battery;
                }
            }
            set
            {
                battery = value;
            }
        }

        public override string ToString()
        {
            if (this.manufacturer == null)
            {
                return string.Format("Model: {0}\r\nPrice: {1} leva.", this.model, this.price);
            }

            else if(this.manufacturer != null && this.processor == null)
            {
                return string.Format("Model: {0}\r\nPrice: {1} leva\r\nManufacturer: {2}.", this.model, this.price, this.manufacturer);
            }

            else if (this.processor != null && battery.Name == null)
            {
                return string.Format("Model: {0}\r\nPrice: {1} leva\r\nManufacturer: {2}\r\nProcessor: {3}\r\nRam: {4}\r\nGraphics: {5}\r\nHdd: {6}\r\nScreen: {7}.", this.model, this.price, this.manufacturer, this.processor, this.ram, this.graphics, this.hdd, this.screen);
            }

            else
            {
                return string.Format("Model: {0}\r\nPrice: {1}leva\r\nManufacturer: {2}\r\nProcessor: {3}\r\nRam: {4}\r\nGraphics: {5}\r\nHdd: {6}\r\nScreen: {7}\r\nBattery Model: {8}\r\nBattery Life: {9} hrs.", this.model, this.price, this.manufacturer, this.processor, this.ram, this.graphics, this.hdd, this.screen, this.battery.Name, this.battery.Life);
            }
        }
    }

    class Problem2_LaptopShop
    {
        static void Main()
        {
            Battery myLaptopsBattery = new Battery("Li-Ion, 4-cells, 2550 mAh", 4.5);
            Laptop myLaptop = new Laptop("Acer Aspire", 799, "Acer", "Intel Core i5", "8gb", "Intel HD Graphics", "500GB SSD", "13.3 (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display", myLaptopsBattery);

            Console.WriteLine(myLaptop);
        }
    }
}
