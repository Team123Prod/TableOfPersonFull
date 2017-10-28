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
    public partial class PMain : UserControl
    {
        TableModel tm { get; set; }
        public PMain()
        {
            InitializeComponent();

            tm = new TableModel();

            comboDB.SelectedIndex = 13;
            
        }
        private Person GetPerson()
        {
            //int id = Int32.Parse(txtId.Text);
            //string fn = txtFirstName.Text;
            //string ln = txtLastName.Text;
            //int age = Int32.Parse(txtAge.Text);
            //return new Person(id, fn, ln, age);
            return new Person();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = tm.Search(txtSearch.Text);
            txtSearch.Text = "";
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = tm.Read();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // tm.Create(GetPerson());
            FormCreate fCreate = new FormCreate();
            fCreate.pCreate1.tm = tm;
            fCreate.Hide();
            fCreate.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //tm.Delete(GetPerson());
            FormDelete fDelete = new FormDelete();
            fDelete.pDelete1.tm = tm;
            fDelete.Hide();
            fDelete.Show();
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FormUpdate fUpdate = new FormUpdate();
            fUpdate.pUpdate1.tm = tm;

            int index = e.RowIndex;
            int id = Int32.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
            foreach(Person p in tm.ReturnPersons())
            {
                if(id == p.id)
                {
                    fUpdate.pUpdate1.AddPersonInformation(p);
                }
            }
            fUpdate.Hide();
            fUpdate.Show();

        }

        private void comboDB_SelectedIndexChanged(object sender, EventArgs e)
        {
           tm.SetDataBase(comboDB.SelectedItem.ToString());
        }
    }
}
