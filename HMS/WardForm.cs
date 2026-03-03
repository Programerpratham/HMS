using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace HMS
{
    public partial class WardForm : Form
    {
        string Cnstr = "User Id=system;Password=root;Data Source=localhost:1521/XE;";
        OracleConnection conn;
        public WardForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.IsNewRow) return;

                textBox1.Text = row.Cells["ward_id"].Value?.ToString();
                textBox2.Text = row.Cells["ward_name"].Value?.ToString();
                comboBox1.Text = row.Cells["ward_type"].Value?.ToString();
                textBox3.Text = row.Cells["total_beds"].Value?.ToString();
                textBox4.Text = row.Cells["available_beds"].Value?.ToString();
            }
        }
        void loadgrid()
        {
            OracleDataAdapter da = new OracleDataAdapter("Select * from ward", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(Cnstr);
            comboBox1.Items.Add("General");
            comboBox1.Items.Add("ICU");
            comboBox1.Items.Add("Private");
            loadgrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertqry = $@"insert into ward values
            ({textBox1.Text},
           '{textBox2.Text}',
           '{comboBox1.Text}',
            {textBox3.Text},
            {textBox4.Text})";

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(insertqry, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ward Inserted");
                conn.Close();
                loadgrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string updateqry = $@"update ward set
               ward_name = '{textBox2.Text}',
               ward_type = '{comboBox1.Text}',
               total_beds = {textBox3.Text},
               available_beds = {textBox4.Text}
               where ward_id = {textBox1.Text}";

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(updateqry, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ward Updated");
                conn.Close();
                loadgrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteqry = $@"delete from ward
            where ward_id = {textBox1.Text}";

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(deleteqry, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ward Deleted");
                conn.Close();
                loadgrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }
    }
}
