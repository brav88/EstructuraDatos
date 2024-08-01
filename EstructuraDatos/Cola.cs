using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos
{
	public class IniciaCola
	{
		public void Main()
		{
			string opt = "";
			Cola cola = new Cola();

			do
			{
				Console.WriteLine("Que quiere hacer?");
				Console.WriteLine("1. Insertar en la Cola");
				Console.WriteLine("2. Quitar de la Cola");
				Console.WriteLine("3. Imprimir Cola");
				Console.WriteLine("4. Buscar en la Cola");
				Console.WriteLine("5. Eliminar de la Cola");

				opt = Console.ReadLine();

				if (opt == "1")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();
					Console.WriteLine("Digite el apellido");
					string lastName = Console.ReadLine();

					Persona persona = new Persona(name, lastName);

					cola.Encolar(persona);
				}

				if (opt == "2")
				{
					Persona desencolado = cola.Desencolar();

					Console.WriteLine("Desencolar hizo salir a: " + desencolado.Name + ' ' + desencolado.LastName);
				}

				if (opt == "3")
				{
					cola.Imprimir();
				}

				if (opt == "4")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();

					if (cola.Buscar(name))
					{
						Console.WriteLine("Nombre encontrado");
					}
					else
					{
						Console.WriteLine("No encontrado");
					}
				}

				if (opt == "5")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();

					if (cola.Eliminar(name))
					{
						Console.WriteLine("Persona eliminada");
					}
					else
					{
						Console.WriteLine("No encontrado");
					}
				}

			} while (opt != "99");
		}
	}

	class Cola
	{
		private Nodo frente;
		private Nodo final;
		private int contador = 0;

		public Cola()
		{
			frente = null;
			final = null;
		}

		public bool Buscar(string name)
		{
			if (frente == null)
			{
				throw new InvalidOperationException("La cola está vacía");
			}

			Nodo nodo = frente;

			while (nodo != null)
			{

				if (nodo.Persona.Name == name)
				{
					return true;
				}

				nodo = nodo.Siguiente;
			}

			return false;
		}

		public bool Eliminar(string name)
		{
			if (frente == null)
			{
				return false;
			}

			// Si el nodo a eliminar es el frente
			if (frente.Persona.Name == name)
			{
				Desencolar();
				return true;
			}

			Nodo nodo = frente;
			while (nodo.Siguiente != null && nodo.Siguiente.Persona.Name != name)
			{
				nodo = nodo.Siguiente;
			}

			if (nodo.Siguiente == null)
			{
				return false;
			}

			nodo.Siguiente = nodo.Siguiente.Siguiente;

			// Si el nodo a eliminar es el final
			if (nodo.Siguiente == null)
			{
				final = nodo;
			}

			contador--;
			return true;
		}

		public void Imprimir()
		{
			Nodo nodo = frente;
			if (nodo != null)
			{
				Console.WriteLine("*Frente: " + nodo.Persona.Name + ' ' + nodo.Persona.LastName);

				while (nodo.Siguiente != null)
				{
					nodo = nodo.Siguiente;

					if (nodo == final)
					{
						Console.WriteLine("*Final:" + nodo.Persona.Name + ' ' + nodo.Persona.LastName);
					}
					else
					{
						Console.WriteLine(nodo.Persona.Name + ' ' + nodo.Persona.LastName);
					}

				}
			}
			else
			{
				Console.WriteLine("La cola esta vacia");
			}
		}

		public void Encolar(Persona persona)
		{
			Nodo nuevoNodo = new Nodo(persona);

			if (final != null)
			{
				final.Siguiente = nuevoNodo;
			}
			final = nuevoNodo;
			if (frente == null)
			{
				frente = nuevoNodo;
			}
			contador++;
		}

		public Persona Desencolar()
		{
			if (frente == null)
			{
				throw new InvalidOperationException("La cola está vacía");
			}

			contador--;

			Persona personaFrente = frente.Persona;

			frente = frente.Siguiente;

			if (frente == null)
			{
				final = null;
			}

			return personaFrente;
		}

		public Persona VerFrente()
		{
			if (frente == null)
			{
				throw new InvalidOperationException("La cola está vacia");
			}

			return frente.Persona;
		}

		public Persona VerFinal()
		{
			if (final == null)
			{
				throw new InvalidOperationException("La cola está vacia");
			}

			return final.Persona;
		}

		public bool EstaVacia()
		{
			return frente == null;
		}

		public int Cantidad()
		{
			return contador;
		}
	}
}
