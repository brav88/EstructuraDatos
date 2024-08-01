using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos
{
	internal class Program
	{
		static void Main(string[] args)
		{				
			string opt = "";
			
			do
			{
				Console.WriteLine("Que quiere hacer?");
				Console.WriteLine("1. Menu Pilas");
				Console.WriteLine("2. Menu Colas");
				Console.WriteLine("3. Menu Listas Enlazadas");
				Console.WriteLine("4. Menu Listas Doblemente Enlazadas");
				Console.WriteLine("5. Menu Arboles");

				opt = Console.ReadLine();

				if (opt == "1")
				{
					IniciaPila pila = new IniciaPila();
					pila.Main();
				}

				if (opt == "2")
				{
					IniciaCola cola = new IniciaCola();
					cola.Main();
				}

				if (opt == "3")
				{
					IniciaListaEnlazada lista = new IniciaListaEnlazada();
					lista.Main();
				}

				if (opt == "4")
				{
					IniciaListaDoblementeEnlazada lista = new IniciaListaDoblementeEnlazada();
					lista.Main();					
				}

				if (opt == "5")
				{
					IniciaArbolBinario arbolBinario = new IniciaArbolBinario();
					arbolBinario.Main();
				}
				
			} while (opt != "99");

			Console.WriteLine("Sesion finalizada");
		}
	}
}

