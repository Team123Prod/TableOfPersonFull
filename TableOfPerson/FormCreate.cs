﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableOfPerson
{
    public partial class FormCreate : Form
    {
        public FormCreate()
        {
            InitializeComponent();
        }

        private void btnAddToDB_Click(object sender, EventArgs e)
        {
            this.Close();
            FormUpdate fUpdate = new FormUpdate();
            fUpdate.Hide();
            fUpdate.Show();
        }
    }
}
