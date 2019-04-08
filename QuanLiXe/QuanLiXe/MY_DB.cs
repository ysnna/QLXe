using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLiXe
{
    class MY_DB
    {
<<<<<<< HEAD
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Do_An_Win\LapTrinhWin\QLXe\QuanLiXe\QuanLiXe\DESKTOP-RRRHOP4.mdf;Integrated Security=True;Connect Timeout=30");
        //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LTWindows\QuanLiXe\QuanLiXe\DESKTOP-RRRHOP4.mdf;Integrated Security=True;Connect Timeout=30");
=======

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LTWindows\QuanLiXe\QuanLiXe\DESKTOP-RRRHOP4.mdf;Integrated Security=True;Connect Timeout=30");
>>>>>>> c01e67137a4e353748826b42870024d7016f08d3
        public SqlConnection getConnection
        {
            get { return conn; }
        }
        public void openConnection()
        {
            if ((conn.State == ConnectionState.Closed))
            {
                conn.Open();
            }
        }
        public void closeConnection()
        {
            if ((conn.State == ConnectionState.Open))
            {
                conn.Close();
            }
        }
    }
}