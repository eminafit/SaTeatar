using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaTeatar.WinUI.Pozorista
{
    public partial class frmPozorista : Form
    {
        private APIService _pozoristaService = new APIService("pozorista");
        public frmPozorista()
        {
            InitializeComponent();
        }

        private async void frmPozorista_Load(object sender, EventArgs e)
        {
            var result = await _pozoristaService.Get<List<mPozorista>>(null);
            dgvPozorista.AutoGenerateColumns = false;
            dgvPozorista.DataSource = result;
        }

        private async void btnPretrazi_Click(object sender, EventArgs e)
        {
            var pretraga = txtPretraga.Text;
            var request = new rPozoristaSearch() { Naziv = pretraga };
            var upit = await _pozoristaService.Get<List<mPozorista>>(request);
            dgvPozorista.AutoGenerateColumns = false;
            dgvPozorista.DataSource = upit;
        }
    }
}
