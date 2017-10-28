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
    public partial class PUpdate : UserControl
    {
        private Person person = null;
        public TableModel tm { get; set; }
        public PUpdate()
        {
            InitializeComponent();
        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            tm.AddPhone(person.id, txtPhone.Text);
            listBoxPhones.Items.Add(txtPhone.Text);
            txtPhone.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tm.Update(new Person(Int32.Parse(txtId.Text), txtFirstName.Text, txtLastName.Text, Int32.Parse(txtAge.Text), null));
            txtId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAge.Text = "";
        }
        public void AddPersonInformation(Person person)
        {
            this.person = person;

            labelId.Text += person.id.ToString();
            labelFn.Text += person.fn;
            labelLn.Text += person.ln;
            labelAge.Text += person.age.ToString();

            foreach (Phone phone in person.listOfPhones)
            {
                listBoxPhones.Items.Add(phone.phone);
            }
        }
    }
}
