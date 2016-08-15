using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBTreeSimulator
{
    public class Node
    {
        public Node parent, leftChild, rightChild;
        public int value;
        public string color;
        public DrawNode Graph;

        public Node(int value)
        {
            this.parent = null;
            this.leftChild = null;
            this.rightChild = null;
            this.value = value;
            this.color = "R";
        }
    }
}
