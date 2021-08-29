using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SaTeatar.WinUI.Izvjestaji.frmPostavkeOcjeneIzvjestaj;

namespace SaTeatar.WinUI.Izvjestaji
{
    public partial class frmOcjeneIzvjestaj : Form
    {
        private dtoPO _dtobj = null;
        public frmOcjeneIzvjestaj(dtoPO dtobj )
        {
            InitializeComponent();
            _dtobj = dtobj;
        }

        private void frmOcjeneIzvjestaj_Load(object sender, EventArgs e)
        {
            var rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("Pozoriste", _dtobj.PozoristeNaziv));

            var tblPredstave = new dsSaTeatar.PredstaveDataTable();

            for (int i = 0; i < _dtobj.ListaPredstavaOcjena.Count; i++)
            {
                var red = tblPredstave.NewPredstaveRow();
                red.RedBr = i + 1;
                red.Predstava = _dtobj.ListaPredstavaOcjena[i].PredstavaNaziv;
                red.ProsjecnaOcjena = _dtobj.ListaPredstavaOcjena[i].ProsjecnaOcjena;
                tblPredstave.Rows.Add(red);
            }
            var rds = new ReportDataSource();
            rds.Name = "dsPredstave";
            rds.Value = tblPredstave;

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);


            this.reportViewer1.RefreshReport();
        }
    }
}
