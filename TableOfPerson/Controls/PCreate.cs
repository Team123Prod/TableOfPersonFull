using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableOfPerson.DataBaseApi;

namespace TableOfPerson.Controls
{
    public partial class PCreate : UserControl
    {
        public TableModel tm { get; set; }
        public PCreate()
        {
            InitializeComponent();
        }

        private void btnAddToDB_Click(object sender, EventArgs e)
        {
            FormUpdate fUpdate = new FormUpdate();
            Person p = new Person(Int32.Parse(txtId.Text), txtFirstName.Text, txtLastName.Text, Int32.Parse(txtAge.Text), new List<Phone>());
            tm.Create(p);
            fUpdate.pUpdate1.tm = tm;
            fUpdate.pUpdate1.AddPersonInformation(p);
            fUpdate.Hide();
            fUpdate.Show();
            ParentForm.Close();
        }
    }
}
