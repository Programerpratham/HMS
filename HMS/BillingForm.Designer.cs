namespace HMS
{
    partial class BillingForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblPatient = new Label();
            cmbPatient = new ComboBox();
            dgvBillDetails = new DataGridView();
            colService = new DataGridViewTextBoxColumn();
            colQty = new DataGridViewTextBoxColumn();
            colRate = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            lblSubTotal = new Label();
            txtSubTotal = new TextBox();
            lblTax = new Label();
            txtTax = new TextBox();
            lblDiscount = new Label();
            txtDiscount = new TextBox();
            lblNet = new Label();
            txtNet = new TextBox();
            lblPayment = new Label();
            cmbPaymentMethod = new ComboBox();
            btnSaveBill = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBillDetails).BeginInit();
            SuspendLayout();
            // 
            // lblPatient
            // 
            lblPatient.AutoSize = true;
            lblPatient.Location = new Point(20, 20);
            lblPatient.Name = "lblPatient";
            lblPatient.Size = new Size(163, 32);
            lblPatient.TabIndex = 13;
            lblPatient.Text = "Select Patient:";
            // 
            // cmbPatient
            // 
            cmbPatient.Location = new Point(216, 17);
            cmbPatient.Name = "cmbPatient";
            cmbPatient.Size = new Size(250, 40);
            cmbPatient.TabIndex = 12;
            // 
            // dgvBillDetails
            // 
            dgvBillDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBillDetails.Columns.AddRange(new DataGridViewColumn[] { colService, colQty, colRate, colTotal });
            dgvBillDetails.Location = new Point(137, 79);
            dgvBillDetails.Name = "dgvBillDetails";
            dgvBillDetails.RowHeadersWidth = 82;
            dgvBillDetails.Size = new Size(805, 294);
            dgvBillDetails.TabIndex = 9;
            dgvBillDetails.CellValueChanged += dgvBillDetails_CellValueChanged;
            dgvBillDetails.RowsRemoved += dgvBillDetails_RowsRemoved;
            // 
            // colService
            // 
            colService.HeaderText = "Service Description";
            colService.MinimumWidth = 10;
            colService.Name = "colService";
            colService.Width = 250;
            // 
            // colQty
            // 
            colQty.HeaderText = "Qty";
            colQty.MinimumWidth = 10;
            colQty.Name = "colQty";
            colQty.Width = 80;
            // 
            // colRate
            // 
            colRate.HeaderText = "Rate";
            colRate.MinimumWidth = 10;
            colRate.Name = "colRate";
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Line Total";
            colTotal.MinimumWidth = 10;
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            colTotal.Width = 200;
            // 
            // lblSubTotal
            // 
            lblSubTotal.Location = new Point(452, 376);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(112, 66);
            lblSubTotal.TabIndex = 8;
            lblSubTotal.Text = "Sub Total:";
            // 
            // txtSubTotal
            // 
            txtSubTotal.Location = new Point(570, 379);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.ReadOnly = true;
            txtSubTotal.Size = new Size(100, 39);
            txtSubTotal.TabIndex = 7;
            txtSubTotal.Text = "0";
            // 
            // lblTax
            // 
            lblTax.Location = new Point(452, 442);
            lblTax.Name = "lblTax";
            lblTax.Size = new Size(112, 36);
            lblTax.TabIndex = 6;
            lblTax.Text = "Tax amount:";
            // 
            // txtTax
            // 
            txtTax.Location = new Point(568, 427);
            txtTax.Name = "txtTax";
            txtTax.Size = new Size(100, 39);
            txtTax.TabIndex = 5;
            txtTax.Text = "0";
            txtTax.TextChanged += CalculateFinalTotals;
            // 
            // lblDiscount
            // 
            lblDiscount.Location = new Point(438, 478);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(124, 38);
            lblDiscount.TabIndex = 4;
            lblDiscount.Text = "Discount:";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(570, 470);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(100, 39);
            txtDiscount.TabIndex = 3;
            txtDiscount.Text = "0";
            txtDiscount.TextChanged += CalculateFinalTotals;
            // 
            // lblNet
            // 
            lblNet.Location = new Point(438, 516);
            lblNet.Name = "lblNet";
            lblNet.Size = new Size(109, 32);
            lblNet.TabIndex = 2;
            lblNet.Text = "Net Payable:";
            lblNet.Click += lblNet_Click;
            // 
            // txtNet
            // 
            txtNet.Location = new Point(570, 515);
            txtNet.Name = "txtNet";
            txtNet.ReadOnly = true;
            txtNet.Size = new Size(100, 39);
            txtNet.TabIndex = 1;
            txtNet.Text = "0";
            // 
            // lblPayment
            // 
            lblPayment.AutoSize = true;
            lblPayment.Location = new Point(568, 20);
            lblPayment.Name = "lblPayment";
            lblPayment.Size = new Size(203, 32);
            lblPayment.TabIndex = 11;
            lblPayment.Text = "Payment Method:";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit Card", "UPI" });
            cmbPaymentMethod.Location = new Point(818, 12);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(150, 40);
            cmbPaymentMethod.TabIndex = 10;
            // 
            // btnSaveBill
            // 
            btnSaveBill.Location = new Point(497, 601);
            btnSaveBill.Name = "btnSaveBill";
            btnSaveBill.Size = new Size(100, 35);
            btnSaveBill.TabIndex = 0;
            btnSaveBill.Text = "Save Bill";
            btnSaveBill.Click += btnSaveBill_Click;
            // 
            // BillingForm
            // 
            ClientSize = new Size(1368, 691);
            Controls.Add(btnSaveBill);
            Controls.Add(txtNet);
            Controls.Add(lblNet);
            Controls.Add(txtDiscount);
            Controls.Add(lblDiscount);
            Controls.Add(txtTax);
            Controls.Add(lblTax);
            Controls.Add(txtSubTotal);
            Controls.Add(lblSubTotal);
            Controls.Add(dgvBillDetails);
            Controls.Add(cmbPaymentMethod);
            Controls.Add(lblPayment);
            Controls.Add(cmbPatient);
            Controls.Add(lblPatient);
            Name = "BillingForm";
            Text = "Patient Billing Module";
            Load += BillingForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBillDetails).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.ComboBox cmbPatient;
        private System.Windows.Forms.DataGridView dgvBillDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colService;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblSubTotal, lblTax, lblDiscount, lblNet, lblPayment;
        private System.Windows.Forms.TextBox txtSubTotal, txtTax, txtDiscount, txtNet;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Button btnSaveBill;
    }
}