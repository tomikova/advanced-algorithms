using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NASP2
{
    public class Komponenta
    {
        public string naziv;
        public int vrijednost;
        public int cijena;
    }

    public class Monitor : Komponenta
    {
        public Monitor(string naziv, int vrijednost, int cijena )
        {
            this.naziv = naziv;
            this.vrijednost = vrijednost;
            this.cijena = cijena;
        }
    }

    public class CPU : Komponenta
    {
        public CPU(string naziv, int vrijednost, int cijena)
        {
            this.naziv = naziv;
            this.vrijednost = vrijednost;
            this.cijena = cijena;
        }
    }

    public class GCard : Komponenta
    {
        public GCard(string naziv, int vrijednost, int cijena )
        {
            this.naziv = naziv;
            this.vrijednost = vrijednost;
            this.cijena = cijena;
        }
    }

    public class HardDisk : Komponenta
    {
        public HardDisk(string naziv, int vrijednost, int cijena )
        {
            this.naziv = naziv;
            this.vrijednost = vrijednost;
            this.cijena = cijena;
        }
    }
}
