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
    public partial class ProductModuleForm : Form
    {
        private static string Connectionstring = DbConnection.DBCon();
        public static SqlConnection con = new SqlConnection(Connectionstring);
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        public void LoadCategory() 
        {
            cbCategory.Items.Clear();
            cm = new SqlCommand("SELECT CategoryName FROM tblCategory", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read()) 
            {
                cbCategory.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (MessageBox.Show("Are you sure you want to save this product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tblProduct ( ProductName, ProductQty, ProductPrice,ProductDescription,ProductCategory) VALUES ( @ProductName, @ProductQty, @ProductPrice,@ProductDescription,@ProductCategory)", con);
                    cm.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    cm.Parameters.AddWithValue("@ProductQty", Convert.ToInt32(txtQuantity.Text));
                    cm.Parameters.AddWithValue("@ProductPrice",Convert.ToDouble( txtPrice.Text));
                    cm.Parameters.AddWithValue("@ProductDescription", txtDescription.Text);
                    cm.Parameters.AddWithValue("@ProductCategory", cbCategory.Text);
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
            txtProductName.Clear();
            txtQuantity.Clear();
            txtPrice.Clear();
            txtDescription.Clear() ;
            cbCategory.Text = "";


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
                
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                {
                    
                    if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE  tblProduct SET ProductName=@ProductName, ProductQty=@ProductQty, ProductPrice = @ProductPrice,ProductDescription=@ProductDescription,ProductCategory = @ProductCategory  WHERE ProductId LIKE'" + lblProductId.Text + "' ", con);
                        cm.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cm.Parameters.AddWithValue("@ProductQty", Convert.ToInt32(txtQuantity.Text));
                        cm.Parameters.AddWithValue("@ProductPrice", Convert.ToInt32(txtPrice.Text));
                        cm.Parameters.AddWithValue("@ProductDescription", txtDescription.Text);
                        cm.Parameters.AddWithValue("@ProductCategory", cbCategory.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Product has been successfully updated");
                        this.Dispose();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
