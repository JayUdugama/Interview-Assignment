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
    public partial class UserModuleForms : Form

    {
        private static string Connectionstring = DbConnection.DBCon();
        public static SqlConnection con = new SqlConnection(Connectionstring);
        SqlCommand cm = new SqlCommand();

        public UserModuleForms()
        {
            InitializeComponent();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtConfirmPswrd.Text) 
                {
                    MessageBox.Show("Password did not match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("INSERT INTO tblUser (Username, Fullname, Password,ConfirmPassword, Phone) VALUES (@Username, @Fullname, @Password,@ConfirmPassword , @Phone)", con);
                    cm.Parameters.AddWithValue("@Username", txtUserName.Text);
                    cm.Parameters.AddWithValue("@Fullname", txtFullname.Text);
                    cm.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cm.Parameters.AddWithValue("@ConfirmPasssword", txtConfirmPswrd.Text);
                    cm.Parameters.AddWithValue("@Phone", txtPhoneNo.Text);
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
        

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        public void clear() 
        {
            txtUserName.Clear();
            txtFullname.Clear();
            txtPassword.Clear();
            txtConfirmPswrd.Clear();
            txtPhoneNo.Clear();
            txtConfirmPswrd.Clear();
           
           
        
        }


      
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                { 
                    if (txtPassword.Text != txtConfirmPswrd.Text)
                    {
                        MessageBox.Show("Password did not match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (MessageBox.Show("Are you sure you want to update this user?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE  tblUser SET Username=@Username, Fullname=@Fullname, Password=@Password,ConfirmPassword=@ConfirmPassword, Phone=@Phone WHERE Username LIKE'" + txtUserName.Text + "' ", con);
                        cm.Parameters.AddWithValue("@Username", txtUserName.Text);
                        cm.Parameters.AddWithValue("@Fullname", txtFullname.Text);
                        cm.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cm.Parameters.AddWithValue("@ConfirmPassword", txtConfirmPswrd.Text);
                        cm.Parameters.AddWithValue("@Phone", txtPhoneNo.Text);
                        con.Open();
                        cm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("User has been successfully updated");
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
