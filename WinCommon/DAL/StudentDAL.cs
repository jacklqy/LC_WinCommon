using Common;
using DAL.Base;
using DAL.Helper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentDAL
    {
        public DataTable GetStudentList()
        {
            // string sql = "select * from StudentInfos";
            string cols = PropertyHelper.GetColNames<StudentInfo>("Id");
            string sql = CreateSql.CreateSelectSql<StudentInfo>(cols, "", "Age asc");
            return SqlHelper.GetDataTable(sql, 1);
        }

        public DataTable GetClasses()
        {
            string sql = "select * from ClassInfos where IsDeleted=0";
            return SqlHelper.GetDataTable(sql, 1);
        }

        /// <summary>
        /// 获取指定的学生信息
        /// </summary>
        /// <param name="stuId"></param>
        /// <returns></returns>
        public StudentInfo GetStudent(int stuId)
        {
            string cols = PropertyHelper.GetColNames<StudentInfo>("IsDeleted,Id");
            //string sql = "select * from StudentInfos where StuId=" + stuId;
            string sql = CreateSql.CreateSelectSql<StudentInfo>(cols, "StuId=" + stuId, "");
            SqlDataReader dr = SqlHelper.ExecuteReader(sql, 1);
            StudentInfo stu = DbConvert.DataReaderToModel<StudentInfo>(dr, cols);
            return stu;
        }

        /// <summary>
        /// 获取指定班级的学生信息
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<StudentInfo> GetStudents(int classId)
        {

            //string sql = "select * from StudentInfos where ClassId=" + classId;
            string sql = CreateSql.CreateSelectSql<StudentInfo>("StuId,StuName,ClassId", "ClassId=" + classId, "");
            SqlDataReader dr = SqlHelper.ExecuteReader(sql, 1);
            List<StudentInfo> stuList = DbConvert.DataReaderToList<StudentInfo>(dr, "StuId,StuName,ClassId");
            return stuList;
        }

        public List<StudentInfo> GetStudentListPage(int startIndex,int pageSize)
        {
            string sql = CreateSql.CreateRowSelectSql<StudentInfo>("StuId,StuName,ClassId", "","Id","Age asc");
            string sql1 = $"select * from ({sql}) as Temp where Id between {startIndex} and {startIndex + pageSize - 1}";
            SqlDataReader dr = SqlHelper.ExecuteReader(sql1, 1);
            List<StudentInfo> stuList = DbConvert.DataReaderToList<StudentInfo>(dr, "StuId,StuName,ClassId,Id");
            return stuList;
        }

        public int AddStudent(StudentInfo stuInfo)
        {
            string cols = PropertyHelper.GetColNames<StudentInfo>("IsDeleted,CreateTime");
            SqlModel insert = CreateSql.CreateInsertSql<StudentInfo>(stuInfo, cols, 1);
            string sql = insert.Sql;
            SqlParameter[] paras = insert.Paras;
            object oId= SqlHelper.ExecuteScalar(sql, 1, paras);
            return oId.GetInt();
        }

        public bool EditStudent(StudentInfo stuInfo)
        {
            string cols = "StuId,StuName,Age,StuState";
            SqlModel update = CreateSql.CreateUpdateSql<StudentInfo>(stuInfo, cols, "");
            string sql = update.Sql;
            SqlParameter[] paras = update.Paras;

            return SqlHelper.ExecuteNonQuery(sql, 1, paras) > 0;
        }
    }
}
