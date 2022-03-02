using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT365_Assignment1
{
    public partial class RetrieveEventForm : Form
    {
        public RetrieveEventForm(Event ev)
        {
            InitializeComponent();
            textBox1.Text = ev.ToString();
        }

        private void RetrieveEventForm_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
