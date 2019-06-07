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
            this.buttonEdit = new Clinic.ButtonModified();
            this.buttonRegisterAppointment = new Clinic.ButtonModified();
            this.buttonAppointments = new Clinic.ButtonModified();
            this.buttonLogOut = new Clinic.ButtonModified();
            this.buttonEditAppointment = new Clinic.ButtonModified();
            this.SuspendLayout();
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.White;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEdit.ForeColor = System.Drawing.Color.Black;
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
            this.buttonRegisterAppointment.BackColor = System.Drawing.Color.White;
            this.buttonRegisterAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegisterAppointment.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRegisterAppointment.ForeColor = System.Drawing.Color.Black;
            this.buttonRegisterAppointment.Location = new System.Drawing.Point(3, 53);
            this.buttonRegisterAppointment.Name = "buttonRegisterAppointment";
            this.buttonRegisterAppointment.Size = new System.Drawing.Size(313, 44);
            this.buttonRegisterAppointment.TabIndex = 1;
            this.buttonRegisterAppointment.Text = "Zarejestruj Wizyte";
            this.buttonRegisterAppointment.UseVisualStyleBackColor = true;
            this.buttonRegisterAppointment.Click += new System.EventHandler(this.buttonRegisterAppointment_Click);
            // 
            // buttonAppointments
            // 
            this.buttonAppointments.BackColor = System.Drawing.Color.White;
            this.buttonAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAppointments.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAppointments.ForeColor = System.Drawing.Color.Black;
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
            this.buttonLogOut.BackColor = System.Drawing.Color.White;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOut.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogOut.ForeColor = System.Drawing.Color.Black;
            this.buttonLogOut.Location = new System.Drawing.Point(3, 153);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(313, 44);
            this.buttonLogOut.TabIndex = 3;
            this.buttonLogOut.Text = "Zamknij";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // buttonEditAppointment
            // 
            this.buttonEditAppointment.BackColor = System.Drawing.Color.White;
            this.buttonEditAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditAppointment.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEditAppointment.ForeColor = System.Drawing.Color.Black;
            this.buttonEditAppointment.Location = new System.Drawing.Point(4, 53);
            this.buttonEditAppointment.Name = "buttonEditAppointment";
            this.buttonEditAppointment.Size = new System.Drawing.Size(313, 44);
            this.buttonEditAppointment.TabIndex = 4;
            this.buttonEditAppointment.Text = "Edytuj Wizyte";
            this.buttonEditAppointment.UseVisualStyleBackColor = true;
            this.buttonEditAppointment.Click += new System.EventHandler(this.buttonEditAppointment_Click);
            // 
            // MenuPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAppointments);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonEditAppointment);
            this.Controls.Add(this.buttonRegisterAppointment);
            this.Name = "MenuPanel";
            this.Size = new System.Drawing.Size(320, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonModified buttonEdit;
        private ButtonModified buttonRegisterAppointment;
        private ButtonModified buttonAppointments;
        private ButtonModified buttonLogOut;
        private ButtonModified buttonEditAppointment;
    }
}
