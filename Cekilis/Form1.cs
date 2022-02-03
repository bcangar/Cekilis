using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cekilis
{
    public partial class Form1 : Form
    {

        //List<string> adlar = new List<string>(); try catch te boş liste tanımalaması yaptığımız için aşağıdaki gibi satırı güncelledik.

        List<string> adlar;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            VerileriOku();
            Listele();
            btnYukari.Enabled = false; //Yukarı butonu devre dışı kaldı
        }

        private void VerileriOku()
        {
            try
            {
                adlar = File.ReadAllLines("adlar.txt").ToList();
                //Önceki çalışmadan kayıtlı adlar text ini ,
                //program tekrar açıldığında dizi formatından liste formatına dönüştürerek yazdır.
            }
            catch (Exception)
            {
                adlar = new List<string>();//Eğer hata alırsan, boş listeyle başla 
            }
        }

        void Karistir(List<string> liste)
        {
            int talihliIndeks;
            string gecici;
            for (int i = 0; i < liste.Count; i++)
            {
                talihliIndeks = rnd.Next(i, liste.Count);
                gecici = liste[i];
                liste[i] = liste[talihliIndeks];
                liste[talihliIndeks] = gecici;
            }

        }



        private void btnEkle_Click(object sender, EventArgs e)
        {
            //Hata Kontrolü
            string ad = txtAd.Text.Trim();

            if (ad == "")
            {
                MessageBox.Show("Eklemek için bir ad girmelisiniz!");
                return;
            }

            //Mevcut seçili indeksi not al
            int sid = lstAdlar.SelectedIndex;


            //Verilerin Eklenmesi
            adlar.Add(ad);

            //Formun temizlenmesi
            txtAd.Clear();
            txtAd.Focus();

            //Listbox güncelleme
            Listele();

            //Aynı sıradaki elemanı tekrar seç
            lstAdlar.SelectedIndex = sid;
        }

        private void Listele()
        {
            lstAdlar.Items.Clear();

            foreach (string ad in adlar)
                lstAdlar.Items.Add(ad);
        }

        private void txtAd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                //ENTER tuşuna basılmamış gibi gösteriyor.(ENTER a bastığında pc bildirim sesi gelmeyecek.)
                btnEkle.PerformClick();
            }
        }

        private void btnCekilis_Click(object sender, EventArgs e)
        {
            if (adlar.Count == 0) return;
            Karistir(adlar);
            lblSonuc.Text = adlar[0];
            if (chkKaldir.Checked)
                adlar.RemoveAt(0);
            Listele();
        }

        private void lstAdlar_KeyDown(object sender, KeyEventArgs e)
        {
            int sid = lstAdlar.SelectedIndex;
            if (e.KeyCode == Keys.Delete && sid > -1)
            {
                adlar.RemoveAt(sid);
                Listele();
                lstAdlar.SelectedIndex = sid < lstAdlar.Items.Count ? sid : lstAdlar.Items.Count - 1; //Listeden seçili eleman silindiğinde, silinen elemanın yerine altındaki eleman gelsin.Altında eleman kalmazsa,son kalan eleman silinerek devam edilsin.(Uygulayarak incele)
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                text: "Program kapatılacaktır.Değişiklikleri kaydetmek istiyor musunuz?",
                caption: "Çekiliş",
                buttons: MessageBoxButtons.YesNoCancel,
                icon: MessageBoxIcon.Question,
                defaultButton: MessageBoxDefaultButton.Button3);

            switch (dr)
            {
                case DialogResult.Cancel:
                    e.Cancel = true; //Formun kapatma event ini iptal eder.
                    break;

                case DialogResult.Yes:
                    File.WriteAllLines("adlar.txt", adlar); //Kaydetme işlemi gerçekleşir.
                    break;
                case DialogResult.No:
                    break;

            }

        }

        private void btnYukari_Click(object sender, EventArgs e)
        {
            int sid = lstAdlar.SelectedIndex;
            if (sid < 1) return;
            string gecici = adlar[sid - 1];
            adlar[sid - 1] = adlar[sid];
            adlar[sid] = gecici;
            Listele();
            lstAdlar.SelectedIndex = sid - 1;

        }

        private void btnAsagi_Click(object sender, EventArgs e)
        {

            int sid = lstAdlar.SelectedIndex;
            if (sid < 0 || sid == adlar.Count - 1) return; //sid<0 -> hiç seçim yapılmazsa değişim olmasın
            string gecici = adlar[sid + 1];
            adlar[sid + 1] = adlar[sid];
            adlar[sid] = gecici;
            Listele();
            lstAdlar.SelectedIndex = sid + 1;
        }

        private void lstAdlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnYukari.Enabled = lstAdlar.SelectedIndex > 0; //durum böyleyse TRUE getirir,butona tıklanabilir.
            btnAsagi.Enabled = lstAdlar.SelectedIndex != lstAdlar.Items.Count - 1;
        }
    }
}
