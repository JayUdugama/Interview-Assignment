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
    public partial class OrdersForm : Form
    {
        private static string Connectionstring = DbConnection.DBCon();
        public static SqlConnection con = new SqlConnection(Connectionstring);
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public OrdersForm()
        {
            InitializeComponent();
            LoadOrder();
            
       
        }
        public void LoadOrder()
        {
            double total = 0;
      
            int i = 0;
            dgvOrder.Rows.Clear();
            cm = new SqlCommand("SELECT OrderID, OrderDate, O.ProductId, P.ProductName, O.CustomerID, C.CustomerName ,Qty ,Price ,Total FROM tblOrder AS O JOIN tblCustomer AS C ON O.CustomerId = C.CustomerID JOIN tblProduct AS P ON O.ProductId = P.ProductId WHERE CONCAT(OrderID, OrderDate, O.ProductId, P.ProductName, O.CustomerID, C.CustomerName ,Qty ,Price) LIKE '%"+txtSearch.Text+"%'", con);

            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvOrder.Rows.Add(i, dr[0].ToString(), Convert.ToDateTime(dr[1].ToString()).ToString("dd/MM/yyyy"), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(),dr[7].ToString(),dr[8].ToString());
                total += Convert.ToDouble(dr[8].ToString());
            }
            dr.Close();
            con.Close();

            lblQty.Text = i.ToString();
            lblTotalAmount.Text = total.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderModuleForm moduleForm = new OrderModuleForm();
            moduleForm.ShowDialog();
            LoadOrder();
        }

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOrder.Columns[e.ColumnIndex].Name;
            
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tblOrder WHERE OrderID  LIKE'" + dgvOrder.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Recode has been successfully deleted!");

                    cm = new SqlCommand("UPDATE  tblProduct SET ProductQty=(ProductQty+@ProductQty) WHERE ProductId LIKE'" + dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString() + "' ", con);
                    cm.Parameters.AddWithValue("@ProductQty", Convert.ToInt32(dgvOrder.Rows[e.RowIndex].Cells[5].Value.ToString()));

                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();


                }

            }
            LoadOrder();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
