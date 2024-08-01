using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos
{
	public class IniciaListaEnlazada
	{
		public void Main()
		{
			string opt = "";
			ListaEnlazada lista = new ListaEnlazada();

			do
			{
				Console.WriteLine("Que quiere hacer?");
				Console.WriteLine("1. Insertar en la Lista");
				Console.WriteLine("2. Quitar de la Lista");
				Console.WriteLine("3. Imprimir Lista");
				Console.WriteLine("4. Buscar en la Lista");

				opt = Console.ReadLine();

				if (opt == "1")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();
					Console.WriteLine("Digite el apellido");
					string lastName = Console.ReadLine();

					Persona persona = new Persona(name, lastName);

					lista.Insertar(persona);
				}

				if (opt == "2")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();

					if (lista.Eliminar(name))
					{
						Console.WriteLine("Persona eliminada");
					}
					else
					{
						Console.WriteLine("No encontrado");
					}
				}

				if (opt == "3")
				{
					lista.Imprimir();
				}

				if (opt == "4")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();

					if (lista.Buscar(name))
					{
						Console.WriteLine("Nombre encontrado");
					}
					else
					{
						Console.WriteLine("No encontrado");
					}
				}

			} while (opt != "99");
		}
	}

	class ListaEnlazada
	{
		private Nodo cabeza;
		private int contador = 0;

		public ListaEnlazada()
		{
			cabeza = null;
		}

		public void Insertar(Persona persona)
		{
			Nodo nuevoNodo = new Nodo(persona);
			if (cabeza == null)
			{
				cabeza = nuevoNodo;
			}
			else
			{
				Nodo actual = cabeza;
				while (actual.Siguiente != null)
				{
					actual = actual.Siguiente;
				}
				actual.Siguiente = nuevoNodo;
			}
			contador++;
		}

		public bool Buscar(string name)
		{
			Nodo actual = cabeza;
			while (actual != null)
			{
				if (actual.Persona.Name == name)
				{
					return true;
				}
				actual = actual.Siguiente;
			}
			return false;
		}

		public bool Eliminar(string name)
		{
			if (cabeza == null)
			{
				return false;
			}

			if (cabeza.Persona.Name == name)
			{
				cabeza = cabeza.Siguiente;
				contador--;
				return true;
			}

			Nodo actual = cabeza;
			while (actual.Siguiente != null && actual.Siguiente.Persona.Name != name)
			{
				actual = actual.Siguiente;
			}

			if (actual.Siguiente == null)
			{
				return false;
			}

			actual.Siguiente = actual.Siguiente.Siguiente;
			contador--;
			return true;
		}

		public void Imprimir()
		{
			Nodo actual = cabeza;
			if (actual != null)
			{
				Console.WriteLine("*Cabeza: " + actual.Persona.Name + ' ' + actual.Persona.LastName);
				while (actual.Siguiente != null)
				{
					actual = actual.Siguiente;
					Console.WriteLine(actual.Persona.Name + ' ' + actual.Persona.LastName);
				}
			}
			else
			{
				Console.WriteLine("La lista está vacía");
			}
		}
	}
}
