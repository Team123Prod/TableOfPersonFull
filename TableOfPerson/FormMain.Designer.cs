namespace TableOfPerson
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.peopleDBDataSet = new TableOfPerson.PeopleDBDataSet();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personTableAdapter = new TableOfPerson.PeopleDBDataSetTableAdapters.PersonTableAdapter();
            this.tableAdapterManager = new TableOfPerson.PeopleDBDataSetTableAdapters.TableAdapterManager();
            this.pMain1 = new TableOfPerson.Controls.PMain();
            ((System.ComponentModel.ISupportInitialize)(this.peopleDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // peopleDBDataSet
            // 
            this.peopleDBDataSet.DataSetName = "PeopleDBDataSet";
            this.peopleDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataMember = "Person";
            this.personBindingSource.DataSource = this.peopleDBDataSet;
            // 
            // personTableAdapter
            // 
            this.personTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.PersonTableAdapter = this.personTableAdapter;
            this.tableAdapterManager.UpdateOrder = TableOfPerson.PeopleDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // pMain1
            // 
            this.pMain1.Location = new System.Drawing.Point(-1, 4);
            this.pMain1.Name = "pMain1";
            this.pMain1.Size = new System.Drawing.Size(325, 322);
            this.pMain1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 338);
            this.Controls.Add(this.pMain1);
            this.Name = "FormMain";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.peopleDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PeopleDBDataSet peopleDBDataSet;
        private System.Windows.Forms.BindingSource personBindingSource;
        private PeopleDBDataSetTableAdapters.PersonTableAdapter personTableAdapter;
        private PeopleDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private Controls.PMain pMain1;
    }
}

