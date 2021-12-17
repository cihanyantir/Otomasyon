using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otomasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Form3 aracgirisfrm = new Form3();
        Form4 aracduzenlemefrm = new Form4();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            aracgirisfrm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            aracduzenlemefrm.Show();
        }
    }
}
