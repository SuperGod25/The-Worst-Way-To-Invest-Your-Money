using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacaneaua
{
    public partial class Main_Menu : Form
    {

        
        public Main_Menu()
        {
            InitializeComponent();
        }

        

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Game gameScreen = new Game();

            this.Hide();
            gameScreen.Closed += (s, args) => this.Close();
            gameScreen.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void instruct_btn_Click(object sender, EventArgs e)
        {
            Instructiuni instr = new Instructiuni();
            this.Hide();
            instr.Closed += (s, args) => this.Close();
            instr.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Castiguri castiguri = new Castiguri();
            this.Hide();
            castiguri.Closed += (s, args) => this.Close();
            castiguri.Show();
        }
    }
}
