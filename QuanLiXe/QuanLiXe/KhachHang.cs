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
        public bool insertCus(string vitri,string loaixe, MemoryStream anhbienso, MemoryStream anhxe,
            DateTime ngaygui, DateTime giogui, string yeucau )// Cần thêm các biến

        {
            SqlCommand cmd = new SqlCommand("insert into QUANLIXERAVAO (vitri, loaixe, bienso, ava, ngayguixe, gioguixe, timeyeucau)" +
                "values(@vitri, @loaixe, @pic, @pic1, @ngaygui, @giogui, @yeucau)", mydb.getConnection); // Cần biến kết nối data base
            cmd.Parameters.Add("@vitri", SqlDbType.VarChar).Value = vitri;
            cmd.Parameters.Add("@loaixe", SqlDbType.VarChar).Value = loaixe;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = anhbienso.ToArray();
            cmd.Parameters.Add("@pic1", SqlDbType.Image).Value = anhxe.ToArray();
            cmd.Parameters.Add("@ngaygui", SqlDbType.DateTime).Value = ngaygui;
            cmd.Parameters.Add("@giogui", SqlDbType.DateTime).Value = giogui;
            cmd.Parameters.Add("@yeucau",SqlDbType.VarChar).Value=yeucau;
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
        public DataTable getCus(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        //Xóa Thông Tin, cần bổ sung biến // **
        public bool deleteCus(string vitri)
        {
            SqlCommand cmd = new SqlCommand("delete from QUANLIXERAVAO where vitri = @vitri", mydb.getConnection); //**
            cmd.Parameters.Add("@vitri", SqlDbType.VarChar).Value = vitri;
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
        public bool updateBaiXe(string num,string vitri)
        {
            SqlCommand cmd = new SqlCommand("update BAIXE set A=@num where vitriXe=@vitri ", mydb.getConnection);
            cmd.Parameters.Add("@num", SqlDbType.VarChar).Value = num ;
            
            cmd.Parameters.Add("@vitri", SqlDbType.VarChar).Value = vitri; 
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
        public bool updateBaiXe2(string num, string vitri)
        {
            SqlCommand cmd = new SqlCommand("update BAIXE set B=@num where vitriXe=@vitri ", mydb.getConnection);
            cmd.Parameters.Add("@num", SqlDbType.VarChar).Value = num;

            cmd.Parameters.Add("@vitri", SqlDbType.VarChar).Value = vitri;
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
        public bool updateBaiXe3(string num, string vitri)
        {
            SqlCommand cmd = new SqlCommand("update BAIXE set C=@num where vitriXe=@vitri ", mydb.getConnection);
            cmd.Parameters.Add("@num", SqlDbType.VarChar).Value = num;

            cmd.Parameters.Add("@vitri", SqlDbType.VarChar).Value = vitri;
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
        //public bool updateCus(string vitri, string loaixe, MemoryStream anhbienso, MemoryStream anhxe,
        //    DateTime ngaygui, DateTime giogui, string yeucau)
        //{
        //    SqlCommand cmd = new SqlCommand("update QUANLIXERAVAO set vitri=@vitri, loaixe=@loaixe, bienso=@anhbienso" +
        //        ", ava=@anhxe, ngayguixe=@ngaygui, gioguixe=@giogui, timeyeucau=@yeucau ", mydb.getConnection);
        //    cmd.Parameters.Add("@vitri", SqlDbType.VarChar).Value = vitri;
        //    cmd.Parameters.Add("@loaixe", SqlDbType.VarChar).Value = loaixe;
        //    cmd.Parameters.Add("@pic", SqlDbType.Image).Value = anhbienso.ToArray();
        //    cmd.Parameters.Add("@pic1", SqlDbType.Image).Value = anhxe.ToArray();
        //    cmd.Parameters.Add("@ngaygui", SqlDbType.DateTime).Value = ngaygui;
        //    cmd.Parameters.Add("@giogui", SqlDbType.DateTime).Value = giogui;
        //    cmd.Parameters.Add("@yeucau", SqlDbType.VarChar).Value = yeucau;


        //    mydb.openConnection();
        //    if (cmd.ExecuteNonQuery() == 1)
        //    {
        //        mydb.closeConnection();
        //        return true;
        //    }
        //    else
        //    {
        //        mydb.closeConnection();
        //        return false;
        //    }

        //}
        //// Tổng các xe, bổ sung biến
        //public int totalNumber()
        //{
        //    SqlCommand command = new SqlCommand("SELECT ", mydb.getConnection);// ***
        //    //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
        //    DataTable table = new DataTable();
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    adapter.Fill(table);
        //    return table.Rows.Count;
        //}
        //// Tong xe hoi, can bien //**
        //public int totalCar()
        //{
        //    SqlCommand command = new SqlCommand("SELECT  where ", mydb.getConnection);
        //    //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
        //    command.Parameters.Add("@", SqlDbType.VarChar).Value = "Car"; //**
        //    DataTable table = new DataTable();
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    adapter.Fill(table);
        //    return table.Rows.Count;
        //}
        //// Tong xe may, can bien //**
        //public int totalMotobike()
        //{
        //    SqlCommand command = new SqlCommand("SELECT  from where ", mydb.getConnection); //**
        //    //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
        //    command.Parameters.Add("@", SqlDbType.VarChar).Value = ""; //**
        //    DataTable table = new DataTable();
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    adapter.Fill(table);
        //    return table.Rows.Count;
        //}
        //// Tong xe dap, can bien //**
        //public int totalBike()
        //{
        //    SqlCommand command = new SqlCommand("SELECT  from where ", mydb.getConnection); //**
        //    //SqlCommand comand = new SqlCommand(query + id, db.GetConnection);
        //    command.Parameters.Add("@", SqlDbType.VarChar).Value = ""; //**
        //    DataTable table = new DataTable();
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    adapter.Fill(table);
        //    return table.Rows.Count;
        //}
    }
}