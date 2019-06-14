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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuPanel1 = new Clinic.MenuPanel();
            this.editPanel1 = new Clinic.EditPanel();
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
            this.labelInfo.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInfo.Location = new System.Drawing.Point(42, 31);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(196, 120);
            this.labelInfo.TabIndex = 7;
            this.labelInfo.Text = "Przychodnia lekarska\r\n\r\nPanel\r\n\r\nWitaj!";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInfo.Click += new System.EventHandler(this.labelInfo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(9, 524);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 48);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dawid Mrosek\r\nBartłomiej Madejski\r\nPatryk Parkitny\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(9, 509);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Autorzy:\r\n";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // menuPanel1
            // 
            this.menuPanel1.EditAppointmentButtonVisibility = true;
            this.menuPanel1.Location = new System.Drawing.Point(6, 199);
            this.menuPanel1.Name = "menuPanel1";
            this.menuPanel1.RegisterAppointmentButtonVisibility = true;
            this.menuPanel1.Size = new System.Drawing.Size(313, 204);
            this.menuPanel1.TabIndex = 1;
            // 
            // editPanel1
            // 
            this.editPanel1.Address = "Adres";
            this.editPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.editPanel1.BirthDay = new System.DateTime(2019, 5, 18, 17, 41, 25, 213);
            this.editPanel1.DoctorFields = true;
            this.editPanel1.FirstName = "Imie";
            this.editPanel1.Location = new System.Drawing.Point(337, 12);
            this.editPanel1.Name = "editPanel1";
            this.editPanel1.PatientFields = true;
            this.editPanel1.PhoneNumber = "Telefon";
            this.editPanel1.SharedFields = true;
            this.editPanel1.Size = new System.Drawing.Size(807, 559);
            this.editPanel1.Surname = "Nazwisko";
            this.editPanel1.TabIndex = 8;
            // 
            // appointmentPanel1
            // 
            this.appointmentPanel1.Enabled = false;
            this.appointmentPanel1.Location = new System.Drawing.Point(337, 12);
            this.appointmentPanel1.Name = "appointmentPanel1";
            this.appointmentPanel1.Size = new System.Drawing.Size(767, 512);
            this.appointmentPanel1.TabIndex = 6;
            this.appointmentPanel1.Visible = false;
            // 
            // appointmentsPanel1
            // 
            this.appointmentsPanel1.Enabled = false;
            this.appointmentsPanel1.Location = new System.Drawing.Point(337, 12);
            this.appointmentsPanel1.Name = "appointmentsPanel1";
            this.appointmentsPanel1.Size = new System.Drawing.Size(807, 559);
            this.appointmentsPanel1.TabIndex = 5;
            this.appointmentsPanel1.Visible = false;
            // 
            // registerAppointment1
            // 
            this.registerAppointment1.AppointmentDate = new System.DateTime(2019, 5, 18, 17, 41, 25, 231);
            this.registerAppointment1.DoctorActive = false;
            this.registerAppointment1.Enabled = false;
            this.registerAppointment1.Hour = "";
            this.registerAppointment1.Location = new System.Drawing.Point(337, 12);
            this.registerAppointment1.Name = "registerAppointment1";
            this.registerAppointment1.Size = new System.Drawing.Size(807, 559);
            this.registerAppointment1.TabIndex = 4;
            this.registerAppointment1.Visible = false;
            // 
            // editAppointmentPanel1
            // 
            this.editAppointmentPanel1.AppointmentID = -1;
            this.editAppointmentPanel1.BackColor = System.Drawing.Color.White;
            this.editAppointmentPanel1.Content = "Opis";
            this.editAppointmentPanel1.ID = 0;
            this.editAppointmentPanel1.Location = new System.Drawing.Point(337, 12);
            this.editAppointmentPanel1.Name = "editAppointmentPanel1";
            this.editAppointmentPanel1.Prescription = ((System.Collections.Generic.List<string>)(resources.GetObject("editAppointmentPanel1.Prescription")));
            this.editAppointmentPanel1.Size = new System.Drawing.Size(805, 559);
            this.editAppointmentPanel1.TabIndex = 9;
            this.editAppointmentPanel1.Visible = false;
            // 
            // editAppointmentSearchPanel1
            // 
            this.editAppointmentSearchPanel1.BackColor = System.Drawing.Color.White;
            this.editAppointmentSearchPanel1.Location = new System.Drawing.Point(337, 12);
            this.editAppointmentSearchPanel1.Name = "editAppointmentSearchPanel1";
            this.editAppointmentSearchPanel1.PeselPatient = "PESEL pacjenta";
            this.editAppointmentSearchPanel1.Size = new System.Drawing.Size(805, 555);
            this.editAppointmentSearchPanel1.TabIndex = 10;
            this.editAppointmentSearchPanel1.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(199)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1154, 580);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.menuPanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.editPanel1);
            this.Controls.Add(this.appointmentPanel1);
            this.Controls.Add(this.appointmentsPanel1);
            this.Controls.Add(this.registerAppointment1);
            this.Controls.Add(this.editAppointmentPanel1);
            this.Controls.Add(this.editAppointmentSearchPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1170, 619);
            this.MinimumSize = new System.Drawing.Size(1170, 619);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

