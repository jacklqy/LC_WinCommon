using Common.CustAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("StudentInfos")]
    [PrimaryKey("StuId",autoIncrement =true)]
     public class StudentInfo
    {
        public int Id { get; set; }
        [Column("StuId")]
        public int StudentId { get; set; }
        public string StuName { get; set; }
        [Column("Age")]
        public int StuAge { get; set; }
        // int?  Nullable<int>
        public int? ClassId { get; set; }
        public int StuState { get; set; }
        public int IsDeleted { get; set; }
        public string Remark { get; set; }
    }
}
