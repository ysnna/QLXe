using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuanLiXe
{
    class KhachHang
    {
        MY_DB mydb = new MY_DB();
        public bool insertKhachhang(int MaKH, string HoKH, string TenKH, string DiaChi, int Sdt,DateTime ngaybatdau,DateTime ngayketthuc ,int SoHopDong,MemoryStream picture )
        {
            SqlCommand command = new SqlCommand("INSERT INTO THONGTINKHACHHANG (MaKH, HoKH, TenKH, DiaChi, Sdt, SoHopDong, ngaybatdau, ngayketthuc, picture)" + 
            "VALUES(@Id,@Ho,@Ten,@Diachi,@Sdt,@Sohopdong,@Ngaybatdau,@Ngayketthuc,@Picture)", mydb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = MaKH;
            command.Parameters.Add("@Ho", SqlDbType.VarChar).Value = HoKH;
            command.Parameters.Add("@Ten", SqlDbType.VarChar).Value = TenKH;
            command.Parameters.Add("@Diachi", SqlDbType.VarChar).Value = DiaChi;
            command.Parameters.Add("@Sdt", SqlDbType.Int).Value = Sdt;
            command.Parameters.Add("@Sohopdong", SqlDbType.Int).Value = SoHopDong;
            command.Parameters.Add("@Ngaybatdau", SqlDbType.DateTime).Value = ngaybatdau;
            command.Parameters.Add("@Ngayketthuc", SqlDbType.DateTime).Value = ngayketthuc;
            command.Parameters.Add("@Picture", SqlDbType.Image).Value = picture.ToArray();
            
            mydb.openConnection();
           
               if ((command.ExecuteNonQuery() == 1))
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
        public DataTable getKhachHang(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
