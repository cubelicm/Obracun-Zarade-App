﻿using Client.Forms.UserControls;
using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client.GuiControllers
{
    internal class ObracunZaradeGuiController
    {
        private UCObracunZarade ucObracunZarade;
        private List<VrstaZarade> vrsteZarade = new List<VrstaZarade>();
        private ObracunZarade obracunZaIzmenu;

        private const int COL_RB = 0;
        private const int COL_VRSTA_ZARADE = 1;
        private const int COL_ZARADA_PO_SATU = 2;
        private const int COL_BROJ_SATI = 3;
        private const int COL_UKUPNA_ZARADA_STAVKA = 4;
        private const int COL_NAPOMENA = 5;

        public enum ModObracunZarade { Ubaci, Promeni, Detalji }

        private static ObracunZaradeGuiController instance;
        public static ObracunZaradeGuiController Instance
        {
            get
            {
                if (instance == null) instance = new ObracunZaradeGuiController();
                return instance;
            }
        }

        private ObracunZaradeGuiController() { }

        public UCObracunZarade ShowObracunZaradeUC(ModObracunZarade mod, ObracunZarade oz = null)

        {

            ucObracunZarade = new UCObracunZarade();
            UcitajComboBoxeve();
            PodesiDataGridView();
            PrikaciEventove();

            switch (mod)
            {
                case ModObracunZarade.Ubaci:
                    UIForCreate();
                    break;
                case ModObracunZarade.Promeni:
                    UIForEdit(oz);
                    break;
                case ModObracunZarade.Detalji:
                    UIForDetails(oz);
                    break;
            }
            return ucObracunZarade;
        }



        private void UIForCreate()
        {
            ucObracunZarade.LblNaslov.Text = "Ubaci novi obračun zarade";
            ucObracunZarade.CbRacunovodja.SelectedItem = MainCoordinator.Instance.UlogovanRacunovodja;
            ucObracunZarade.CbRacunovodja.Enabled = false;
            ucObracunZarade.LblId.Visible = false;
            ucObracunZarade.LblStorniran.Visible = false;
            ucObracunZarade.ChkStorniran.Visible = false;
            ucObracunZarade.BtnSacuvaj.Text = "Ubaci novi obračun zarade";
            ucObracunZarade.DateTimePickerDatumOd.Value = DateTime.Now.AddMonths(-1);
            ucObracunZarade.DateTimePickerDatumDo.Value = DateTime.Now;
        }

        private void UIForEdit(ObracunZarade oz)
        {
            obracunZaIzmenu = oz;
            ucObracunZarade.LblNaslov.Text = "Promeni obračun zarade";

            PopuniPodatkeObracuna(oz);
            UcitajStavkeUGrid(oz);

            
            ucObracunZarade.CbZaposleni.Enabled = false;
            ucObracunZarade.CbRacunovodja.Enabled = false;
            ucObracunZarade.DateTimePickerDatumOd.Enabled = false;
            ucObracunZarade.DateTimePickerDatumDo.Enabled = false;

            
            ucObracunZarade.DataGridView1.ReadOnly = false;
            ucObracunZarade.BtnDodajStavku.Visible = true;
            ucObracunZarade.BtnObrisiStavku.Visible = true;

            ucObracunZarade.ChkStorniran.Visible = true;
            ucObracunZarade.ChkStorniran.Checked = oz.Storniran;
            ucObracunZarade.LblStorniran.Visible = oz.Storniran;

            ucObracunZarade.BtnSacuvaj.Text = "Sačuvaj promene";
        }

        private void UIForDetails(ObracunZarade oz)
        {

            ucObracunZarade.LblNaslov.Text = "Detalji obračuna zarade";

            PopuniPodatkeObracuna(oz);
            UcitajStavkeUGrid(oz);

            ucObracunZarade.CbZaposleni.Enabled = false;
            ucObracunZarade.CbRacunovodja.Enabled = false;
            ucObracunZarade.DateTimePickerDatumOd.Enabled = false;
            ucObracunZarade.DateTimePickerDatumDo.Enabled = false;
            ucObracunZarade.TxtNapomena.Enabled = false;

            ucObracunZarade.DataGridView1.ReadOnly = true;

            ucObracunZarade.BtnDodajStavku.Visible = false;

            ucObracunZarade.BtnObrisiStavku.Visible = false;
            ucObracunZarade.BtnSacuvaj.Visible = false;

            ucObracunZarade.ChkStorniran.Visible = false;
            ucObracunZarade.LblStorniran.Visible = oz.Storniran;
        }

        private void PopuniPodatkeObracuna(ObracunZarade oz)
        {
            if (oz == null)
            {
                MessageBox.Show("Obracun nije uspesno ucitan");
                return;
            }
            ucObracunZarade.LblId.Text = $"ID: {oz.IdObracunZarade}";
            ucObracunZarade.LblId.Visible = true;
            ucObracunZarade.DateTimePickerDatumOd.Value = oz.DatumOd;
            ucObracunZarade.DateTimePickerDatumDo.Value = oz.DatumDo;
            ucObracunZarade.TxtNapomena.Text = oz.Napomena;
            ucObracunZarade.CbZaposleni.SelectedValue = oz.Zaposleni.IdZaposleni;
            ucObracunZarade.CbRacunovodja.SelectedValue = oz.Racunovodja.IdRacunovodja;
            ucObracunZarade.LblUkupanIznos.Text = $"Ukupna zarada: {oz.UkupnaZarada}";
        }

        private void UcitajStavkeUGrid(ObracunZarade oz)
        {
            var grid = ucObracunZarade.DataGridView1;
            grid.CellValueChanged -= Grid_CellValueChanged;
            grid.Rows.Clear();

            Response res = Communication.Instance.VratiStavkeObracuna(oz);
            if (!res.isSuccessful)
            {
                ucObracunZarade.LblError.ForeColor = Color.Red;
                ucObracunZarade.LblError.Text = "Greška pri učitavanju stavki: " + res.Error;
                grid.CellValueChanged += Grid_CellValueChanged;
                return;
            }

            List<StavkaObracunaZarade> stavke =
                Communication.Instance.serializer.ReadType<List<StavkaObracunaZarade>>(res.Object);

            foreach (var stavka in stavke.OrderBy(st => st.Rb))
            {
                int idx = grid.Rows.Add();
                grid.Rows[idx].Cells[COL_RB].Value = stavka.Rb;
                grid.Rows[idx].Cells[COL_VRSTA_ZARADE].Value = stavka.VrstaZarade?.IdVrstaZarade;
                grid.Rows[idx].Cells[COL_ZARADA_PO_SATU].Value = stavka.VrstaZarade?.ZaradaPoSatu;
                grid.Rows[idx].Cells[COL_BROJ_SATI].Value = stavka.BrojSati;
                grid.Rows[idx].Cells[COL_UKUPNA_ZARADA_STAVKA].Value = stavka.UkupnaZaradaStavka;
                grid.Rows[idx].Cells[COL_NAPOMENA].Value = stavka.Napomena;
            }

            grid.CellValueChanged += Grid_CellValueChanged;
        }




        private void ChkStorniran_CheckedChanged(object sender, EventArgs e)
        {
            ucObracunZarade.LblStorniran.Visible = ucObracunZarade.ChkStorniran.Checked;
        }


        private void UcitajComboBoxeve()
        {
            List<Zaposleni> zaposleni = Communication.Instance.serializer
                .ReadType<List<Zaposleni>>(Communication.Instance.VratiZaposlene().Object);
            ucObracunZarade.CbZaposleni.DataSource = zaposleni;
            ucObracunZarade.CbZaposleni.SelectedIndex = -1;
            ucObracunZarade.CbZaposleni.DisplayMember = "ImePrezime";
            ucObracunZarade.CbZaposleni.ValueMember = "IdZaposleni";

            List<Racunovodja> racunovodje = Communication.Instance.serializer
                .ReadType<List<Racunovodja>>(Communication.Instance.VratiRacunovodje().Object);
            ucObracunZarade.CbRacunovodja.DataSource = racunovodje;
            ucObracunZarade.CbRacunovodja.SelectedIndex = -1;
            ucObracunZarade.CbRacunovodja.DisplayMember = "ImePrezime";
            ucObracunZarade.CbRacunovodja.ValueMember = "IdRacunovodja";

            vrsteZarade = Communication.Instance.serializer
                .ReadType<List<VrstaZarade>>(Communication.Instance.VratiVrsteZarada().Object);
        }


        private void PodesiDataGridView()
        {
            var grid = ucObracunZarade.DataGridView1;
            grid.Columns.Clear();
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRb", HeaderText = "Rb", ReadOnly = true, FillWeight = 40 });
            grid.Columns.Add(new DataGridViewComboBoxColumn { Name = "colVrstaZarade", HeaderText = "Vrsta zarade", DataSource = vrsteZarade, DisplayMember = "ImeVrste", ValueMember = "IdVrstaZarade", FillWeight = 130 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colZaradaPoSatu", HeaderText = "Zarada po satu", ReadOnly = true, FillWeight = 100 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colBrojSati", HeaderText = "Broj sati", FillWeight = 90 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUkupnaZaradaStavka", HeaderText = "Ukupna zarada stavke", ReadOnly = true, FillWeight = 130 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNapomena", HeaderText = "Napomena", FillWeight = 150 });
        }

        private void PrikaciEventove()
        {
            var grid = ucObracunZarade.DataGridView1;
            grid.CellValueChanged += Grid_CellValueChanged;
            grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChanged;
            grid.CellValidating += Grid_CellValidating;
            grid.DataError += Grid_DataError;

            ucObracunZarade.BtnDodajStavku.Click += BtnDodajStavku_Click;
            ucObracunZarade.BtnObrisiStavku.Click += BtnObrisiStavku_Click;
            ucObracunZarade.BtnSacuvaj.Click += BtnSacuvaj_Click;
            ucObracunZarade.ChkStorniran.CheckedChanged += ChkStorniran_CheckedChanged;
        }

        private void Grid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != COL_BROJ_SATI) return;
            string unos = e.FormattedValue?.ToString() ?? "";
            if (string.IsNullOrWhiteSpace(unos)) return;
            if (!int.TryParse(unos, out int brojSati) || brojSati < 0)
            {
                ucObracunZarade.LblError.ForeColor = Color.Red;
                ucObracunZarade.LblError.Text = "Broj sati mora biti ceo pozitivan broj.";
                e.Cancel = true;
            }
            else
            {
                ucObracunZarade.DataGridView1.Rows[e.RowIndex].ErrorText = "";
            }
        }

        private void Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void Grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var grid = ucObracunZarade.DataGridView1;
            if (grid.IsCurrentCellDirty)
                grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void BtnDodajStavku_Click(object sender, EventArgs e)
        {
            var grid = ucObracunZarade.DataGridView1;
            int noviRb = grid.Rows.Count + 1;
            int noviIndeks = grid.Rows.Add();
            grid.Rows[noviIndeks].Cells[COL_RB].Value = noviRb;
            grid.Rows[noviIndeks].Cells[COL_BROJ_SATI].Value = 0;
            grid.Rows[noviIndeks].Cells[COL_UKUPNA_ZARADA_STAVKA].Value = 0m;
        }

        private void BtnObrisiStavku_Click(object sender, EventArgs e)
        {
            var grid = ucObracunZarade.DataGridView1;
            if (grid.CurrentRow == null)
            {
                ucObracunZarade.LblError.ForeColor = Color.Red;
                ucObracunZarade.LblError.Text = "Morate selektovati stavku koju želite da obrišete.";
                return;
            }
            grid.Rows.Remove(grid.CurrentRow);
            OsveziRedneBrojeve();
            OsveziUkupnuZaradu();
        }

        private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != COL_BROJ_SATI && e.ColumnIndex != COL_VRSTA_ZARADE) return;

            var grid = ucObracunZarade.DataGridView1;
            var row = grid.Rows[e.RowIndex];

            int.TryParse(row.Cells[COL_BROJ_SATI].Value?.ToString(), out int brojSati);
            VrstaZarade vrsta = vrsteZarade.FirstOrDefault(v => v.IdVrstaZarade.Equals(row.Cells[COL_VRSTA_ZARADE].Value));

            row.Cells[COL_ZARADA_PO_SATU].Value = vrsta?.ZaradaPoSatu;
            decimal ukupno = vrsta != null ? brojSati * vrsta.ZaradaPoSatu : 0m;
            row.Cells[COL_UKUPNA_ZARADA_STAVKA].Value = ukupno;

            OsveziUkupnuZaradu();
        }

        private void OsveziRedneBrojeve()
        {
            var grid = ucObracunZarade.DataGridView1;
            for (int i = 0; i < grid.Rows.Count; i++)
                grid.Rows[i].Cells[COL_RB].Value = i + 1;
        }

        private void OsveziUkupnuZaradu()
        {
            var grid = ucObracunZarade.DataGridView1;
            decimal ukupno = 0;
            foreach (DataGridViewRow row in grid.Rows)
            {
                decimal.TryParse(row.Cells[COL_UKUPNA_ZARADA_STAVKA].Value?.ToString(), out decimal vrednost);
                ukupno += vrednost;
            }
            ucObracunZarade.LblUkupanIznos.Text = $"Ukupna zarada: {ukupno}";
        }

        private List<StavkaObracunaZarade> PokupiStavkeIzGrida()
        {
            var grid = ucObracunZarade.DataGridView1;
            List<StavkaObracunaZarade> stavke = new List<StavkaObracunaZarade>();

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.IsNewRow) continue;

                object idVrste = row.Cells[COL_VRSTA_ZARADE].Value;
                if (idVrste == null || idVrste == DBNull.Value)
                    throw new Exception($"Morate izabrati vrstu zarade za stavku {row.Cells[COL_RB].Value}.");

                int.TryParse(row.Cells[COL_BROJ_SATI].Value?.ToString(), out int brojSati);
                decimal.TryParse(row.Cells[COL_UKUPNA_ZARADA_STAVKA].Value?.ToString(), out decimal ukupnaZaradaStavka);
                int.TryParse(row.Cells[COL_RB].Value?.ToString(), out int rb);

                VrstaZarade vrsta = vrsteZarade.FirstOrDefault(v => v.IdVrstaZarade.Equals(idVrste))
                    ?? throw new Exception($"Vrsta zarade za stavku {row.Cells[COL_RB].Value} nije validna.");

                stavke.Add(new StavkaObracunaZarade
                {
                    Rb = rb,
                    BrojSati = brojSati,
                    UkupnaZaradaStavka = ukupnaZaradaStavka,
                    Napomena = row.Cells[COL_NAPOMENA].Value?.ToString() ?? "",
                    VrstaZarade = vrsta
                });
            }
            return stavke;
        }



        private void BtnSacuvaj_Click(object sender, EventArgs e)
        {
            ucObracunZarade.LblError.Text = "";
            try
            {
                if (obracunZaIzmenu != null)
                {
                    List<StavkaObracunaZarade> stavke = PokupiStavkeIzGrida();

                    if (stavke.Count == 0)
                    {
                        ucObracunZarade.LblError.ForeColor = Color.Red;
                        ucObracunZarade.LblError.Text = "Sistem ne može da zapamti obračun zarade";
                        return;
                    }

                    obracunZaIzmenu.Napomena = ucObracunZarade.TxtNapomena.Text;
                    obracunZaIzmenu.Storniran = ucObracunZarade.ChkStorniran.Checked;
                    obracunZaIzmenu.UkupnaZarada = stavke.Sum(s => s.UkupnaZaradaStavka);

                    
                    Response res = Communication.Instance.IzmeniObracunZarade(obracunZaIzmenu,stavke);
                    if (!res.isSuccessful)
                    {
                        ucObracunZarade.LblError.ForeColor = Color.Red;
                        ucObracunZarade.LblError.Text = "Sistem ne može da zapamti obračun zarade " + res.Error;
                        return;
                    }

                    ucObracunZarade.LblError.ForeColor = System.Drawing.Color.Green;
                    ucObracunZarade.LblError.Text = "Sistem je zapamtio obračun zarade";
                    string obracunzarade = $"Racunovodja: {((Racunovodja)ucObracunZarade.CbRacunovodja.SelectedItem).ImePrezime}\n" +
                                          $"Zaposleni: {((Zaposleni)ucObracunZarade.CbZaposleni.SelectedItem).ImePrezime}\n" +
                                          $"DatumOd: {ucObracunZarade.DateTimePickerDatumOd.Value.ToString("dd. MM. yyyy")}\n" +
                                          $"DatumDo: {ucObracunZarade.DateTimePickerDatumDo.Value.ToString("dd. MM. yyyy")}\n" +
                                          $"UkupnaZarada: {stavke.Sum(s => s.UkupnaZaradaStavka)}\n" +
                                          $"Napomena: {ucObracunZarade.TxtNapomena.Text}";


                    MessageBox.Show("Sistem je zapamtio obračun zarade\n" + obracunzarade, "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    List<StavkaObracunaZarade> stavke = PokupiStavkeIzGrida();

                    if (stavke.Count == 0)
                    {
                        ucObracunZarade.LblError.ForeColor = Color.Red;
                        ucObracunZarade.LblError.Text = "Morate uneti bar jednu stavku obračuna.";
                        return;
                    }

                    Zaposleni zaposleni = (Zaposleni)ucObracunZarade.CbZaposleni.SelectedItem;
                    Racunovodja racunovodja = (Racunovodja)ucObracunZarade.CbRacunovodja.SelectedItem;

                    if (zaposleni == null)
                    {
                        ucObracunZarade.LblError.ForeColor = Color.Red;
                        ucObracunZarade.LblError.Text = "Morate izabrati zaposlenog.";
                        return;
                    }

                    ObracunZarade oz = new ObracunZarade
                    {
                        DatumOd = ucObracunZarade.DateTimePickerDatumOd.Value,
                        DatumDo = ucObracunZarade.DateTimePickerDatumDo.Value,
                        Napomena = ucObracunZarade.TxtNapomena.Text,
                        UkupnaZarada = stavke.Sum(s => s.UkupnaZaradaStavka),
                        Zaposleni = zaposleni,
                        Racunovodja = racunovodja,
                        Storniran = false
                    };
                    
                    Response res = Communication.Instance.UbaciObracunZarade(oz, stavke);
                    if (!res.isSuccessful)
                    {
                        ucObracunZarade.LblError.ForeColor = Color.Red;
                        ucObracunZarade.LblError.Text = "Greška: " + res.Error;
                        return;
                    }

                    ucObracunZarade.LblError.ForeColor = System.Drawing.Color.Green;
                    ucObracunZarade.LblError.Text = "Sistem je zapamtio obračun zarade.";
                    string obracunzarade = $"Racunovodja: {((Racunovodja)ucObracunZarade.CbRacunovodja.SelectedItem).ImePrezime}\n" +
                                          $"Zaposleni: {((Zaposleni)ucObracunZarade.CbZaposleni.SelectedItem).ImePrezime}\n" +
                                          $"DatumOd: {ucObracunZarade.DateTimePickerDatumOd.Value.ToString("dd. MM. yyyy")}\n" +
                                          $"DatumDo: {ucObracunZarade.DateTimePickerDatumDo.Value.ToString("dd. MM. yyyy")}\n" +
                                          $"UkupnaZarada: {stavke.Sum(s => s.UkupnaZaradaStavka)}\n" +
                                          $"Napomena: {ucObracunZarade.TxtNapomena.Text}";


                    MessageBox.Show("Sistem je zapamtio obračun zarade\n" + obracunzarade, "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OcistiFormu();
                }
            }
            catch (Exception ex)
            {
                ucObracunZarade.LblError.Text = ex.Message;
            }
        }

        private void OcistiFormu()
        {
            ucObracunZarade.CbZaposleni.SelectedIndex = -1;
            ucObracunZarade.TxtNapomena.Text = "";
            ucObracunZarade.DateTimePickerDatumOd.Value = DateTime.Now.AddMonths(-1);
            ucObracunZarade.DateTimePickerDatumDo.Value = DateTime.Now;
            ucObracunZarade.DataGridView1.Rows.Clear();
            ucObracunZarade.LblUkupanIznos.Text = "Ukupna zarada: ";
        }
    }
}