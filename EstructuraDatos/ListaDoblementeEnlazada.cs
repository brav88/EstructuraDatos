using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos
{
	public class IniciaListaDoblementeEnlazada
	{
		public void Main()
		{
			string opt = "";
			ListaDoblementeEnlazada lista = new ListaDoblementeEnlazada();

			do
			{
				Console.WriteLine("Que quiere hacer?");
				Console.WriteLine("1. Insertar en la Lista Doble");
				Console.WriteLine("2. Imprimir Lista Doble");
				Console.WriteLine("3. Imprimir Lista Doble Reversa");
				Console.WriteLine("4. Insertar Despues De");
				Console.WriteLine("5. Insertar Antes De");

				opt = Console.ReadLine();

				if (opt == "1")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();
					Console.WriteLine("Digite el apellido");
					string lastName = Console.ReadLine();

					Persona persona = new Persona(name, lastName);

					lista.Insertar(persona);

					Console.WriteLine("Dato encolado con exito");
				}

				if (opt == "2")
				{
					Console.WriteLine("Esta es la lista de datos de la Lista Doble:");
					lista.Imprimir();
				}

				if (opt == "3")
				{
					Console.WriteLine("Esta es la lista de datos de la Lista Doble en reversa:");
					lista.ImprimirReversa();
				}

				if (opt == "4")
				{
					Console.WriteLine("Digite el nombre nuevo");
					string name = Console.ReadLine();
					Console.WriteLine("Digite el apellido nuevo");
					string lastName = Console.ReadLine();

					Console.WriteLine("Digite el nombre actual");
					string name2 = Console.ReadLine();
					Console.WriteLine("Digite el apellido actual");
					string lastName2 = Console.ReadLine();

					Persona personaNueva = new Persona(name, lastName);
					Persona personaActual = new Persona(name2, lastName2);

					lista.InsertarDespuesDe(personaNueva, personaActual);

					Console.WriteLine("Dato encolado con exito");
				}

				if (opt == "14")
				{
					Console.WriteLine("Digite el nombre nuevo");
					string name = Console.ReadLine();
					Console.WriteLine("Digite el apellido nuevo");
					string lastName = Console.ReadLine();

					Console.WriteLine("Digite el nombre actual");
					string name2 = Console.ReadLine();
					Console.WriteLine("Digite el apellido actual");
					string lastName2 = Console.ReadLine();

					Persona personaNueva = new Persona(name, lastName);
					Persona personaActual = new Persona(name2, lastName2);

					lista.InsertarAntesDe(personaNueva, personaActual);

					Console.WriteLine("Dato encolado con exito");
				}


			} while (opt != "99");
		}
	}

	class ListaDoblementeEnlazada
	{
		private NodoLD cabeza;
		private NodoLD cola;

		private NodoNumeros inicio;
		private NodoNumeros fin;

		private int contador = 0;

		public ListaDoblementeEnlazada()
		{
			cabeza = null;
			cola = null;
		}

		public void OrdenarLista()
		{
			NodoNumeros actual = inicio;
			if (actual != null)
			{
				if (actual.Numero < actual.Siguiente.Numero)
				{
					actual.Siguiente.Anterior = actual.Siguiente;
					actual.Siguiente.Numero = actual.Numero;
					actual.Siguiente = actual;
					actual = actual.Siguiente.Anterior;
				}

			}
			else
			{
				Console.WriteLine("La lista está vacía");
			}
		}

		public void Insertar(Persona persona)
		{
			NodoLD nuevoNodo = new NodoLD(persona);

			if (cabeza == null)
			{
				cabeza = nuevoNodo;
				cola = nuevoNodo;
			}
			else
			{
				cola.Siguiente = nuevoNodo;
				nuevoNodo.Anterior = cola;
				cola = nuevoNodo;
			}
			contador++;
		}

		public void InsertarDespuesDe(Persona personaNueva, Persona personaActual)
		{
			NodoLD personaNuevaNodo = new NodoLD(personaNueva);
			NodoLD personaActualNodo = new NodoLD(personaActual);

			if (personaActualNodo.Persona.Name == cola.Persona.Name &&
				personaActualNodo.Persona.LastName == cola.Persona.LastName)
			{
				Insertar(personaNueva);

				return;
			}

			NodoLD actual = cabeza;
			if (actual != null)
			{
				do
				{
					if (actual.Persona.Name == personaActualNodo.Persona.Name &&
						actual.Persona.LastName == personaActualNodo.Persona.LastName)
					{
						actual.Siguiente.Anterior = personaNuevaNodo;
						personaNuevaNodo.Siguiente = actual.Siguiente;
						actual.Siguiente = personaNuevaNodo;
						personaNuevaNodo.Anterior = actual;

						contador++;

						return;
					}
					else
					{
						actual = actual.Siguiente;
					}
				} while (actual != null);
			}
			else
			{
				Insertar(personaNueva);
			}
		}

		public void InsertarAntesDe(Persona personaNueva, Persona personaActual)
		{
			NodoLD personaNuevaNodo = new NodoLD(personaNueva);
			NodoLD personaActualNodo = new NodoLD(personaActual);

			NodoLD actual = cabeza;
			if (actual != null)
			{
				do
				{
					if (actual.Siguiente.Persona.Name == personaActualNodo.Persona.Name &&
						actual.Siguiente.Persona.LastName == personaActualNodo.Persona.LastName)
					{
						InsertarDespuesDe(personaNueva, actual.Persona);

						return;
					}
					else
					{
						actual = actual.Siguiente;
					}
				} while (actual != null);
			}
			else
			{
				Insertar(personaNueva);
			}
		}

		public bool Buscar(string name)
		{
			NodoLD actual = cabeza;
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
				if (cabeza != null)
				{
					cabeza.Anterior = null;
				}
				else
				{
					cola = null;
				}
				contador--;
				return true;
			}

			NodoLD actual = cabeza;
			while (actual != null && actual.Persona.Name != name)
			{
				actual = actual.Siguiente;
			}

			if (actual == null)
			{
				return false;
			}

			if (actual.Siguiente != null)
			{
				actual.Siguiente.Anterior = actual.Anterior;
			}
			else
			{
				cola = actual.Anterior;
			}

			if (actual.Anterior != null)
			{
				actual.Anterior.Siguiente = actual.Siguiente;
			}

			contador--;
			return true;
		}

		public void Imprimir()
		{
			NodoLD actual = cabeza;
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

		public void ImprimirReversa()
		{
			NodoLD actual = cola;

			if (actual != null)
			{
				Console.WriteLine("*Cola: " + actual.Persona.Name + ' ' + actual.Persona.LastName);
				while (actual.Anterior != null)
				{
					actual = actual.Anterior;
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
