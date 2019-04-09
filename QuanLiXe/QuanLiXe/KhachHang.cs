using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace QuanLiXe
{
    class KhachHang
    {
        MY_DB mydb = new MY_DB();
        //Them Khach Hang,cần bổ sung biến
        public bool insertStudent(MemoryStream picture)// Cần thêm các biến
        {
            SqlCommand cmd = new SqlCommand("insert into  @pic)", mydb.getConnection); // Cần biến kết nối data base
            //
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
        //Lấy thông tin, cần bổ sung biến
        public DataTable getStudents(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        //Xóa Thông Tin, cần bổ sung biến // **
        public bool deleteStudent(int id)
        {
            SqlCommand cmd = new SqlCommand("delete from Std where id = @id", mydb.getConnection); //**
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
        //Update thông tin, cần bổ sung biến //**
        public bool updateStudent( MemoryStream pic)
        {
            SqlCommand cmd = new SqlCommand("update Std set fname = @fn, lname = @ln, bdate = @bdt, gender = @gdr, phone = @phn, address = @adrs, picture = @pic where id = @id", mydb.getConnection);
           
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
        // Tổng các xe, bổ sung biến
        public int totalNumber()
        {
            SqlCommand command = new SqlCommand("SELECT ", mydb.getConnection);// ***
            //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table.Rows.Count;
        }
        // Tong xe hoi, can bien //**
        public int totalCar()
        {
            SqlCommand command = new SqlCommand("SELECT  where ", mydb.getConnection);
            //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
            command.Parameters.Add("@", SqlDbType.VarChar).Value = "Car"; //**
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table.Rows.Count;
        }
        // Tong xe may, can bien //**
        public int totalMotobike()
        {
            SqlCommand command = new SqlCommand("SELECT  from where ", mydb.getConnection); //**
            //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
            command.Parameters.Add("@", SqlDbType.VarChar).Value = ""; //**
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table.Rows.Count;
        }
        // Tong xe dap, can bien //**
        public int totalBike()
        {
            SqlCommand command = new SqlCommand("SELECT  from where ", mydb.getConnection); //**
            //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
            command.Parameters.Add("@", SqlDbType.VarChar).Value = ""; //**
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table.Rows.Count;
        }
    }
}
