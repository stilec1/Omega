using Omega.Views;
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
        public string id, znacka, rok_vyroby, cena, @vykon, historie;
        public FormCarsWiev(FormCars parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lbltext.Text = "Upravit auta";
            btnSave.Text = "Upravit ";
            txtZnacka.Text = znacka;
            txtRok_vyroby.Text = rok_vyroby;
            txtCena.Text = cena;
            txtVykon.Text = @vykon;
            txtHistorie.Text = historie;
        }
        public void SaveInfo()
        {
            lbltext.Text = "Přidat auto";
            btnSave.Text = "Uložit";
        }
        public void Clear()
        {
            txtZnacka.Text = txtRok_vyroby.Text = txtCena.Text = txtVykon.Text =txtHistorie.Text = string.Empty;
        }

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
