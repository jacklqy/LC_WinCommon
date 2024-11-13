using Common;
using DAL.Base;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentNewDAL:BaseDAL<StudentInfo>
    {
          public bool AddStudent(StudentInfo stuInfo)
        {
            string cols = PropertyHelper.GetColNames<StudentInfo>("IsDeleted,StuId");
            return Add(stuInfo,cols, 0)>0;
        }

        public int  AddStudentWithId(StudentInfo stuInfo)
        {
            string cols = PropertyHelper.GetColNames<StudentInfo>("IsDeleted,StuId");
            return Add(stuInfo, cols, 1);
        }

        public bool UpdateStudent(StudentInfo stuInfo)
        {
            string cols = PropertyHelper.GetColNames<StudentInfo>("IsDeleted");
            return Update(stuInfo, cols);
        }

        public StudentInfo GetStudent(int stuId)
        {
            string cols = PropertyHelper.GetColNames<StudentInfo>("IsDeleted");
            return GetById(stuId, cols);
        }

        public List<StudentInfo> GetCboStudents()
        {
            return GetModelList("StuId,StuName", "", 0);
        }

        public List<StudentInfo> GetStudents(string stuName,int classId)
        {
            string strWhere = "IsDeleted=0";
            if (string.IsNullOrEmpty(stuName))
                strWhere += " and StuName like @stuName";
            if (classId > 0)
                strWhere += " and ClassId=" + classId;
            SqlParameter para = new SqlParameter("@stuName", $"%{stuName}%");
            return GetModelList(strWhere, "StuId,StuName,Age,ClassId", "", para);
        }
    }
}
