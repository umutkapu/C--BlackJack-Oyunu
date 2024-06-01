using System;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class GameScreen : Form
    {
        Random random = new Random();
        int aceCount = 0;
        int aceCountDealer = 0;
        int sayac = 0;
        int toplam = 0;
        int kasaToplam = 0;
        int[] oyuncuKartlar = new int[6];
        int[] kasaKartlar = new int[6];
        int oyuncuPuan = 0, kasaPuan = 0;
        string[] suits = { "clubs", "diamonds", "hearts", "spades" };
        string dosyaYolu = @"C:\Users\umutk\Dropbox\PC\Desktop\BlackJack\kartIndır1\kartIndır1\playing_cards\";

        public GameScreen()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            if(oyuncuPuan == 0)
            {
                oyuncuSkorTablosu.Text = "OYUNCU: " + oyuncuPuan.ToString();
            }
            if(kasaPuan == 0)
            {
                kasaSkorTablosu.Text="KASA: "+kasaPuan.ToString();
            }

            ilk2Kart();
            KartGoster(pictureBox3, oyuncuKartlar[0]);
            KartGoster(pictureBox2, oyuncuKartlar[1]);
            labelGizle();
            ilkKartDurumu();
        }

        private void labelGizle()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
        }

        private void cekButton_Click(object sender, EventArgs e)
        {
            sayac++;
            if (sayac == 1)
            {
                oyuncuKartlar[2] = random.Next(1, 11);
                label3.Text = oyuncuKartlar[2].ToString();
                KartGoster(pictureBox8, oyuncuKartlar[2]);
                pictureBox8.Visible = true;
                toplam = KartDegeriniEkle(oyuncuKartlar[2], toplam);
                oyuncuSkor.Text = toplam.ToString();

            }
            else if (sayac == 2)
            {
                oyuncuKartlar[3] = random.Next(1, 11);
                label4.Text = oyuncuKartlar[3].ToString();
                KartGoster(pictureBox7, oyuncuKartlar[3]);
                pictureBox7.Visible = true;
                toplam = KartDegeriniEkle(oyuncuKartlar[3], toplam);
                oyuncuSkor.Text = toplam.ToString();

            }
            else if (sayac == 3)
            {
                oyuncuKartlar[4] = random.Next(1, 11);
                label5.Text = oyuncuKartlar[4].ToString();
                KartGoster(pictureBox6, oyuncuKartlar[4]);
                pictureBox6.Visible = true;
                toplam = KartDegeriniEkle(oyuncuKartlar[4], toplam);
                oyuncuSkor.Text = toplam.ToString();
                if (toplam < 21)
                {
                    label13.Size = new Size(150, 80);
                    label13.Text = "5 KART OYUNU!";
                    label13.Visible = true;
                    cekButton.Visible = false;
                    kalButton.Visible = false;
                    oyuncuPuan++;
                    oyuncuSkorGoster();
                }

            }
            else if (sayac == 4)
            {
                oyuncuKartlar[5] = random.Next(1, 11);
                label6.Text = oyuncuKartlar[5].ToString();
                KartGoster(pictureBox9, oyuncuKartlar[5]);
                pictureBox9.Visible = true;
                toplam = KartDegeriniEkle(oyuncuKartlar[5], toplam);
                oyuncuSkor.Text = toplam.ToString();

            }
        }

        void oyuncuSkorGoster()
        {
            oyuncuSkorTablosu.Text = "OYUNCU: " + oyuncuPuan.ToString();
            CheckGameOver();
        }

        void kasaSkorGoster()
        {
            kasaSkorTablosu.Text="KASA: "+kasaPuan.ToString();
            CheckGameOver();
        }

        private void CheckGameOver()
        {
            if (oyuncuPuan >= 5)
            {
                MessageBox.Show("OYUN BİTTİ! OYUNCU KAZANDI!");
                cekButton.Enabled = false;
                kalButton.Enabled = false;
                restartButton.Enabled = false;
            }
            else if (kasaPuan >= 5)
            {
                MessageBox.Show("OYUN BİTTİ! KASA KAZANDI!");
                cekButton.Enabled = false;
                kalButton.Enabled = false;
                restartButton.Enabled = false;
            }
        }
        private void ilk2Kart()
        {
            oyuncuKartlar[0] = random.Next(1, 11);
            oyuncuKartlar[1] = random.Next(1, 11);
            label1.Text = oyuncuKartlar[0].ToString();
            label2.Text = oyuncuKartlar[1].ToString();
            toplam = KartDegeriniEkle(oyuncuKartlar[0], toplam);
            toplam = KartDegeriniEkle(oyuncuKartlar[1], toplam);
            oyuncuSkor.Text = toplam.ToString();
          
            if (toplam == 21)
            {
                label13.Size = new Size(150, 80);
                label13.Text = "BLACKJACK!";
                label13.Visible = true;
                cekButton.Enabled = false;
                kalButton.Enabled = false;
                oyuncuPuan++;
                oyuncuSkorGoster();
            }
        }

        private void kasaIlk2Kart()
        {
            kasaKartlar[0] = random.Next(1, 11);
            kasaKartlar[1] = random.Next(1, 11);
            label7.Text = kasaKartlar[0].ToString();
            label8.Text = kasaKartlar[1].ToString();
            kasaToplam = KartDegeriniEkleKasa(kasaKartlar[0], kasaToplam);
            kasaToplam = KartDegeriniEkleKasa(kasaKartlar[1], kasaToplam);
            kasaSkor.Text = kasaToplam.ToString();
            KartGoster(pictureBox5, kasaKartlar[1]);
            
            if(kasaToplam == 21)
            {
                label13.Size = new Size(150, 80);
                label13.Text = "BLACKJACK!";
                label13.Visible = true;
                cekButton.Enabled = false;
                kalButton.Enabled = false;
                kasaPuan++;
                kasaSkorGoster();
            }
            dealerPlay();
        }


        void KartGoster(PictureBox pictureBox, int kart)
        {
            string randomSuit = suits[random.Next(suits.Length)];
            string kartDosyasi = kart + "_of_" + randomSuit + ".png";
            if (kart == 1)
            {
                kartDosyasi = "ace_of_" + randomSuit + ".png";
            }
            pictureBox.Image = Image.FromFile(dosyaYolu + kartDosyasi);
        }

        private int KartDegeriniEkle(int kart, int mevcutToplam)
        {
            if (kart == 1)
            {
                aceCount++;
                mevcutToplam += 11;
            }
            else
            {
                mevcutToplam += kart;
            }

            while (mevcutToplam > 21 && aceCount > 0)
            {
                mevcutToplam -= 10;
                aceCount--;
            }

            return mevcutToplam;
        }

        private int KartDegeriniEkleKasa(int kart, int mevcutToplam)
        {
            if (kart == 1)
            {
                aceCountDealer++;
                mevcutToplam += 11;
            }
            else
            {
                mevcutToplam += kart;
            }

            while (mevcutToplam > 21 && aceCountDealer > 0)
            {
                mevcutToplam -= 10;
                aceCountDealer--;
            }

            return mevcutToplam;
        }

        private void ilkKartDurumu()
        {
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            pictureBox11.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
        }

        private void dealerPlay()
        {
            int i = 2;
            while (kasaToplam < 17 && i < 6)
            {
                kasaKartlar[i] = random.Next(1, 11);
                kasaToplam = KartDegeriniEkleKasa(kasaKartlar[i], kasaToplam);
                KartGoster((PictureBox)Controls.Find("pictureBox" + (8 + i), true)[0], kasaKartlar[i]);
                Controls.Find("pictureBox" + (8 + i), true)[0].Visible = true;
                kasaSkor.Text = kasaToplam.ToString();
                i++;
            }
            determineWinner();
        }

        private void determineWinner()
        {
            if (kasaToplam > 21 && toplam <= 21)
            {
                label13.Text = "OYUNCU KAZANDI!";
                oyuncuPuan++;
                oyuncuSkorGoster();
            }
            else if (toplam > 21 && kasaToplam <= 21)
            {
                label13.Text = "KASA KAZANDI!";
                kasaPuan++;
                kasaSkorGoster();
            }
            else if (toplam <= 21 && kasaToplam <= 21)
            {
                if (kasaToplam > toplam)
                {
                    label13.Text = "KASA KAZANDI!";
                    kasaPuan++;
                    kasaSkorGoster();
                }
                else if (kasaToplam == toplam)
                {
                    label13.Text = "BERABERE!";
                }
                else
                {
                    label13.Text = "OYUNCU KAZANDI!";
                    oyuncuPuan++;
                    oyuncuSkorGoster();
                }
            }
            else
            {
                label13.Text = "BERABERE!";
            }
            label13.Visible = true;
        }

        private void kalButton_Click(object sender, EventArgs e)
        {
            cekButton.Enabled = false;
            kalButton.Enabled = false;
            kasaIlk2Kart();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            aceCount = 0;
            aceCountDealer = 0;
            sayac = 0;
            toplam = 0;
            kasaToplam = 0;
            oyuncuKartlar = new int[6];
            kasaKartlar = new int[6];



            cekButton.Enabled = true;
            kalButton.Enabled = true;
            cekButton.Visible = true;
            kalButton.Visible = true;
            oyuncuSkor.Text = "0";
            kasaSkor.Text = "0";
            label13.Visible = false;

            StartGame();
        }


    }
}
