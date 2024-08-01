using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos
{
	public class IniciaPila
	{
		public void Main()
		{
			string opt = "";
			Pila miPila = new Pila();

			do
			{
				Console.WriteLine("Que quiere hacer?");
				Console.WriteLine("1. Insertar en la Pila");
				Console.WriteLine("2. Quitar de la Pila");
				Console.WriteLine("3. Imprimir Pila");
				Console.WriteLine("4. Buscar en la Pila");

				opt = Console.ReadLine();

				if (opt == "1")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();
					Console.WriteLine("Digite el apellido");
					string lastName = Console.ReadLine();

					Persona persona = new Persona(name, lastName);

					miPila.Push(persona);
				}

				if (opt == "2")
				{
					Persona desenpilado = miPila.Pop();

					Console.WriteLine("Desenpilar hizo salir a: " + desenpilado.Name + ' ' + desenpilado.LastName);
				}

				if (opt == "3")
				{
					miPila.Imprimir();
				}

				if (opt == "4")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();

					if (miPila.Buscar(name))
					{
						Console.WriteLine("Dato encontrado");
					}
					else
					{
						Console.WriteLine("Dato NO encontrado");
					}
				}

			} while (opt != "99");
		}
	}

	class Pila
	{
		private Nodo cima;
		private int contador = 0;

		public Pila()
		{
			cima = null;
		}

		public void Imprimir()
		{
			if (EstaVacia())
			{
				Console.WriteLine("La pila esta vacia");
				return;
			}

			Nodo nodo = cima;
			Console.WriteLine("*Cima: " + nodo.Persona.Name + ' ' + nodo.Persona.LastName);

			while (nodo.Siguiente != null)
			{
				nodo = nodo.Siguiente;
				Console.WriteLine(nodo.Persona.Name + ' ' + nodo.Persona.LastName);
			}
		}

		public bool Buscar(string name)
		{
			if (EstaVacia())
			{
				Console.WriteLine("La pila esta vacia");
				
				return false;
			}

			Nodo nodo = cima;

			do
			{
				if (nodo.Persona.Name == name)
				{
					return true;
				}

				nodo = nodo.Siguiente;

			} while (nodo != null);

			return false;
		}

		public void Push(Persona persona)
		{
			Nodo nuevoNodo = new Nodo(persona);

			nuevoNodo.Siguiente = cima;
			cima = nuevoNodo;
			contador++;
		}

		public Persona Pop()
		{
			if (cima == null)
			{
				throw new InvalidOperationException("La pila está vacía");
			}

			contador--;

			Persona personaCima = cima.Persona;
			cima = cima.Siguiente;
			return personaCima;
		}

		public Persona Peek()
		{
			if (cima == null)
			{
				throw new InvalidOperationException("La pila está vacía");
			}

			return cima.Persona;
		}

		public bool EstaVacia()
		{
			return cima == null;
		}

		public int Cantidad()
		{
			return contador;
		}
	}
}
