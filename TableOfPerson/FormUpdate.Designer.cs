namespace TableOfPerson
{
    partial class FormUpdate
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
            this.pUpdate1 = new TableOfPerson.Controls.PUpdate();
            this.SuspendLayout();
            // 
            // pUpdate1
            // 
            this.pUpdate1.Location = new System.Drawing.Point(0, 0);
            this.pUpdate1.Name = "pUpdate1";
            this.pUpdate1.Size = new System.Drawing.Size(451, 407);
            this.pUpdate1.TabIndex = 0;
            // 
            // FormUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 406);
            this.Controls.Add(this.pUpdate1);
            this.Name = "FormUpdate";
            this.Text = "Update";
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.PUpdate pUpdate1;
    }
}