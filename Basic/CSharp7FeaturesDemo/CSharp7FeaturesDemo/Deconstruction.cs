using System;

namespace CSharp7FeaturesDemo
{
    internal class Deconstruction
    {
        internal void Run()
        {
            var (myGas, myMileage, myName) = new Car(50, 100, "Ferrari");

            Console.WriteLine($"myGas: {myGas}");
            Console.WriteLine($"myMileage: {myMileage}");
            Console.WriteLine($"myName: {myName}");

            var (yourGas, yourMileage, yourName) = new Car(100, 200, "Lamborghini");

            Console.WriteLine($"yourGas: {yourGas}");
            Console.WriteLine($"yourMileage: {yourMileage}");
            Console.WriteLine($"yourName: {yourName}");

        }

        public class Car
        {
            private int _gas { get; set; }
            private int _mileage { get; set; }
            private string _name { get; set; }

            public Car(int Gas, int Mileage, string Name)
            {
                this._gas = Gas;
                this._mileage = Mileage;
                this._name = Name;
            }

            public void Deconstruct(out int Gas, out int Mileage, out string Name)
            {
                Gas = this._gas;
                Mileage = this._mileage;
                Name = this._name;
            }
        }
    }
}