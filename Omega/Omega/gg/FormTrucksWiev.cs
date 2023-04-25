using Omega.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omega.Forms
{
    public partial class FormTrucksWiev : Form
    {
        private readonly FormTrucks _parent;
        public string id, znacka2, model1,nosnost,cena2, rok_vyroby2, palivo;

        

        public FormTrucksWiev(FormTrucks parent2)
        {
            InitializeComponent();
            _parent = parent2;
        }
        public void UpdateInfo2()
        {
            lbltext2.Text = "Upravit nakladaky";
            btnSave2.Text = "Upravit ";
            txtZnacka2.Text = znacka2;
            txtModel1.Text = model1;
            txtNosnost.Text = nosnost;
            txtCena2.Text = cena2;
            txtRok_vyroby2.Text = rok_vyroby2;
            txtPalivo.Text = palivo;
           
        }
        public void SaveInfo2()
        {
            lbltext2.Text = "Přidat nakladaky";
            btnSave2.Text = "Uložit";
        }
        public void Clear2()
        {
            txtZnacka2.Text = txtModel1.Text = txtNosnost.Text = txtCena2.Text = txtRok_vyroby2.Text = txtPalivo.Text = string.Empty;
        }
        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (txtZnacka2.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka znacka je prázdná! Musí být více jak tři znaky");
                return;

            }
            if (txtModel1.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka model je prázdná! Musí být více jak tři znaky");
                return;
            }
            if (txtNosnost.Text.Trim().Length == 0)
            {
                MessageBox.Show("Kolonka nosnost je prázdná! Musí být více jak tři znaky");
                return;

            }
            if (txtCena2.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka cena je prázdná! Musí být více jak tři znaky");
                return;

            }
            if (txtRok_vyroby2.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka rok_vyroby je prázdná! Musí být více jak tři znaky");
                return;
            }
            if (txtPalivo.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka palivo je prázdná! Musí být více jak tři znaky");
                return;

            }
            
            if (btnSave2.Text == "Uložit")
            {
                Truck tr = new Truck(txtZnacka2.Text.Trim(), txtModel1.Text.Trim(), txtNosnost.Text.Trim(), txtCena2.Text.Trim(), txtRok_vyroby2.Text.Trim(), txtPalivo.Text.Trim());
                DbCar.AddTruck(tr);
                Clear2();
            }
            if (btnSave2.Text == "Upravit ")
            {
                Truck tr = new Truck(txtZnacka2.Text.Trim(), txtModel1.Text.Trim(), txtNosnost.Text.Trim(), txtCena2.Text.Trim(), txtRok_vyroby2.Text.Trim(), txtPalivo.Text.Trim());
                DbCar.UpdateTruck(tr, id);
            }
            _parent.Display2();
        }
    }
}
