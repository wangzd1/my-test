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
    public partial class 学生信息管理 : Form
    {
        public 学生信息管理()
        {
            InitializeComponent();
        }

        private void 学生信息管理_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from xsxx");
        }
        private void GetData(string selectCommand)
        {
            try
            {
                String connectionString = "Integrated Security=SSPI;Database=成绩查询系统;Server=localhost;";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("出错");
            }
        }
        public bool IsNumberic(string oText)
        {
            try
            {
                int var1 = Convert.ToInt32(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)//添加
        {
            if (textBox1.Text != String.Empty)
            {
                if (IsNumberic(textBox1.Text))
                {
                    int i = Convert.ToInt32(textBox1.Text);
                    if (i > 0)
                    {
                        SqlConnection thisConn = new SqlConnection("Integrated Security=SSPI;Database=成绩查询系统;Server=localhost;");
                        SqlDataAdapter thisAdapter = new SqlDataAdapter("select * from xsxx where 学号='" + textBox1.Text + "'", thisConn);
                        DataSet thisDataSet = new DataSet();
                        thisAdapter.Fill(thisDataSet);
                        if (thisDataSet.Tables[0].Rows.Count == 0)
                        {
                            if (textBox2.Text != String.Empty)
                            {
                                if (textBox3.Text != String.Empty)
                                {
                                    if (textBox4.Text != String.Empty)
                                    {
                                        if (IsNumberic(textBox4.Text))
                                        {
                                            int j = Convert.ToInt32(textBox4.Text);
                                            if (j > 0)
                                            {
                                                if (textBox5.Text != String.Empty)
                                                {
                                                    if (IsNumberic(textBox5.Text))
                                                    {
                                                        int k = Convert.ToInt32(textBox5.Text);
                                                        if (k > 0)
                                                        {
                                                            GetData("insert into xsxx values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')");
                                                            GetData("select * from xsxx");
                                                            MessageBox.Show("学生信息添加成功！");
                                                        }
                                                        else
                                                            MessageBox.Show("年龄必须为正整数！");
                                                    }
                                                    else
                                                        MessageBox.Show("请输入数字！");
                                                }
                                                else
                                                    MessageBox.Show("年龄不能为空！");
                                            }
                                            else
                                                MessageBox.Show("班级不存在，请重新输入！");
                                        }
                                        else
                                            MessageBox.Show("请输入数字！");
                                    }
                                    else
                                        MessageBox.Show("班级不能为空！");
                                }
                                else
                                    MessageBox.Show("性别不能为空！");
                            }
                            else
                                MessageBox.Show("姓名不能为空！");
                        }
                        else
                        {
                            MessageBox.Show("学号已存在，请重新输入！");
                        }

                    }
                    else
                        MessageBox.Show("学号不存在，请重新输入！");

                }
                else
                    MessageBox.Show("请输入数字！");

            }
            else
                MessageBox.Show("学号不能为空！");
           
            
        }

        private void button3_Click(object sender, EventArgs e)//删除
        {
            GetData("delete xsxx where 学号='"+textBox1.Text+"'");
            GetData("delete cjpm where 学号='" + textBox1.Text + "'");
            GetData("delete xxxx where 学号='" + textBox1.Text + "'");
            GetData("select * from xsxx");
            MessageBox.Show("学生信息删除成功！");
        }

        private void button2_Click(object sender, EventArgs e)//选择修改项
        {
            int a = dataGridView1.CurrentRow.Index;
            textBox1.Text = (string)dataGridView1.Rows[a].Cells[0].Value;
            textBox2.Text = (string)dataGridView1.Rows[a].Cells[1].Value;
            textBox3.Text = (string)dataGridView1.Rows[a].Cells[2].Value;
            textBox4.Text = (string)dataGridView1.Rows[a].Cells[3].Value;
            textBox5.Text = dataGridView1.Rows[a].Cells[4].Value.ToString();
            GetData("delete xsxx where 学号='" + textBox1.Text + "'");
            
            GetData("select * from xsxx");
        }

        private void button4_Click(object sender, EventArgs e)//确认修改
        {
            if (textBox1.Text != String.Empty)
            {
                if (IsNumberic(textBox1.Text))
                {
                    int i = Convert.ToInt32(textBox1.Text);
                    if (i > 0)
                    {
                        SqlConnection thisConn = new SqlConnection("Integrated Security=SSPI;Database=成绩查询系统;Server=localhost;");
                        SqlDataAdapter thisAdapter = new SqlDataAdapter("select * from xsxx where 学号='" + textBox1.Text + "'", thisConn);
                        DataSet thisDataSet = new DataSet();
                        thisAdapter.Fill(thisDataSet);
                        if (thisDataSet.Tables[0].Rows.Count == 0)
                        {
                            if (textBox2.Text != String.Empty)
                            {
                                if (textBox3.Text != String.Empty)
                                {
                                    if (textBox4.Text != String.Empty)
                                    {
                                        if (IsNumberic(textBox4.Text))
                                        {
                                            int j = Convert.ToInt32(textBox4.Text);
                                            if (j > 0)
                                            {
                                                if (textBox5.Text != String.Empty)
                                                {
                                                    if (IsNumberic(textBox5.Text))
                                                    {
                                                        int k = Convert.ToInt32(textBox5.Text);
                                                        if (k > 0)
                                                        {
                                                            GetData("insert into xsxx values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')");
                                                            GetData("select * from xsxx");
                                                            MessageBox.Show("学生信息修改成功！");
                                                        }
                                                        else
                                                            MessageBox.Show("年龄必须为正整数！");
                                                    }
                                                    else
                                                        MessageBox.Show("请输入数字！");
                                                }
                                                else
                                                    MessageBox.Show("年龄不能为空！");
                                            }
                                            else
                                                MessageBox.Show("班级不存在，请重新输入！");
                                        }
                                        else
                                            MessageBox.Show("请输入数字！");
                                    }
                                    else
                                        MessageBox.Show("班级不能为空！");
                                }
                                else
                                    MessageBox.Show("性别不能为空！");
                            }
                            else
                                MessageBox.Show("姓名不能为空！");
                        }
                        else
                        {
                            MessageBox.Show("学号已存在，请重新输入！");
                        }

                    }
                    else
                        MessageBox.Show("学号不存在，请重新输入！");

                }
                else
                    MessageBox.Show("请输入数字！");

            }
            else
                MessageBox.Show("学号不能为空！");
        }
    }
}
