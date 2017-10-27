using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableOfPerson.Controls
{
    public partial class PDelete : UserControl
    {
        public TableModel tm { get; set; }
        public PDelete()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tm.Delete(Int32.Parse(txtId.Text));
            txtId.Text = "";
        }
    }
}
