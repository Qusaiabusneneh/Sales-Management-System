using Busniess_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Management.App.Login
{
    public partial class FRM_Login: Form
    {
        public FRM_Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
         {
            clsUsers user = clsUsers.Find(txtUsername.Text.Trim(),(txtPassword.Text.Trim()));
            if (user != null)
            {
                if(chkRemeber.Checked)
                {
                    //store username and password
                    clsGlobal.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    //store empty username and password
                    clsGlobal.RememberUsernameAndPassword("", "");
                }
                clsGlobal.CurrentUser = user;
                FRM_Main main = new FRM_Main(this);
                main.lblUsername.Text = clsGlobal.CurrentUser.Username;
                main.lblPremission.Text = clsGlobal.CurrentUser.UserRoll;
                clsGlobal.CurrentUser.UserState = "True";
                clsGlobal.CurrentUser.Save();
                this.Hide();
                main.ShowDialog();
            }
            else
             {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FRM_Login_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";

            if (clsGlobal.GetSortedCredential(ref Username, ref Password))
            {
                txtPassword.Text = Password;
                txtUsername.Text = Username;
                chkRemeber.Checked = true;
            }
            else
                chkRemeber.Checked = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
