namespace Clinic
{
    partial class EditAppointmentSearchPanel
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
            this.textBoxPatientPesel = new System.Windows.Forms.TextBox();
            this.dateTimePickerAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSearch = new Clinic.ButtonModified();
            this.SuspendLayout();
            // 
            // textBoxPatientPesel
            // 
            this.textBoxPatientPesel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPatientPesel.Location = new System.Drawing.Point(359, 228);
            this.textBoxPatientPesel.Name = "textBoxPatientPesel";
            this.textBoxPatientPesel.Size = new System.Drawing.Size(189, 26);
            this.textBoxPatientPesel.TabIndex = 0;
            this.textBoxPatientPesel.TextChanged += new System.EventHandler(this.textBoxPatientPesel_TextChanged);
            // 
            // dateTimePickerAppointmentDate
            // 
            this.dateTimePickerAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePickerAppointmentDate.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAppointmentDate.Location = new System.Drawing.Point(359, 260);
            this.dateTimePickerAppointmentDate.Name = "dateTimePickerAppointmentDate";
            this.dateTimePickerAppointmentDate.Size = new System.Drawing.Size(189, 26);
            this.dateTimePickerAppointmentDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(223, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "PESEL pacjenta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(223, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data wizyty";
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSearch.ForeColor = System.Drawing.Color.Black;
            this.buttonSearch.Location = new System.Drawing.Point(359, 292);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(189, 38);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Szukaj";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // EditAppointmentSearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dateTimePickerAppointmentDate);
            this.Controls.Add(this.textBoxPatientPesel);
            this.Name = "EditAppointmentSearchPanel";
            this.Size = new System.Drawing.Size(809, 572);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPatientPesel;
        private System.Windows.Forms.DateTimePicker dateTimePickerAppointmentDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ButtonModified buttonSearch;
    }
}
