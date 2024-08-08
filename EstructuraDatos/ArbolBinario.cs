using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos
{
	public class IniciaArbolBinario
	{
		public void Main()
		{
			ArbolBinario miArbol = new ArbolBinario();
			ArbolBinario miArbol2 = new ArbolBinario();
			string opt = "";

			do
			{
				Console.WriteLine("Que quiere hacer con los Arboles?");
				Console.WriteLine("1. Crear un arbol segun cantidad de nodos");
				Console.WriteLine("2. Verificar si 2 arboles son iguales");
				
				opt = Console.ReadLine();

				if (opt == "1")
				{
					Console.WriteLine("Cuantos nodos desea en el arbol?");
					int cantidadNodos = Convert.ToInt16(Console.ReadLine());

					for (int i = 1; i <= cantidadNodos; i++)
					{
						Console.WriteLine("Digite el numero del nodo " + i);
						int nodo = Convert.ToInt16(Console.ReadLine());
						miArbol.Insertar(nodo);
					}
				}

				if (opt == "2")
				{
					Console.WriteLine("Cuantos nodos desea en el arbol 1 ?");
					int cantidadNodos1 = Convert.ToInt16(Console.ReadLine());

					for (int i = 1; i <= cantidadNodos1; i++)
					{
						Console.WriteLine("Digite el numero del nodo " + i + " del Arbol 1");
						int nodo = Convert.ToInt16(Console.ReadLine());
						miArbol.Insertar(nodo);
					}

					Console.WriteLine("Cuantos nodos desea en el arbol 2 ?");
					int cantidadNodos2 = Convert.ToInt16(Console.ReadLine());

					for (int i = 1; i <= cantidadNodos2; i++)
					{
						Console.WriteLine("Digite el numero del nodo " + i + " del Arbol 2");
						int nodo = Convert.ToInt16(Console.ReadLine());
						miArbol2.Insertar(nodo);
					}				
				}

				//miArbol.DibujarArbolBinario(miArbol.raiz);
				//miArbol2.DibujarArbolDirectorio(miArbol2.raiz);

				Console.WriteLine("Resultado");
				miArbol.CompararArboles2(miArbol, miArbol2);

				//int altura = miArbol.ObtenerAltura(miArbol.raiz);
				//Console.WriteLine("La altura del árbol es: " + altura);

				//Console.WriteLine("Impresion INORDEN");
				//miArbol.MostrarInOrden();

				//int suma = miArbol.ObtenerSumaTotal();
				//Console.WriteLine("La suma del árbol es: " + suma);

			} while (opt != "99");
		}
	}

	public class NodoArbol
	{
		public int Valor;
		public NodoArbol Izquierdo;
		public NodoArbol Derecho;

		public NodoArbol(int valor)
		{
			Valor = valor;
			Izquierdo = null;
			Derecho = null;
		}
	}

	public class ArbolBinario
	{
		public NodoArbol raiz;
		int sumaTotalFinal = 0;
		List<int> lista;

		public ArbolBinario()
		{
			raiz = null;
			lista = new List<int>();
		}

		public bool CompararArboles(ArbolBinario arbol1, ArbolBinario arbol2)
		{
			arbol1.MostrarInOrden();
			arbol2.MostrarInOrden();
			
			if (arbol1.lista.Count != arbol2.lista.Count)
			{
				Console.WriteLine("Arboles NO Iguales");
				return false;
			}

			for (int i = 0; i < arbol1.lista.Count; i++)
			{
				if (arbol1.lista[i] != arbol2.lista[i])
				{
					Console.WriteLine("Arboles NO Iguales");
					return false;
				}
			}

			Console.WriteLine("Arboles Iguales");
			return true;
		}

		public bool CompararArboles2(ArbolBinario arbol1, ArbolBinario arbol2)
		{
			arbol1.MostrarInOrden();
			arbol2.MostrarInOrden();

			if ((arbol1.lista.Count != arbol2.lista.Count) || (arbol1.ObtenerSumaTotal() != arbol2.ObtenerSumaTotal()))
			{
				Console.WriteLine("Arboles NO Iguales");
				return false;
			}

			Console.WriteLine("Arboles Iguales");
			return true;
		}

		public int ObtenerAltura(NodoArbol nodo)
		{
			if (nodo == null)
			{
				return -1; // Si el nodo es null, la altura es -1 (árbol vacío)
			}

			int alturaIzquierda = ObtenerAltura(nodo.Izquierdo);
			int alturaDerecha = ObtenerAltura(nodo.Derecho);

			return Math.Max(alturaIzquierda, alturaDerecha) + 1;
		}

		public void Insertar(int valor)
		{
			NodoArbol nuevoNodo = new NodoArbol(valor);
			if (raiz == null)
			{
				raiz = nuevoNodo;
			}
			else
			{
				InsertarRecursivo(raiz, nuevoNodo);
			}
		}

		public int ObtenerSumaTotal()
		{
			sumaTotalFinal = 0;

			int sumaDerecha = SumaTotal(raiz.Derecho);
			int sumaIzquierda = SumaTotal(raiz.Izquierdo);

			return sumaDerecha + sumaIzquierda + raiz.Valor;		
		}

		public int SumaTotal(NodoArbol nodo)
		{

			if (nodo != null)
			{
				sumaTotalFinal = nodo.Valor + SumaTotal(nodo.Derecho);
				sumaTotalFinal = sumaTotalFinal + SumaTotal(nodo.Izquierdo);
			}
			else
			{
				return 0;
			}

			return sumaTotalFinal;
		}

		private void InsertarRecursivo(NodoArbol actual, NodoArbol nuevoNodo)
		{
			if (nuevoNodo.Valor < actual.Valor)
			{
				if (actual.Izquierdo == null)
				{
					actual.Izquierdo = nuevoNodo;
				}
				else
				{
					InsertarRecursivo(actual.Izquierdo, nuevoNodo);
				}
			}
			else
			{
				if (actual.Derecho == null)
				{
					actual.Derecho = nuevoNodo;
				}
				else
				{
					InsertarRecursivo(actual.Derecho, nuevoNodo);
				}
			}
		}

		public NodoArbol Buscar(int valor)
		{
			return BuscarRecursivo(raiz, valor);
		}

		private NodoArbol BuscarRecursivo(NodoArbol actual, int valor)
		{
			if (actual == null || actual.Valor == valor)
			{
				return actual;
			}

			if (valor < actual.Valor)
			{
				return BuscarRecursivo(actual.Izquierdo, valor);
			}
			else
			{
				return BuscarRecursivo(actual.Derecho, valor);
			}
		}

		public void MostrarInOrden()
		{
			MostrarInOrdenRecursivo(raiz);
			Console.WriteLine();
		}

		private void MostrarInOrdenRecursivo(NodoArbol actual)
		{
			if (actual != null)
			{
				MostrarInOrdenRecursivo(actual.Izquierdo);
				Console.Write(actual.Valor + " ");
				lista.Add(actual.Valor);
				MostrarInOrdenRecursivo(actual.Derecho);
			}
		}

		public void DibujarArbolBinario(NodoArbol node, int space = 0, int level = 0, int maxLevel = 5)
		{
			if (node == null || level == maxLevel)
				return;

			space += 10;

			DibujarArbolBinario(node.Derecho, space, level + 1, maxLevel);

			Console.WriteLine();
			for (int i = 10; i < space; i++)
				Console.Write(" ");
			Console.WriteLine(node.Valor);

			DibujarArbolBinario(node.Izquierdo, space, level + 1, maxLevel);
		}

		public void DibujarArbolDirectorio(NodoArbol node, string indent = "", bool last = true)
		{
			if (node == null) return;

			Console.Write(indent);
			if (last)
			{
				Console.Write("└─");
				indent += "  ";
			}
			else
			{
				Console.Write("├─");
				indent += "| ";
			}

			Console.WriteLine(node.Valor);

			DibujarArbolDirectorio(node.Izquierdo, indent, false);
			DibujarArbolDirectorio(node.Derecho, indent, true);
		}
	}
}
