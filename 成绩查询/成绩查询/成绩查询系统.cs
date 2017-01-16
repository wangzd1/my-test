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
namespace 成绩查询
{
    public partial class 成绩查询系统 : Form
    {
        public 成绩查询系统()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("请输入用户名和密码");
                    textBox1.Focus();
                }
                else
                {
                    if (textBox1.Text == "" && textBox2.Text != "")
                    {
                        MessageBox.Show("请输入用户名");
                        textBox1.Focus();
                    }
                    else
                    {
                        if (textBox1.Text != "" && textBox2.Text == "")
                        {
                            MessageBox.Show("请输入密码");
                            textBox2.Focus();
                        }
                        else
                        {
                            SqlConnection thisConn = new SqlConnection("Integrated Security=SSPI;Database=成绩查询系统;Server=localhost;");
                            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM 用户 WHERE 用户名='" + textBox1.Text + "'and 密码='" + textBox2.Text + "'", thisConn);
                            DataSet thisDataSet = new DataSet();
                            thisAdapter.Fill(thisDataSet);
                            if (thisDataSet.Tables[0].Rows.Count > 0)
                            {
                                用户界面 yh = new 用户界面();
                                yh.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("用户名或密码错误");
                            }


                        }
                    }
                }
            }
            if (radioButton2.Checked)
            {
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("请输入用户名和密码");
                    textBox1.Focus();
                }
                else
                {
                    if (textBox1.Text == "" && textBox2.Text != "")
                    {
                        MessageBox.Show("请输入用户名");
                        textBox1.Focus();
                    }
                    else
                    {
                        if (textBox1.Text != "" && textBox2.Text == "")
                        {
                            MessageBox.Show("请输入密码");
                            textBox2.Focus();
                        }
                        else
                        {
                            SqlConnection thisConn = new SqlConnection("Integrated Security=SSPI;Database=成绩查询系统;Server=localhost;");
                            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM 管理员 WHERE 管理员名='" + textBox1.Text + "'and 密码='" + textBox2.Text + "'", thisConn);
                            DataSet thisDataSet = new DataSet();
                            thisAdapter.Fill(thisDataSet);
                            if (thisDataSet.Tables[0].Rows.Count > 0)
                            {
                                管理员界面 gly = new 管理员界面();
                                gly.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("管理员名或密码错误");
                            }


                        }
                    }
                }
            }
        }

        private void 成绩查询系统_Load(object sender, EventArgs e)
        {

        }
    }
}
