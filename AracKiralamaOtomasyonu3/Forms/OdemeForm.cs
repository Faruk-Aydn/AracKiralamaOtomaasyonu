﻿using System;
using System.Windows.Forms;

namespace AracKiralamaOtomasyonu3
{
    public partial class OdemeForm : Form
    {
        public bool OdemeBasarili { get; private set; }

        public OdemeForm()
        {
            InitializeComponent();
            OdemeBasarili = false;
        }

        private void btnOdemeYap_Click(object sender, EventArgs e)
        {
            // Kart numarasının 16 haneli olup olmadığını kontrol et
            if (txtKartNumarasi.Text.Length != 16 || !long.TryParse(txtKartNumarasi.Text, out _))
            {
                MessageBox.Show("Geçersiz kart numarası. 16 haneli bir kart numarası girin.", "Ödeme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // CVV'nin 3 haneli olup olmadığını kontrol et
            if (txtCVV.Text.Length != 3 || !int.TryParse(txtCVV.Text, out _))
            {
                MessageBox.Show("Geçersiz CVV. 3 haneli bir CVV girin.", "Ödeme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Son kullanma tarihinin geçmişte olup olmadığını kontrol et
            if (dtpSonKullanmaTarihi.Value <= DateTime.Now)
            {
                MessageBox.Show("Kartın son kullanma tarihi geçmiş.", "Ödeme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kart sahibi adının boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(txtKartSahibi.Text))
            {
                MessageBox.Show("Kart sahibinin adını girin.", "Ödeme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tüm kontroller geçildiyse
            MessageBox.Show("Ödeme başarıyla tamamlandı!", "Ödeme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OdemeBasarili = true;
            this.Close();
        }
    }
}