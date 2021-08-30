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
using SaTeatar.Model.Requests;
using System.IO;

namespace SaTeatar.WinUI.Djelatnici
{
    public partial class frmDjelatniciDetalji : Form
    {
        private APIService _vrsteDjelatnika = new APIService("vrstedjelatnika");
        private APIService _djelatnici = new APIService("djelatnici");
        private int? _id = null;
        public frmDjelatniciDetalji(int? idDjelatnika=null)
        {
            InitializeComponent();
            _id = idDjelatnika;
            AutoValidate = AutoValidate.Disable;

        }

        private rDjelatniciInsert inrequest = new rDjelatniciInsert();
        private rDjelatniciUpdate uprequest = new rDjelatniciUpdate();
        private mDjelatnici djelatnik = new mDjelatnici();
        private bool dodanaSlika = false;

        private async void frmDjelatniciDetalji_Load(object sender, EventArgs e)
        {
            chStatus.Checked = true;
            await LoadVrstaDjelatnika();


            if (_id.HasValue)
            {
                djelatnik = await _djelatnici.GetById<mDjelatnici>(_id);

                txtIme.Text = djelatnik.Ime;
                txtPrezime.Text = djelatnik.Prezime;
                txtBiografija.Text = djelatnik.Biografija;
                chStatus.Checked = djelatnik.Status;
                cmbVrsteDjelatnika.SelectedValue = djelatnik.VrstaDjelatnikaId;


                if (djelatnik.Slika?.Length>0)
                {
                    using (MemoryStream ms = new MemoryStream(djelatnik.Slika))
                    {
                        pbSlika.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbSlika.Visible = false;
                }

            }
        }

        private async Task LoadVrstaDjelatnika()
        {
            var result = await _vrsteDjelatnika.Get<List<mVrsteDjelatnika>>(null);
            result.Insert(0, new mVrsteDjelatnika());
            cmbVrsteDjelatnika.DisplayMember = "Naziv";
            cmbVrsteDjelatnika.ValueMember = "VrstaDjelatnikaId";
            cmbVrsteDjelatnika.DataSource = result;
        }

        private async void txtSacuvaj_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                if (!_id.HasValue)
                {
                    inrequest.Ime = txtIme.Text;
                    inrequest.Prezime = txtPrezime.Text;
                    inrequest.Biografija = txtBiografija.Text;
                    inrequest.Status = chStatus.Checked;
                    if (dodanaSlika == false)
                    {
                        inrequest.Slika = null;
                    }

                    await _djelatnici.Insert<mDjelatnici>(inrequest);

                    MessageBox.Show("Uspjesno dodan djelatnik!");
                    this.Close();
                }
                else
                {

                    uprequest.Biografija = txtBiografija.Text;
                    uprequest.Ime = txtIme.Text;
                    uprequest.Prezime = txtPrezime.Text;
                    uprequest.Status = chStatus.Checked;

                    if (dodanaSlika == false)
                    {
                        uprequest.Slika = djelatnik.Slika;
                    }

                    await _djelatnici.Update<mDjelatnici>(_id, uprequest);

                    MessageBox.Show("Uspjesno izmijenjen djelatnik!");
                    this.Close();
                }
            }
        }

        private void btnDodajSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result==DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                var file = File.ReadAllBytes(filename);
                if (_id.HasValue)
                {
                    uprequest.Slika = file;
                    dodanaSlika = true;
                }
                else
                {
                    inrequest.Slika = file;
                    dodanaSlika = true;
                }
                txtSlikaInput.Text = filename;

                Image slika = Image.FromFile(filename);
                pbSlika.Image = slika;
            }
        }

        private void cmbVrsteDjelatnika_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idvdobj = cmbVrsteDjelatnika.SelectedValue;
            if (int.TryParse(idvdobj.ToString(),out int idvd))
            {
                if (idvd!=0)
                {
                    if (_id.HasValue)
                    {
                        uprequest.VrstaDjelatnikaId = idvd;
                    }
                    else
                    {
                        inrequest.VrstaDjelatnikaId = idvd;
                    }
                }
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                errorProvider.SetError(txtIme, Properties.Resources.Validation_RequiredField);
                e.Cancel=true;
            }
            else
            {
                if (txtIme.Text.Length<3)
                {
                    errorProvider.SetError(txtIme, Properties.Resources.Validation_MinLength);
                    e.Cancel = true;
                }
                else
                errorProvider.SetError(txtIme, null);
            }

        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                if (txtPrezime.Text.Length < 3)
                {
                    errorProvider.SetError(txtPrezime, Properties.Resources.Validation_MinLength);
                    e.Cancel = true;
                }
                else
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private void cmbVrsteDjelatnika_Validating(object sender, CancelEventArgs e)
        {
            if (cmbVrsteDjelatnika.SelectedValue == null || int.Parse(cmbVrsteDjelatnika.SelectedValue.ToString())==0)
            {
                errorProvider.SetError(cmbVrsteDjelatnika, Properties.Resources.Validation_RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbVrsteDjelatnika, null);
            }

        }
    }
}
