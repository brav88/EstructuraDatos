using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
	public class Motor
	{
		public int _cc { get; set; }

		public Motor(int cc) 
		{
			_cc = cc;
		}
	}

	public class Car
	{
		public Motor _motor;

		public int SerialNumber { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string Color { get; set; }

		public Car(Motor motor)
		{
			_motor = motor;
		}

		public string Accelerate()
		{
			return "Car is accelerating...";
		}
		
		public void Decelerate(string message)
		{
			Console.WriteLine(message);
		}
	}

	public class Manufacter
	{		
		public Car GetCar()
		{
			return new Car(new Motor(2000));
		}

		public void Main()
		{
			Car car1 = new Car(new Motor(2500));
			Car car2 = new Car(new Motor(3500));
			Car car3 = new Car(new Motor(1500));

			car1.Brand = "Honda";
			car2.Brand = "Toyota";

			Console.WriteLine(car1._motor);
			Console.WriteLine(car2._motor);

			car1.Decelerate("Desacelerar...");

			string resultado = car1.Accelerate();

			Console.WriteLine(car1.Brand + car1.Accelerate());
			car2.Accelerate();
			car3.Accelerate();
		}
	}

	public class CarTypes
	{
		public string Pretol = "";
		public string Electric = "";
	}

	
}
