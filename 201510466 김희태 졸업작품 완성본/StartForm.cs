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
    public partial class StartForm : Form
    {
        public delegate void FormSendDataHandler(string sendstring); //매장, 포장 텍스트 옮기는 이벤트 생성
        public StartForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm frmmain = new MainForm(); // mainForm형 frmmain 인스턴스화(객체 생성)
            frmmain.Passvalue = button1.Text;  // 전달자(Passvalue)를 통해서 mainForm 로 전달
            this.Hide();
            frmmain.ShowDialog();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm frmmain = new MainForm(); // mainForm형 frmmain 인스턴스화(객체 생성)
            frmmain.Passvalue = button2.Text;  // 전달자(Passvalue)를 통해서 mainForm 로 전달
            this.Hide();
            frmmain.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LogInForm lginfrm = new LogInForm();
            this.Hide();
            lginfrm.ShowDialog();
        }
    }
}
