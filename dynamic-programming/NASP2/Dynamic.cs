using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace NASP2
{
    public class Dynamic
    {
        public int budget = 0;
        public int totalValue = 0;
        public int totalCost = 0;
        public List<Komponenta> bestChoice = new List<Komponenta>();

        public Dynamic(int _budget)
        {
            this.budget = _budget;
        }

        private Komponenta[] BubbleSort(Komponenta[] array)
        {
            Komponenta temp = null;

            for (int i = 0; i < array.Length; i++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    if (array[sort].cijena < array[sort + 1].cijena)
                    {
                        temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                    }
                }
            }
            return array;
        }

        public void Calculate(Komponenta komp1, Komponenta komp2, Komponenta komp3, Komponenta komp4)
        {
            Komponenta[] komponente = {komp1, komp2, komp3, komp4};
            komponente = BubbleSort(komponente);

            int[,] valueTable = new int[5, budget + 1];
            int[,] keepTable = new int[5, budget + 1];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < budget + 1; j++)
                {
                    if (i == 0)
                    {
                        valueTable[i, j] = 0;
                        keepTable[i, j] = 0;
                    }
                    else
                    {
                        if (komponente[i-1].cijena > j)
                        {
                            valueTable[i, j] = valueTable[i-1,j];
                            keepTable[i, j] = 0;
                        }
                        else
                        {
                            int diff = j - komponente[i-1].cijena;
                            int add = komponente[i-1].vrijednost + valueTable[i - 1, diff];
                            if (add >= valueTable[i - 1, j])
                            {
                                valueTable[i, j] = add;
                                keepTable[i, j] = 1;
                            }
                            else
                            {
                                valueTable[i, j] = valueTable[i - 1, j];
                                keepTable[i, j] = 0;
                            }
                        }
                    }
                }
            }

            if (totalValue <= valueTable[4, budget])
            {
                List<Komponenta> tmp = new List<Komponenta>();
                int cost = 0;

                int i = 4, w = budget;
                while (i != 0)
                {
                    if (keepTable[i, w] == 1)
                    {
                        tmp.Add(komponente[i-1]);
                        w -= komponente[i-1].cijena;
                        i -= 1;
                    }
                    else
                    {
                        i -= 1;
                    }
                }

                foreach (Komponenta k in tmp)
                {
                    cost += k.cijena;
                }

                if (totalValue == valueTable[4, budget])
                {

                    if (cost < totalCost || bestChoice.Count == 0)
                    {
                        totalCost = cost;
                        bestChoice.Clear();
                        bestChoice = tmp;
                    }
                }
                else
                {
                    totalCost = cost;
                    bestChoice.Clear();
                    bestChoice = tmp;
                    totalValue = valueTable[4, budget];
                }
            }
        }
    }
}
