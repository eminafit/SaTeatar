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
using static SaTeatar.WinUI.frmPostavkeZaIzvjestaje;

namespace SaTeatar.WinUI
{
     
    public partial class frmTopPosjetiteljiIzvjestaj : Form
    {
        private dtoTopPosjetioci _objTP;
        public frmTopPosjetiteljiIzvjestaj(dtoTopPosjetioci objTP)
        {
            InitializeComponent();
            _objTP = objTP;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {
            var rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter( "Pozoriste", _objTP.PozoristeNaziv));
            //rpc.Add(new ReportParameter( "DatumOd", _objTP.DatumOd.ToString("dd.MM.yyyy.")));
            //rpc.Add(new ReportParameter( "DatumDo", _objTP.DatumDo.ToString("dd.MM.yyyy.")));
            rpc.Add(new ReportParameter( "DatumOdStr", _objTP.DatumOd.ToString("dd.MM.yyyy.")));
            rpc.Add(new ReportParameter( "DatumDoStr", _objTP.DatumDo.ToString("dd.MM.yyyy.")));

            var tblPosjetitelji = new dsSaTeatar.PosjetiteljiDataTable();
            var tblPosjetiteljiNovi = new dsSaTeatar.PosjetiteljiDataTable();

            //dodavanje redova
            for (int i = 0; i < 5; i++)
            {
                var red = tblPosjetitelji.NewPosjetiteljiRow();
                red.RedBr = i + 1;
                red.ImePrezime = $"Ime Prezime {i + 1}";
                red.BrKupljenihKarti = i + 3;
                tblPosjetitelji.Rows.Add(red);
            }

            //rad sa objektima umjesto datasata
            var listaPosjetitelja = new List<object>();
            for (int i = 0; i < 5; i++)
            {
                listaPosjetitelja.Add(
                    new
                    {
                        Id = i + 1,
                        ImePrezime = $"an_Ime Prezime {i + 1}",
                        BrKupljenihKarti = i + 3
                    });
            //    tblPosjetitelji.Rows.Add(listaPosjetitelja[i]);
            }

            //dodavanje redova
            for (int i = 0; i < _objTP.Kupci.Count; i++)
            {
                var red = tblPosjetiteljiNovi.NewPosjetiteljiRow();
                red.RedBr = _objTP.Kupci[i].RedBr;
                red.ImePrezime = _objTP.Kupci[i].KupacImePrezime;
                red.BrKupljenihKarti = _objTP.Kupci[i].BrKarti;
                tblPosjetiteljiNovi.Rows.Add(red);
            }

            //vezati datatable za izvjestaj
            var rds = new ReportDataSource();
            rds.Name = "dsPosjetitelji";
            //rds.Value = tblPosjetitelji;
            //rds.Value = listaPosjetitelja;
            rds.Value = tblPosjetiteljiNovi;

            reportViewer1.LocalReport.DataSources.Add(rds);


            //vezati rpc za izvjestaj
            reportViewer1.LocalReport.SetParameters(rpc);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
