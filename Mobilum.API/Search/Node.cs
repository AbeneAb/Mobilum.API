using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilum.API.Search
{
    public class Node
    {
        public Node(char value, int depth, Node parent, string name = null)
        {
            Value = value;
            Children = new List<Node>();
            Depth = depth;
            Parent = parent;
            Name = name;
        }

        public char Value { get; set; }
        public List<Node> Children { get; set; }
        public Node Parent { get; set; }

        public string Name { get; set; }
        public int EndPathDepth { get; set; } = int.MaxValue;
        public int Depth { get; set; }
        public Node FindChildNode(char c)
        {
            foreach (var child in Children)
                if (child.Value == c)
                    return child;

            return null;
        }

        public Node GetShortestPathEndNode()
        {
            var endNode = this;
            while (endNode.Children.Count > 0)
            {
                endNode = endNode.Children.FirstOrDefault();
            }
            return endNode;
        }
    }
}
