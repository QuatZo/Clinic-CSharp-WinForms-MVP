namespace Clinic
{
    partial class RegisterAppointmentPanel
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
            this.buttonRegister = new System.Windows.Forms.Button();
            this.dateTimePickerAppointment = new System.Windows.Forms.DateTimePicker();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.comboBoxSpecialization = new System.Windows.Forms.ComboBox();
            this.comboBoxDoctor = new System.Windows.Forms.ComboBox();
            this.textBoxHours = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(277, 356);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(212, 23);
            this.buttonRegister.TabIndex = 15;
            this.buttonRegister.Text = "Zarejestruj";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // dateTimePickerAppointment
            // 
            this.dateTimePickerAppointment.Location = new System.Drawing.Point(277, 304);
            this.dateTimePickerAppointment.Name = "dateTimePickerAppointment";
            this.dateTimePickerAppointment.Size = new System.Drawing.Size(212, 20);
            this.dateTimePickerAppointment.TabIndex = 13;
            // 
            // textBoxContent
            // 
            this.textBoxContent.Location = new System.Drawing.Point(277, 228);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(212, 70);
            this.textBoxContent.TabIndex = 12;
            this.textBoxContent.Text = "Opis (nadpisywany później przez lekarza)";
            // 
            // comboBoxSpecialization
            // 
            this.comboBoxSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpecialization.FormattingEnabled = true;
            this.comboBoxSpecialization.Location = new System.Drawing.Point(277, 174);
            this.comboBoxSpecialization.Name = "comboBoxSpecialization";
            this.comboBoxSpecialization.Size = new System.Drawing.Size(212, 21);
            this.comboBoxSpecialization.TabIndex = 11;
            this.comboBoxSpecialization.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpecialization_SelectedIndexChanged);
            // 
            // comboBoxDoctor
            // 
            this.comboBoxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoctor.Enabled = false;
            this.comboBoxDoctor.FormattingEnabled = true;
            this.comboBoxDoctor.Location = new System.Drawing.Point(277, 201);
            this.comboBoxDoctor.Name = "comboBoxDoctor";
            this.comboBoxDoctor.Size = new System.Drawing.Size(212, 21);
            this.comboBoxDoctor.TabIndex = 10;
            this.comboBoxDoctor.SelectedIndexChanged += new System.EventHandler(this.comboBoxDoctor_SelectedIndexChanged);
            // 
            // textBoxHours
            // 
            this.textBoxHours.Enabled = false;
            this.textBoxHours.Location = new System.Drawing.Point(277, 330);
            this.textBoxHours.Name = "textBoxHours";
            this.textBoxHours.Size = new System.Drawing.Size(212, 20);
            this.textBoxHours.TabIndex = 17;
            // 
            // RegisterAppointmentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxHours);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.dateTimePickerAppointment);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.comboBoxSpecialization);
            this.Controls.Add(this.comboBoxDoctor);
            this.Name = "RegisterAppointmentPanel";
            this.Size = new System.Drawing.Size(767, 527);
            this.Load += new System.EventHandler(this.RegisterAppointmentPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.DateTimePicker dateTimePickerAppointment;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.ComboBox comboBoxSpecialization;
        private System.Windows.Forms.ComboBox comboBoxDoctor;
        private System.Windows.Forms.TextBox textBoxHours;
    }
}
