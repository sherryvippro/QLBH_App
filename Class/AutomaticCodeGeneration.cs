using QLBH_App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_App
{
    internal class AutomaticCodeGeneration
    {
        QLBanHangDBEntities qLBanHang = new QLBanHangDBEntities();
        public AutomaticCodeGeneration() { }
        public string CodeGeneration(string TenBang, string TruongMa, string MaBatDau)
        {
            string ma = "";
            string MaMax = "";
            // Tìm hóa đơn có mã cao nhất trong cơ sở dữ liệu
            switch (TenBang)
            {
                case "SanPham": MaMax = qLBanHang.SanPhams.OrderByDescending(x => x.MaSP).Select(x => x.MaSP).FirstOrDefault(); 
                    break;
                case "LoaiHang":
                    MaMax = qLBanHang.LoaiHangs.OrderByDescending(x => x.MaLoai).Select(x => x.MaLoai).FirstOrDefault();
                    break;
                case "KhachHang":
                    MaMax = qLBanHang.KhachHangs.OrderByDescending(x => x.MaKH).Select(x => x.MaKH).FirstOrDefault();
                    break;
                case "HDBan":
                    MaMax = qLBanHang.HDBans.OrderByDescending(x => x.MaHDB).Select(x => x.MaHDB).FirstOrDefault();
                    break;
            }
            if (MaMax == "" || MaMax == null)
            {
                ma = MaBatDau + "001";
            }
            else
            {
                // Lấy mã cao nhất hiện tại
                string macaonhat = MaMax;
                // Tách phần số từ mã hiện tại và tăng giá trị lên 1
                int soHienTai = int.Parse(macaonhat.Substring(MaBatDau.Length));
                soHienTai++;
                // Tạo mã mới dựa trên số vừa tăng và định dạng mẫu
                ma = MaBatDau + soHienTai.ToString("000");
            }
            

            return ma;
        }
    }
}
