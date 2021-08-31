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

namespace SaTeatar.WinUI.Predstave
{
    public partial class frmPredstave : Form
    {
        private readonly APIService _tipPredstavaService = new APIService("TipoviPredstava");
        private readonly APIService _predstaveService = new APIService("Predstava");
        public frmPredstave()
        {
            InitializeComponent();
        }

        private async void frmPredstave_Load(object sender, EventArgs e)
        {
            await LoadTipoviPredstava();
        }

        private async Task LoadTipoviPredstava()
        {
            var result = await _tipPredstavaService.Get<List<mTipoviPredstava>>(null);
            result.Insert(0, new mTipoviPredstava());
            cmbTipoviPredstave.DisplayMember = "Naziv";
            cmbTipoviPredstave.ValueMember = "TipPredstaveId";
            cmbTipoviPredstave.DataSource = result;
        }

        private async void cmbTipoviPredstave_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbTipoviPredstave.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int id))
            {
                if (id!=0)
                {
                    await LoadPredstave(id);
                }
            }
        }

        private async Task LoadPredstave(int tipId)
        {
            var result = await _predstaveService.Get<List<mPredstave>>
                (
                    new rPredstavaSearch()
                    {
                        TipPredstaveId = tipId,
                    }
                ); 
            result.Sort((x, y) => x.Naziv.CompareTo(y.Naziv));
            dgvPredstave.AutoGenerateColumns = false;
            dgvPredstave.DataSource = result;
        }

        private void dgvPredstave_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int rowindex = dgvPredstave.CurrentCell.RowIndex;
            int columnindex = dgvPredstave.CurrentCell.ColumnIndex;
            var value = dgvPredstave.CurrentCell.Value; 
            var id = dgvPredstave.Rows[rowindex].Cells["PredstavaId"].Value;
            frmPredstaveDetalji frm = new frmPredstaveDetalji(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}
