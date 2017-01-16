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
    public partial class 学生成绩管理 : Form
    {
        public 学生成绩管理()
        {
            InitializeComponent();
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
        private void 学生成绩管理_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetData("  select xxxx.学号,kc.课程号,xsxx.姓名,课程名,性别,成绩,年龄,学分,xsxx.班级 from kc,xxxx,xsxx where kc.课程号=xxxx.课程号 and xsxx.学号=xxxx.学号");
            
        }

        private void button1_Click(object sender, EventArgs e)//添加
        {
            if(textBox1.Text!=String.Empty)
            {
                if (IsNumberic(textBox1.Text))
                {
                    int i = Convert.ToInt32(textBox1.Text);
                    if (i > 0)
                    {
                        SqlConnection thisConn = new SqlConnection("Integrated Security=SSPI;Database=成绩查询系统;Server=localhost;");
                        SqlDataAdapter thisAdapter = new SqlDataAdapter("select * from xxxx where 学号='" + textBox1.Text + "'and 课程号='"+textBox2.Text+"'", thisConn);
                        DataSet thisDataSet = new DataSet();
                        thisAdapter.Fill(thisDataSet);
                        if (thisDataSet.Tables[0].Rows.Count == 0)
                        {
                            if(textBox2.Text!=String.Empty)
                            {
                                if (textBox3.Text != String.Empty)
                                {
                                    if (textBox4.Text != String.Empty)
                                    {
                                        String connectionString = "Integrated Security=SSPI;Database=成绩查询系统;Server=localhost;";
                                        SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from kc where 课程号='" + textBox2.Text + "'and 课程名='" + textBox4.Text + "'", connectionString);
                                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                                        DataTable table = new DataTable();
                                        dataAdapter.Fill(table);
                                        if (table.Rows.Count > 0)
                                        {
                                            if (textBox5.Text != String.Empty)
                                            {
                                                if (textBox6.Text != String.Empty)
                                                {
                                                    if (IsNumberic(textBox6.Text))
                                                    {
                                                        i = Convert.ToInt32(textBox6.Text);
                                                        if (i > 0)
                                                        {
                                                            if (textBox7.Text != String.Empty)
                                                            {
                                                                if (IsNumberic(textBox6.Text))
                                                                {
                                                                    i = Convert.ToInt32(textBox7.Text);
                                                                    if (i > 0)
                                                                    {
                                                                        if (textBox8.Text != String.Empty)
                                                                        {
                                                                            SqlDataAdapter dataAdapter2 = new SqlDataAdapter("select * from kc where 课程名='" + textBox4.Text + "'and 学分='" + textBox8.Text + "'", connectionString);
                                                                            SqlCommandBuilder commandBuilder2 = new SqlCommandBuilder(dataAdapter2);
                                                                            DataTable table2 = new DataTable();
                                                                            dataAdapter2.Fill(table2);
                                                                            if (table2.Rows.Count > 0)
                                                                            {
                                                                                if (textBox9.Text != String.Empty)
                                                                                {
                                                                                    if (IsNumberic(textBox9.Text))
                                                                                    {
                                                                                        i = Convert.ToInt32(textBox9.Text);
                                                                                        if (i > 0)
                                                                                        {
                                                                                            SqlDataAdapter dataAdapter3 = new SqlDataAdapter("select * from cjpm where 学号='" + textBox1.Text + "'", connectionString);
                                                                                            SqlCommandBuilder commandBuilder3 = new SqlCommandBuilder(dataAdapter3);
                                                                                            DataTable table3 = new DataTable();
                                                                                            dataAdapter3.Fill(table3);
                                                                                            if (table3.Rows.Count > 0)
                                                                                            {
                                                                                                GetData("insert into xxxx values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "')");
                                                                                                GetData("update cjpm set 总分=总分+'" + textBox6.Text + "'where 学号='" + textBox1.Text + "'");
                                                                                                GetData("update cjpm set 排名 = (select rank from(select 学号,ROW_NUMBER() over(order by 总分 desc) as rank from cjpm) as ranktable where 学号 = cjpm.学号)select * from cjpm");
                                                                                                GetData("  select xxxx.学号,kc.课程号,xsxx.姓名,课程名,性别,成绩,年龄,学分,xsxx.班级 from kc,xxxx,xsxx where kc.课程号=xxxx.课程号 and xsxx.学号=xxxx.学号");
                                                                                                MessageBox.Show("学生成绩添加成功1！");
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                GetData("insert into cjpm values ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox9.Text + "','" + textBox6.Text + "',1)");
                                                                                                GetData("insert into xxxx values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "')");
                                                                                                GetData("update cjpm set 总分='" + textBox6.Text + "'where 学号='" + textBox1.Text + "'");
                                                                                                GetData("update cjpm set 排名 = (select rank from(select 学号,ROW_NUMBER() over(order by 总分 desc) as rank from cjpm) as ranktable where 学号 = cjpm.学号)select * from cjpm");
                                                                                                GetData("  select xxxx.学号,kc.课程号,xsxx.姓名,课程名,性别,成绩,年龄,学分,xsxx.班级 from kc,xxxx,xsxx where kc.课程号=xxxx.课程号 and xsxx.学号=xxxx.学号");
                                                                                                MessageBox.Show("学生成绩添加成功！");
                                                                                            }
                                                                                            
                                                                                        }
                                                                                        else
                                                                                            MessageBox.Show("班级必须大于0！");
                                                                                    }
                                                                                    else
                                                                                        MessageBox.Show("班级必须为数字！");
 
                                                                                }
                                                                                else
                                                                                    MessageBox.Show("班级不能为空！");
 
                                                                            }
                                                                            else
                                                                                MessageBox.Show("学分和课程名不匹配！");
                                                                        }
                                                                        else
                                                                            MessageBox.Show("学分不能为空！");
 
                                                                    }
                                                                    else
                                                                        MessageBox.Show("年龄必须大于0！");
 
                                                                }
                                                                else
                                                                    MessageBox.Show("年龄必须为数字！");
                                                            }
                                                            else
                                                                MessageBox.Show("年龄不能为空！");
 
                                                        }
                                                        else
                                                            MessageBox.Show("成绩必须大于0！");
 
                                                    }
                                                    else
                                                        MessageBox.Show("成绩必须为数字！");
                                                }
                                                else
                                                    MessageBox.Show("请输入成绩！");
                                            }
                                            else
                                                MessageBox.Show("请输入性别！");
                                        }
                                        else
                                            MessageBox.Show("课程号与课程名不匹配！");
                                        
                                    }
                                    else
                                        MessageBox.Show("课程名不能为空！");
                                }
                                else
                                    MessageBox.Show("姓名不能为空！");
                            }
                            else
                                MessageBox.Show("课程号不能为空！");

                        }
                        else
                            MessageBox.Show("此学号和课程号所对应成绩已存在请选择修改！");
                    }
                    else
                        MessageBox.Show("学号必须大于0！");
                }
                else
                    MessageBox.Show("学号必须为数字！");
            }
            else
                MessageBox.Show("学号不能为空！");
            
        }

        private void button4_Click(object sender, EventArgs e)//删除
        {
            
            GetData("update cjpm set 总分 = 总分 - (select 成绩 from xxxx where 学号 ='" + textBox1.Text + "' and 课程号 ='" + textBox2.Text + "')where 学号 ='" + textBox1.Text + "'");
            GetData("delete xxxx where 学号='" + textBox1.Text + "'and 课程号='" + textBox2.Text + "'");
            GetData("update cjpm set 排名 = (select rank from(select 学号,ROW_NUMBER() over(order by 总分 desc) as rank from cjpm) as ranktable where 学号 = cjpm.学号)select * from cjpm");
            GetData("  select xxxx.学号,kc.课程号,xsxx.姓名,课程名,性别,成绩,年龄,学分,xsxx.班级 from kc,xxxx,xsxx where kc.课程号=xxxx.课程号 and xsxx.学号=xxxx.学号");
            MessageBox.Show("学生成绩删除成功！");
        }

        private void button2_Click(object sender, EventArgs e)//选择修改项
        {
            int a = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[a].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[a].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[a].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[a].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[a].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[a].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[a].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.Rows[a].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[a].Cells[8].Value.ToString();
            GetData("update cjpm set 总分 = 总分 - (select 成绩 from xxxx where 学号 ='" + textBox1.Text + "' and 课程号 ='" + textBox2.Text + "')where 学号 ='" + textBox1.Text + "'");
            GetData("delete xxxx where 学号='" + textBox1.Text + "'and 课程号='" + textBox2.Text + "'");
            
            GetData("  select xxxx.学号,kc.课程号,xsxx.姓名,课程名,性别,成绩,年龄,学分,xsxx.班级 from kc,xxxx,xsxx where kc.课程号=xxxx.课程号 and xsxx.学号=xxxx.学号");
        }

        private void button3_Click(object sender, EventArgs e)//确认修改
        {
            if (textBox1.Text != String.Empty)
            {
                if (IsNumberic(textBox1.Text))
                {
                    int i = Convert.ToInt32(textBox1.Text);
                    if (i > 0)
                    {
                        SqlConnection thisConn = new SqlConnection("Integrated Security=SSPI;Database=成绩查询系统;Server=localhost;");
                        SqlDataAdapter thisAdapter = new SqlDataAdapter("select * from xxxx where 学号='" + textBox1.Text + "'and 课程号='" + textBox2.Text + "'", thisConn);
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
                                        String connectionString = "Integrated Security=SSPI;Database=成绩查询系统;Server=localhost;";
                                        SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from kc where 课程号='" + textBox2.Text + "'and 课程名='" + textBox4.Text + "'", connectionString);
                                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                                        DataTable table = new DataTable();
                                        dataAdapter.Fill(table);
                                        if (table.Rows.Count > 0)
                                        {
                                            if (textBox5.Text != String.Empty)
                                            {
                                                if (textBox6.Text != String.Empty)
                                                {
                                                    if (IsNumberic(textBox6.Text))
                                                    {
                                                        i = Convert.ToInt32(textBox6.Text);
                                                        if (i > 0)
                                                        {
                                                            if (textBox7.Text != String.Empty)
                                                            {
                                                                if (IsNumberic(textBox6.Text))
                                                                {
                                                                    i = Convert.ToInt32(textBox7.Text);
                                                                    if (i > 0)
                                                                    {
                                                                        if (textBox8.Text != String.Empty)
                                                                        {
                                                                            SqlDataAdapter dataAdapter2 = new SqlDataAdapter("select * from kc where 课程名='" + textBox4.Text + "'and 学分='" + textBox8.Text + "'", connectionString);
                                                                            SqlCommandBuilder commandBuilder2 = new SqlCommandBuilder(dataAdapter);
                                                                            DataTable table2 = new DataTable();
                                                                            dataAdapter.Fill(table2);
                                                                            if (table2.Rows.Count > 0)
                                                                            {
                                                                                if (textBox9.Text != String.Empty)
                                                                                {
                                                                                    if (IsNumberic(textBox9.Text))
                                                                                    {
                                                                                        i = Convert.ToInt32(textBox9.Text);
                                                                                        if (i > 0)
                                                                                        {
                                                                                            GetData("insert into xxxx values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "')");
                                                                                            GetData("update cjpm set 总分=总分+'" + textBox6.Text + "'where 学号='"+textBox1.Text+"'");
                                                                                            GetData("update cjpm set 排名 = (select rank from(select 学号,ROW_NUMBER() over(order by 总分 desc) as rank from cjpm) as ranktable where 学号 = cjpm.学号)select * from cjpm");
                                                                                            GetData("  select xxxx.学号,kc.课程号,xsxx.姓名,课程名,性别,成绩,年龄,学分,xsxx.班级 from kc,xxxx,xsxx where kc.课程号=xxxx.课程号 and xsxx.学号=xxxx.学号");
                                                                                            MessageBox.Show("学生成绩修改成功！");                                                                                        
                                                                                        }
                                                                                        else
                                                                                            MessageBox.Show("班级必须大于0！");
                                                                                    }
                                                                                    else
                                                                                        MessageBox.Show("班级必须为数字！");

                                                                                }
                                                                                else
                                                                                    MessageBox.Show("班级不能为空！");

                                                                            }
                                                                            else
                                                                                MessageBox.Show("学分和课程名不匹配！");
                                                                        }
                                                                        else
                                                                            MessageBox.Show("学分不能为空！");

                                                                    }
                                                                    else
                                                                        MessageBox.Show("年龄必须大于0！");

                                                                }
                                                                else
                                                                    MessageBox.Show("年龄必须为数字！");
                                                            }
                                                            else
                                                                MessageBox.Show("年龄不能为空！");

                                                        }
                                                        else
                                                            MessageBox.Show("成绩必须大于0！");

                                                    }
                                                    else
                                                        MessageBox.Show("成绩必须为数字！");
                                                }
                                                else
                                                    MessageBox.Show("请输入成绩！");
                                            }
                                            else
                                                MessageBox.Show("请输入性别！");
                                        }
                                        else
                                            MessageBox.Show("课程号与课程名不匹配！");

                                    }
                                    else
                                        MessageBox.Show("课程名不能为空！");
                                }
                                else
                                    MessageBox.Show("姓名不能为空！");
                            }
                            else
                                MessageBox.Show("课程号不能为空！");

                        }
                        else
                            MessageBox.Show("此学号已存在！");
                    }
                    else
                        MessageBox.Show("学号必须大于0！");
                }
                else
                    MessageBox.Show("学号必须为数字！");
            }
            else
                MessageBox.Show("学号不能为空！");
        }
    }
}
