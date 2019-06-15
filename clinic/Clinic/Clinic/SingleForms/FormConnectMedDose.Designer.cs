namespace Clinic
{
    partial class FormConnectMedDose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnectMedDose));
            this.comboBoxMedicine = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new Clinic.ButtonModified();
            this.buttonExit = new Clinic.ButtonModified();
            this.comboBoxDose = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxMedicine
            // 
            this.comboBoxMedicine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMedicine.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxMedicine.FormattingEnabled = true;
            this.comboBoxMedicine.Location = new System.Drawing.Point(38, 51);
            this.comboBoxMedicine.Name = "comboBoxMedicine";
            this.comboBoxMedicine.Size = new System.Drawing.Size(191, 30);
            this.comboBoxMedicine.TabIndex = 0;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.White;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAdd.ForeColor = System.Drawing.Color.Black;
            this.buttonAdd.Location = new System.Drawing.Point(38, 87);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(191, 35);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Dodaj";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.White;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonExit.ForeColor = System.Drawing.Color.Black;
            this.buttonExit.Location = new System.Drawing.Point(250, 87);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(191, 35);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Wyjdź";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // comboBoxDose
            // 
            this.comboBoxDose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDose.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxDose.FormattingEnabled = true;
            this.comboBoxDose.Location = new System.Drawing.Point(250, 51);
            this.comboBoxDose.Name = "comboBoxDose";
            this.comboBoxDose.Size = new System.Drawing.Size(191, 30);
            this.comboBoxDose.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Dodane leki pokażą się na liście dopiero po wyłączeniu tego okna.";
            // 
            // FormConnectMedDose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(474, 141);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDose);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxMedicine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(490, 180);
            this.MinimumSize = new System.Drawing.Size(490, 180);
            this.Name = "FormConnectMedDose";
            this.Text = "Połącz lek z dawką";
            this.Load += new System.EventHandler(this.FormAddRowToPrescription_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMedicine;
        private System.Windows.Forms.ComboBox comboBoxDose;
        private System.Windows.Forms.Label label1;
        private ButtonModified buttonAdd;
        private ButtonModified buttonExit;
    }
}