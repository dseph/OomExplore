using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OomExplore
{
    public partial class ItemPropertiesForm : Form
    {
        public ItemPropertiesForm()
        {
            InitializeComponent();
        }

        public string WindowTitle
        {

            set { this.Text = value; }
        }

 
        private void ItemPropertiesForm_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void SetListView(ref ListView oListView) 
        {
            this.listView1 = oListView; 
        }

      
    }
}
