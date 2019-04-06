using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace _17110094_NguyenAnh_Login
{
    class STUDENT
    {
        MY_DB mydb = new MY_DB();
        public bool insertStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("insert into Std (id, fname,lname, bdate, gender, phone, address,picture)" +
                " values (@id, @fn, @ln, @bd, @gen, @phn, @add, @pic)", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@bd", SqlDbType.DateTime).Value = bdate;
            cmd.Parameters.Add("@gen", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@add", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public DataTable getStudents(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        public bool deleteStudent(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from Std where id = @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        public bool updateStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream pic)
        {
            SqlCommand cmd = new SqlCommand("update Std set fname = @fn, lname = @ln, bdate = @bdt, gender = @gdr, phone = @phn, address = @adrs, picture = @pic where id = @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            cmd.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = pic.ToArray();
            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}