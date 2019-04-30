namespace Clinic
{
    partial class EditPanel
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
            this.comboBoxSex = new System.Windows.Forms.ComboBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPESEL = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.dateTimePickerBirthDay = new System.Windows.Forms.DateTimePicker();
            this.textBoxRoom = new System.Windows.Forms.TextBox();
            this.comboBoxHours = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxSex
            // 
            this.comboBoxSex.Enabled = false;
            this.comboBoxSex.FormattingEnabled = true;
            this.comboBoxSex.Items.AddRange(new object[] {
            "kobieta",
            "mezczyzna"});
            this.comboBoxSex.Location = new System.Drawing.Point(279, 262);
            this.comboBoxSex.Name = "comboBoxSex";
            this.comboBoxSex.Size = new System.Drawing.Size(200, 21);
            this.comboBoxSex.TabIndex = 30;
            this.comboBoxSex.Text = "Płeć";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(279, 391);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(200, 23);
            this.buttonEdit.TabIndex = 27;
            this.buttonEdit.Text = "Zapisz";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(279, 236);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(200, 20);
            this.textBoxPhoneNumber.TabIndex = 26;
            this.textBoxPhoneNumber.Text = "Telefon";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(279, 315);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(200, 20);
            this.textBoxAddress.TabIndex = 25;
            this.textBoxAddress.Text = "Adres";
            // 
            // textBoxPESEL
            // 
            this.textBoxPESEL.Enabled = false;
            this.textBoxPESEL.Location = new System.Drawing.Point(279, 210);
            this.textBoxPESEL.Name = "textBoxPESEL";
            this.textBoxPESEL.Size = new System.Drawing.Size(200, 20);
            this.textBoxPESEL.TabIndex = 31;
            this.textBoxPESEL.Text = "PESEL";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Enabled = false;
            this.textBoxSurname.Location = new System.Drawing.Point(279, 184);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(200, 20);
            this.textBoxSurname.TabIndex = 32;
            this.textBoxSurname.Text = "Nazwisko";
            // 
            // textBoxName
            // 
            this.textBoxName.Enabled = false;
            this.textBoxName.Location = new System.Drawing.Point(279, 158);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 20);
            this.textBoxName.TabIndex = 33;
            this.textBoxName.Text = "Imie";
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(279, 132);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(200, 20);
            this.textBoxID.TabIndex = 34;
            this.textBoxID.Text = "ID";
            // 
            // dateTimePickerBirthDay
            // 
            this.dateTimePickerBirthDay.Enabled = false;
            this.dateTimePickerBirthDay.Location = new System.Drawing.Point(279, 289);
            this.dateTimePickerBirthDay.Name = "dateTimePickerBirthDay";
            this.dateTimePickerBirthDay.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerBirthDay.TabIndex = 35;
            // 
            // textBoxRoom
            // 
            this.textBoxRoom.Location = new System.Drawing.Point(279, 262);
            this.textBoxRoom.Name = "textBoxRoom";
            this.textBoxRoom.Size = new System.Drawing.Size(200, 20);
            this.textBoxRoom.TabIndex = 36;
            this.textBoxRoom.Text = "Numer gabinetu";
            // 
            // comboBoxHours
            // 
            this.comboBoxHours.FormattingEnabled = true;
            this.comboBoxHours.Items.AddRange(new object[] {
            "poranne",
            "popoludniowe",
            "wieczorowe"});
            this.comboBoxHours.Location = new System.Drawing.Point(279, 288);
            this.comboBoxHours.Name = "comboBoxHours";
            this.comboBoxHours.Size = new System.Drawing.Size(200, 21);
            this.comboBoxHours.TabIndex = 37;
            this.comboBoxHours.Text = "Godziny przyjmowania";
            // 
            // EditPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxHours);
            this.Controls.Add(this.textBoxRoom);
            this.Controls.Add(this.dateTimePickerBirthDay);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxPESEL);
            this.Controls.Add(this.comboBoxSex);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.textBoxPhoneNumber);
            this.Controls.Add(this.textBoxAddress);
            this.Name = "EditPanel";
            this.Size = new System.Drawing.Size(807, 559);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSex;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxPESEL;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthDay;
        private System.Windows.Forms.TextBox textBoxRoom;
        private System.Windows.Forms.ComboBox comboBoxHours;
    }
}
