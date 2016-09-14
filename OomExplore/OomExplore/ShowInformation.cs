using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OomExplore
{
    public partial class ShowInformation : Form
    {

        public ShowInformation()
        {
            InitializeComponent();
        }

        public string WindowTitle
        {

            set { this.Text = value; }
        }
        

        private void ShowInformation_Load(object sender, EventArgs e)
        {

        }

        private void txtInformation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}