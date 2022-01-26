using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Pacaneaua
{
    public partial class Game : Form
    {
        public static int bet = 10, credits = 1000;
        public static float totalWin = 0;
        public static int p1, p2, p3, p4, p5;
        SoundPlayer rollSound = new SoundPlayer(@"C:\Users\filip\source\repos\Pacaneaua\Pacaneaua\roll.wav");
        SoundPlayer lilWinSound = new SoundPlayer(@"C:\Users\filip\source\repos\Pacaneaua\Pacaneaua\lilWin.wav");
        SoundPlayer bigWinSound = new SoundPlayer(@"C:\Users\filip\source\repos\Pacaneaua\Pacaneaua\bigWin.wav");

        public static class IntUtil
        {
            private static Random random;

            private static void Init()
            {
                if (random == null) random = new Random();
            }

            public static int Random(int min,int max)
            {
                Init();
                return random.Next(min, max);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btn_plus_Click_1(object sender, EventArgs e)
        {
            if (bet > 0 && bet < 1000)
            {
                bet += 10;



                if (bet >= 1000)
                    bet = 1000;
                lbl_Bet.Text = bet.ToString();
            }
        }

        private void btn_minus_Click_1(object sender, EventArgs e)
        {
            if (bet > 10)
            {
                bet -= 10;
                lbl_Bet.Text = bet.ToString();
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            bigWinSound.Stop();
            lilWinSound.Stop();
            rollSound.Play();


            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;

            if (credits >= bet)
            {
                credits -= bet;
                lbl_Credits.Text = credits.ToString();

                for (var i = 0; i < 10; i++)
                {
                    p1 = IntUtil.Random(1, 9);
                    p2 = IntUtil.Random(1, 9);
                    p3 = IntUtil.Random(1, 9);
                    p4 = IntUtil.Random(1, 9);
                    p5 = IntUtil.Random(1, 9);
                }

                if (pictureBox1.Image != null)
                    pictureBox1.Image.Dispose();
                pictureBox1.Image = Image.FromFile(p1.ToString() + ".png");

                if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
                pictureBox2.Image = Image.FromFile(p2.ToString() + ".png");

                if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                pictureBox3.Image = Image.FromFile(p3.ToString() + ".png");

                if (pictureBox4.Image != null) pictureBox4.Image.Dispose();
                pictureBox4.Image = Image.FromFile(p4.ToString() + ".png");

                if (pictureBox5.Image != null) pictureBox5.Image.Dispose();
                pictureBox5.Image = Image.FromFile(p5.ToString() + ".png");

                /////3 OF A KIND
                if ((p1 == 1 && p2 == 1 && p3 == 1) || (p1 == 8 && p2 == 1 && p3 == 1) 
                    || (p1 == 1 && p2 == 8 && p3 == 1) || (p1 == 1 && p2 == 1 && p3 == 8) 
                    || (p1==8 && p2==8 && p3==1) || (p1 == 8 && p2 == 1 && p3 == 8) || (p1 == 1 && p2 == 8 && p3 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    totalWin = bet * 15;
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();

                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();

                }///BARS

                if ((p1 == 2 && p2 == 2 && p3 == 2) || (p1 == 8 && p2 == 2 && p3 == 2) 
                    || (p1 == 2 && p2 == 8 && p3 == 2) || (p1 == 2 && p2 == 2 && p3 == 8) 
                    || (p1 == 8 && p2 == 8 && p3 == 2) || (p1==8 && p2==2 && p3==8) || (p1==2 && p2==8 && p3==8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    totalWin = bet * 3;
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///CHERRIES

                if ((p1 == 3 && p2 == 3 && p3 == 3) || (p1 == 8 && p2 == 3 && p3 == 3) 
                    || (p1 == 3 && p2 == 8 && p3 == 3) || (p1 == 3 && p2 == 3 && p3 == 8) 
                    || (p1 == 8 && p2 == 8 && p3 == 3) || (p1 == 8 && p2 == 3 && p3 == 8) || (p1 == 3 && p2 == 8 && p3 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 4);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///BELLS

                if ((p1 == 4 && p2 == 4 && p3 == 4) || (p1 == 8 && p2 == 4 && p3 == 4) 
                    || (p1 == 4 && p2 == 8 && p3 == 4) || (p1 == 4 && p2 == 4 && p3 == 8) 
                    || (p1 == 8 && p2 == 8 && p3 == 4) || (p1 == 8 && p2 == 4 && p3 == 8) || (p1 == 4 && p2 == 8 && p3 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 100);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///COINS

                if ((p1 == 5 && p2 == 5 && p3 == 5) || (p1 == 8 && p2 == 5 && p3 == 5) 
                    || (p1 == 5 && p2 == 8 && p3 == 5) || (p1 == 5 && p2 == 5 && p3 == 8) 
                    || (p1 == 8 && p2 == 8 && p3 == 5) || (p1 == 8 && p2 == 5 && p3 == 8) || (p1 == 5 && p2 == 8 && p3 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 3.5);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///LEMONS

                if ((p1 == 6 && p2 == 6 && p3 == 6) || (p1 == 8 && p2 == 6 && p3 == 6)
                    || (p1 == 6 && p2 == 8 && p3 == 6) || (p1 == 6 && p2 == 6 && p3 == 8)
                    || (p1 == 8 && p2 == 8 && p3 == 6) || (p1 == 8 && p2 == 6 && p3 == 8) || (p1 == 6 && p2 == 8 && p3 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 2);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///APPLES

                if ((p1 == 7 && p2 == 7 && p3 == 7) || (p1 == 8 && p2 == 7 && p3 == 7)
                   || (p1 == 7 && p2 == 8 && p3 == 7) || (p1 == 7 && p2 == 7 && p3 == 8)
                   || (p1 == 8 && p2 == 8 && p3 == 7) || (p1 == 8 && p2 == 7 && p3 == 8) || (p1 == 7 && p2 == 8 && p3 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 5);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///PLUMS

                /////4 OF A KIND



                if ((p1 == 1 && p2 == 1 && p3 == 1 && p4 == 1) || (p1 == 8 && p2 == 1 && p3 == 1 && p4 == 1)
                   || (p1 == 1 && p2 == 8 && p3 == 1 && p4 == 1) || (p1 == 1 && p2 == 1 && p3 == 8 && p4 == 1)
                   || (p1 == 1 && p2 == 1 && p3 == 1 && p4 == 8) || (p1 == 8 && p2 == 8 && p3 == 1 && p4 == 1)
                   || (p1 == 8 && p2 == 1 && p3 == 8 && p4 == 1) || (p1 == 1 && p2 == 8 && p3 == 8 && p4 == 1)
                   || (p1 == 1 && p2 == 8 && p3 == 1 && p4 == 8) || (p1 == 1 && p2 == 1 && p3 == 8 && p4 == 8) || (p1 == 8 && p2 == 1 && p3 == 1 && p4 == 8)
                   || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 1) || (p1 == 8 && p2 == 8 && p3 == 1 && p4 == 8)
                   || (p1 == 8 && p2 == 1 && p3 == 8 && p4 == 8) || (p1 == 1 && p2 == 8 && p3 == 8 && p4 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 25);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///BARS

                if ((p1 == 2 && p2 == 2 && p3 == 2 && p4 == 2) || (p1 == 8 && p2 == 2 && p3 == 2 && p4 == 2)
                   || (p1 == 2 && p2 == 8 && p3 == 2 && p4 == 2) || (p1 == 2 && p2 == 2 && p3 == 8 && p4 == 2)
                   || (p1 == 2 && p2 == 2 && p3 == 2 && p4 == 8) || (p1 == 8 && p2 == 8 && p3 == 2 && p4 == 2)
                   || (p1 == 8 && p2 == 2 && p3 == 8 && p4 == 2) || (p1 == 2  && p2 == 8 && p3 == 8 && p4 == 2) || (p1 == 8 && p2 == 2 && p3 == 2 && p4 == 8)
                   || (p1 == 2 && p2 == 8 && p3 == 2 && p4 == 8) || (p1 == 2 && p2 == 2 && p3 == 8 && p4 == 8)
                   || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 2) || (p1 == 8 && p2 == 8 && p3 == 2 && p4 == 8)
                   || (p1 == 8 && p2 == 2 && p3 == 8 && p4 == 8) || (p1 == 2 && p2 == 8 && p3 == 8 && p4 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 6);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///CHERRIES

                if ((p1 == 3 && p2 == 3 && p3 == 3 && p4 == 3) || (p1 == 8 && p2 == 3 && p3 == 3 && p4 == 3)
                   || (p1 == 3 && p2 == 8 && p3 == 3 && p4 == 3) || (p1 == 3 && p2 == 3 && p3 == 8 && p4 == 3)
                   || (p1 == 3 && p2 == 3 && p3 == 3 && p4 == 3) || (p1 == 8 && p2 == 8 && p3 == 3 && p4 == 3)
                   || (p1 == 8 && p2 == 3 && p3 == 8 && p4 == 3) || (p1 == 3 && p2 == 8 && p3 == 8 && p4 == 3) || (p1==8 && p2==3 && p3==3 && p4==8)
                   || (p1 == 3 && p2 == 8 && p3 == 3 && p4 == 8) || (p1 == 3 && p2 == 3 && p3 == 8 && p4 == 8)
                   || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 3) || (p1 == 8 && p2 == 8 && p3 == 3 && p4 == 8)
                   || (p1 == 8 && p2 == 3 && p3 == 8 && p4 == 8) || (p1 == 3 && p2 == 8 && p3 == 8 && p4 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 9);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///BELLS

                if ((p1 == 4 && p2 == 4 && p3 == 4 && p4 == 4) || (p1 == 8 && p2 == 4 && p3 == 4 && p4 == 4)
                   || (p1 == 4 && p2 == 8 && p3 == 4 && p4 == 4) || (p1 == 4 && p2 == 4 && p3 == 8 && p4 == 4)
                   || (p1 == 4 && p2 == 4 && p3 == 4 && p4 == 8) || (p1 == 8 && p2 == 8 && p3 == 4 && p4 == 4)
                   || (p1 == 8 && p2 == 4 && p3 == 8 && p4 == 4) || (p1 == 4 && p2 == 8 && p3 == 8 && p4 == 4) || (p1 == 8 && p2 == 4 && p3 == 4 && p4 == 8)
                   || (p1 == 4 && p2 == 8 && p3 == 4 && p4 == 8) || (p1 == 4 && p2 == 4 && p3 == 8 && p4 == 8)
                   || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 4) || (p1 == 8 && p2 == 8 && p3 == 4 && p4 == 8)
                   || (p1 == 8 && p2 == 4 && p3 == 8 && p4 == 8) || (p1 == 4 && p2 == 8 && p3 == 8 && p4 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 250);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    bigWinSound.Play();
                }///COINS

                if ((p1 == 5 && p2 == 5 && p3 == 5 && p4 == 5) || (p1 == 8 && p2 == 5 && p3 == 5 && p4 == 5)
                   || (p1 == 5 && p2 == 8 && p3 == 5 && p4 == 5) || (p1 == 5 && p2 == 5 && p3 == 8 && p4 == 5)
                   || (p1 == 5 && p2 == 5 && p3 == 5 && p4 == 8) || (p1 == 8 && p2 == 8 && p3 == 5 && p4 == 5)
                   || (p1 == 8 && p2 == 5 && p3 == 8 && p4 == 5) || (p1 == 5 && p2 == 8 && p3 == 8 && p4 == 5)
                   || (p1 == 5 && p2 == 8 && p3 == 5 && p4 == 8) || (p1 == 5 && p2 == 5 && p3 == 8 && p4 == 8) || (p1 == 8 && p2 == 5 && p3 == 5 && p4 == 8)
                   || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 5) || (p1 == 8 && p2 == 8 && p3 == 5 && p4 == 8)
                   || (p1 == 8 && p2 == 5 && p3 == 8 && p4 == 8) || (p1 == 5 && p2 == 8 && p3 == 8 && p4 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 8);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///LEMONS

                if ((p1 == 6 && p2 == 6 && p3 == 6 && p4 == 6) || (p1 == 8 && p2 == 6 && p3 == 6 && p4 == 6)
                   || (p1 == 6 && p2 == 8 && p3 == 6 && p4 == 6) || (p1 == 6 && p2 == 6 && p3 == 8 && p4 == 6)
                   || (p1 == 6 && p2 == 6 && p3 == 6 && p4 == 8) || (p1 == 8 && p2 == 8 && p3 == 6 && p4 == 6)
                   || (p1 == 8 && p2 == 6 && p3 == 8 && p4 == 6) || (p1 == 6 && p2 == 8 && p3 == 8 && p4 == 6)
                   || (p1 == 6 && p2 == 8 && p3 == 6 && p4 == 8) || (p1 == 6 && p2 == 6 && p3 == 8 && p4 == 8) || (p1 == 8 && p2 == 6 && p3 == 6 && p4 == 8)
                   || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 6) || (p1 == 8 && p2 == 8 && p3 == 6 && p4 == 8)
                   || (p1 == 8 && p2 == 6 && p3 == 8 && p4 == 8) || (p1 == 6 && p2 == 8 && p3 == 8 && p4 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet *7.5);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///APPLES


                if ((p1 == 7 && p2 == 7 && p3 == 7 && p4 == 7) || (p1 == 8 && p2 == 7 && p3 == 7 && p4 == 7)
                   || (p1 == 7 && p2 == 8 && p3 == 7 && p4 == 7) || (p1 == 7 && p2 == 7 && p3 == 8 && p4 == 7)
                   || (p1 == 7 && p2 == 7 && p3 == 7 && p4 == 8) || (p1 == 8 && p2 == 8 && p3 == 7 && p4 == 7)
                   || (p1 == 8 && p2 == 7 && p3 == 8 && p4 == 7) || (p1 == 7 && p2 == 8 && p3 == 8 && p4 == 7)
                   || (p1 == 7 && p2 == 8 && p3 == 7 && p4 == 8) || (p1 == 7 && p2 == 7 && p3 == 8 && p4 == 8) || (p1 == 8 && p2 == 7 && p3 == 7 && p4 == 8)
                   || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 7) || (p1 == 8 && p2 == 8 && p3 == 7 && p4 == 8)
                   || (p1 == 8 && p2 == 7 && p3 == 8 && p4 == 8) || (p1 == 7 && p2 == 8 && p3 == 8 && p4 == 8))
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 12);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///PLUMS

                 ///5 OF A KIND FULL

                if ((p1 == 1 && p2 == 1 && p3 == 1 && p4 == 1 && p5 == 1)
                      || (p1 == 8 && p2 == 1 && p3 == 1 && p4 == 1 && p5 == 1)
                      || (p1 == 1 && p2 == 8 && p3 == 1 && p4 == 1 && p5 == 1) || (p1 == 1 && p2 == 1 && p3 == 8 && p4 == 1 && p5 == 1)
                      || (p1 == 1 && p2 == 1 && p3 == 1 && p4 == 8 && p5 == 1) || (p1 == 1 && p2 == 1 && p3 == 1 && p4 == 1 && p5 == 8)
                      || (p1 == 8 && p2 == 8 && p3 == 1 && p4 == 1 && p5 == 1) || (p1 == 8 && p2 == 1 && p3 == 8 && p4 == 1 && p5 == 1)
                      || (p1 == 8 && p2 == 1 && p3 == 1 && p4 == 8 && p5 == 1) || (p1 == 8 && p2 == 1 && p3 == 1 && p4 == 1 && p5 == 8)
                      || (p1 == 1 && p2 == 8 && p3 == 8 && p4 == 1 && p5 == 1) || (p1 == 1 && p2 == 8 && p3 == 1 && p4 == 8 && p5 == 1)
                      || (p1 == 1 && p2 == 8 && p3 == 1 && p4 == 1 && p5 == 8) || (p1 == 1 && p2 == 1 && p3 == 8 && p4 == 8 && p5 == 1)
                      || (p1 == 1 && p2 == 1 && p3 == 8 && p4 == 1 && p5 == 8) || (p1 == 1 && p2 == 1 && p3 == 1 && p4 == 8 && p5 == 8)///2 TRIF
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 1 && p5 == 1) || (p1 == 8 && p2 == 8 && p3 == 1 && p4 == 8 && p5 == 1)
                      || (p1 == 8 && p2 == 8 && p3 == 1 && p4 == 1 && p5 == 8) || (p1 == 8 && p2 == 1 && p3 == 8 && p4 == 8 && p5 == 1)
                      || (p1 == 8 && p2 == 1 && p3 == 8 && p4 == 1 && p5 == 8) || (p1 == 8 && p2 == 1 && p3 == 1 && p4 == 8 && p5 == 8)
                      || (p1 == 1 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 1) || (p1 == 1 && p2 == 8 && p3 == 1 && p4 == 8 && p5 == 8)
                      || (p1 == 1 && p2 == 1 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 1 && p2 == 8 && p3 == 8 && p4 == 1 && p5 == 8)///3 TRIF 
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 1) || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 1 && p5 == 8)
                      || (p1 == 8 && p2 == 1 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 8 && p2 == 8 && p3 == 1 && p4 == 8 && p5 == 8)
                      || (p1 == 1 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 8))///4 TRIF
                {
                     pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 40);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///BARS


                if ((p1 == 2 && p2 == 2 && p3 == 2 && p4 == 2 && p5 == 2)
                      || (p1 == 8 && p2 == 2 && p3 == 2 && p4 == 2 && p5 == 2)
                      || (p1 == 2 && p2 == 8 && p3 == 2 && p4 == 2 && p5 == 2) || (p1 == 2 && p2 == 2 && p3 == 8 && p4 == 2 && p5 == 2)
                      || (p1 == 2 && p2 == 2 && p3 == 2 && p4 == 8 && p5 == 2) || (p1 == 2 && p2 == 2 && p3 == 2 && p4 == 2 && p5 == 8)
                      || (p1 == 8 && p2 == 8 && p3 == 2 && p4 == 2 && p5 == 2) || (p1 == 8 && p2 == 2 && p3 == 8 && p4 == 2 && p5 == 2)
                      || (p1 == 8 && p2 == 2 && p3 == 2 && p4 == 8 && p5 == 2) || (p1 == 8 && p2 == 2 && p3 == 2 && p4 == 2 && p5 == 8)
                      || (p1 == 2 && p2 == 8 && p3 == 8 && p4 == 2 && p5 == 2) || (p1 == 2 && p2 == 8 && p3 == 2 && p4 == 8 && p5 == 2)
                      || (p1 == 2 && p2 == 8 && p3 == 2 && p4 == 2 && p5 == 8) || (p1 == 2 && p2 == 2 && p3 == 8 && p4 == 8 && p5 == 2)
                      || (p1 == 2 && p2 == 2 && p3 == 8 && p4 == 2 && p5 == 8) || (p1 == 2 && p2 == 2 && p3 == 2 && p4 == 8 && p5 == 8)///2 TRIF
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 2 && p5 == 2) || (p1 == 8 && p2 == 8 && p3 == 2 && p4 == 8 && p5 == 2)
                      || (p1 == 8 && p2 == 8 && p3 == 2 && p4 == 2 && p5 == 8) || (p1 == 8 && p2 == 2 && p3 == 8 && p4 == 8 && p5 == 2)
                      || (p1 == 8 && p2 == 2 && p3 == 8 && p4 == 2 && p5 == 8) || (p1 == 8 && p2 == 2 && p3 == 2 && p4 == 8 && p5 == 8)
                      || (p1 == 2 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 2) || (p1 == 2 && p2 == 8 && p3 == 2 && p4 == 8 && p5 == 8)
                      || (p1 == 2 && p2 == 2 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 2 && p2 == 8 && p3 == 8 && p4 == 2 && p5 == 8)///3 TRIF 
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 2) || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 2 && p5 == 8)
                      || (p1 == 8 && p2 == 2 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 8 && p2 == 8 && p3 == 2 && p4 == 8 && p5 == 8)
                      || (p1 == 2 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 8))///4 TRIF
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 10);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///CHERRIES


                if ((p1 == 3 && p2 == 3 && p3 == 3 && p4 == 3 && p5 == 3)
                      || (p1 == 8 && p2 == 3 && p3 == 3 && p4 == 3 && p5 == 3)
                      || (p1 == 3 && p2 == 8 && p3 == 3 && p4 == 3 && p5 == 3) || (p1 == 3 && p2 == 3 && p3 == 8 && p4 == 3 && p5 == 3)
                      || (p1 == 3 && p2 == 3 && p3 == 3 && p4 == 8 && p5 == 3) || (p1 == 3 && p2 == 3 && p3 == 3 && p4 == 3 && p5 == 8)
                      || (p1 == 8 && p2 == 8 && p3 == 3 && p4 == 3 && p5 == 3) || (p1 == 8 && p2 == 3 && p3 == 8 && p4 == 3 && p5 == 3)
                      || (p1 == 8 && p2 == 3 && p3 == 3 && p4 == 8 && p5 == 3) || (p1 == 8 && p2 == 3 && p3 == 3 && p4 == 3 && p5 == 8)
                      || (p1 == 3 && p2 == 8 && p3 == 8 && p4 == 3 && p5 == 3) || (p1 == 3 && p2 == 8 && p3 == 3 && p4 == 8 && p5 == 3)
                      || (p1 == 3 && p2 == 8 && p3 == 3 && p4 == 3 && p5 == 8) || (p1 == 3 && p2 == 3 && p3 == 8 && p4 == 8 && p5 == 3)
                      || (p1 == 3 && p2 == 3 && p3 == 8 && p4 == 3 && p5 == 8) || (p1 == 3 && p2 == 3 && p3 == 3 && p4 == 8 && p5 == 8)///2 TRIF
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 3 && p5 == 3) || (p1 == 8 && p2 == 8 && p3 == 3 && p4 == 8 && p5 == 3)
                      || (p1 == 8 && p2 == 8 && p3 == 3 && p4 == 3 && p5 == 8) || (p1 == 8 && p2 == 3 && p3 == 8 && p4 == 8 && p5 == 3)
                      || (p1 == 8 && p2 == 3 && p3 == 8 && p4 == 3 && p5 == 8) || (p1 == 8 && p2 == 3 && p3 == 3 && p4 == 8 && p5 == 8)
                      || (p1 == 3 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 3) || (p1 == 3 && p2 == 8 && p3 == 3 && p4 == 8 && p5 == 8)
                      || (p1 == 3 && p2 == 3 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 3 && p2 == 8 && p3 == 8 && p4 == 3 && p5 == 8)///3 TRIF 
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 3) || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 3 && p5 == 8)
                      || (p1 == 8 && p2 == 3 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 8 && p2 == 8 && p3 == 3 && p4 == 8 && p5 == 8)
                      || (p1 == 3 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 8))///4 TRIF
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 20);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///BELLS


                if ((p1 == 4 && p2 == 4 && p3 == 4 && p4 == 4 && p5 == 4) 
                      || (p1 == 8 && p2 == 4 && p3 == 4 && p4 == 4 && p5 == 4)
                      || (p1 == 4 && p2 == 8 && p3 == 4 && p4 == 4 && p5 == 4) || (p1 == 4 && p2 == 4 && p3 == 8 && p4 == 4 && p5 == 4)
                      || (p1 == 4 && p2 == 4 && p3 == 4 && p4 == 8 && p5 == 4) || (p1 == 4 && p2 == 4 && p3 == 4 && p4 == 4 && p5 == 8) 
                      || (p1 == 8 && p2 == 8 && p3 == 4 && p4 == 4 && p5 == 4) || (p1 == 8 && p2 == 4 && p3 == 8 && p4 == 4 && p5 == 4)
                      || (p1 == 8 && p2 == 4 && p3 == 4 && p4 == 8 && p5 == 4) || (p1 == 8 && p2 == 4 && p3 == 4 && p4 == 4 && p5 == 8)
                      || (p1 == 4 && p2 == 8 && p3 == 8 && p4 == 4 && p5 == 4) || (p1 == 4 && p2 == 8 && p3 == 4 && p4 == 8 && p5 == 4)
                      || (p1 == 4 && p2 == 8 && p3 == 4 && p4 == 4 && p5 == 8) || (p1 == 4 && p2 == 4 && p3 == 8 && p4 == 8 && p5 == 4)
                      || (p1 == 4 && p2 == 4 && p3 == 8 && p4 == 4 && p5 == 8) || (p1 == 4 && p2 == 4 && p3 == 4 && p4 == 8 && p5 == 8)///2 TRIF
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 4 && p5 == 4) || (p1 == 8 && p2 == 8 && p3 == 4 && p4 == 8 && p5 == 4) 
                      || (p1 == 8 && p2 == 8 && p3 == 4 && p4 == 4 && p5 == 8) || (p1 == 8 && p2 == 4 && p3 == 8 && p4 == 8 && p5 == 4) 
                      || (p1 == 8 && p2 == 4 && p3 == 8 && p4 == 4 && p5 == 8) || (p1 == 8 && p2 == 4 && p3 == 4 && p4 == 8 && p5 == 8) 
                      || (p1 == 4 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 4) || (p1 == 4 && p2 == 8 && p3 == 4 && p4 == 8 && p5 == 8) 
                      || (p1 == 4 && p2 == 4 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 4 && p2 == 8 && p3 == 8 && p4 == 4 && p5 == 8)///3 TRIF 
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 4) || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 4 && p5 == 8)
                      || (p1 == 8 && p2 == 4 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 8 && p2 == 8 && p3 == 4 && p4 == 8 && p5 == 8)
                      || (p1 == 4 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 8))///4 TRIF
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 500);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    bigWinSound.Play();
                }///COINS


                if ((p1 == 5 && p2 == 5 && p3 == 5 && p4 == 5 && p5 == 5)
                      || (p1 == 8 && p2 == 5 && p3 == 5 && p4 == 5 && p5 == 5)
                      || (p1 == 5 && p2 == 8 && p3 == 5 && p4 == 5 && p5 == 5) || (p1 == 5 && p2 == 5 && p3 == 8 && p4 == 5 && p5 == 5)
                      || (p1 == 5 && p2 == 5 && p3 == 5 && p4 == 8 && p5 == 5) || (p1 == 5 && p2 == 5 && p3 == 5 && p4 == 5 && p5 == 8)
                      || (p1 == 8 && p2 == 8 && p3 == 5 && p4 == 5 && p5 == 5) || (p1 == 8 && p2 == 5 && p3 == 8 && p4 == 5 && p5 == 5)
                      || (p1 == 8 && p2 == 5 && p3 == 5 && p4 == 8 && p5 == 5) || (p1 == 8 && p2 == 5 && p3 == 5 && p4 == 5 && p5 == 8)
                      || (p1 == 5 && p2 == 8 && p3 == 8 && p4 == 5 && p5 == 5) || (p1 == 5 && p2 == 8 && p3 == 5 && p4 == 8 && p5 == 5)
                      || (p1 == 5 && p2 == 8 && p3 == 5 && p4 == 5 && p5 == 8) || (p1 == 5 && p2 == 5 && p3 == 8 && p4 == 8 && p5 == 5)
                      || (p1 == 5 && p2 == 5 && p3 == 8 && p4 == 5 && p5 == 8) || (p1 == 5 && p2 == 5 && p3 == 5 && p4 == 8 && p5 == 8)///2 TRIF
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 5 && p5 == 5) || (p1 == 8 && p2 == 8 && p3 == 5 && p4 == 8 && p5 == 5)
                      || (p1 == 8 && p2 == 8 && p3 == 5 && p4 == 5 && p5 == 8) || (p1 == 8 && p2 == 5 && p3 == 8 && p4 == 8 && p5 == 5)
                      || (p1 == 8 && p2 == 5 && p3 == 8 && p4 == 5 && p5 == 8) || (p1 == 8 && p2 == 5 && p3 == 5 && p4 == 8 && p5 == 8)
                      || (p1 == 5 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 5) || (p1 == 5 && p2 == 8 && p3 == 5 && p4 == 8 && p5 == 8)
                      || (p1 == 5 && p2 == 5 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 5 && p2 == 8 && p3 == 8 && p4 == 5 && p5 == 8)///3 TRIF 
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 5) || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 5 && p5 == 8)
                      || (p1 == 8 && p2 == 5 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 8 && p2 == 8 && p3 == 5 && p4 == 8 && p5 == 8)
                      || (p1 == 5 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 8))///4 TRIF
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 15);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///LEMONS

                if ((p1 == 6 && p2 == 6 && p3 == 6 && p4 == 6 && p5 == 6)
                      || (p1 == 8 && p2 == 6 && p3 == 6 && p4 == 6 && p5 == 6)
                      || (p1 == 6 && p2 == 8 && p3 == 6 && p4 == 6 && p5 == 6) || (p1 == 6 && p2 == 6 && p3 == 8 && p4 == 6 && p5 == 6)
                      || (p1 == 6 && p2 == 6 && p3 == 6 && p4 == 8 && p5 == 6) || (p1 == 6 && p2 == 6 && p3 == 6 && p4 == 6 && p5 == 8)
                      || (p1 == 8 && p2 == 8 && p3 == 6 && p4 == 6 && p5 == 6) || (p1 == 8 && p2 == 6 && p3 == 8 && p4 == 6 && p5 == 6)
                      || (p1 == 8 && p2 == 6 && p3 == 6 && p4 == 8 && p5 == 6) || (p1 == 8 && p2 == 6 && p3 == 6 && p4 == 6 && p5 == 8)
                      || (p1 == 6 && p2 == 8 && p3 == 8 && p4 == 6 && p5 == 6) || (p1 == 6 && p2 == 8 && p3 == 6 && p4 == 8 && p5 == 6)
                      || (p1 == 6 && p2 == 8 && p3 == 6 && p4 == 6 && p5 == 8) || (p1 == 6 && p2 == 6 && p3 == 8 && p4 == 8 && p5 == 6)
                      || (p1 == 6 && p2 == 6 && p3 == 8 && p4 == 6 && p5 == 8) || (p1 == 6 && p2 == 6 && p3 == 6 && p4 == 8 && p5 == 8)///2 TRIF
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 6 && p5 == 6) || (p1 == 8 && p2 == 8 && p3 == 6 && p4 == 8 && p5 == 6)
                      || (p1 == 8 && p2 == 8 && p3 == 6 && p4 == 6 && p5 == 8) || (p1 == 8 && p2 == 6 && p3 == 8 && p4 == 8 && p5 == 6)
                      || (p1 == 8 && p2 == 6 && p3 == 8 && p4 == 6 && p5 == 8) || (p1 == 8 && p2 == 6 && p3 == 6 && p4 == 8 && p5 == 8)
                      || (p1 == 6 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 6) || (p1 == 6 && p2 == 8 && p3 == 6 && p4 == 8 && p5 == 8)
                      || (p1 == 6 && p2 == 6 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 6 && p2 == 8 && p3 == 8 && p4 == 6 && p5 == 8)///3 TRIF 
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 6) || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 6 && p5 == 8)
                      || (p1 == 8 && p2 == 6 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 8 && p2 == 8 && p3 == 6 && p4 == 8 && p5 == 8)
                      || (p1 == 6 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 8))///4 TRIF
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 19.5);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///APPLES


                if ((p1 == 7 && p2 == 7 && p3 == 7 && p4 == 7 && p5 == 7)
                      || (p1 == 8 && p2 == 7 && p3 == 7 && p4 == 7 && p5 == 7)
                      || (p1 == 7 && p2 == 8 && p3 == 7 && p4 == 7 && p5 == 7) || (p1 == 7 && p2 == 7 && p3 == 8 && p4 == 7 && p5 == 7)
                      || (p1 == 7 && p2 == 7 && p3 == 7 && p4 == 8 && p5 == 7) || (p1 == 7 && p2 == 7 && p3 == 7 && p4 == 7 && p5 == 8)
                      || (p1 == 8 && p2 == 8 && p3 == 7 && p4 == 7 && p5 == 7) || (p1 == 8 && p2 == 7 && p3 == 8 && p4 == 7 && p5 == 7)
                      || (p1 == 8 && p2 == 7 && p3 == 7 && p4 == 8 && p5 == 7) || (p1 == 8 && p2 == 7 && p3 == 7 && p4 == 7 && p5 == 8)
                      || (p1 == 7 && p2 == 8 && p3 == 8 && p4 == 7 && p5 == 7) || (p1 == 7 && p2 == 8 && p3 == 7 && p4 == 8 && p5 == 7)
                      || (p1 == 7 && p2 == 8 && p3 == 7 && p4 == 7 && p5 == 8) || (p1 == 7 && p2 == 7 && p3 == 8 && p4 == 8 && p5 == 7)
                      || (p1 == 7 && p2 == 7 && p3 == 8 && p4 == 7 && p5 == 8) || (p1 == 7 && p2 == 7 && p3 == 7 && p4 == 8 && p5 == 8)///2 TRIF
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 7 && p5 == 7) || (p1 == 8 && p2 == 8 && p3 == 7 && p4 == 8 && p5 == 7)
                      || (p1 == 8 && p2 == 8 && p3 == 7 && p4 == 7 && p5 == 8) || (p1 == 8 && p2 == 7 && p3 == 8 && p4 == 8 && p5 == 7)
                      || (p1 == 8 && p2 == 7 && p3 == 8 && p4 == 7 && p5 == 8) || (p1 == 8 && p2 == 7 && p3 == 7 && p4 == 8 && p5 == 8)
                      || (p1 == 7 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 7) || (p1 == 7 && p2 == 8 && p3 == 7 && p4 == 8 && p5 == 8)
                      || (p1 == 7 && p2 == 7 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 7 && p2 == 8 && p3 == 8 && p4 == 7 && p5 == 8)///3 TRIF 
                      || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 7) || (p1 == 8 && p2 == 8 && p3 == 8 && p4 == 7 && p5 == 8)
                      || (p1 == 8 && p2 == 7 && p3 == 8 && p4 == 8 && p5 == 8) || (p1 == 8 && p2 == 8 && p3 == 7 && p4 == 8 && p5 == 8)
                      || (p1 == 7 && p2 == 8 && p3 == 8 && p4 == 8 && p5 == 8))///4 TRIF
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 16.5);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    lilWinSound.Play();
                }///PLUMS

                if(p1==8 && p2==8 && p3==8 && p4==8 && p5==8)
                {
                    pictureBox1.BackColor = Color.PaleGreen;
                    pictureBox2.BackColor = Color.PaleGreen;
                    pictureBox3.BackColor = Color.PaleGreen;
                    pictureBox4.BackColor = Color.PaleGreen;
                    pictureBox5.BackColor = Color.PaleGreen;
                    totalWin = (float)(bet * 750);
                    credits += (int)totalWin;
                    lbl_Credits.Text = credits.ToString();
                    label4.Text = "Last Win:" + totalWin.ToString();
                    bigWinSound.Play();
                }///5 TRIF

            }
            else if (credits < bet)
            {
                MessageBox.Show("Credite insuficiente");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        public Game()
        {
            InitializeComponent();
        }

        

    }
}
