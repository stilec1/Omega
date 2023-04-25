using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omega
{
    internal class ThemeColor
    {
        /*Statické vlastnosti PrimaryColor a SecondaryColor reprezentují hlavní a vedlejší barvu tématu.*/
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }
        /*Statická List<string> ColorList obsahuje seznam předdefinovaných barev v hexadecimálním formátu.*/
        public static List<string> ColorList = new List<string>() { "#3F51B5",
                                                                    "#009688",
                                                                    "#FF5722",
                                                                    "#607D8B",
                                                                    "#FF9800",
                                                                    "#9C27B0",
                                                                    "#2196F3",
                                                                    "#EA676C",
                                                                    "#E41A4A",
                                                                    "#5978BB",
                                                                    "#018790",
                                                                    "#0E3441",
                                                                    "#00B0AD",
                                                                    "#721D47",
                                                                    "#EA4833",
                                                                    "#EF937E",
                                                                    "#F37521",
                                                                    "#A12059",
                                                                    "#126881",
                                                                    "#8BC240",
                                                                    "#364D5B",
                                                                    "#C7DC5B",
                                                                    "#0094BC",
                                                                    "#E4126B",
                                                                    "#43B76E",
                                                                   "#FF4B0082",
                                                                    "#7BCFE9",
                                                                    "#B71C46"};
        /*Metoda ChangeColorBrightness přijímá vstupní barvu a korekční faktor a upravuje jas barvy na základě tohoto faktoru. 
         * Pokud je korekční faktor menší než nula, barva se ztmaví, pokud je větší než nula, barva se zesvětlí. 
         * Výsledná barva se pak vrátí jako objekt třídy Color.*/
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            //Pokud je korekční faktor menší než 0, ztmavte barvu
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            //Pokud je korekční faktor větší než nula, zesvětlete barvu. 
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
