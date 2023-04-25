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
using System.Xml;

namespace Omega.Forms
{
    public partial class FormMotorbikesWiev : Form
    {
        private readonly FormMotorbikes _parent;
        public string id, znacka1,model, rok_vyroby1,barva, cena1, stav_tachometru, pocet_vlastniku;


        public FormMotorbikesWiev(FormMotorbikes parent1)
        {
            InitializeComponent();
            _parent = parent1;
        }
        public void UpdateInfo1()
        {
            lbltext1.Text = "Upravit motorky";
            btnSave1.Text = "Upravit ";
            txtZnacka1.Text = znacka1;
            txtModel.Text = model;
            txtRok_vyroby1.Text = rok_vyroby1;
            txtBarva.Text = barva;
            txtCena1.Text = cena1;
            txtStav_tachometru.Text = stav_tachometru;
            txtPocet_vlastniku.Text = pocet_vlastniku;
        }
        public void SaveInfo1()
        {
            lbltext1.Text = "Přidat motorky";
            btnSave1.Text = "Uložit";
        }
        public void Clear1()
        {
            txtZnacka1.Text = txtModel.Text = txtRok_vyroby1.Text = txtBarva.Text = txtCena1.Text = txtStav_tachometru.Text = txtPocet_vlastniku.Text = string.Empty;
        }
        private void btnSave1_Click(object sender, EventArgs e)
        {
            if (txtZnacka1.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka znacka je prázdná! Musí být více jak tři znaky");
                return;

            }
            if (txtModel.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka model je prázdná! Musí být více jak tři znaky");
                return;

            }
            if (txtRok_vyroby1.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka rok_vyroby je prázdná! Musí být více jak tři znaky");
                return;
            }
            if (txtBarva.Text.Trim().Length < 3)
            {
                MessageBox.Show("Kolonka barva je prázdná! Musí být více jak tři znaky");
                return;

            }
            if (txtCena1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Kolonka cena je prázdná! Musí být více jak jeden znaky");
                return;
            }

            if (txtStav_tachometru.Text.Trim().Length == 0)
            {
                MessageBox.Show("Kolonka stav tachometru je prázdná! Musí být více jak jeden znaky");
                return;
            }
            if (txtPocet_vlastniku.Text.Trim().Length == 0)
            {
                MessageBox.Show("Kolonka pocet vlastniku je prázdná! Musí být více jak tři znaky");
                return;
            }
            if (btnSave1.Text == "Uložit")
            {
                Motorbike mo = new Motorbike(txtZnacka1.Text.Trim(), txtModel.Text.Trim(), txtRok_vyroby1.Text.Trim(), txtBarva.Text.Trim(), txtCena1.Text.Trim(), txtStav_tachometru.Text.Trim(), txtPocet_vlastniku.Text.Trim());
                DbCar.AddMotorbike(mo);
                Clear1();
            }
            if (btnSave1.Text == "Upravit ")
            {
                Motorbike mo = new Motorbike(txtZnacka1.Text.Trim(), txtModel.Text.Trim(), txtRok_vyroby1.Text.Trim(), txtBarva.Text.Trim(), txtCena1.Text.Trim(), txtStav_tachometru.Text.Trim(), txtPocet_vlastniku.Text.Trim());
                DbCar.UpdateMotorbike(mo, id);
            }
            _parent.Display1();
        }
    }
}
