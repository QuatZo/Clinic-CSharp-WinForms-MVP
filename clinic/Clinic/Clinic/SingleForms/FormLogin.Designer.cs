namespace Clinic
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxPesel = new System.Windows.Forms.TextBox();
            this.buttonLogin = new Clinic.ButtonModified();
            this.SuspendLayout();
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxID.Location = new System.Drawing.Point(63, 122);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(243, 26);
            this.textBoxID.TabIndex = 6;
            this.textBoxID.Text = "ID";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSurname.Location = new System.Drawing.Point(63, 90);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(243, 26);
            this.textBoxSurname.TabIndex = 5;
            this.textBoxSurname.Text = "Nazwisko";
            // 
            // textBoxPesel
            // 
            this.textBoxPesel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPesel.Location = new System.Drawing.Point(63, 58);
            this.textBoxPesel.Name = "textBoxPesel";
            this.textBoxPesel.Size = new System.Drawing.Size(243, 26);
            this.textBoxPesel.TabIndex = 4;
            this.textBoxPesel.Text = "PESEL";
            this.textBoxPesel.TextChanged += new System.EventHandler(this.textBoxPesel_TextChanged);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.White;
            this.buttonLogin.Enabled = false;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogin.ForeColor = System.Drawing.Color.Black;
            this.buttonLogin.Location = new System.Drawing.Point(114, 171);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(137, 37);
            this.buttonLogin.TabIndex = 7;
            this.buttonLogin.Text = "Logowanie";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 255);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxPesel);
            this.Controls.Add(this.buttonLogin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(389, 294);
            this.MinimumSize = new System.Drawing.Size(389, 294);
            this.Name = "FormLogin";
            this.Text = "Panel logowania";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxPesel;
        private ButtonModified buttonLogin;
    }
}