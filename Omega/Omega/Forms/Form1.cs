
using Omega.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Omega
{
    public partial class Form1 : Form
    {
        /*Proměnné 'currentButtonrandom, tempIndex a activeForm jsou deklarovány jako privátní proměnné třídy.*/
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        /*Metoda Form1() je konstruktorem třídy a nastavuje několik vlastností formuláře a skrývá tlačítko pro zavření dílčího formuláře.*/
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        /*Metody 'Release a 'SendMessageSendMessage() jsou deklarovány jako externí metody, které se volají z nativních Windows API.*/
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        /*Metoda 'SelectThemeColor náhodně vybere barvu ze seznamu a vrátí ji jako objekt 'ColorColor.*/
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while(tempIndex == index)
            {
               index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        /*Metoda 'ActivateButton přijímá tlačítko jako parametr a zajišťuje, že aktuální tlačítko má správnou barvu a vlastnosti. 
         * Metoda také upravuje barvy v různých částech aplikace a ukládá primární a sekundární barvy do třídy 'ThemeColorThemeColor.*/
        private void ActivateButton(object btnSender)
        {
            if(btnSender != null)
            {
                if(currentButton != (Button) btnSender )
                {

                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font= new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color,-0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }

        }
        /*Metoda 'DisableButton nastaví všechny tlačítka v menu na defaultní barvu.*/
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if(previousBtn.GetType()==typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(128, 0, 0);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font= new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                }
            }
        }
        /*Metoda 'OpenChildForm. Metoda také zavolá 'ActivateButtonActivateButton() pro aktuálně stisknuté tlačítko a upravuje nadpis formuláře.*/
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }
        /*Metody 'btnProducts_Click()btnOrders_Click() a btnCustomers_Click() jsou události kliknutí na tlačítka v menu a spouští metodu 'OpenChildFormOpenChildForm() pro odpovídající dílčí formulář.*/
        private void btnProducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCars(),sender);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormMotorbikes(), sender);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormTrucks(), sender);
        }
        /*Metoda btnCloseChildForm_Click() zavírá aktuálně otevřený dílčí formulář a volá metodu 'Reset().*/
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        /*Metoda Reset() obnoví všechny vlastnosti a barvy na výchozí hodnoty*/
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "DOMU";
            panelTitleBar.BackColor = Color.FromArgb(157, 34, 53);
            panelLogo.BackColor = Color.FromArgb(157, 34, 53);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        /*Metody btnClose_Click_1(), 'btnMaximize_Click_btnMaximize_Click_1() a 'btnMinimalizovatbtnMinimize_Click() jsou události kliknutí na tlačítka pro zavření, maximalizaci a minimalizaci formuláře.*/
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click_1(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
    }
}



