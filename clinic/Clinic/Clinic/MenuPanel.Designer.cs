namespace Clinic
{
    partial class MenuPanel
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
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonRegisterAppointment = new System.Windows.Forms.Button();
            this.buttonAppointments = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(3, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(313, 44);
            this.buttonEdit.TabIndex = 0;
            this.buttonEdit.Text = "Edytuj dane";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonRegisterAppointment
            // 
            this.buttonRegisterAppointment.Location = new System.Drawing.Point(3, 53);
            this.buttonRegisterAppointment.Name = "buttonRegisterAppointment";
            this.buttonRegisterAppointment.Size = new System.Drawing.Size(313, 44);
            this.buttonRegisterAppointment.TabIndex = 1;
            this.buttonRegisterAppointment.Text = "Zarejestruj Wizyte";
            this.buttonRegisterAppointment.UseVisualStyleBackColor = true;
            // 
            // buttonAppointments
            // 
            this.buttonAppointments.Location = new System.Drawing.Point(3, 103);
            this.buttonAppointments.Name = "buttonAppointments";
            this.buttonAppointments.Size = new System.Drawing.Size(313, 44);
            this.buttonAppointments.TabIndex = 2;
            this.buttonAppointments.Text = "Wizyty";
            this.buttonAppointments.UseVisualStyleBackColor = true;
            this.buttonAppointments.Click += new System.EventHandler(this.buttonAppointments_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(3, 153);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(313, 44);
            this.buttonLogOut.TabIndex = 3;
            this.buttonLogOut.Text = "Zamknij";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // MenuPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonRegisterAppointment);
            this.Controls.Add(this.buttonAppointments);
            this.Controls.Add(this.buttonLogOut);
            this.Name = "MenuPanel";
            this.Size = new System.Drawing.Size(320, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonRegisterAppointment;
        private System.Windows.Forms.Button buttonAppointments;
        private System.Windows.Forms.Button buttonLogOut;
    }
}
