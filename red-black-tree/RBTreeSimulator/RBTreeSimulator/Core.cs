using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RBTreeSimulator
{
    public class Core
    {
        public static void AddNode(int number, ref Node root)
        {
            if (root == null)
            {
                root = new Node(number);
                root.color = "B";
            }
            else
            {
                Node currentNode = root;
                while (true)
                {
                    if (number > currentNode.value)
                    {
                        if (currentNode.rightChild == null)
                        {
                            Node newNode = new Node(number);
                            newNode.parent = currentNode;
                            currentNode.rightChild = newNode;
                            RBInsertFixup(newNode, ref root);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.rightChild;
                        }
                    }
                    else if (number < currentNode.value)
                    {
                        if (currentNode.leftChild == null)
                        {
                            Node newNode = new Node(number);
                            newNode.parent = currentNode;
                            currentNode.leftChild = newNode;
                            RBInsertFixup(newNode, ref root);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.leftChild;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Number " + number + " is already in the tree!");
                        break;
                    }
                }
            }
        }

        public static void DeleteNode(int number, ref Node root)
        {
            Node currentNode = root;
            if (root != null)
            {
                while (true)
                {
                    if (number > currentNode.value)
                    {
                        if (currentNode.rightChild == null)
                        {
                            MessageBox.Show("Number " + number.ToString() + " is not in the tree!");
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.rightChild;
                        }
                    }
                    else if (number < currentNode.value)
                    {
                        if (currentNode.leftChild == null)
                        {
                            MessageBox.Show("Number " + number.ToString() + " is not in the tree!");
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.leftChild;
                        }
                    }
                    else
                    {
                        Node NodeToDelete = currentNode;
                        Node X;
                        Node N;

                        if (NodeToDelete.leftChild != null)
                        {
                            X = NodeToDelete.leftChild;
                            if (X.rightChild != null)
                            {
                                while (true)
                                {
                                    if (X.rightChild != null)
                                    {
                                        X = X.rightChild;
                                    }
                                    else
                                        break;
                                }
                                NodeToDelete.value = X.value;
                                X.parent.rightChild = X.leftChild;
                                if (X.leftChild != null)
                                {
                                    X.leftChild.parent = X.parent;
                                    N = X.leftChild;
                                }
                                else
                                {
                                    N = new Node(-1); //sentinel
                                    N.color = "BB";
                                    N.parent = X.parent;
                                }
                                if (X.color == "B")
                                {
                                    if (N != null && N.color == "R")
                                    {
                                        N.color = "B";
                                    }
                                    else
                                    {
                                        N.color = "BB";
                                        RBDeleteFixup(N, ref root);
                                    }
                                }

                            }
                            else
                            {
                                NodeToDelete.value = X.value;
                                NodeToDelete.leftChild = X.leftChild;
                                if (X.leftChild != null)
                                {
                                    X.leftChild.parent = NodeToDelete;
                                    N = X.leftChild;
                                }
                                else
                                {
                                    N = new Node(-1); //sentinel
                                    N.color = "BB";
                                    N.parent = NodeToDelete;
                                }
                                if (X.color == "B")
                                {
                                    if (N != null && N.color == "R")
                                    {
                                        N.color = "B";
                                    }
                                    else
                                    {
                                        N.color = "BB";
                                        RBDeleteFixup(N, ref root);
                                    }
                                }
                            }
                        }
                        else if (NodeToDelete.rightChild != null)
                        {
                            X = NodeToDelete.rightChild;
                            NodeToDelete.value = X.value;
                            NodeToDelete.rightChild = X.rightChild;
                            if (X.rightChild != null)
                            {
                                X.rightChild.parent = NodeToDelete;
                                N = X.rightChild;
                            }
                            else
                            {
                                N = new Node(-1); //sentinel
                                N.color = "BB";
                                N.parent = NodeToDelete;
                            }
                            NodeToDelete.leftChild = X.leftChild;
                            if (X.leftChild != null)
                            {
                                X.leftChild.parent = NodeToDelete;
                            }

                            if (X.color == "B")
                            {
                                if (N != null && N.color == "R")
                                {
                                    N.color = "B";
                                }
                                else
                                {
                                    N.color = "BB";
                                    RBDeleteFixup(N, ref root);
                                }
                            }
                        }
                        else
                        {
                            if (NodeToDelete == root)
                            {
                                root = null;
                            }
                            else
                            {
                                if (NodeToDelete.parent.leftChild != null && NodeToDelete.parent.leftChild.value == NodeToDelete.value)
                                {
                                    NodeToDelete.parent.leftChild = null;
                                    if (NodeToDelete.color == "B")
                                    {
                                        N = new Node(-1); //sentinel
                                        N.color = "BB";
                                        N.parent = NodeToDelete.parent;
                                        RBDeleteFixup(N, ref root);
                                    }
                                }
                                else
                                {
                                    NodeToDelete.parent.rightChild = null;
                                    if (NodeToDelete.color == "B")
                                    {
                                        N = new Node(-1); //sentinel
                                        N.color = "BB";
                                        N.parent = NodeToDelete.parent;
                                        RBDeleteFixup(N, ref root);
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Number " + number.ToString() + " is not in the tree!");
            }
        }

        public static void RBInsertFixup(Node node, ref Node root)
        {
            if (node.parent == null)
            {
                node.color = "B";
                root = node;
            }
            else
            {
                if (node.parent.color == "R")
                {
                    if (node.parent.parent.rightChild != null && node.parent.value == node.parent.parent.rightChild.value)
                    {
                        if (node.parent.parent.leftChild != null && node.parent.parent.leftChild.color == "R")
                        {
                            node.parent.color = "B";
                            node.parent.parent.leftChild.color = "B";
                            node.parent.parent.color = "R";
                            RBInsertFixup(node.parent.parent, ref root);
                        }
                        else
                        {
                            Node G = node.parent.parent;
                            if (node.parent.leftChild != null && node.value == node.parent.leftChild.value)
                            {
                                RightRotation(node, node.parent, G);
                            }
                            Node P = G.rightChild;
                            Node N = P.rightChild;
                            Node GGP = G.parent;
                            if (GGP != null && GGP.leftChild.value == G.value)
                            {
                                GGP.leftChild = P;
                            }
                            else if (GGP != null && GGP.rightChild.value == G.value)
                            {
                                GGP.rightChild = P;
                            }
                            G.rightChild = P.leftChild;
                            if (P.leftChild != null)
                            {
                                P.leftChild.parent = G;
                            }
                            P.leftChild = G;
                            P.parent = GGP;
                            G.parent = P;
                            G.color = "R";
                            P.color = "B";
                            if (GGP == null)
                            {
                                root = P;
                            }
                        }
                    }
                    else
                    {
                        if (node.parent.parent.rightChild != null && node.parent.parent.rightChild.color == "R")
                        {
                            node.parent.color = "B";
                            node.parent.parent.rightChild.color = "B";
                            node.parent.parent.color = "R";
                            RBInsertFixup(node.parent.parent, ref root);
                        }
                        else
                        {
                            Node G = node.parent.parent;
                            if (node.parent.rightChild != null && node.value == node.parent.rightChild.value)
                            {
                                LeftRotation(node, node.parent, G);
                            }
                            Node P = G.leftChild;
                            Node N = P.leftChild;
                            Node GGP = G.parent;
                            if (GGP != null && GGP.leftChild.value == G.value)
                            {
                                GGP.leftChild = P;
                            }
                            else if (GGP != null && GGP.rightChild.value == G.value)
                            {
                                GGP.rightChild = P;
                            }

                            G.leftChild = P.rightChild;
                            if (P.rightChild != null)
                            {
                                P.rightChild.parent = G;
                            }
                            P.rightChild = G;
                            P.parent = GGP;
                            G.parent = P;
                            G.color = "R";
                            P.color = "B";
                            if (GGP == null)
                            {
                                root = P;
                            }
                        }
                    }
                }
            }
        }

        static void LeftRotation(Node N, Node P, Node G)
        {
            P.rightChild = N.leftChild;
            if (N.leftChild != null)
            {
                N.leftChild.parent = P;
            }
            N.leftChild = P;
            P.parent = N;
            N.parent = G;
            G.leftChild = N;
        }

        static void RightRotation(Node N, Node P, Node G)
        {
            P.leftChild = N.rightChild;
            if (N.rightChild != null)
            {
                N.rightChild.parent = P;
            }
            N.rightChild = P;
            P.parent = N;
            N.parent = G;
            G.rightChild = N;
        }

        public static void RBDeleteFixup(Node N, ref Node root)
        {
            Node S;
            Node P = N.parent;
            string color;

            if (N.parent.leftChild == null || N.parent.leftChild.value == N.value)
            {
                S = N.parent.rightChild;
                if (S.color == "R")
                {
                    color = S.color;
                    S.color = P.color;
                    P.color = color;

                    //left rotation
                    P.rightChild = S.leftChild;
                    if (S.leftChild != null)
                    {
                        S.leftChild.parent = P;
                    }
                    S.leftChild = P;
                    S.parent = P.parent;
                    P.parent = S;
                    if (S.parent != null)
                    {
                        if (S.parent.leftChild != null && S.parent.leftChild.value == P.value)
                        {
                            S.parent.leftChild = S;
                        }
                        else
                        {
                            S.parent.rightChild = S;
                        }
                    }
                    else
                    {
                        root = S;
                    }
                }
                if ((N.parent.rightChild.leftChild == null || N.parent.rightChild.leftChild.color == "B") && (N.parent.rightChild.rightChild == null || N.parent.rightChild.rightChild.color == "B"))
                {
                    //phase 2
                    N.color = "B";
                    N.parent.rightChild.color = "R";
                    if (N.parent.color == "R")
                    {
                        N.parent.color = "B";
                    }
                    else
                    {
                        N.parent.color = "BB";
                    }
                    if (N.parent.parent == null)
                    {
                        N.parent.color = "B";
                        root = N.parent;
                    }
                    if (N.parent.color == "BB")
                    {
                        RBDeleteFixup(N.parent, ref root);
                    }
                }
                else if (N.parent.rightChild.leftChild != null && N.parent.rightChild.leftChild.color == "R" && (N.parent.rightChild.rightChild == null || N.parent.rightChild.rightChild.color == "B"))
                {
                    //phase 3
                    S = N.parent.rightChild;
                    Node SL = S.leftChild;
                    // right rotation
                    S.leftChild = SL.rightChild;
                    if (SL.rightChild != null)
                    {
                        SL.rightChild.parent = S;
                    }
                    SL.rightChild = S;
                    SL.parent = S.parent;
                    S.parent = SL;
                    N.parent.rightChild = SL;
                    color = S.color;
                    S.color = SL.color;
                    SL.color = color;

                    //phase 4
                    //left rotation
                    Node P2 = N.parent;
                    Node S2 = SL;
                    P2.rightChild = S2.leftChild;
                    if (S2.leftChild != null)
                    {
                        S2.leftChild.parent = P2;
                    }
                    S2.leftChild = P2;
                    S2.parent = P2.parent;
                    if (P2.parent == null)
                    {
                        root = S2;
                    }
                    else
                    {
                        if (P2.parent.leftChild != null && P2.parent.leftChild.value == P2.value)
                        {
                            P2.parent.leftChild = S2;
                        }
                        else
                        {
                            P2.parent.rightChild = S2;
                        }
                    }
                    P2.parent = S2;
                    color = P2.color;
                    P2.color = S2.color;
                    S2.color = color;
                    S2.rightChild.color = "B";
                    N.color = "B";
                }
                else if (N.parent.rightChild.rightChild != null && N.parent.rightChild.rightChild.color == "R")
                {
                    //phase4
                    //left rotation
                    Node P2 = N.parent;
                    Node S2 = N.parent.rightChild;
                    P2.rightChild = S2.leftChild;
                    if (S2.leftChild != null)
                    {
                        S2.leftChild.parent = P2;
                    }
                    S2.leftChild = P2;
                    S2.parent = P2.parent;
                    if (P2.parent == null)
                    {
                        root = S2;
                    }
                    else
                    {
                        if (P2.parent.leftChild != null && P2.parent.leftChild.value == P2.value)
                        {
                            P2.parent.leftChild = S2;
                        }
                        else
                        {
                            P2.parent.rightChild = S2;
                        }
                    }
                    P2.parent = S2;
                    color = P2.color;
                    P2.color = S2.color;
                    S2.color = color;
                    S2.rightChild.color = "B";
                    N.color = "B";
                }
            }

            else if (N.parent.rightChild == null || N.parent.rightChild.value == N.value)
            {
                S = N.parent.leftChild;

                if (S.color == "R")
                {
                    color = S.color;
                    S.color = P.color;
                    P.color = color;

                    //right rotation
                    P.leftChild = S.rightChild;
                    if (S.rightChild != null)
                    {
                        S.rightChild.parent = P;
                    }
                    S.rightChild = P;
                    S.parent = P.parent;
                    P.parent = S;

                    if (S.parent != null)
                    {
                        if (S.parent.leftChild.value == P.value)
                        {
                            S.parent.leftChild = S;
                        }
                        else
                        {
                            S.parent.rightChild = S;
                        }
                    }
                    else
                    {
                        root = S;
                    }
                }

                if ((N.parent.leftChild.rightChild == null || N.parent.leftChild.rightChild.color == "B") && (N.parent.leftChild.leftChild == null || N.parent.leftChild.leftChild.color == "B"))
                {
                    //phase 2
                    N.color = "B";
                    N.parent.leftChild.color = "R";
                    if (N.parent.color == "R")
                    {
                        N.parent.color = "B";
                    }
                    else
                    {
                        N.parent.color = "BB";
                    }
                    if (N.parent.parent == null)
                    {
                        N.parent.color = "B";
                        root = N.parent;
                    }
                    if (N.parent.color == "BB")
                    {
                        RBDeleteFixup(N.parent, ref root);
                    }
                }
                else if (N.parent.leftChild.rightChild != null && N.parent.leftChild.rightChild.color == "R" && (N.parent.leftChild.leftChild == null || N.parent.leftChild.leftChild.color == "B"))
                {
                    //phase 3
                    S = N.parent.leftChild;
                    Node SL = S.rightChild;
                    // left rotation
                    S.rightChild = SL.leftChild;
                    if (SL.leftChild != null)
                    {
                        SL.leftChild.parent = S;
                    }
                    SL.leftChild = S;
                    SL.parent = S.parent;
                    S.parent = SL;
                    N.parent.leftChild = SL;
                    color = S.color;
                    S.color = SL.color;
                    SL.color = color;

                    //phase 4
                    //left rotation
                    Node P2 = N.parent;
                    Node S2 = SL;
                    P2.leftChild = S2.rightChild;
                    if (S2.rightChild != null)
                    {
                        S2.rightChild.parent = P2;
                    }
                    S2.rightChild = P2;
                    S2.parent = P2.parent;
                    if (P2.parent == null)
                    {
                        root = S2;
                    }
                    else
                    {
                        if (P2.parent.rightChild != null && P2.parent.rightChild.value == P2.value)
                        {
                            P2.parent.rightChild = S2;
                        }
                        else
                        {
                            P2.parent.leftChild = S2;
                        }
                    }
                    P2.parent = S2;
                    color = P2.color;
                    P2.color = S2.color;
                    S2.color = color;
                    S2.leftChild.color = "B";
                    N.color = "B";
                }
                else if (N.parent.leftChild.leftChild != null && N.parent.leftChild.leftChild.color == "R")
                {
                    //phase 4
                    //left rotation
                    Node P2 = N.parent;
                    Node S2 = N.parent.leftChild;
                    P2.leftChild = S2.rightChild;
                    if (S2.rightChild != null)
                    {
                        S2.rightChild.parent = P2;
                    }
                    S2.rightChild = P2;
                    S2.parent = P2.parent;
                    if (P2.parent == null)
                    {
                        root = S2;
                    }
                    else
                    {
                        if (P2.parent.rightChild != null && P2.parent.rightChild.value == P2.value)
                        {
                            P2.parent.rightChild = S2;
                        }
                        else
                        {
                            P2.parent.leftChild = S2;
                        }
                    }
                    P2.parent = S2;
                    color = P2.color;
                    P2.color = S2.color;
                    S2.color = color;
                    S2.leftChild.color = "B";
                    N.color = "B";
                }
            }
        }
    }
}
