namespace Clinic
{
    partial class AppointmentPanel
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
            this.dateTimePickerAppointment = new System.Windows.Forms.DateTimePicker();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.textBoxDoctor = new System.Windows.Forms.TextBox();
            this.textBoxPatient = new System.Windows.Forms.TextBox();
            this.textBoxPatientPesel = new System.Windows.Forms.TextBox();
            this.listBoxPrescription = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // dateTimePickerAppointment
            // 
            this.dateTimePickerAppointment.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dateTimePickerAppointment.Enabled = false;
            this.dateTimePickerAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAppointment.Location = new System.Drawing.Point(259, 313);
            this.dateTimePickerAppointment.Name = "dateTimePickerAppointment";
            this.dateTimePickerAppointment.Size = new System.Drawing.Size(214, 20);
            this.dateTimePickerAppointment.TabIndex = 20;
            // 
            // textBoxContent
            // 
            this.textBoxContent.Enabled = false;
            this.textBoxContent.Location = new System.Drawing.Point(259, 201);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(214, 106);
            this.textBoxContent.TabIndex = 19;
            this.textBoxContent.Text = "Opis ";
            this.textBoxContent.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxDoctor
            // 
            this.textBoxDoctor.Enabled = false;
            this.textBoxDoctor.Location = new System.Drawing.Point(259, 175);
            this.textBoxDoctor.Name = "textBoxDoctor";
            this.textBoxDoctor.Size = new System.Drawing.Size(214, 20);
            this.textBoxDoctor.TabIndex = 24;
            this.textBoxDoctor.Text = "Lekarz";
            // 
            // textBoxPatient
            // 
            this.textBoxPatient.Enabled = false;
            this.textBoxPatient.Location = new System.Drawing.Point(259, 149);
            this.textBoxPatient.Name = "textBoxPatient";
            this.textBoxPatient.Size = new System.Drawing.Size(214, 20);
            this.textBoxPatient.TabIndex = 26;
            this.textBoxPatient.Text = "Pacjent";
            // 
            // textBoxPatientPesel
            // 
            this.textBoxPatientPesel.Enabled = false;
            this.textBoxPatientPesel.Location = new System.Drawing.Point(259, 123);
            this.textBoxPatientPesel.Name = "textBoxPatientPesel";
            this.textBoxPatientPesel.Size = new System.Drawing.Size(214, 20);
            this.textBoxPatientPesel.TabIndex = 27;
            this.textBoxPatientPesel.Text = "PESEL";
            // 
            // listBoxPrescription
            // 
            this.listBoxPrescription.Enabled = false;
            this.listBoxPrescription.FormattingEnabled = true;
            this.listBoxPrescription.Location = new System.Drawing.Point(259, 339);
            this.listBoxPrescription.Name = "listBoxPrescription";
            this.listBoxPrescription.Size = new System.Drawing.Size(214, 173);
            this.listBoxPrescription.TabIndex = 28;
            // 
            // AppointmentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxPrescription);
            this.Controls.Add(this.textBoxPatientPesel);
            this.Controls.Add(this.textBoxPatient);
            this.Controls.Add(this.textBoxDoctor);
            this.Controls.Add(this.dateTimePickerAppointment);
            this.Controls.Add(this.textBoxContent);
            this.Name = "AppointmentPanel";
            this.Size = new System.Drawing.Size(683, 526);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePickerAppointment;
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.TextBox textBoxDoctor;
        private System.Windows.Forms.TextBox textBoxPatient;
        private System.Windows.Forms.TextBox textBoxPatientPesel;
        private System.Windows.Forms.ListBox listBoxPrescription;
    }
}
