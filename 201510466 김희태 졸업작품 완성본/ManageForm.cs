using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace 졸업작품
{
    public partial class ManageForm : Form
    {
        SqlConnection sqlcon
            = new SqlConnection("Data Source=DESKTOP-FDSU6JG;User ID=201510466;Password=rlagmlxo");
        DataGridView stock = new DataGridView();
        public ManageForm()
        {
            InitializeComponent();
        }
        string[] crry = { "기본 카레라이스", "포크 카레라이스", "비프 카레라이스",
            "알새우 카레라이스", "허브치킨 카레라이스", "해산물 카레라이스" };
        string[] udon = { "기본 카레우동", "버섯 카레우동", "비프 카레우동",
            "알새우 카레우동", "해산물 카레우동", "허브치킨 카레우동" };
        string[] pst = { "기본 크림카레파스타", "버섯 크림카레파스타",
         "함박 크림카레파스타", "허브치킨 크림카레파스타"};
        string[] set = { "비프 세트", "치킨 세트", "포크 세트",
         "해산물 세트", "2인 세트A", "2인 세트B"};
        string[] side = { "게살 튀김", "닭 가라아게", "프리미엄 소시지",
         "왕새우 튀김", "치즈 돈까스", "치킨까스"};
        string[] tpp = {"마늘 후레이크", "아삭아삭 대파", "멜탕치즈",
        "날계란","고로케","치즈 고로케"};
        string[,] lbitem = new string[6, 6];
        string dgvindex;
        string customdgvindex;
        string customdgvname;
        string sltindex;
        string g = "'";
        string sltindex2 = "";
        private void ManageForm_Load(object sender, EventArgs e)
        {

        }
        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mainindexnum = comboBox1.SelectedIndex;
            int indexnum = comboBox2.SelectedIndex;
            string menuname = comboBox2.SelectedItem.ToString();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int sel = comboBox1.SelectedIndex;
            switch (sel)
            {
                case 0:
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(crry);
                    break;
                case 1:
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(udon);
                    break;
                case 2:
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(pst);
                    break;
                case 3:
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(set);
                    break;
                case 4:
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(side);
                    break;
                case 5:
                    comboBox2.Items.Clear();
                    comboBox2.Items.AddRange(tpp);
                    break;
            }
        }


        private void stockplus_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int udtstock = Convert.ToInt32(udtstock_txt.Text);
                string sltmenu = dgvindex.ToString();
                string usepoint = "UPDATE menuTbl SET "
                                + "재고 = 재고 + '" + udtstock + "'"
                                + "WHERE 메뉴명 = '" + sltmenu + "'";
                SqlCommand stockpluscomm = new SqlCommand();
                stockpluscomm.CommandText = usepoint;
                stockpluscomm.Connection = sqlcon;
                sqlcon.Open();
                stockpluscomm.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("재고가 " + udtstock + "개 추가되었습니다");
                string sltstock = "SELECT * FROM menuTbl order by 메뉴명 asc";
                SqlCommand command = new SqlCommand();
                command.CommandText = sltstock;
                command.Connection = sqlcon;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch
            {
                MessageBox.Show("변경하실 수량을 적어주세요.");
            }
        }

        private void sltall_btn_Click(object sender, EventArgs e)
        {
            string sltstock = "SELECT * FROM saleTbl order by 판매번호 asc";
            SqlCommand command = new SqlCommand();
            command.CommandText = sltstock;
            command.Connection = sqlcon;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void sltstock_btn_Click(object sender, EventArgs e)
        {
            string sltstock = "SELECT * FROM menuTbl order by 메뉴명 asc";
            SqlCommand command = new SqlCommand();
            command.CommandText = sltstock;
            command.Connection = sqlcon;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void stockminus_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int udtstock = Convert.ToInt32(udtstock_txt.Text);
                string sltmenu = dgvindex.ToString();
                string usepoint = "UPDATE menuTbl SET "
                                + "재고 = 재고 - '" + udtstock + "'"
                                + "WHERE 메뉴명 = '" + sltmenu + "'";
                SqlCommand stockpluscomm = new SqlCommand();
                stockpluscomm.CommandText = usepoint;
                stockpluscomm.Connection = sqlcon;
                sqlcon.Open();
                stockpluscomm.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("재고가 " + udtstock + "개 감소되었습니다");
                string sltstock = "SELECT * FROM menuTbl order by 메뉴명 asc";
                SqlCommand command = new SqlCommand();
                command.CommandText = sltstock;
                command.Connection = sqlcon;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch
            {
                MessageBox.Show("변경하실 수량을 적어주세요.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvindex = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void sltdatemenu_btn_Click(object sender, EventArgs e)
        {
            string datetime1 = Regex.Replace(dateTimePicker1.Text, @"\D", "");
            string datetime2 = Regex.Replace(dateTimePicker2.Text, @"\D", "");
            if (comboBox2.Text == "")
            {
                MessageBox.Show("조회하실 메뉴를 선택해주세요.");
                comboBox1.Focus();
            }
            else
            {
                string sltstock = "SELECT * FROM saleTbl " +
                    "WHERE 판매날짜 >= '" + datetime1 + "' AND 판매날짜 <= '" + datetime2 + "' AND 메뉴 = '" + comboBox2.Text + "'";
                SqlCommand command = new SqlCommand();
                command.CommandText = sltstock;
                command.Connection = sqlcon;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void sltdate_btn_Click(object sender, EventArgs e)
        {
            string datetime1 = Regex.Replace(dateTimePicker1.Text, @"\D", "");
            string datetime2 = Regex.Replace(dateTimePicker2.Text, @"\D", "");
            string sltstock = "SELECT * FROM saleTbl " +
                "WHERE 판매날짜 >= '" + datetime1 + "' AND 판매날짜 <= '" + datetime2 + "'";
            SqlCommand command = new SqlCommand();
            command.CommandText = sltstock;
            command.Connection = sqlcon;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cusinsert_btn_Click(object sender, EventArgs e)
        {
            try
            {

                int nullpoint = 0;
                if (cusname_txt.Text == "")
                {
                    MessageBox.Show("고객성함을 확인해주세요.");
                }
                else
                {
                    if (cusphone_txt.Text == "")
                    {
                        MessageBox.Show("고객전화번호를 확인해주세요.");
                    }
                    else
                    {
                        if (cuspoint_txt.Text == "")
                        {
                            cuspoint_txt.Text = nullpoint.ToString();
                            string cusinsert = "INSERT INTO customTbl VALUES('"
                                + cusname_txt.Text + "', '"
                                + cusphone_txt.Text + "', '"
                                + Convert.ToInt32(cuspoint_txt.Text) + "')";
                            SqlCommand command = new SqlCommand();
                            command.CommandText = cusinsert;
                            command.Connection = sqlcon;
                            sqlcon.Open();
                            command.ExecuteNonQuery();
                            sqlcon.Close();
                        }
                        else
                        {
                            string cusinsert = "INSERT INTO customTbl VALUES('"
                                + cusname_txt.Text + "', '"
                                + cusphone_txt.Text + "', '"
                                + Convert.ToInt32(cuspoint_txt.Text) + "')";
                            SqlCommand command = new SqlCommand();
                            command.CommandText = cusinsert;
                            command.Connection = sqlcon;
                            sqlcon.Open();
                            command.ExecuteNonQuery();
                            sqlcon.Close();
                        }
                    }
                }
                cusselect_btn.PerformClick();
            }
            catch
            {
                MessageBox.Show("이미 등록된 고객입니다. 전화번호를 확인해주세요.");
            }
        }

        private void cusupdate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (cusname_txt.Text == "" || cusphone_txt.Text == "" || cuspoint_txt.Text == "")
                {
                    MessageBox.Show("수정하실 고객을 선택해주세요");
                }
                else
                {
                    string udtcustom = "UPDATE customTbl SET "
                                    + "회원이름 = '" + cusname_txt.Text + "',"
                                       + "전화번호 = '" + cusphone_txt.Text + "',"
                                       + "포인트 = '" + Convert.ToInt32(cuspoint_txt.Text) + "'"
                                    + "WHERE 회원이름 = '" + customdgvname+ "'";
                    SqlCommand stockpluscomm = new SqlCommand();
                    stockpluscomm.CommandText = udtcustom;
                    stockpluscomm.Connection = sqlcon;
                    sqlcon.Open();
                    stockpluscomm.ExecuteNonQuery();
                    sqlcon.Close();
                    MessageBox.Show(cusname_txt.Text + "님의 정보를 변경하였습니다..");
                    custom_dgv.Rows[0].Selected = true;
                }
                cusselect_btn.PerformClick();
                customdgvname = custom_dgv.Rows[0].Cells[0].Value.ToString();
            }
            catch
            {
                MessageBox.Show("정보를 변경할 고객을 선택해주세요.");
            }
        }

        private void cusdelete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string cusdelete = "DELETE FROM customTbl " +
                "WHERE 전화번호 = '" + Convert.ToInt32(customdgvindex) + "'";
                SqlCommand deletecomm = new SqlCommand();
                deletecomm.CommandText = cusdelete;
                deletecomm.Connection = sqlcon;
                string cusdelete2 = "UPDATE saleTbl SET "
                                       + "회원번호 = '" + sltindex2 + "'"
                                    + "WHERE 회원번호 = '" + cusphone_txt.Text + "'";
                SqlCommand deletecomm2 = new SqlCommand();
                deletecomm2.CommandText = cusdelete2;
                deletecomm2.Connection = sqlcon;
                sqlcon.Open();
                deletecomm.ExecuteNonQuery();
                deletecomm2.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("삭제하였습니다.");
                cusallselect_btn.PerformClick();
                custom_dgv.Rows[0].Selected = true;
                cusname_txt.Text = custom_dgv.Rows[0].Cells[0].Value.ToString();
                cusphone_txt.Text = custom_dgv.Rows[0].Cells[1].Value.ToString();
                cuspoint_txt.Text = custom_dgv.Rows[0].Cells[2].Value.ToString();
            }
            catch
            {
                MessageBox.Show("삭제하실 고객을 선택해주세요");
            }
        }

        private void cusallselect_btn_Click(object sender, EventArgs e)
        {
            string cusallselect = "SELECT * FROM customTbl order by 회원이름 asc";
            SqlCommand command = new SqlCommand();
            command.CommandText = cusallselect;
            command.Connection = sqlcon;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            custom_dgv.DataSource = table;
            if (custom_dgv.Rows[0].Cells[0].Value.ToString() == null || custom_dgv.Rows[0].Cells[1].Value.ToString() == null || custom_dgv.Rows[0].Cells[2].Value.ToString() == null)
            {
                cusname_txt.Text = "";
                cusphone_txt.Text = "";
                cuspoint_txt.Text = "";
            }
            else
            {
                cusname_txt.Text = custom_dgv.Rows[0].Cells[0].Value.ToString();
                cusphone_txt.Text = custom_dgv.Rows[0].Cells[1].Value.ToString();
                cuspoint_txt.Text = custom_dgv.Rows[0].Cells[2].Value.ToString();
            }
        }

        private void cusselect_btn_Click(object sender, EventArgs e)
        {
            if (cusname_txt.Text == "")
            {
                MessageBox.Show("검색하실 회원의 이름을 적어주세요.");
            }
            else
            {
                string sltcus = "SELECT * FROM customTbl " +
                "WHERE 회원이름 = '" + cusname_txt.Text + "'";
                SqlCommand cusinsertcomm = new SqlCommand();
                cusinsertcomm.CommandText = sltcus;
                cusinsertcomm.Connection = sqlcon;
                SqlDataAdapter adapter = new SqlDataAdapter(cusinsertcomm);
                DataTable table = new DataTable();
                adapter.Fill(table);
                custom_dgv.DataSource = table;
                cusname_txt.Text = custom_dgv.Rows[0].Cells[0].Value.ToString();
                cusphone_txt.Text = custom_dgv.Rows[0].Cells[1].Value.ToString();
                cuspoint_txt.Text = custom_dgv.Rows[0].Cells[2].Value.ToString();
            }
        }

        private void custom_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            customdgvindex = custom_dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            customdgvname = custom_dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            cusname_txt.Text = custom_dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            cusphone_txt.Text = custom_dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            cuspoint_txt.Text = custom_dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void gostart_btn_Click(object sender, EventArgs e)
        {
            StartForm strtfrm = new StartForm();
            this.Hide();
            strtfrm.ShowDialog();
        }

        private void gosale_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void gocustomer_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }

        private void gostart2_btn_Click(object sender, EventArgs e)
        {
            StartForm strtfrm = new StartForm();
            this.Hide();
            strtfrm.ShowDialog();
        }
    }
 }
