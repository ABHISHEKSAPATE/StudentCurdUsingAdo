using System.Data.SqlClient;
namespace StudentCurdUsingAdo.Models
{
    public class StudentCurd
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;


        public StudentCurd(IConfiguration configuration)
        {
            this.configuration = configuration;
            conn = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }

        //GET ALL STUDENT
        public List<Student> GetStudents() 
        {
            List<Student> students = new List<Student>();
            cmd = new SqlCommand("select *from studentdata", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.Rollno = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Percentage = Convert.ToDecimal(dr["percentage"]);
                    students.Add(student);
                }
            }
            conn.Close();
            return students;
        }

        //ADD STUDENT
        public int AddStudent(Student stu)
        {
            int result = 0;
            string qry = "insert into studentdata values(@name,@branch,@percentage)";
            cmd= new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@name",stu.Name);
            cmd.Parameters.AddWithValue("@branch", stu.Branch);
            cmd.Parameters.AddWithValue("@percentage", stu.Percentage);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;

        }

        //UPDATE
        public int UpdateStudent(Student stu)
        {
            int result = 0;
            string qry = "update studentdata set name=@name,branch=@branch, where rollno=@rollno";
            cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@name", stu.Name);
            cmd.Parameters.AddWithValue("@branch", stu.Branch);
            cmd.Parameters.AddWithValue("@percentage",stu.Percentage);
            cmd.Parameters.AddWithValue("@rollno", stu.Rollno);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }


        //DELETE EMPLOYEE
        public int DeleteStudent(int rollno)
        {
            int result = 0;
            string qry = "delete from studentdata where rollno=@rollno";
            cmd = new SqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            conn.Open();
            result = cmd.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        //GET STUDENT BY ROLL NO
        public Student GetStudentById(int rollno)
        {
            Student student = new Student();
            cmd = new SqlCommand("select * from studentdata where rollno=@rollno", conn);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.Rollno = Convert.ToInt32(dr["rollno"]);
                    student.Name = dr["name"].ToString();
                    student.Branch = dr["branch"].ToString();
                    student.Percentage = Convert.ToDecimal(dr["percentage"]);
                  

                }
            }
            conn.Close();
            return student;
        }


    }
}
