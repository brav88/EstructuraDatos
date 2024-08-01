using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos
{
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
}
