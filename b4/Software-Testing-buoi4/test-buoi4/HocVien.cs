using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_buoi4
{
    public class HocVien
    {
        private string maSo;
        private string hoTen;
        private string queQuan;
        private List<double> diemMonHoc;

        public HocVien(string maSo, string hoTen, string queQuan, List<double> diemMonHoc)
        {
            this.maSo = maSo;
            this.hoTen = hoTen;
            this.queQuan = queQuan;
            this.diemMonHoc = diemMonHoc;
        }

        public string MaSo
        {
            get { return maSo; }
            set { maSo = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public string QueQuan
        {
            get { return queQuan; }
            set { queQuan = value; }
        }

        public List<double> DiemMonHoc
        {
            get { return diemMonHoc; }
            set { diemMonHoc = value; }
        }

        // Tính ?i?m trung bình
        public double TinhDiemTrungBinh()
        {
            if (diemMonHoc == null || diemMonHoc.Count == 0)
                return 0;

            double tong = 0;
            foreach (double diem in diemMonHoc)
            {
                tong += diem;
            }
            return tong / diemMonHoc.Count;
        }

        // Ki?m tra h?c viên có ?? ?i?u ki?n nh?n h?c b?ng không
        public bool DuDieuKienHocBong()
        {
            double diemTrungBinh = TinhDiemTrungBinh();
            
            // ?i?m trung bình ph?i t? 8.0 tr? lên
            if (diemTrungBinh < 8.0)
                return false;

            // Không có môn nào d??i 5.0
            foreach (double diem in diemMonHoc)
            {
                if (diem < 5.0)
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            string diemStr = String.Join(", ", diemMonHoc);
            return $"[{maSo}] {hoTen} - {queQuan} - ?i?m: [{diemStr}] - TB: {TinhDiemTrungBinh():F2}";
        }
    }
}
