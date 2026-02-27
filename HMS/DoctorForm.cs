using System;
using System.Data;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client; // Oracle's official library
using System.Windows.Forms;

namespace HMS
{
    public partial class DoctorForm : Form
    {
        // IMPORTANT: Replace this with your Oracle Connection String
        // Example: "Data Source=localhost:1521/XEPDB1;User Id=your_username;Password=your_password;"
        private string connectionString = "Data Source=Localhost:1521/XE;User Id=system;Password=root;";

        public DoctorForm()
        {
            InitializeComponent();
        }

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            LoadDoctorData();
        }

        // --- Helper Method: Load Data ---
        private void LoadDoctorData()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = "SELECT DOCTOR_ID, DOC_NAME, SPECIALIZATION, PHONE, EMAIL FROM DOCTORS";
                    OracleDataAdapter sda = new OracleDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dgvDoctors.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Add Button ---
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorId.Text) || string.IsNullOrWhiteSpace(txtDocName.Text))
            {
                MessageBox.Show("Doctor ID and Name are required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    // Oracle uses : instead of @ for parameters
                    string query = "INSERT INTO DOCTORS (DOCTOR_ID, DOC_NAME, SPECIALIZATION, PHONE, EMAIL) VALUES (:Id, :Name, :Spec, :Phone, :Email)";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.BindByName = true; // Crucial for Oracle to match variables by name, not order
                        cmd.Parameters.Add(new OracleParameter("Id", txtDoctorId.Text));
                        cmd.Parameters.Add(new OracleParameter("Name", txtDocName.Text));
                        cmd.Parameters.Add(new OracleParameter("Spec", txtSpecialization.Text));
                        cmd.Parameters.Add(new OracleParameter("Phone", txtPhone.Text));
                        cmd.Parameters.Add(new OracleParameter("Email", txtEmail.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Doctor added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                LoadDoctorData();
                btnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding doctor: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Update Button ---
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorId.Text))
            {
                MessageBox.Show("Please select a doctor to update (Doctor ID is required).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(connectionString))
                {
                    string query = "UPDATE DOCTORS SET DOC_NAME=:Name, SPECIALIZATION=:Spec, PHONE=:Phone, EMAIL=:Email WHERE DOCTOR_ID=:Id";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.BindByName = true;
                        cmd.Parameters.Add(new OracleParameter("Name", txtDocName.Text));
                        cmd.Parameters.Add(new OracleParameter("Spec", txtSpecialization.Text));
                        cmd.Parameters.Add(new OracleParameter("Phone", txtPhone.Text));
                        cmd.Parameters.Add(new OracleParameter("Email", txtEmail.Text));
                        cmd.Parameters.Add(new OracleParameter("Id", txtDoctorId.Text));

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Doctor updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Doctor ID not found.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                LoadDoctorData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating doctor: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Delete Button ---
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDoctorId.Text))
            {
                MessageBox.Show("Please select a doctor to delete.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this doctor?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (OracleConnection conn = new OracleConnection(connectionString))
                    {
                        string query = "DELETE FROM DOCTORS WHERE DOCTOR_ID=:Id";
                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.BindByName = true;
                            cmd.Parameters.Add(new OracleParameter("Id", txtDoctorId.Text));

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Doctor deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    LoadDoctorData();
                    btnClear_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting doctor: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Clear Button ---
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDoctorId.Clear();
            txtDocName.Clear();
            txtSpecialization.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtDoctorId.Focus();
        }

        // --- DataGridView Cell Click ---
        private void dgvDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDoctors.Rows[e.RowIndex];

                // Note: Oracle column names are returned in UPPERCASE by default
                txtDoctorId.Text = row.Cells["DOCTOR_ID"].Value?.ToString();
                txtDocName.Text = row.Cells["DOC_NAME"].Value?.ToString();
                txtSpecialization.Text = row.Cells["SPECIALIZATION"].Value?.ToString();
                txtPhone.Text = row.Cells["PHONE"].Value?.ToString();
                txtEmail.Text = row.Cells["EMAIL"].Value?.ToString();
            }
        }
    }
}