using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 졸업작품
{
    public partial class MainForm : Form
    {
        List<toppingclass> order = new List<toppingclass>();
        List<menuclass> menuclasses = new List<menuclass>();
        public delegate void FormSendDataHandler(string sendstring);
        int 메뉴가격;
        string 메뉴명;
        string[] 토핑 = new string[10] { "", "", "", "", "", "", "", "", "", "" };
        int[] 토핑가격 = new int[10];
        int sum = 0;
        string 주문메뉴;
        string[] a = new string[28];
        int[] b = new int[28];
        int 주문금액;
        public string Passvalue //매장,포장 선택텍스트 가져오기
        {
            get; 
            set;
        }
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label31.Text = Passvalue;
            dataGridView2.DataSource = order.ToList();
        }
        private void refreshDGV()
        {
            dataGridView2.DataSource = order.ToList();
        }
        private void setDGV(int num)
        {
            order.Add(new toppingclass(토핑[num], 토핑가격[num]));
        }
        private void rmvDGV(int num)
        {
            토핑[num] = "";
            토핑가격[num] = 0;
            order.Clear();
            for (int i = 0; i < 10; i++)
            {
                if (토핑[i] != "")
                {
                    setDGV(i);
                }
                else
                {
                    continue;
                }
            }
            refreshDGV();
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = order;
            dataGridView2.Refresh();

        }
        public void isChecked(bool Checked, string name, int price, int num)
        {
            string tpp2 = "";
            string tpp = "";
            if (Checked)
            {
                토핑[num] = name + "\r\t";
                토핑가격[num] = price;
                sum += price;
                setDGV(num);
                refreshDGV();
                for (int i = 0; i < 10; i++)
                {
                    if (토핑[i] != "")
                    {
                        tpp = (tpp + 토핑[i] + 토핑가격[i] + "\r\n");
                        tpp2 += 토핑[i] + "  ";
                    }
                    else
                    {
                        continue;
                    }
                }
                slctprice_txt.Text = tpp;
                slct_txt.Text = tpp2;
            }
            else
            {
                토핑[num] = "";
                토핑가격[num] = 0;
                sum -= price;
                rmvDGV(num);
                for (int i = 0; i < 10; i++)
                {
                    if (토핑[i] != "")
                    {
                        tpp = (tpp + 토핑[i] + 토핑가격[i] + "\r\n");
                        tpp2 += 토핑[i] + "  ";
                    }
                    else
                    {
                        continue;
                    }
                }
                slctprice_txt.Text = tpp;
                slct_txt.Text = tpp2;
            }
            price_lbl.Text = (메뉴가격 + sum).ToString();
        }
        private void calcOrder()
        {
            int 금액합계s = menuclasses
                .GroupBy(o => o.메인메뉴)
                .Select(g => g.Sum(o => o.가격))
                .Sum();
            menuclasses.Add(new menuclass("합계", "", 금액합계s ));
            dataGridView1.DataSource = menuclasses.ToList();
            주문금액 = 금액합계s;
        }
        private void currybtn_Click(object sender, EventArgs e)
        {
            menutab.SelectedTab = menutab.TabPages[0];
        }

        private void udonbtn_Click(object sender, EventArgs e)
        {
            menutab.SelectedTab = menutab.TabPages[1];
        }

        private void ricebtn_Click(object sender, EventArgs e)
        {
            menutab.SelectedTab = menutab.TabPages[2];
        }

        private void setbtn_Click(object sender, EventArgs e)
        {
            menutab.SelectedTab = menutab.TabPages[3];
        }

        private void sidebtn_Click(object sender, EventArgs e)
        {
            menutab.SelectedTab = menutab.TabPages[4];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = mncrry_lbl.Text;
            메뉴가격 = Convert.ToInt32(mncrryprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = frkcrry_lbl.Text;
            메뉴가격 = Convert.ToInt32(fkcrryprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = bfcrry_lbl.Text;
            메뉴가격 = Convert.ToInt32(bfcrryprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = shrcrry_lbl.Text;
            메뉴가격 = Convert.ToInt32(shrcrryprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = hbckcrry_lbl.Text;
            메뉴가격 = Convert.ToInt32(shrcrryprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = sfcrry_lbl.Text;
            메뉴가격 = Convert.ToInt32(shrcrryprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(price_lbl.Text);
            if (radioButton1.Checked == false && radioButton2.Checked == false &&
                radioButton3.Checked == false && radioButton4.Checked == false)
            {
                MessageBox.Show("맵기는 필수로 선택하셔야 합니다.");
            }
            else
            {
                int maxindex = menuclasses.Count;
                if (maxindex > 0)
                {
                    maxindex -= 1;
                    menuclasses.RemoveAt(maxindex);
                }
                menuclasses.Add(new menuclass(메뉴명, slct_txt.Text, price));
                dataGridView1.DataSource = menuclasses.ToList();
                tabControl1.SelectedTab = tabControl1.TabPages[0];
                dataGridView1.DataSource = menuclasses.ToList();
                grtpp_ckbox.Checked = wlshtpp_ckbox.Checked = chstpp_ckbox.Checked =
                    eggtpp_ckbox.Checked = croqtpp_ckbox.Checked = chcroqtpp_ckbox.Checked = false;
                radioButton1.Checked = radioButton2.Checked =
                    radioButton3.Checked = radioButton4.Checked = false;
                a[maxindex] = 메뉴명;
                b[maxindex] = price;
                calcOrder();
                주문메뉴 = 주문메뉴 + "\r\t" + 메뉴명;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            int price = 0;
            int checknum = 0;
            isChecked(radioButton1.Checked, radioButton1.Text, price, checknum);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            int price = 0;
            int checknum = 1;
            isChecked(radioButton2.Checked, radioButton2.Text, price, checknum);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            int price = 0;
            int checknum = 2;
            isChecked(radioButton3.Checked, radioButton3.Text, price, checknum);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            int price = 0;
            int checknum = 3;
            isChecked(radioButton4.Checked, radioButton4.Text, price, checknum);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            int price = 1000;
            int checknum = 4;
            isChecked(grtpp_ckbox.Checked, grtpp_ckbox.Text, price, checknum);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int price = 500;
            int checknum = 5;
            isChecked(wlshtpp_ckbox.Checked, wlshtpp_ckbox.Text, price, checknum);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            int price = 1500;
            int checknum = 6;
            isChecked(chstpp_ckbox.Checked, chstpp_ckbox.Text, price, checknum);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            int price = 500;
            int checknum = 7;
            isChecked(eggtpp_ckbox.Checked, eggtpp_ckbox.Text, price, checknum);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            int price = 2000;
            int checknum = 8;
            isChecked(croqtpp_ckbox.Checked, croqtpp_ckbox.Text, price, checknum);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            int price = 3000;
            int checknum = 9;
            isChecked(chcroqtpp_ckbox.Checked, chcroqtpp_ckbox.Text, price, checknum);
        }

        private void count_btn_Click(object sender, EventArgs e)
        {
            PayForm payfrm = new PayForm();
            DialogResult result = MessageBox.Show("포인트를 사용하시겠습니까?.",
               "확인완료", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                payfrm.주문메뉴 = 주문메뉴;
                payfrm.주문금액 = 주문금액;
                payfrm.포장여부 = label31.Text;
                payfrm.a = a;
                payfrm.b = b;
                payfrm.Show();
                payfrm.pointsave();
                this.Close();
            }
            else
            {
                payfrm.주문메뉴 = 주문메뉴;
                payfrm.주문금액 = 주문금액;
                payfrm.포장여부 = label31.Text;
                payfrm.a = a;
                payfrm.b = b;
                payfrm.Show();
                this.Close();
            }
        }
        private void mnudon_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = mnudon_lbl.Text;
            메뉴가격 = Convert.ToInt32(mnudonprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void mshudon_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = mshudon_lbl.Text;
            메뉴가격 = Convert.ToInt32(mshudonprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void bfudon_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = bfudon_lbl.Text;
            메뉴가격 = Convert.ToInt32(bfudonprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void shrudon_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = shrudon_lbl.Text;
            메뉴가격 = Convert.ToInt32(shrudonprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void sfudon_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = sfudon_lbl.Text;
            메뉴가격 = Convert.ToInt32(sfudonprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void hbckudon_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = hbckudon_lbl.Text;
            메뉴가격 = Convert.ToInt32(hbckudonprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void mnpst_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = mnpst_lbl.Text;
            메뉴가격 = Convert.ToInt32(mnpstprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void mshpst_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = mshpst_lbl.Text;
            메뉴가격 = Convert.ToInt32(mshpstprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void hbpst_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = hbpst_lbl.Text;
            메뉴가격 = Convert.ToInt32(hbpstprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void hbckpst_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = hbckpst_lbl.Text;
            메뉴가격 = Convert.ToInt32(hbckpstprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void bfset_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = bfset_lbl.Text;
            메뉴가격 = Convert.ToInt32(bfsetprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void ckset_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = ckset_lbl.Text;
            메뉴가격 = Convert.ToInt32(cksetprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void fkset_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = fkset_lbl.Text;
            메뉴가격 = Convert.ToInt32(fksetprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void sfset_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = sfset_lbl.Text;
            메뉴가격 = Convert.ToInt32(sfsetprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void twoseta_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = twoseta_lbl.Text;
            메뉴가격 = Convert.ToInt32(twosetaprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void twosetb_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = twosetb_lbl.Text;
            메뉴가격 = Convert.ToInt32(twosetbprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void crbside_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = crbside_lbl.Text;
            메뉴가격 = Convert.ToInt32(crbsideprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void ckside_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = ckside_lbl.Text;
            메뉴가격 = Convert.ToInt32(cksideprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void ssgside_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = ssgside_lbl.Text;
            메뉴가격 = Convert.ToInt32(ssgsideprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void shrside_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = shrside_lbl.Text;
            메뉴가격 = Convert.ToInt32(shrsideprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void chdonside_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = chdonside_lbl.Text;
            메뉴가격 = Convert.ToInt32(chdonsideprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void ckgasside_btn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            메뉴명 = ckgasside_lbl.Text;
            메뉴가격 = Convert.ToInt32(ckgassideprc_lbl.Text);
            tppslct_lbl.Text = 메뉴명 + "의 토핑을 추가해주세요.";
            price_lbl.Text = 메뉴가격.ToString();
            radioButton1.Checked = true;
        }

        private void return_btn_Click(object sender, EventArgs e)
        {
            StartForm strtfrm = new StartForm();
            strtfrm.Show();
            this.Close();
        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("삭제하실 메뉴를 더블클릭 해주세요.");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string item = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show(item + " 선택을 삭제하겠습니까?", "선택삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                menuclasses.RemoveAt(e.RowIndex);
                menuclasses.RemoveAt(menuclasses.Count - 1);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = menuclasses;
                calcOrder();
                dataGridView1.Refresh();
                a[e.RowIndex] = null;
                b[e.RowIndex] = 0;
            }
        }
    }
}
