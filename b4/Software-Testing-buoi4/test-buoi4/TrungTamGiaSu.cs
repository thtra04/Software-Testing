using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_buoi4
{
    public class TrungTamGiaSu
    {
        private List<HocVien> danhSachHocVien;

        public TrungTamGiaSu()
        {
            danhSachHocVien = new List<HocVien>();
        }

        // Thêm h?c viên vào danh sách
        public void ThemHocVien(HocVien hv)
        {
            danhSachHocVien.Add(hv);
        }

        // L?y t?t c? h?c viên
        public List<HocVien> LayDanhSachHocVien()
        {
            return danhSachHocVien;
        }

        // Tìm h?c viên có thành tích h?c t?p t?t (?? ?i?u ki?n h?c b?ng)
        public List<HocVien> TimHocVienNhanHocBong()
        {
            List<HocVien> ketQua = new List<HocVien>();
            
            foreach (HocVien hv in danhSachHocVien)
            {
                if (hv.DuDieuKienHocBong())
                {
                    ketQua.Add(hv);
                }
            }

            return ketQua;
        }

        // Xác ??nh danh sách h?c viên có th? nh?n h?c b?ng
        public List<HocVien> XacDinhHocVienNhanHocBong()
        {
            return TimHocVienNhanHocBong();
        }

        // L?y s? l??ng h?c viên
        public int LaySoLuongHocVien()
        {
            return danhSachHocVien.Count;
        }
    }
}
