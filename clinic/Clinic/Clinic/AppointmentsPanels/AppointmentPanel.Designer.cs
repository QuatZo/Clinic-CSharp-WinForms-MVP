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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePickerAppointment
            // 
            this.dateTimePickerAppointment.CustomFormat = "dd-MM-yyyy HH:mm";
            this.dateTimePickerAppointment.Enabled = false;
            this.dateTimePickerAppointment.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAppointment.Location = new System.Drawing.Point(209, 162);
            this.dateTimePickerAppointment.Name = "dateTimePickerAppointment";
            this.dateTimePickerAppointment.Size = new System.Drawing.Size(214, 26);
            this.dateTimePickerAppointment.TabIndex = 20;
            // 
            // textBoxContent
            // 
            this.textBoxContent.BackColor = System.Drawing.Color.White;
            this.textBoxContent.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxContent.Location = new System.Drawing.Point(209, 358);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.ReadOnly = true;
            this.textBoxContent.Size = new System.Drawing.Size(401, 139);
            this.textBoxContent.TabIndex = 19;
            this.textBoxContent.Text = "Opis ";
            this.textBoxContent.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxDoctor
            // 
            this.textBoxDoctor.BackColor = System.Drawing.Color.White;
            this.textBoxDoctor.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDoctor.Location = new System.Drawing.Point(209, 130);
            this.textBoxDoctor.Name = "textBoxDoctor";
            this.textBoxDoctor.ReadOnly = true;
            this.textBoxDoctor.Size = new System.Drawing.Size(214, 26);
            this.textBoxDoctor.TabIndex = 24;
            this.textBoxDoctor.Text = "Lekarz";
            // 
            // textBoxPatient
            // 
            this.textBoxPatient.BackColor = System.Drawing.Color.White;
            this.textBoxPatient.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPatient.Location = new System.Drawing.Point(209, 98);
            this.textBoxPatient.Name = "textBoxPatient";
            this.textBoxPatient.ReadOnly = true;
            this.textBoxPatient.Size = new System.Drawing.Size(214, 26);
            this.textBoxPatient.TabIndex = 26;
            this.textBoxPatient.Text = "Pacjent";
            // 
            // textBoxPatientPesel
            // 
            this.textBoxPatientPesel.BackColor = System.Drawing.Color.White;
            this.textBoxPatientPesel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPatientPesel.Location = new System.Drawing.Point(209, 66);
            this.textBoxPatientPesel.Name = "textBoxPatientPesel";
            this.textBoxPatientPesel.ReadOnly = true;
            this.textBoxPatientPesel.Size = new System.Drawing.Size(214, 26);
            this.textBoxPatientPesel.TabIndex = 27;
            this.textBoxPatientPesel.Text = "PESEL";
            // 
            // listBoxPrescription
            // 
            this.listBoxPrescription.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxPrescription.FormattingEnabled = true;
            this.listBoxPrescription.ItemHeight = 22;
            this.listBoxPrescription.Location = new System.Drawing.Point(209, 194);
            this.listBoxPrescription.Name = "listBoxPrescription";
            this.listBoxPrescription.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxPrescription.Size = new System.Drawing.Size(291, 158);
            this.listBoxPrescription.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(102, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 29;
            this.label1.Text = "PESEL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(102, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 22);
            this.label2.TabIndex = 30;
            this.label2.Text = "Pacjent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(102, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 31;
            this.label3.Text = "Lekarz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(102, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 22);
            this.label4.TabIndex = 32;
            this.label4.Text = "Opis wizyty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(102, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 22);
            this.label5.TabIndex = 33;
            this.label5.Text = "Data wizyty";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(102, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 22);
            this.label6.TabIndex = 34;
            this.label6.Text = "Recepta";
            // 
            // AppointmentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
