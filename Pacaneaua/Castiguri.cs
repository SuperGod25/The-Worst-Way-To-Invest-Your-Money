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
    public partial class Castiguri : Form
    {
        public Castiguri()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Main_Menu meniu = new Main_Menu();
            this.Hide();
            meniu.Closed += (s, args) => this.Close();
            meniu.Show();
        }
    }
}
