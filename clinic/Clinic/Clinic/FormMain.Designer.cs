namespace Clinic
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelInfo = new System.Windows.Forms.Label();
            this.editPanel1 = new Clinic.EditPanel();
            this.menuPanel1 = new Clinic.MenuPanel();
            this.appointmentPanel1 = new Clinic.AppointmentPanel();
            this.appointmentsPanel1 = new Clinic.AppointmentsPanel();
            this.registerAppointment1 = new Clinic.RegisterAppointmentPanel();
            this.editAppointmentPanel1 = new Clinic.EditAppointmentPanel();
            this.editAppointmentSearchPanel1 = new Clinic.EditAppointmentSearchPanel();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(68, 13);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(207, 264);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "Przychodnia lekarska\r\n\r\nPanel\r\n\r\nWitaj\r\n\r\n\r\nAutorzy:\r\nMadejski\r\nMrosek\r\nParkitny";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // editPanel1
            // 
            this.editPanel1.Address = "Adres";
            this.editPanel1.BirthDay = new System.DateTime(2019, 5, 18, 17, 41, 25, 213);
            this.editPanel1.DoctorFields = true;
            this.editPanel1.FirstName = "Imie";
            this.editPanel1.Location = new System.Drawing.Point(337, 13);
            this.editPanel1.Name = "editPanel1";
            this.editPanel1.PatientFields = true;
            this.editPanel1.PhoneNumber = "Telefon";
            this.editPanel1.SharedFields = true;
            this.editPanel1.Size = new System.Drawing.Size(807, 559);
            this.editPanel1.Surname = "Nazwisko";
            this.editPanel1.TabIndex = 8;
            // 
            // menuPanel1
            // 
            this.menuPanel1.EditAppointmentButtonVisibility = true;
            this.menuPanel1.Location = new System.Drawing.Point(16, 321);
            this.menuPanel1.Name = "menuPanel1";
            this.menuPanel1.RegisterAppointmentButtonVisibility = true;
            this.menuPanel1.Size = new System.Drawing.Size(325, 204);
            this.menuPanel1.TabIndex = 1;
            // 
            // appointmentPanel1
            // 
            this.appointmentPanel1.Enabled = false;
            this.appointmentPanel1.Location = new System.Drawing.Point(337, 13);
            this.appointmentPanel1.Name = "appointmentPanel1";
            this.appointmentPanel1.Size = new System.Drawing.Size(767, 512);
            this.appointmentPanel1.TabIndex = 6;
            this.appointmentPanel1.Visible = false;
            // 
            // appointmentsPanel1
            // 
            this.appointmentsPanel1.Enabled = false;
            this.appointmentsPanel1.Location = new System.Drawing.Point(337, 13);
            this.appointmentsPanel1.Name = "appointmentsPanel1";
            this.appointmentsPanel1.Size = new System.Drawing.Size(766, 517);
            this.appointmentsPanel1.TabIndex = 5;
            this.appointmentsPanel1.Visible = false;
            // 
            // registerAppointment1
            // 
            this.registerAppointment1.AppointmentDate = new System.DateTime(2019, 5, 18, 17, 41, 25, 231);
            this.registerAppointment1.DoctorActive = false;
            this.registerAppointment1.Enabled = false;
            this.registerAppointment1.Location = new System.Drawing.Point(337, 13);
            this.registerAppointment1.Name = "registerAppointment1";
            this.registerAppointment1.Size = new System.Drawing.Size(767, 513);
            this.registerAppointment1.TabIndex = 4;
            this.registerAppointment1.Visible = false;
            // 
            // editAppointmentPanel1
            // 
            this.editAppointmentPanel1.AppointmentID = -1;
            this.editAppointmentPanel1.Content = "Opis";
            this.editAppointmentPanel1.ID = 0;
            this.editAppointmentPanel1.Location = new System.Drawing.Point(337, 13);
            this.editAppointmentPanel1.Name = "editAppointmentPanel1";
            this.editAppointmentPanel1.Prescription = ((System.Collections.Generic.List<string>)(resources.GetObject("editAppointmentPanel1.Prescription")));
            this.editAppointmentPanel1.Size = new System.Drawing.Size(767, 517);
            this.editAppointmentPanel1.TabIndex = 9;
            this.editAppointmentPanel1.Visible = false;
            // 
            // editAppointmentSearchPanel1
            // 
            this.editAppointmentSearchPanel1.Location = new System.Drawing.Point(337, 13);
            this.editAppointmentSearchPanel1.Name = "editAppointmentSearchPanel1";
            this.editAppointmentSearchPanel1.PeselPatient = "PESEL pacjenta";
            this.editAppointmentSearchPanel1.Size = new System.Drawing.Size(767, 517);
            this.editAppointmentSearchPanel1.TabIndex = 10;
            this.editAppointmentSearchPanel1.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 537);
            this.Controls.Add(this.editPanel1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.menuPanel1);
            this.Controls.Add(this.appointmentPanel1);
            this.Controls.Add(this.appointmentsPanel1);
            this.Controls.Add(this.registerAppointment1);
            this.Controls.Add(this.editAppointmentPanel1);
            this.Controls.Add(this.editAppointmentSearchPanel1);
            this.Name = "FormMain";
            this.Text = "Panel pacjenta";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuPanel menuPanel1;
        private RegisterAppointmentPanel registerAppointment1;
        private AppointmentsPanel appointmentsPanel1;
        private AppointmentPanel appointmentPanel1;
        private System.Windows.Forms.Label labelInfo;
        private EditPanel editPanel1;
        private EditAppointmentPanel editAppointmentPanel1;
        private EditAppointmentSearchPanel editAppointmentSearchPanel1;
    }
}

