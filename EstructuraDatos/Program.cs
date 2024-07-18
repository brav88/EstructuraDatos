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
			Cola miCola = new Cola();			
			Pila miPila = new Pila();
			ListaEnlazada miLista = new ListaEnlazada();
			ListaDoblementeEnlazada listaDoblementeEnlazada = new ListaDoblementeEnlazada();

			do
			{
				Console.WriteLine("Que quiere hacer?");
				Console.WriteLine("1. Encolar");
				Console.WriteLine("2. Imprimir cola");
				Console.WriteLine("3. Desencolar");
				Console.WriteLine("4. Buscar");
				Console.WriteLine("5. Eliminar");
				Console.WriteLine("6. Imprimir Pila");
				Console.WriteLine("7. Desenpilar");
				Console.WriteLine("8. Enlistar");
				Console.WriteLine("9. Imprimir Lista");
				Console.WriteLine("10. Encolar Lista Doble");
				Console.WriteLine("11. Imprimir Lista Doble");
				Console.WriteLine("12. Imprimir Lista Doble Reversa");
				Console.WriteLine("13. Encolar despues de");
				Console.WriteLine("14. Encolar antes de");
				Console.WriteLine("99. Salir");

				opt = Console.ReadLine();

				if (opt == "1")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();
					Console.WriteLine("Digite el apellido");
					string lastName = Console.ReadLine();

					Persona persona = new Persona(name, lastName);

					miCola.Encolar(persona);

					Console.WriteLine("Dato encolado con exito");
				}

				if (opt == "2")
				{
					Console.WriteLine("Esta es la lista de datos de la Cola:");
					miCola.Imprimir();
				}

				if (opt == "3")
				{
					Persona desencolado = miCola.Desencolar();

					miPila.Push(desencolado);

					Console.WriteLine("Desencolar hizo salir a: " + desencolado.Name +' '+ desencolado.LastName);
				}

				if (opt == "4")
				{
					Console.WriteLine("Digite el nombre que busca");
					string name = Console.ReadLine();
					Console.WriteLine("Resultado: " + miCola.Buscar(name));
				}

				if (opt == "5")
				{
					Console.WriteLine("Digite el nombre que desea eliminar");
					string name = Console.ReadLine();
					bool eliminado = miCola.Eliminar(name);
					if (eliminado)
					{
						Console.WriteLine("Elemento eliminado con éxito");
					}
					else
					{
						Console.WriteLine("Elemento no encontrado");
					}
				}

				if (opt == "6")
				{
					Console.WriteLine("Esta es la lista de datos de la Pila:");
					miPila.Imprimir();
				}

				if (opt == "7")
				{
					Persona desenpilado = miPila.Pop();

					miCola.Encolar(desenpilado);

					Console.WriteLine("Desenpilar hizo salir a: " + desenpilado.Name + ' ' + desenpilado.LastName);
				}

				if (opt == "8")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();
					Console.WriteLine("Digite el apellido");
					string lastName = Console.ReadLine();

					Persona persona = new Persona(name, lastName);

					miLista.Insertar(persona);
					
					Console.WriteLine("Dato encolado con exito");
				}

				if (opt == "9")
				{
					Console.WriteLine("Esta es la lista de datos de la Lista Simple:");
					miLista.Imprimir();
				}

				if (opt == "10")
				{
					Console.WriteLine("Digite el nombre");
					string name = Console.ReadLine();
					Console.WriteLine("Digite el apellido");
					string lastName = Console.ReadLine();

					Persona persona = new Persona(name, lastName);

					listaDoblementeEnlazada.Insertar(persona);				

					Console.WriteLine("Dato encolado con exito");
				}

				if (opt == "11")
				{
					Console.WriteLine("Esta es la lista de datos de la Lista Doble:");
					listaDoblementeEnlazada.Imprimir();
				}

				if (opt == "12")
				{
					Console.WriteLine("Esta es la lista de datos de la Lista Doble en reversa:");
					listaDoblementeEnlazada.ImprimirReversa();
				}

				if (opt == "13")
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

					listaDoblementeEnlazada.InsertarDespuesDe(personaNueva, personaActual);

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

					listaDoblementeEnlazada.InsertarAntesDe(personaNueva, personaActual);

					Console.WriteLine("Dato encolado con exito");
				}

			} while (opt != "99");

			Console.WriteLine("Sesion finalizada");
		}
	}

	class Persona
	{
		public string Name;
		public string LastName;

		public Persona(string name, string lastName)
		{
			Name = name;
			LastName = lastName;
		}
	}

	class Nodo
	{
		public Persona Persona;
		public Nodo Siguiente;

		public Nodo(Persona persona)
		{
			Persona = persona;
		}
	}

	class NodoLD
	{		
		public Persona Persona;
		public NodoLD Siguiente;
		public NodoLD Anterior;

		public NodoLD(Persona persona)
		{
			Persona = persona;
		}
	}

	class NodoNumeros
	{
		public int Numero;
		public NodoNumeros Siguiente;
		public NodoNumeros Anterior;

		public NodoNumeros(int numero)
		{
			Numero = numero;
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
