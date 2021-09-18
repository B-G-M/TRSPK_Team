using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_3
{
	class Node
	{
		private List<Node> Children = new List<Node>();
		private string Text = "A";
		private string lang = "BCDEFGHIJKLMNOPQRSTUVWXYZ";
		private static int counter = 0;
		private static int deep = 0;
		private static int[] arr = new int[26];
		private static string tree;
		private Random rnd = new Random();
		private int rnd_num;
		private Node temp;
		public void Create_Tree(Node node)
		{
			node.rnd_num = node.Text == "A" ? 3 : rnd.Next(0, 3);
			
			for (int i = 0; i < node.rnd_num; i++)
			{
				if(counter >= 25) { break; }
				temp = new Node();
				temp.Text = Convert.ToString(lang[counter]);
				counter++;
				node.Children.Add(temp);
				Create_Tree(temp);
			}
			return;
		}
		public string Сreate_string (Node node)
		{
			tree += node.Text + '\n';
			for (int i = 0; i < node.Children.Count(); i++)
			{
				temp = node.Children[i];
				if(node.Children.Count() - (i + 1) <= 0)
				{
					arr[deep] = 1;
				}
				else
				{
					arr[deep] = 0;
				}
				for (int t = 0; t < deep; t++)
				{
					if (arr[t] != 1)
					{
						tree += "│ ";
					}
					else
					{
						tree += "  ";
					}
				}
				if (node.Children.Count() != 0)
				{
					if (node.Children.Last() == temp)
					{
						tree += "└─";
					}
					else
					{
						tree += "├─";
					}
					deep++;
					Сreate_string (temp);
					deep--;
				}
				else
				{
					tree += "└─";
					tree += node.Text + '\n';
					Console.WriteLine(tree);
				}
				
			}
			return tree;
		}
	}
}
