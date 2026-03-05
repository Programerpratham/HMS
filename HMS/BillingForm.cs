using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace HMS
{
    public partial class BillingForm : Form
    {
        string connString = "Data Source=Localhost:1521/XE;User Id=system;Password=root;";

        public BillingForm()
        {
            InitializeComponent();
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            LoadPatients();
            cmbPaymentMethod.SelectedIndex = 0; // Default to Cash
        }

        private void LoadPatients()
        {
            using (OracleConnection conn = new OracleConnection(connString))
            {
                OracleDataAdapter da = new OracleDataAdapter("SELECT PID, P_NAME FROM PATIENTS", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbPatient.DataSource = dt;
                cmbPatient.DisplayMember = "P_NAME";
                cmbPatient.ValueMember = "PID";
                cmbPatient.SelectedIndex = -1;
            }
        }

        // --- PREDEFINED RATES HELPER METHOD ---
        private decimal GetServiceRate(string serviceName)
        {
            // You can adjust these placeholder prices to fit your project requirements
            switch (serviceName)
            {
                case "Emergency Bill": return 1500;
                case "OPD Bill (Out Patient Department)": return 500;
                case "IPD Bill (In Patient Department)": return 1000;
                case "Consultation Bill": return 800;
                case "Surgery Bill": return 25000;
                case "Laboratory Bill": return 1200;
                case "X-Ray": return 600;
                case "CT Scan": return 3500;
                case "MRI": return 7000;
                case "ECG": return 400;
                case "Sonography": return 1500;
                case "Pharmacy Bill": return 0; // Set to 0 so the user can type the exact medicine cost
                case "Nursing Charges": return 800;
                case "Operation Theatre (OT) Charges": return 10000;
                case "Room / Ward Charges": return 2000;
                case "ICU Bill": return 5000;
                case "Ambulance Bill": return 1500;
                case "Admission Charges": return 1000;
                case "Discharge Charges": return 500;
                default: return 0;
            }
        }

        // --- REAL-TIME MATH LOGIC ---

        private void dgvBillDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBillDetails.Rows[e.RowIndex];

                // 1. Auto-fill the Rate and Qty if the user selects a Service Description
                if (e.ColumnIndex == 0 && row.Cells[0].Value != null)
                {
                    string selectedService = row.Cells[0].Value.ToString();
                    decimal predefinedRate = GetServiceRate(selectedService);

                    // Set the Rate column (Index 2)
                    row.Cells[2].Value = predefinedRate.ToString("0.00");

                    // Set Qty column (Index 1) to "1" by default if it's empty
                    if (row.Cells[1].Value == null || string.IsNullOrWhiteSpace(row.Cells[1].Value.ToString()))
                    {
                        row.Cells[1].Value = "1";
                    }
                }

                // 2. Calculate the Line Total if Service, Qty, or Rate changes
                if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    decimal qty = 0, rate = 0;

                    decimal.TryParse(Convert.ToString(row.Cells[1].Value), out qty);
                    decimal.TryParse(Convert.ToString(row.Cells[2].Value), out rate);

                    row.Cells[3].Value = (qty * rate).ToString("0.00");
                    CalculateSubTotal();
                }
            }
        }

        private void dgvBillDetails_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateSubTotal();
        }

        private void CalculateSubTotal()
        {
            decimal subTotal = 0;
            foreach (DataGridViewRow row in dgvBillDetails.Rows)
            {
                if (row.Cells[3].Value != null)
                {
                    subTotal += Convert.ToDecimal(row.Cells[3].Value);
                }
            }
            txtSubTotal.Text = subTotal.ToString("0.00");

            // Trigger the auto-calculation of Tax, Discount, and Net Payable
            CalculateFinalTotals(this, EventArgs.Empty);
        }

        private void CalculateFinalTotals(object sender, EventArgs e)
        {
            decimal subTotal = 0;
            decimal.TryParse(txtSubTotal.Text, out subTotal);

            // Predefined Calculations: 18% Tax and 5% Discount
            decimal tax = subTotal * 0.18m;
            subTotal = subTotal - tax;
            decimal discount = subTotal * 0.05m;

            // Update UI fields automatically
            txtTax.Text = tax.ToString("0.00");
            txtDiscount.Text = discount.ToString("0.00");

            // Final Net Payable: Sub Total + Tax - Discount
            decimal netPayable = (subTotal + tax) - discount;
            txtNet.Text = netPayable.ToString("0.00");
        }

        // --- DATABASE SAVE LOGIC WITH TRANSACTIONS ---

        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            if (cmbPatient.SelectedValue == null)
            {
                MessageBox.Show("Please select a patient.");
                return;
            }

            if (dgvBillDetails.Rows.Count <= 1) // Accounts for the empty new row
            {
                MessageBox.Show("Please enter at least one service/item.");
                return;
            }

            using (OracleConnection conn = new OracleConnection(connString))
            {
                conn.Open();

                // Begin Transaction to ensure Header and Details save together
                using (OracleTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Insert Header and retrieve the generated BILL_NO
                        string headerQuery = @"INSERT INTO BILL_HEADER (BILL_NO, PID, SUB_TOTAL, TAX_AMOUNT, DISCOUNT, NET_AMOUNT, PAYMENT_METHOD) 
                                               VALUES (seq_bill_no.NEXTVAL, :pid, :sub, :tax, :disc, :net, :paymethod) 
                                               RETURNING BILL_NO INTO :inserted_bill_no";

                        OracleCommand cmdHeader = new OracleCommand(headerQuery, conn);
                        cmdHeader.Parameters.Add(":pid", cmbPatient.SelectedValue);
                        cmdHeader.Parameters.Add(":sub", Convert.ToDecimal(txtSubTotal.Text));
                        cmdHeader.Parameters.Add(":tax", Convert.ToDecimal(txtTax.Text));
                        cmdHeader.Parameters.Add(":disc", Convert.ToDecimal(txtDiscount.Text));
                        cmdHeader.Parameters.Add(":net", Convert.ToDecimal(txtNet.Text));
                        cmdHeader.Parameters.Add(":paymethod", cmbPaymentMethod.SelectedItem.ToString());

                        // Output parameter to get the auto-generated ID back
                        OracleParameter outputIdParam = new OracleParameter(":inserted_bill_no", OracleDbType.Decimal);
                        outputIdParam.Direction = ParameterDirection.Output;
                        cmdHeader.Parameters.Add(outputIdParam);

                        cmdHeader.ExecuteNonQuery();

                        // Get the newly created Bill Number
                        string newBillNo = outputIdParam.Value.ToString();

                        // 2. Loop through the grid and insert Details
                        string detailQuery = @"INSERT INTO BILL_DETAILS (DETAIL_ID, BILL_NO, SERVICE_DESC, QTY, RATE, LINE_TOTAL) 
                        VALUES (seq_bill_detail.NEXTVAL, :bno, :servdesc, :qty, :rate, :total)";

                        OracleCommand cmdDetail = new OracleCommand(detailQuery, conn);

                        foreach (DataGridViewRow row in dgvBillDetails.Rows)
                        {
                            if (!row.IsNewRow && row.Cells[0].Value != null)
                            {
                                cmdDetail.Parameters.Clear();
                                cmdDetail.Parameters.Add(":bno", newBillNo);
                                cmdDetail.Parameters.Add(":servdesc", row.Cells[0].Value.ToString());
                                cmdDetail.Parameters.Add(":qty", Convert.ToDecimal(row.Cells[1].Value));
                                cmdDetail.Parameters.Add(":rate", Convert.ToDecimal(row.Cells[2].Value));
                                cmdDetail.Parameters.Add(":total", Convert.ToDecimal(row.Cells[3].Value));
                                cmdDetail.ExecuteNonQuery();
                            }
                        }

                        // 3. Commit the transaction if everything succeeded
                        trans.Commit();
                        MessageBox.Show($"Bill successfully generated! Bill Number: {newBillNo}");

                        // Reset Form
                        dgvBillDetails.Rows.Clear();
                        txtTax.Text = "0";
                        txtDiscount.Text = "0";
                        cmbPatient.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Error saving bill. Transaction rolled back. Details: " + ex.Message);
                    }
                }
            }
        }

        private void lblNet_Click(object sender, EventArgs e)
        {

        }
    }
}