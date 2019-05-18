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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPatientPesel
            // 
            this.textBoxPatientPesel.Location = new System.Drawing.Point(284, 215);
            this.textBoxPatientPesel.Name = "textBoxPatientPesel";
            this.textBoxPatientPesel.Size = new System.Drawing.Size(200, 20);
            this.textBoxPatientPesel.TabIndex = 0;
            this.textBoxPatientPesel.Text = "PESEL pacjenta";
            this.textBoxPatientPesel.TextChanged += new System.EventHandler(this.textBoxPatientPesel_TextChanged);
            // 
            // dateTimePickerAppointmentDate
            // 
            this.dateTimePickerAppointmentDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePickerAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAppointmentDate.Location = new System.Drawing.Point(284, 242);
            this.dateTimePickerAppointmentDate.Name = "dateTimePickerAppointmentDate";
            this.dateTimePickerAppointmentDate.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerAppointmentDate.TabIndex = 1;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(284, 269);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(200, 23);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Szukaj";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // EditAppointmentSearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dateTimePickerAppointmentDate);
            this.Controls.Add(this.textBoxPatientPesel);
            this.Name = "EditAppointmentSearchPanel";
            this.Size = new System.Drawing.Size(581, 440);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPatientPesel;
        private System.Windows.Forms.DateTimePicker dateTimePickerAppointmentDate;
        private System.Windows.Forms.Button buttonSearch;
    }
}
