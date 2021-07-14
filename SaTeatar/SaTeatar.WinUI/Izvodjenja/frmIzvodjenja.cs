using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;

namespace SaTeatar.WinUI.Izvodjenja
{
    public partial class frmIzvodjenja : Form
    {
        APIService _izvodjenjaService = new APIService("izvodjenja");
        APIService _predstaveService = new APIService("predstava");
        APIService _pozoristaService = new APIService("pozorista");

        public frmIzvodjenja()
        {
            InitializeComponent();
        }

        private async void frmIzvodjenja_Load(object sender, EventArgs e)
        {
            var izvodjenja = await _izvodjenjaService.Get<List<mIzvodjenja>>(null);
            dgvIzvodjenja.DataSource = izvodjenja;
        }
    }
}
