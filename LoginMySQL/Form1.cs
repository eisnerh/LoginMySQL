using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMySQL
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtuserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtuserName.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnEnter.PerformClick();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtuserName.Text)){
                MessageBox.Show("Please enter a valid user name!","Message",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtuserName.Focus();
                return;
            }

            try
            {
                dbtest_loginDataSetTableAdapters.usersTableAdapter user = new dbtest_loginDataSetTableAdapters.usersTableAdapter();
                dbtest_loginDataSet.usersDataTable dt = user.Login(txtuserName.Text, txtPassword.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("You have been succesfully logged in.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Your username or password is incorrect","Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
