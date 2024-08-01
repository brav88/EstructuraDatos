using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatosEjemplo
{
	public class Ejemplos
	{
		public void Main()
		{
			Stack stack = new Stack();

			stack.Push("CocaCola", 1000);
			stack.Push("Pepsi", 800);
		}
	}

	public class Node
	{
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public Node Next { get; set; }

		public Node(string productName, decimal productPrice)
		{
			ProductName = productName;
			ProductPrice = productPrice;
		}
	}

	public class Stack
	{
		public Node Top { get; set; }
		public int counter { get; set; }

		public Stack()
		{
			Top = null;
			counter = 0;
		}

		public void Push(string productName, decimal productPrice)
		{
			Node node = new Node(productName, productPrice);

			node.Next = Top;
			Top = node;
			counter++;
		}
	}
}
