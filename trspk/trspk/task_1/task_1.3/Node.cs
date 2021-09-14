using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_3
{
	class Node
	{
		public Node(string Text)
		{
			this.Text = Text;
		}
		List<Node> Children;
		private Node temp;
		private string Text;
		public void add_Children(string Text)
		{
			Children.Add(new Node(Text));
		}
		public void Create_Children(Node node)
		{
			for (int i = 0;; i++)
			{
				Console.WriteLine("Для окончания ввода введите: end");
				Console.Write("Введите строку: ");
				Text = Console.ReadLine();
				add_Children(Text);
				if (Text == "end") { return; }
				else { add_Children(Text); };
			}

		}
	}
}
