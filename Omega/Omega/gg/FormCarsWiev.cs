
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega
{
    public partial class FormCarsWiev : Form
    {
        private readonly FormCars _parent;
        public string id, znacka, rok_vyroby, cena, vykon, historie;
        /*Konstruktor třídy FormCarsWiev přijímá instanci třídy FormCars, která je rodičovskou třídou.
         * To znamená, že třída FormCarsWiev bude ovládána z třídy FormCars.*/
        public FormCarsWiev(FormCars parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        /*Metoda UpdateInfo() aktualizuje obsah formuláře, aby zobrazila údaje o existujícím automobilu, který bude upravován.*/
        public void UpdateInfo()
        {
            lbltext.Text = "Upravit auta";
            btnSave.Text = "Upravit ";
            txtZnacka.Text = znacka;
            txtRok_vyroby.Text = rok_vyroby;
            txtCena.Text = cena;
            txtVykon.Text = vykon;
            txtHistorie.Text = historie;
        }
        /*Metoda SaveInfo() zobrazí formulář pro přidání nového automobilu.*/
        public void SaveInfo()
        {
            lbltext.Text = "Přidat auto";
            btnSave.Text = "Uložit";
        }
        /*Tato metoda nastavuje hodnotu textových polí (txtZnacka, txtRok_vyroby, txtCena, txtVykon a txtHistorie) na prázdné řetězce. 
         * Tím se vymažou veškeré předchozí vstupy uživatele z těchto polí a připraví se tak formulář pro nový vstup.*/
        public void Clear()
        {
            txtZnacka.Text = txtRok_vyroby.Text = txtCena.Text = txtVykon.Text =txtHistorie.Text = string.Empty;
        }
        /*Metoda btnSave_Click() je spouštěna při kliknutí na tlačítko Uložit nebo Upravit.
         * Pokud se tlačítko jmenuje "Uložit", metoda přidá nový záznam automobilu do databáze. 
         * Pokud se tlačítko jmenuje "Upravit", metoda aktualizuje existující záznam.

        Pokud jsou některé povinné pole prázdné, metoda zobrazí chybovou hlášku a operace nebude provedena. 
        V opačném případě se nový nebo upravený záznam uloží do databáze a třída FormCars zobrazí aktualizovaný seznam automobilů v DataGridView.*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtZnacka.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka znacka je prázdná! Musí být více jak tři znaky");
                return;
                
            }
            if (txtRok_vyroby.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka rok_vyroby je prázdná! Musí být více jak tři znaky");
                return;
            }
            if (txtCena.Text.Trim().Length == 0)
            {
                MessageBox.Show("Kolonka cena je prázdná! Musí být více jak jeden znaky");
                return;
            }
            
            if (txtVykon.Text.Trim().Length ==0)
            {
                MessageBox.Show("Kolonka vykon je prázdná! Musí být více jak jeden znaky");
                return;
            }
            if (txtHistorie.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka historie je prázdná! Musí být více jak tři znaky");
                return;
            }
            if (btnSave.Text == "Uložit")
            {
                Car cr = new Car(txtZnacka.Text.Trim(),txtRok_vyroby.Text.Trim(), txtCena.Text.Trim(), txtVykon.Text.Trim(),txtHistorie.Text.Trim());
                DbCar.AddCar(cr);
                Clear();
            }
            if(btnSave.Text == "Upravit ")
            {
                Car cr = new Car(txtZnacka.Text.Trim(), txtRok_vyroby.Text.Trim(), txtCena.Text.Trim(), txtVykon.Text.Trim(), txtHistorie.Text.Trim());
                DbCar.UpdateCar(cr,id);
            }
            _parent.Display();
        }
    }
}
