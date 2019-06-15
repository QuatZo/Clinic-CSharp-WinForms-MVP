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
            this.dateTimePickerAppointment = new System.Windows.Forms.DateTimePicker();
            this.textBoxContent = new System.Windows.Forms.TextBox();
            this.comboBoxSpecialization = new System.Windows.Forms.ComboBox();
            this.comboBoxDoctor = new System.Windows.Forms.ComboBox();
            this.textBoxHours = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonRegister = new Clinic.ButtonModified();
            this.SuspendLayout();
            // 
            // dateTimePickerAppointment
            // 
            this.dateTimePickerAppointment.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePickerAppointment.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerAppointment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAppointment.Location = new System.Drawing.Point(341, 214);
            this.dateTimePickerAppointment.Name = "dateTimePickerAppointment";
            this.dateTimePickerAppointment.Size = new System.Drawing.Size(301, 26);
            this.dateTimePickerAppointment.TabIndex = 13;
            this.dateTimePickerAppointment.ValueChanged += new System.EventHandler(this.dateTimePickerAppointment_ValueChanged);
            // 
            // textBoxContent
            // 
            this.textBoxContent.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxContent.Location = new System.Drawing.Point(194, 313);
            this.textBoxContent.Multiline = true;
            this.textBoxContent.Name = "textBoxContent";
            this.textBoxContent.Size = new System.Drawing.Size(520, 114);
            this.textBoxContent.TabIndex = 12;
            this.textBoxContent.Text = "Opis (nadpisywany później przez lekarza)";
            // 
            // comboBoxSpecialization
            // 
            this.comboBoxSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpecialization.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxSpecialization.FormattingEnabled = true;
            this.comboBoxSpecialization.Location = new System.Drawing.Point(341, 142);
            this.comboBoxSpecialization.Name = "comboBoxSpecialization";
            this.comboBoxSpecialization.Size = new System.Drawing.Size(301, 30);
            this.comboBoxSpecialization.TabIndex = 11;
            this.comboBoxSpecialization.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpecialization_SelectedIndexChanged);
            // 
            // comboBoxDoctor
            // 
            this.comboBoxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoctor.Enabled = false;
            this.comboBoxDoctor.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.comboBoxDoctor.FormattingEnabled = true;
            this.comboBoxDoctor.Location = new System.Drawing.Point(341, 178);
            this.comboBoxDoctor.Name = "comboBoxDoctor";
            this.comboBoxDoctor.Size = new System.Drawing.Size(301, 30);
            this.comboBoxDoctor.TabIndex = 10;
            this.comboBoxDoctor.SelectedIndexChanged += new System.EventHandler(this.comboBoxDoctor_SelectedIndexChanged);
            // 
            // textBoxHours
            // 
            this.textBoxHours.Enabled = false;
            this.textBoxHours.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxHours.Location = new System.Drawing.Point(341, 246);
            this.textBoxHours.Name = "textBoxHours";
            this.textBoxHours.Size = new System.Drawing.Size(301, 26);
            this.textBoxHours.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(159, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Specjalizacja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(159, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "Lekarz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(75, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 22);
            this.label3.TabIndex = 20;
            this.label3.Text = "Opis wizyty";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(159, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 22);
            this.label4.TabIndex = 21;
            this.label4.Text = "Data wizyty";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(159, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 22);
            this.label5.TabIndex = 22;
            this.label5.Text = "Godziny przyjmowania";
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.White;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRegister.ForeColor = System.Drawing.Color.Black;
            this.buttonRegister.Location = new System.Drawing.Point(312, 448);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(212, 37);
            this.buttonRegister.TabIndex = 15;
            this.buttonRegister.Text = "Zarejestruj";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // RegisterAppointmentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxHours);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.dateTimePickerAppointment);
            this.Controls.Add(this.textBoxContent);
            this.Controls.Add(this.comboBoxSpecialization);
            this.Controls.Add(this.comboBoxDoctor);
            this.Name = "RegisterAppointmentPanel";
            this.Size = new System.Drawing.Size(818, 527);
            this.Load += new System.EventHandler(this.RegisterAppointmentPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxContent;
        private System.Windows.Forms.ComboBox comboBoxSpecialization;
        private System.Windows.Forms.ComboBox comboBoxDoctor;
        private System.Windows.Forms.TextBox textBoxHours;
        private System.Windows.Forms.DateTimePicker dateTimePickerAppointment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ButtonModified buttonRegister;
        private System.Windows.Forms.Label label5;
    }
}
