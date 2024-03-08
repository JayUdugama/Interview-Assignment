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
    public partial class UserForms : Form
    {
        private static string Connectionstring = DbConnection.DBCon();
        public static SqlConnection con = new SqlConnection(Connectionstring);
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public UserForms()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("Select * fROM tblUser", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString() ,dr[4].ToString());
            }
            dr.Close();
            con.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModuleForms userModule = new UserModuleForms();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = true;
            userModule.ShowDialog();
            LoadUser();

        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModuleForms userModule = new UserModuleForms();
                userModule.txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtFullname.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtPassword.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtConfirmPswrd.Text= dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                userModule.txtPhoneNo.Text = dgvUser.Rows[e.RowIndex].Cells[5].Value.ToString();
                
                
                userModule.btnSave.Enabled = false;
                userModule.btnUpdate.Enabled = true;
                userModule.txtUserName.Enabled = false;
                userModule.ShowDialog();
            }

            else if (colName == "Delete") 
            {
                if (MessageBox.Show("Are you sure you want to delete this user?","Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tblUser WHERE Username  LIKE'"+ dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString()+"'",con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Recode has been successfully deleted!");


                }
            
            }
            LoadUser();
        }

        
    }
}