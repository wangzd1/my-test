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
    public partial class 开课查询 : Form
    {
        public 开课查询()
        {
            InitializeComponent();
        }

        private void 开课查询_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
            GetData("select * from kc");
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                if (IsNumberic(textBox1.Text))
                {
                    int i = Convert.ToInt32(textBox1.Text);
                    if (i > 0)
                    {
                        SqlConnection thisConn = new SqlConnection("Integrated Security=SSPI;Database=成绩查询系统;Server=localhost;");
                        SqlDataAdapter thisAdapter = new SqlDataAdapter("select 学号,姓名,班级,总分 from cjpm where 学号='" + textBox1.Text + "'", thisConn);
                        DataSet thisDataSet = new DataSet();
                        thisAdapter.Fill(thisDataSet);
                        if (thisDataSet.Tables[0].Rows.Count > 0)
                        {
                            GetData("select xxxx.课程号,课程名,学分 from kc,xxxx where 学号='" + textBox1.Text + "' and xxxx.课程号=kc.课程号");
                        }
                        else
                        {
                            MessageBox.Show("学号不存在，请重新输入！");
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
