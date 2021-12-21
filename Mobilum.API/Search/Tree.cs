using Mobilum.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilum.API.Search
{
    public class Tree
    {
        private readonly Node _root;
        public static Tree Instace => new Tree();
        public bool DataIsLoaded { get; set; } = false;
        private Tree()
        {
            _root = new Node('^', 0, null);
        }
        public Node Prefix(string query)
        {
            var currentNode = _root;
            var result = currentNode;

            foreach (var c in query)
            {
                currentNode = currentNode.FindChildNode(c);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }
        public void InsertData(IEnumerable<Region> regions)
        {
            foreach (var region in regions)
            {
                Insert(region.Name, region.RegionCode);
            }
            DataIsLoaded = true;
        }
        private void Insert(string name, string regionCode)
        {
            var commonPrefix = Prefix(regionCode);
            var current = commonPrefix;

            for (var i = current.Depth; i < regionCode.Length; i++)
            {
                var newNode = new Node(regionCode[i], current.Depth + 1, current);
                current.Children.Add(newNode);
                current = newNode;
            }

            current.Children.Add(new Node('$', current.Depth + 1, current, name));

            var parentNode = current.Parent;
            while (parentNode.Value != '^')
            {
                if (parentNode.EndPathDepth > current.Depth + 1)
                {
                    parentNode.EndPathDepth = current.Depth + 1;
                }
                parentNode.Children = parentNode.Children.OrderByDescending(x => x.EndPathDepth).ToList();
                parentNode = parentNode.Parent;
            }
        }
    }
}
