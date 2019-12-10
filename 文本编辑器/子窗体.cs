using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 作业5
{
    public partial class 子窗体 : Form
    {
        public 子窗体()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("版权所有-Ruvik!<(－︿－)>");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你想查找个啥子，不会！(＠￣ー￣＠)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("就不替换，气死你！(￣_,￣ )");
        }
    }
}
