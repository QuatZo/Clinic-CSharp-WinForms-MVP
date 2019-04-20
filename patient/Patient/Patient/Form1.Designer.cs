namespace Patient
{
    partial class Form1
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
            this.appointmentPanel1 = new Patient.AppointmentPanel();
            this.appointmentsPanel1 = new Patient.AppointmentsPanel();
            this.registerAppointment1 = new Patient.RegisterAppointmentPanel();
            this.registerPanel1 = new Patient.RegisterPanel();
            this.loginPanel1 = new Patient.LoginPanel();
            this.infoPanel1 = new Patient.InfoPanel();
            this.menuPanel1 = new Patient.MenuPanel();
            this.SuspendLayout();
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
            this.registerAppointment1.Enabled = false;
            this.registerAppointment1.Location = new System.Drawing.Point(337, 13);
            this.registerAppointment1.Name = "registerAppointment1";
            this.registerAppointment1.Size = new System.Drawing.Size(767, 513);
            this.registerAppointment1.TabIndex = 4;
            this.registerAppointment1.Visible = false;
            // 
            // registerPanel1
            // 
            this.registerPanel1.Enabled = false;
            this.registerPanel1.Location = new System.Drawing.Point(337, 13);
            this.registerPanel1.Name = "registerPanel1";
            this.registerPanel1.Size = new System.Drawing.Size(766, 512);
            this.registerPanel1.TabIndex = 3;
            this.registerPanel1.Visible = false;
            // 
            // loginPanel1
            // 
            this.loginPanel1.Location = new System.Drawing.Point(337, 13);
            this.loginPanel1.Name = "loginPanel1";
            this.loginPanel1.Size = new System.Drawing.Size(766, 512);
            this.loginPanel1.TabIndex = 2;
            // 
            // infoPanel1
            // 
            this.infoPanel1.Location = new System.Drawing.Point(12, 13);
            this.infoPanel1.Name = "infoPanel1";
            this.infoPanel1.Size = new System.Drawing.Size(318, 229);
            this.infoPanel1.TabIndex = 1;
            // 
            // menuPanel1
            // 
            this.menuPanel1.Location = new System.Drawing.Point(12, 321);
            this.menuPanel1.Name = "menuPanel1";
            this.menuPanel1.Size = new System.Drawing.Size(325, 204);
            this.menuPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 537);
            this.Controls.Add(this.appointmentPanel1);
            this.Controls.Add(this.appointmentsPanel1);
            this.Controls.Add(this.registerAppointment1);
            this.Controls.Add(this.registerPanel1);
            this.Controls.Add(this.loginPanel1);
            this.Controls.Add(this.infoPanel1);
            this.Controls.Add(this.menuPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MenuPanel menuPanel1;
        private InfoPanel infoPanel1;
        private LoginPanel loginPanel1;
        private RegisterPanel registerPanel1;
        private RegisterAppointmentPanel registerAppointment1;
        private AppointmentsPanel appointmentsPanel1;
        private AppointmentPanel appointmentPanel1;
    }
}

