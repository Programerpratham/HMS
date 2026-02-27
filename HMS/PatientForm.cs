using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace HMS
{
    public partial class PatientForm : Form
    {
        // Your Oracle connection string
        private string connectionString = "Data Source=Localhost:1521/XE;User Id=system;Password=root;";

        public PatientForm()
        {
            InitializeComponent();
        }

        private void PatientForm_Load(object sender, EventArgs e)
        {
            LoadPatientData();
        }

        // --- Helper Method: Load Data ---
        private void LoadPatientData()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = "SELECT PID, P_NAME, GENDER, AGE, CONTACT, ADDRESS, DISEASE FROM PATIENTS";
                    OracleDataAdapter sda = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvPatients.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Helper Method: Get Selected Gender ---
        private string GetSelectedGender()
        {
            if (rdoMale.Checked)
                return "Male";
            if (rdoFemale.Checked)
                return "Female";

            return ""; // Returns empty if neither is checked
        }

        // --- Add Button ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPid.Text) || string.IsNullOrWhiteSpace(txtPName.Text))
            {
                MessageBox.Show("Patient ID and Name are required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = "INSERT INTO PATIENTS (PID, P_NAME, GENDER, AGE, CONTACT, ADDRESS, DISEASE) VALUES (:Id, :Name, :Gender, :Age, :Contact, :Address, :Disease)";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add(new OracleParameter("Id", txtPid.Text));
                        cmd.Parameters.Add(new OracleParameter("Name", txtPName.Text));
                        cmd.Parameters.Add(new OracleParameter("Gender", GetSelectedGender())); // Uses the radio buttons
                        cmd.Parameters.Add(new OracleParameter("Age", txtAge.Text));
                        cmd.Parameters.Add(new OracleParameter("Contact", txtContact.Text));
                        cmd.Parameters.Add(new OracleParameter("Address", txtAddress.Text));
                        cmd.Parameters.Add(new OracleParameter("Disease", txtDisease.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Patient added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                LoadPatientData();
                btnClear_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding patient: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Update Button ---
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPid.Text))
            {
                MessageBox.Show("Please select a patient to update (PID is required).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = "UPDATE PATIENTS SET P_NAME=:Name, GENDER=:Gender, AGE=:Age, CONTACT=:Contact, ADDRESS=:Address, DISEASE=:Disease WHERE PID=:Id";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add(new OracleParameter("Name", txtPName.Text));
                        cmd.Parameters.Add(new OracleParameter("Gender", GetSelectedGender())); // Uses the radio buttons
                        cmd.Parameters.Add(new OracleParameter("Age", txtAge.Text));
                        cmd.Parameters.Add(new OracleParameter("Contact", txtContact.Text));
                        cmd.Parameters.Add(new OracleParameter("Address", txtAddress.Text));
                        cmd.Parameters.Add(new OracleParameter("Disease", txtDisease.Text));
                        cmd.Parameters.Add(new OracleParameter("Id", txtPid.Text));

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Patient updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Patient ID not found.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                LoadPatientData();
                btnClear_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating patient: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Delete Button ---
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPid.Text))
            {
                MessageBox.Show("Please select a patient to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this patient?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (OracleConnection conn = new OracleConnection(connectionString))
                    {
                        string query = "DELETE FROM PATIENTS WHERE PID=:Id";
                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.BindByName = true;
                            cmd.Parameters.Add(new OracleParameter("Id", txtPid.Text));

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Patient deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    LoadPatientData();
                    btnClear_Click(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting patient: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Clear Button ---
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPid.Clear();
            txtPName.Clear();

            // Uncheck the radio buttons
            rdoMale.Checked = false;
            rdoFemale.Checked = false;

            txtAge.Clear();
            txtContact.Clear();
            txtAddress.Clear();
            txtDisease.Clear();
            txtPid.Focus();
        }

        // --- DataGridView Cell Click ---
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvPatients.Rows[e.RowIndex];

                txtPid.Text = row.Cells["PID"].Value?.ToString() ?? "";
                txtPName.Text = row.Cells["P_NAME"].Value?.ToString() ?? "";

                // Read gender from DB and check the correct radio button
                string gender = row.Cells["GENDER"].Value?.ToString() ?? "";
                if (gender == "Male")
                {
                    rdoMale.Checked = true;
                    rdoFemale.Checked = false;
                }
                else if (gender == "Female")
                {
                    rdoMale.Checked = false;
                    rdoFemale.Checked = true;
                }
                else
                {
                    rdoMale.Checked = false;
                    rdoFemale.Checked = false;
                }

                txtAge.Text = row.Cells["AGE"].Value?.ToString() ?? "";
                txtContact.Text = row.Cells["CONTACT"].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["ADDRESS"].Value?.ToString() ?? "";
                txtDisease.Text = row.Cells["DISEASE"].Value?.ToString() ?? "";
            }
        }
    }
}