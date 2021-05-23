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
    public partial class PayForm : Form
    {
        SqlConnection sqlcon 
            = new SqlConnection("Data Source=DESKTOP-FDSU6JG;User ID=201510466;Password=rlagmlxo");
        MainForm mnfrm = new MainForm();
        StartForm strtfrm = new StartForm();
        public void pointsave()
        {
            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }
        public PayForm()
        {
            InitializeComponent();
        }
        public int 주문금액
        {
            get;
            set;
        }
        public string 주문메뉴
        {
            get;
            set;
        }
        public string 포장여부
        {
            get;
            set;
        }
        public string[] a
        {
            get;
            set;
        }
        public int[] b
        {
            get;
            set;
        }
        string 결제수단;
        string 회원번호;
        double per;
        public void 적립()
        {

        }
        private void card_btn_Click(object sender, EventArgs e)
        {
            회원번호 = "";
            DialogResult result = MessageBox.Show("포인트를 적립하시겠습니까?.",
                "확인완료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[1];
                결제수단 = card_btn.Text;
            }
            else
            {
                결제수단 = card_btn.Text;
                int p = 0;
                string timer = timer_lbl.Text + "/";
                string timer2 = DateTime.Now.ToString();
                DateTime dt = Convert.ToDateTime(timer2);
                string q = "yyyyMMdd";
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == null)
                    {
                        continue;
                    }
                    else
                    {
                        p++;
                        string 판매 = "INSERT INTO saleTbl VALUES('"
                    + timer + p.ToString() + "', '"
                    + a[i] + "', '"
                    + b[i] + "', '"
                    + 결제수단 + "', '"
                    + 회원번호 + "', '"
                    + 포장여부 + "', '"
                    + Convert.ToInt32(dt.ToString(q)) + "')";
                        string 재고관리 = "UPDATE menuTbl SET "
                            + "재고 = 재고 -'" + 1 + "'"
                            + "WHERE 메뉴명 = '" + a[i] + "'";
                        string 판매량관리 = "UPDATE menuTbl SET "
                            + "판매량 = 판매량 +'" + 1 + "'"
                            + "WHERE 메뉴명 = '" + a[i] + "'";
                        SqlCommand command = new SqlCommand();
                        command.CommandText = 판매;
                        command.Connection = sqlcon;
                        SqlCommand 재고comm = new SqlCommand();
                        재고comm.CommandText = 재고관리;
                        재고comm.Connection = sqlcon;
                        SqlCommand 판매량comm = new SqlCommand();
                        판매량comm.CommandText = 판매량관리;
                        판매량comm.Connection = sqlcon;
                        sqlcon.Open();
                        command.ExecuteNonQuery();
                        재고comm.ExecuteNonQuery();
                        판매량comm.ExecuteNonQuery();
                        sqlcon.Close();
                    }
                }
                MessageBox.Show("결제가 완료되었습니다.");
                this.Close();
                strtfrm.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             timer_lbl.Text = DateTime.Now.ToString("F");
        }

        private void PayForm_Load(object sender, EventArgs e)
        {
            label10.Text = 주문금액.ToString() + "원";
            label14.Text = 주문금액.ToString() + "원";
        }

        private void cash_btn_Click(object sender, EventArgs e)
        {
            회원번호 = "";
            DialogResult result = MessageBox.Show("포인트를 적립하시겠습니까?.",
                "확인완료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[1];
                결제수단 = cash_btn.Text;
            }
            else
            {
                결제수단 = cash_btn.Text;
                int p = 0;
                string timer = timer_lbl.Text + "/";
                string timer2 = DateTime.Now.ToString();
                DateTime dt = Convert.ToDateTime(timer2);
                string q = "yyyyMMdd";
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == null)
                    {
                        continue;
                    }
                    else
                    {
                        string 판매 = "INSERT INTO saleTbl VALUES('"
                            + timer + p.ToString() + "', '"
                            + a[i] + "', '"
                            + b[i] + "', '"
                            + 결제수단 + "', '"
                            + 회원번호 + "', '"
                            + 포장여부 + "', '"
                            + Convert.ToInt32(dt.ToString(q)) + "')";
                        string 재고관리 = "UPDATE menuTbl SET "
                            + "재고 = 재고 -'" + 1 + "'"
                            + "WHERE 메뉴명 = '" + a[i] + "'";
                        string 판매량관리 = "UPDATE menuTbl SET "
                            + "판매량 = 판매량 +'" + 1 + "'"
                            + "WHERE 메뉴명 = '" + a[i] + "'";
                        SqlCommand command = new SqlCommand();
                        command.CommandText = 판매;
                        command.Connection = sqlcon;
                        SqlCommand 재고comm = new SqlCommand();
                        재고comm.CommandText = 재고관리;
                        재고comm.Connection = sqlcon;
                        SqlCommand 판매량comm = new SqlCommand();
                        판매량comm.CommandText = 판매량관리;
                        판매량comm.Connection = sqlcon;
                        sqlcon.Open();
                        command.ExecuteNonQuery();
                        재고comm.ExecuteNonQuery();
                        판매량comm.ExecuteNonQuery();
                        sqlcon.Close();
                    }
                }
                MessageBox.Show("결제가 완료되었습니다.");
                this.Close();
                strtfrm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlcon.Close();
            회원번호 = textBox1.Text + textBox4.Text;
            string 회원판매 = "select 회원이름 from customTbl where 전화번호 = '" + 회원번호 + "'";
            SqlCommand 회원판매command = new SqlCommand();
            회원판매command.CommandText = 회원판매;
            회원판매command.Connection = sqlcon; 
            SqlDataReader reader;
            sqlcon.Open();
            reader = 회원판매command.ExecuteReader();
            if (reader.HasRows)
            {
                sqlcon.Close();
                DialogResult result = MessageBox.Show("010" + 회원번호 + "님 적립되었습니다.",
                        "확인완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if(결제수단 == "카드 결제")
                    {
                        per = 0.05;
                    }
                    else
                    {
                        per = 0.1;
                    }
                    string 적립 = "UPDATE customTbl SET "  
                        +"포인트 = 포인트+'" + 주문금액*per + "'" 
                        +"WHERE 전화번호 = '" + 회원번호 + "'";
                    int p = 0;
                    string timer = timer_lbl.Text + "/";
                    string timer2 = DateTime.Now.ToString();
                    DateTime dt = Convert.ToDateTime(timer2);
                    string q = "yyyyMMdd";
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (a[i] == null)
                        {
                            continue;
                        }
                        else
                        {
                            string 판매 = "INSERT INTO saleTbl VALUES('"
                                + timer + p.ToString() + "', '"
                                + a[i] + "', '"
                                + b[i] + "', '"
                                + 결제수단 + "', '"
                                + 회원번호 + "', '"
                                + 포장여부 + "', '"
                                + Convert.ToInt32(dt.ToString(q)) + "')";
                            string 재고관리 = "UPDATE menuTbl SET "
                                + "재고 = 재고 -'" + 1 + "'"
                                + "WHERE 메뉴명 = '" + a[i] + "'";
                            string 판매량관리 = "UPDATE menuTbl SET "
                                + "판매량 = 판매량 +'" + 1 + "'"
                                + "WHERE 메뉴명 = '" + a[i] + "'";
                            SqlCommand 판매command = new SqlCommand();
                            판매command.CommandText = 판매;
                            판매command.Connection = sqlcon;
                            SqlCommand 재고comm = new SqlCommand();
                            재고comm.CommandText = 재고관리;
                            재고comm.Connection = sqlcon;
                            SqlCommand 판매량comm = new SqlCommand();
                            판매량comm.CommandText = 판매량관리;
                            판매량comm.Connection = sqlcon;
                            sqlcon.Open();
                            판매command.ExecuteNonQuery();
                            재고comm.ExecuteNonQuery();
                            판매량comm.ExecuteNonQuery();
                            sqlcon.Close();
                            p++;
                        }
                    }
                    SqlCommand 적립command = new SqlCommand();
                    적립command.CommandText = 적립;
                    적립command.Connection = sqlcon;
                    sqlcon.Open();
                    적립command.ExecuteNonQuery();
                    sqlcon.Close();
                    this.Close();
                    strtfrm.ShowDialog();
                }
            }
            else
            {
                sqlcon.Close();
                MessageBox.Show("전화번호를 확인해주세요.");
                textBox1.Clear();
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }


        private void canclepoint_btn_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void usepoint_btn_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox3.Text) > Convert.ToInt32(label7.Text))
            {
                MessageBox.Show("잔여포인트를 확인해주세요");
            }
            else
            {
                sqlcon.Close();
                string usepoint = "UPDATE customTbl SET "
                            + "포인트 = 포인트-'" + Convert.ToInt32(textBox3.Text) + "'"
                            + "WHERE 전화번호 = '" + (phonenum1_txt.Text + phonenum2_txt.Text) + "'";
                SqlCommand usepointcomm = new SqlCommand();
                usepointcomm.CommandText = usepoint;
                usepointcomm.Connection = sqlcon;
                sqlcon.Open();
                usepointcomm.ExecuteNonQuery();
                sqlcon.Close();
                string sltpoint = "select 전화번호, 포인트 from customTbl " +
                    "where 전화번호 = '" + (phonenum1_txt.Text + phonenum2_txt.Text) + "'";
                SqlCommand sltpointcomm = new SqlCommand();
                sltpointcomm.CommandText = sltpoint;
                sltpointcomm.Connection = sqlcon;
                sqlcon.Open();
                SqlDataReader reader = sltpointcomm.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["전화번호"].ToString() == (phonenum1_txt.Text + phonenum2_txt.Text))
                    {
                        int a = Convert.ToInt32(textBox3.Text);
                        MessageBox.Show("남은 포인트는 " + reader["포인트"].ToString() + "포인트 입니다.");
                        label7.Text = reader["포인트"].ToString() + "원";
                        label12.Text = textBox3.Text + "원";
                        label14.Text = (주문금액 - a).ToString() + "원";
                        tabControl1.SelectedTab = tabControl1.TabPages[0];
                        reader.Close();
                        sqlcon.Close();
                        return;
                    }
                }
                reader.Close();
                sqlcon.Close();
            }
        }

        private void sltpoint_btn_Click(object sender, EventArgs e)
        {
            string sltpoint = "select 전화번호, 포인트 from customTbl " +
                "where 전화번호 = '" + (phonenum1_txt.Text + phonenum2_txt.Text) + "'";
            SqlCommand sltpointcomm = new SqlCommand();
            sltpointcomm.CommandText = sltpoint;
            sltpointcomm.Connection = sqlcon;
            sqlcon.Open();
            SqlDataReader reader = sltpointcomm.ExecuteReader();
            while (reader.Read())
            {
                if (reader["전화번호"].ToString() == (phonenum1_txt.Text+phonenum2_txt.Text))
                {
                    label7.Text = reader["포인트"].ToString();
                    return;
                }
            }
            reader.Close();
            sqlcon.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
