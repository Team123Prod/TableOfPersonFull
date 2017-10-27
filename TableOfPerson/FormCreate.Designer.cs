namespace TableOfPerson
{
    partial class FormCreate
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
            this.pCreate1 = new TableOfPerson.Controls.PCreate();
            this.SuspendLayout();
            // 
            // pCreate1
            // 
            this.pCreate1.Location = new System.Drawing.Point(8, 2);
            this.pCreate1.Name = "pCreate1";
            this.pCreate1.Size = new System.Drawing.Size(416, 173);
            this.pCreate1.TabIndex = 0;
            // 
            // FormCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 166);
            this.Controls.Add(this.pCreate1);
            this.Name = "FormCreate";
            this.Text = "Create";
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.PCreate pCreate1;
    }
}