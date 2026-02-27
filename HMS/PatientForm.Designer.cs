namespace HMS
{
    partial class PatientForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblPid = new System.Windows.Forms.Label();
            this.lblPName = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDisease = new System.Windows.Forms.Label();

            this.txtPid = new System.Windows.Forms.TextBox();
            this.txtPName = new System.Windows.Forms.TextBox();

            // Radio Buttons instead of TextBox
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.rdoFemale = new System.Windows.Forms.RadioButton();

            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtDisease = new System.Windows.Forms.TextBox();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.dgvPatients = new System.Windows.Forms.DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.SuspendLayout();

            // Labels
            this.lblPid.AutoSize = true;
            this.lblPid.Location = new System.Drawing.Point(30, 30);
            this.lblPid.Name = "lblPid";
            this.lblPid.Text = "Patient ID:";

            this.lblPName.AutoSize = true;
            this.lblPName.Location = new System.Drawing.Point(30, 70);
            this.lblPName.Name = "lblPName";
            this.lblPName.Text = "Name:";

            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(30, 110);
            this.lblGender.Name = "lblGender";
            this.lblGender.Text = "Gender:";

            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(30, 150);
            this.lblAge.Name = "lblAge";
            this.lblAge.Text = "Age:";

            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(30, 190);
            this.lblContact.Name = "lblContact";
            this.lblContact.Text = "Contact:";

            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(30, 230);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Text = "Address:";

            this.lblDisease.AutoSize = true;
            this.lblDisease.Location = new System.Drawing.Point(30, 270);
            this.lblDisease.Name = "lblDisease";
            this.lblDisease.Text = "Disease:";

            // TextBoxes & RadioButtons
            this.txtPid.Location = new System.Drawing.Point(130, 27);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(200, 23);

            this.txtPName.Location = new System.Drawing.Point(130, 67);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(200, 23);

            // rdoMale
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(130, 108);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(51, 19);
            this.rdoMale.Text = "Male";
            this.rdoMale.UseVisualStyleBackColor = true;

            // rdoFemale
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(190, 108);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(63, 19);
            this.rdoFemale.Text = "Female";
            this.rdoFemale.UseVisualStyleBackColor = true;

            this.txtAge.Location = new System.Drawing.Point(130, 147);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(200, 23);

            this.txtContact.Location = new System.Drawing.Point(130, 187);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(200, 23);

            this.txtAddress.Location = new System.Drawing.Point(130, 227);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 23);

            this.txtDisease.Location = new System.Drawing.Point(130, 267);
            this.txtDisease.Name = "txtDisease";
            this.txtDisease.Size = new System.Drawing.Size(200, 23);

            // Buttons
            this.btnAdd.Location = new System.Drawing.Point(30, 320);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(120, 320);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 30);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(210, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClear.Location = new System.Drawing.Point(300, 320);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // DataGridView
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Location = new System.Drawing.Point(30, 370);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.Size = new System.Drawing.Size(650, 200);
            this.dgvPatients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellClick);

            // PatientForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 600);
            this.Controls.Add(this.dgvPatients);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDisease);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtAge);

            // Add RadioButtons instead of txtGender
            this.Controls.Add(this.rdoMale);
            this.Controls.Add(this.rdoFemale);

            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.lblDisease);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblPName);
            this.Controls.Add(this.lblPid);
            this.Name = "PatientForm";
            this.Text = "Manage Patients";
            this.Load += new System.EventHandler(this.PatientForm_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.Label lblPName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblDisease;

        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtDisease;

        // Added RadioButtons
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.RadioButton rdoFemale;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvPatients;
    }
}