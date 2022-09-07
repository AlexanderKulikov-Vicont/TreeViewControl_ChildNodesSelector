using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Grid;

namespace ChildNodesSelector
{
    public static class RND
    {
        private static Random rnd = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public static int Counter = 0;
        public static string GetNewString(int length)
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        public static int GetNewInt(int i1, int i2)
        {
            Counter++;
            return rnd.Next(i1, i2);
        }
    }

    public class CustomChildrenSelector : IChildNodesSelector
    {
        public IEnumerable SelectChildren(object item)
        {
            Console.WriteLine(item.GetType().ToString());
            if (item.GetType() == typeof(GeneralClass)) { return ((GeneralClass)item).Nodes; }
            else if (item.GetType() == typeof(NodeClass)) { return ((NodeClass)item).Nodes; }
            return null;
        }
    }

    public class GeneralClass
    {
        public string Name { get; set; } = "GeneralObj";
        public ObservableCollection<NodeClass> Nodes { get; set; } = new ObservableCollection<NodeClass>();


        public GeneralClass()
        {
            int cycles = RND.GetNewInt(1, 4);
            for (int i = 0; i < cycles; i++)
            {
                Nodes.Add(new NodeClass());
            }
        }
    }

    public class NodeClass
    {
        public string Name { get; set; } = "NodeObj";
        public ObservableCollection<NodeClass> Nodes { get; set; } = new ObservableCollection<NodeClass>();
        

        public NodeClass()
        {
            if (RND.Counter > 500) { return; }
            int cycles = RND.GetNewInt(1, 10);
            for (int i = 5; i < cycles; i++)
            {
                Nodes.Add(new NodeClass());
            }
        }
    }


}
