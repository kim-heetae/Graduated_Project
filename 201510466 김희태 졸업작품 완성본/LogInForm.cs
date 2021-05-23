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

namespace 졸업작품
{
    public partial class LogInForm : Form
    {
        SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-FDSU6JG;User ID=201510466;Password=rlagmlxo");
        public LogInForm()
        {
            InitializeComponent();
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            string login = "select * from managerTbl where 아이디 = '" + id_txt.Text
            + "' and 비밀번호 = '" + pw_txt.Text + "'";
            SqlCommand command = new SqlCommand();
            command.CommandText = login;
            command.Connection = sqlcon;
            SqlDataReader reader;
            sqlcon.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("환영합니다. 로그인 성공");
                ManageForm mngfrm = new ManageForm();
                this.Hide();
                mngfrm.ShowDialog();
                sqlcon.Close();
            }
            else
            {
                MessageBox.Show("아이디와 비밀번호를 확인해주세요.");
                pw_txt.Clear();
                id_txt.Clear();
                id_txt.Focus();
                sqlcon.Close();
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void pw_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Login_btn_Click(sender, e);
            }
        }
    }
}
