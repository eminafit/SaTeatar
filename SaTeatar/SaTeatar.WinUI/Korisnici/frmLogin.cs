using SaTeatar.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaTeatar.WinUI.Korisnici
{
    public partial class frmLogin : Form
    {
        private readonly APIService _api = new APIService("Korisnici");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnPrijava_Click(object sender, EventArgs e)
        {
            APIService.Username = txtKorisnickoIme.Text;
            APIService.Password = txtLozinka.Text;

            try
            {
                var result = await _api.Get<List<mKorisnici>>(null);
                frmIndex frm = new frmIndex(); //?
                frm.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Pogresno korisnicko ime ili lozinka!");
            }
        }
    }
}
