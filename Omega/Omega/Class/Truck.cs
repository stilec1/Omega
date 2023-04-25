using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Omega.Class
{
    class Truck
    {
       

        public string Znacka2 { get; set; }

        public string Model1 { get; set; }
        public string Nosnost { get; set; }
        public string Cena2 { get; set; }
        public string Rok_vyroby2 { get; set; }
        
        public string Palivo { get; set; }
    
        public Truck(string znacka2, string model1, string nosnost, string cena2, string rok_vyroby2, string palivo)
        {
        Znacka2 = znacka2;
        Model1 = model1;
        Nosnost = nosnost;
        Cena2 = cena2;
        Rok_vyroby2 = rok_vyroby2;
        Palivo = palivo;
        }
    }
}
