namespace HMS
{
    partial class DoctorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDoctorId = new System.Windows.Forms.Label();
            this.lblDocName = new System.Windows.Forms.Label();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtDoctorId = new System.Windows.Forms.TextBox();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.txtSpecialization = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvDoctors = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
            this.SuspendLayout();

            // Labels
            this.lblDoctorId.AutoSize = true;
            this.lblDoctorId.Location = new System.Drawing.Point(30, 30);
            this.lblDoctorId.Name = "lblDoctorId";
            this.lblDoctorId.Text = "Doctor ID:";

            this.lblDocName.AutoSize = true;
            this.lblDocName.Location = new System.Drawing.Point(30, 70);
            this.lblDocName.Name = "lblDocName";
            this.lblDocName.Text = "Name:";

            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.Location = new System.Drawing.Point(30, 110);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Text = "Specialization:";

            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(30, 150);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Text = "Phone:";

            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(30, 190);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email:";

            // TextBoxes
            this.txtDoctorId.Location = new System.Drawing.Point(130, 27);
            this.txtDoctorId.Name = "txtDoctorId";
            this.txtDoctorId.Size = new System.Drawing.Size(200, 23);

            this.txtDocName.Location = new System.Drawing.Point(130, 67);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.Size = new System.Drawing.Size(200, 23);

            this.txtSpecialization.Location = new System.Drawing.Point(130, 107);
            this.txtSpecialization.Name = "txtSpecialization";
            this.txtSpecialization.Size = new System.Drawing.Size(200, 23);

            this.txtPhone.Location = new System.Drawing.Point(130, 147);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 23);

            this.txtEmail.Location = new System.Drawing.Point(130, 187);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 23);

            // Buttons
            this.btnAdd.Location = new System.Drawing.Point(30, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(120, 240);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 30);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(210, 240);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Location = new System.Drawing.Point(300, 240);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // DataGridView
            this.dgvDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctors.Location = new System.Drawing.Point(30, 290);
            this.dgvDoctors.Name = "dgvDoctors";
            this.dgvDoctors.Size = new System.Drawing.Size(550, 200);
            this.dgvDoctors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoctors_CellClick);

            // DoctorForm (Main Form Settings)
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 520);
            this.Controls.Add(this.dgvDoctors);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtSpecialization);
            this.Controls.Add(this.txtDocName);
            this.Controls.Add(this.txtDoctorId);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.lblDocName);
            this.Controls.Add(this.lblDoctorId);
            this.Name = "DoctorForm";
            this.Text = "Manage Doctors";
            this.Load += new System.EventHandler(this.DoctorForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Variable Declarations added here outside the method
        private System.Windows.Forms.Label lblDoctorId;
        private System.Windows.Forms.Label lblDocName;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtDoctorId;
        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.TextBox txtSpecialization;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvDoctors;
    }
}   