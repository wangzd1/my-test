using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 成绩查询
{
    public partial class 管理员界面 : Form
    {
        public 管理员界面()
        {
            InitializeComponent();
        }

        private void 管理员界面_Load(object sender, EventArgs e)
        {

        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            帮助 help = new 帮助();
            help.ShowDialog();
        }

        private void 开课情况查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            开课查询 kkcx = new 开课查询();
            kkcx.ShowDialog();
        }

        private void 学生成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            成绩查询 cjcx = new 成绩查询();
            cjcx.ShowDialog();
        }

        private void 学生信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            学生信息管理 xsxxgl = new 学生信息管理();
            xsxxgl.ShowDialog();
        }

        private void 学生记录维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            学生成绩管理 xscjgl = new 学生成绩管理();
            xscjgl.ShowDialog();
        }
    }
}
