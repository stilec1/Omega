using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega
{
   class Car
    {

        public string Znacka { get; set; }
        public string Rok_vyroby { get; set; }
        public string Cena { get; set; }
        public string Vykon { get; set; }
        public string Historie { get; set; }


        public Car(string znacka, string rok_vyroby, string cena, string vykon, string historie)
        {
            Znacka = znacka;
            Rok_vyroby = rok_vyroby;
            Cena = cena;
            Vykon = vykon;
            Historie = historie;
        }
    }
}
