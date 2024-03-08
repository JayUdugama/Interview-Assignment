using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory_Management_System
{
    public partial class OrderModuleForm : Form
    {
        private static string Connectionstring = DbConnection.DBCon();
        public static SqlConnection con = new SqlConnection(Connectionstring);
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int qty = 0;
        public OrderModuleForm()
        {
            InitializeComponent();
            LoadCustomer();
            LoadProduct();
        }


        public void LoadCustomer()
        {
            int i = 0;
            dgvCustomer.Rows.Clear();
            con.Open();
            cm = new SqlCommand("Select CustomerID, CustomerName FROM tblCustomer WHERE CONCAT(CustomerID, CustomerName) LIKE '%" + txtSearchCustomer.Text + "%'", con);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCustomer.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }
            dr.Close();
            con.Close();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            con.Open();
            cm = new SqlCommand("Select * FROM tblProduct WHERE CONCAT(ProductName, ProductQty, ProductPrice, ProductDescription, ProductCategory) LIKE '%" + txtSearchProoduct.Text + "%'", con);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            con.Close();
        }


        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomerId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCustomerName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer();
        }

        private void txtSearchProoduct_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

       

        
        

        

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GetQty();

            if (Convert.ToInt32(nudQty.Value) > qty) 
            {
                MessageBox.Show("Instock quantity is not enough", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudQty.Value = nudQty.Value - 1;
                return;
            }

            if (Convert.ToInt32(nudQty.Value) > 0)
            {
                double total = Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(nudQty.Value);
                txtTotal.Text = total.ToString();
            }
        }

        private void dgvProduct_Click(object sender, EventArgs e)
        {

        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCustomerId.Text = dgvCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCustomerName.Text = dgvCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductId.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtProductName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();

            //qty = Convert.ToInt32(dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString());

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerId.Text == "")
                {
                    MessageBox.Show("Please select Custome!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtProductId.Text == "")
                {
                    MessageBox.Show("Please select product!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to Insert this order?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tblOrder (OrderDate, ProductId, CustomerId, Qty ,Price ,Total) VALUES (@OrderDate, @ProductId, @CustomerId, @Qty ,@Price ,@Total)", con);
                    cm.Parameters.AddWithValue("@OrderDate", (dtOrder.Value));
                    cm.Parameters.AddWithValue("@ProductId", Convert.ToInt32(txtProductId.Text));
                    cm.Parameters.AddWithValue("@CustomerId", Convert.ToInt32(txtCustomerId.Text));
                    cm.Parameters.AddWithValue("@Qty", Convert.ToInt32(nudQty.Value));
                    cm.Parameters.AddWithValue("@Price", Convert.ToInt32(txtPrice.Text));
                    cm.Parameters.AddWithValue("@Total",Convert.ToInt32(txtTotal.Text));
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Order has been inserted successfully");
                    clear();

                    cm = new SqlCommand("UPDATE  tblProduct SET ProductQty=(ProductQty-@ProductQty) WHERE ProductId LIKE'" + txtProductId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@ProductQty", Convert.ToInt32(nudQty.Value));
                    
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    clear();
                    LoadProduct();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

               }
        public void clear() 
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtProductId.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            nudQty.Value = 0;
            txtTotal.Clear();
            dtOrder.Value = DateTime.Now;


            

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
           
            
        }

        public void GetQty() 
        {
            cm = new SqlCommand("Select ProductQty FROM tblProduct WHERE ProductId ='" + txtProductId.Text + "'",con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                qty = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
