using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace 智慧校园体育云平台
{
    public partial class Main : Skin_Mac
    {
        //设公共字符串变量name(便于传参)，用于储存按钮上的text，以便"信息"窗口使用
         public String name = string.Empty;
        public Main()
        {
            InitializeComponent();
        }

        //当Student按钮被点击
        private void button1_Click(object sender, EventArgs e)
        {
            Operation t = new Operation(this);
            name = button1.Text;//讲按钮上的text赋给字符串name
            t.Show();
        }

        //当Running按钮被点击
        private void button2_Click(object sender, EventArgs e)
        {
            Operation t = new Operation(this);
            name = button2.Text;
            t.Show();
        }


        //当Test按钮被点击
        private void button3_Click(object sender, EventArgs e)
        {
            Operation t = new Operation(this);
            name = button3.Text;
            t.Show();
        }

        //当Match_按钮被点击
        private void button4_Click(object sender, EventArgs e)
        {
            Operation t = new Operation(this);
            name = button4.Text;
            t.Show();
        }
    }
}
