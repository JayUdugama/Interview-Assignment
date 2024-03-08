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
    public partial class CustomerModuleForm : Form
    {
        private static string Connectionstring = DbConnection.DBCon();
        public static SqlConnection con = new SqlConnection(Connectionstring);
        SqlCommand cm = new SqlCommand();
        public CustomerModuleForm()
        {
            InitializeComponent();
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (MessageBox.Show("Are you sure you want to save this Customer?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tblCustomer (CustomerName,PhoneNo) VALUES ( @CustomerName, @PhoneNo)", con);
                    cm.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cm.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User added successfully");
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        public void clear()
        {
            txtCustomerName.Clear();
            txtPhoneNo.Clear();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;



        }

        private void lblCustomerId_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                {
                   
                    if (MessageBox.Show("Are you sure you want to update this customer?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE  tblCustomer SET CustomerName=@CustomerName, PhoneNo=@PhoneNo WHERE CustomerID LIKE'" + lblCustomerId.Text + "' ", con);
                        cm.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                        cm.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Customer has been successfully updated");
                        this.Dispose();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
