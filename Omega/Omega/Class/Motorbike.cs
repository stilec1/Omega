using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Class
{
     class Motorbike
    {
        
        public string Znacka1 { get; set; }
        public string Model { get; set; }
        public string Rok_vyroby1 { get; set; }
        public string Barva { get; set; }
        public string Cena1 { get; set; }
        public string Stav_tachometru { get; set; }
        public string Pocet_vlastniku { get; set; }

        public Motorbike(string znacka1, string model, string rok_vyroby1, string barva, string cena1, string stav_tachometru, string pocet_vlastniku)
        {
            Znacka1 = znacka1;
            Model = model;
            Rok_vyroby1 = rok_vyroby1;
            Barva = barva;
            Cena1 = cena1;
            Stav_tachometru = stav_tachometru;
            Pocet_vlastniku = pocet_vlastniku;
        }
    }
}
