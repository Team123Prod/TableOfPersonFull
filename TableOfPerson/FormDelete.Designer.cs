namespace TableOfPerson
{
    partial class FormDelete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pDelete1 = new TableOfPerson.Controls.PDelete();
            this.SuspendLayout();
            // 
            // pDelete1
            // 
            this.pDelete1.Location = new System.Drawing.Point(26, 12);
            this.pDelete1.Name = "pDelete1";
            this.pDelete1.Size = new System.Drawing.Size(158, 145);
            this.pDelete1.TabIndex = 0;
            // 
            // FormDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 159);
            this.Controls.Add(this.pDelete1);
            this.Name = "FormDelete";
            this.Text = "Delete";
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.PDelete pDelete1;
    }
}