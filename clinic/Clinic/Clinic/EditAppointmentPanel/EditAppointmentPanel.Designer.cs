namespace Clinic
{
    partial class EditAppointmentPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.listBoxReceipt = new System.Windows.Forms.ListBox();
            this.labelHelp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new Clinic.ButtonModified();
            this.buttonDelete = new Clinic.ButtonModified();
            this.buttonAdd = new Clinic.ButtonModified();
            this.SuspendLayout();
            // 
            // textBoxContent
            // 
            this.textBoxContent.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxContent.Location = new System.Drawing.Point(29, 72);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(368, 246);
            this.textBoxContent.TabIndex = 0;
            this.textBoxContent.Text = "Opis";
            // 
            // listBoxReceipt
            // 
            this.listBoxReceipt.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxReceipt.FormattingEnabled = true;
            this.listBoxReceipt.ItemHeight = 22;
            this.listBoxReceipt.Location = new System.Drawing.Point(419, 72);
            this.listBoxReceipt.Name = "listBoxReceipt";
            this.listBoxReceipt.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxReceipt.Size = new System.Drawing.Size(368, 246);
            this.listBoxReceipt.TabIndex = 1;
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHelp.Location = new System.Drawing.Point(252, 397);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(292, 64);
            this.labelHelp.TabIndex = 5;
            this.labelHelp.Text = "Wybierz ile chcesz za pomocą CTRL, SHIFT lub STRZAŁEK.\r\nPowyższe odnosi się do ch" +
    "ęci usunięcia wpisów. \r\nJeśli chcesz dodać lek do recepty, kliknij na +.\r\nPrzyci" +
    "sk \"Zapisz\" zapisuje opis!\r\n";
            this.labelHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(428, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "-1";
            this.label1.Visible = false;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.White;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(169, 336);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 38);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Zapisz";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.White;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDelete.ForeColor = System.Drawing.Color.Black;
            this.buttonDelete.Location = new System.Drawing.Point(616, 333);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(112, 39);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "-";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.White;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAdd.ForeColor = System.Drawing.Color.Black;
            this.buttonAdd.Location = new System.Drawing.Point(498, 333);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(112, 39);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // EditAppointmentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listBoxReceipt);
            this.Controls.Add(this.textBoxContent);
            this.Name = "EditAppointmentPanel";
            this.Size = new System.Drawing.Size(817, 620);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.ListBox listBoxReceipt;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Label label1;
        private ButtonModified buttonAdd;
        private ButtonModified buttonDelete;
        private ButtonModified buttonSave;
    }
}
