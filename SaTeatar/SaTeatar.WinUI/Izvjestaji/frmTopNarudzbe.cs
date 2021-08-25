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
using static SaTeatar.WinUI.Izvjestaji.frmPostavkaIzvjestajaTopNarudzbe;

namespace SaTeatar.WinUI.Izvjestaji
{
    public partial class frmTopNarudzbe : Form
    {
        private dtoTopNarudzbe _dtobj;
        public frmTopNarudzbe(dtoTopNarudzbe dtobj)
        {
            InitializeComponent();
            _dtobj = dtobj;
        }

        private void frmTopNarudzbe_Load(object sender, EventArgs e)
        {
            var rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("Pozoriste", _dtobj.PozoristeNaziv));
            rpc.Add(new ReportParameter("DatumOdStr", _dtobj.DatumOd.ToString("dd.MM.yyyy.")));
            rpc.Add(new ReportParameter("DatumDoStr", _dtobj.DatumDo.ToString("dd.MM.yyyy.")));

            var tblNarudzbe = new dsSaTeatar.NarudzbeDataTable();

            for (int i = 0; i < _dtobj.Narudzbe.Count; i++)
            {
                var red = tblNarudzbe.NewNarudzbeRow();
                red.BrNarudzbe = _dtobj.Narudzbe[i].BrNarudzbe;
                red.Kupac = _dtobj.Narudzbe[i].Kupac;
                red.Iznos = _dtobj.Narudzbe[i].Iznos;
                red.RedBr = _dtobj.Narudzbe[i].RedBr;
                tblNarudzbe.Rows.Add(red);
            }
            var rds = new ReportDataSource();
            rds.Name = "dsNarudzbe";
            rds.Value = tblNarudzbe;

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.SetParameters(rpc);

            this.reportViewer1.RefreshReport();
        }
    }
}
