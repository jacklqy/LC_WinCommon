using Common;
using DAL;
using DAL.Base;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinCommonDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StudentDAL studentDAL = new StudentDAL();
        private void Form1_Load(object sender, EventArgs e)
        {
            //DataTable dt = studentDAL.GetStudentList();
            //List<StudentInfo> 
            //DataRow dr = dt.Rows[0];
            //StudentInfo stu = DbConvert.DataRowToModel<StudentInfo>(dr, "");
            //List<StudentInfo> stuList = DbConvert.DataTableToList<StudentInfo>(dt, "");

            //StudentInfo stu1 = studentDAL.GetStudent(27);
            //List<StudentInfo> stuList2 = studentDAL.GetStudents(7);
            // dataGridView1.DataSource = stuList2;

            LoadClasses();
        }

        private void LoadClasses()
        {
            //DataTable dt = studentDAL.GetClasses();
            //cboClasses.DisplayMember = "ClassName";
            //cboClasses.ValueMember = "ClassId";
            //cboClasses.DataSource = dt;
            //cboClasses.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //insert 语句
            string sql = "insert into StudentInfos (StuName,Age,ClassId,Remark,StuState) values (@StuName,@Age,@ClassId,@Remark,@StuState)";

            //int id = studentDAL.AddStudent(new StudentInfo()
            //{
            //    StuName = txtStuName.Text.Trim(),
            //    StuAge = txtAge.Text.GetInt(),
            //    ClassId = cboClasses.SelectedValue.GetInt(),
            //    StuState = chkState.Checked ? 1 : 0,
            //    Remark = txtRemark.Text.Trim()
            //});

            int stuId = 50;
            string stuName = "各自安好";
            int age = 30;
            int stuState = 0;

            StudentInfo stuInfo = new StudentInfo()
            {
                StuAge = age,
                StuName = stuName,
                StudentId = stuId,
                StuState = stuState
            };
            bool update = studentDAL.EditStudent(stuInfo);

            DataTable dt1 = studentDAL.GetStudentList();
            StudentInfo stu1 = studentDAL.GetStudent(50);
            List<StudentInfo> stuList1 = studentDAL.GetStudents(7);
            List<StudentInfo> stuList2 = studentDAL.GetStudentListPage(5, 8);

            
        }





        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
