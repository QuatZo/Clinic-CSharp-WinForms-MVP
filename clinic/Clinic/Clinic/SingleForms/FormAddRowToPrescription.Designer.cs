namespace Clinic
{
    partial class FormAddRowToPrescription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddRowToPrescription));
            this.listBoxRows = new System.Windows.Forms.ListBox();
            this.buttonSave = new Clinic.ButtonModified();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEdit = new Clinic.ButtonModified();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxRows
            // 
            this.listBoxRows.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxRows.FormattingEnabled = true;
            this.listBoxRows.ItemHeight = 22;
            this.listBoxRows.Location = new System.Drawing.Point(81, 45);
            this.listBoxRows.Name = "listBoxRows";
            this.listBoxRows.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxRows.Size = new System.Drawing.Size(297, 334);
            this.listBoxRows.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.White;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(115, 398);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(227, 35);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Dodaj";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(435, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zaznacz kombinacje za pomocą CTRL, SHIFT lub STRZAŁEK.\r\n";
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.White;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEdit.ForeColor = System.Drawing.Color.Black;
            this.buttonEdit.Location = new System.Drawing.Point(115, 439);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(227, 35);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Brakuje leku/dawki";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(102, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Jeśli nie chcesz nic dodać, wyłącz te okno.";
            // 
            // FormAddRowToPrescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 519);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.listBoxRows);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(476, 558);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(476, 558);
            this.Name = "FormAddRowToPrescription";
            this.Text = "Dodaj lek z dawką do recepty";
            this.Load += new System.EventHandler(this.FormAddRowToPrescription_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxRows;
        private System.Windows.Forms.Label label1;
        private ButtonModified buttonSave;
        private ButtonModified buttonEdit;
        private System.Windows.Forms.Label label2;
    }
}