using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1_3
{
	class Node
	{
		List<Node> Children = new List<Node>();
		private string Text = "A";
		private string lang = "BCDEFGHIJKLMNOPQRSTUVWXYZ";
		public static int j = 0;
		private static int k = 0;
		private static int[] arr = new int[26];
		private static string tree;
		private Random rnd = new Random();
		private int rnd_num;
		private Node temp;
		public void create_Tree(Node node)
		{
			node.rnd_num = node.Text == "A" ? 3 : rnd.Next(0, 3);
			
			for (int i = 0; i < node.rnd_num; i++)
			{
				if(j >= 25) { break; }
				temp = new Node();
				temp.Text = Convert.ToString(lang[j]);
				j++;
				node.Children.Add(temp);
				create_Tree(temp);
			}
			return;
		}
		public string print_Tree(Node node)
		{
			tree += node.Text + '\n';
			for (int i = 0; i < node.Children.Count(); i++)
			{
				temp = node.Children[i];
				if(node.Children.Count() - (i + 1) <= 0)
				{
					arr[k] = 1;
				}
				else
				{
					arr[k] = 0;
				}
				for (int t = 0; t < k; t++)
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
					k++;
					print_Tree(temp);
					k--;
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
