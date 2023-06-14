using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaiTap13062023
{
    internal class Program
    {
        public class Bakery
        {
            private List<BreadType> menu;

            public Bakery()
            {
                menu = new List<BreadType>();
            }
            public void AddToMenu(BreadType breadType)
            {
                menu.Add(breadType);
            }

            public void DisplayMenu()
            {
                Console.WriteLine("Menu:");
                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", (i + 1), menu[i].Name);
                }
            }

            public IBread TakeOrder()
            {
                Console.Write("Order: ");
                int order = Int32.Parse(Console.ReadLine());


                if (order <= 3 && order > 0)
                {
                    BreadFactory breadFactory;
                    int index = order - 1;

                    if (menu[index].Name == "Normal Bread")
                        breadFactory = new NormalBreadFactory();
                    else if (menu[index].Name == "Cheese Bread")
                        breadFactory = new CheeseBreadFactory();
                    else
                        breadFactory = new MeatBreadFactory();

                    return breadFactory.Make();
                }
                else
                {
                    Console.WriteLine("Menu doesn't have this item");
                    return null;
                }
            }
        }

        public class BreadType
        {
            public string Name { get; }

            public BreadType(string name)
            {
                Name = name;
            }

        }

        public interface IBread
        {
            void Make();
        }

        public class NormalBread : IBread
        {
            public void Make()
            {
                Console.WriteLine("Baking normal bread...\nDone!");
            }
        }

        public class CheeseBread : IBread
        {
            public void Make()
            {
                Console.WriteLine("Baking cheese bread...\nDone!");
            }
        }

        public class MeatBread : IBread
        {
            public void Make()
            {
                Console.WriteLine("Baking meat bread...\nDone!");
            }
        }

        public abstract class BreadFactory
        {
            private BreadType type { get; set; }

            public BreadFactory(BreadType type)
            {
                this.type = type;
            }

            public abstract IBread Make();

            public BreadType GetBread()
            {
                return type;
            }
        }

        public class NormalBreadFactory : BreadFactory
        {
            public NormalBreadFactory() : base(new BreadType("Normal Bread")) { }
            public override IBread Make()
            {
                IBread bread = new NormalBread();
                bread.Make();
                return bread;
            }
        }

        public class CheeseBreadFactory : BreadFactory
        {
            public CheeseBreadFactory() : base(new BreadType("Cheese Bread")) { }
            public override IBread Make()
            {
                IBread bread = new CheeseBread();
                bread.Make();
                return bread;
            }
        }

        public class MeatBreadFactory : BreadFactory
        {
            public MeatBreadFactory() : base(new BreadType("Meat Bread")) { }
            public override IBread Make()
            {
                IBread bread = new MeatBread();
                bread.Make();
                return bread;
            }
        }

        static void Main(string[] args)
        {
            Bakery bakery = new Bakery();

            bakery.AddToMenu(new BreadType("Normal Bread"));
            bakery.AddToMenu(new BreadType("Cheese Bread"));
            bakery.AddToMenu(new BreadType("Meat Bread"));

            bakery.DisplayMenu();
            bakery.TakeOrder();
        }
    }
}
