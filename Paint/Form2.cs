using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public MyList log;

        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = log.Print();
        }
    }
}
