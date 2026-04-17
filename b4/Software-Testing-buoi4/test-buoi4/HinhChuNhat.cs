using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_buoi4
{
    public class HinhChuNhat
    {
        private Diem diemTrenBenTrai;
        private Diem diemDuoiBenPhai;

        public HinhChuNhat(Diem diemTrenBenTrai, Diem diemDuoiBenPhai)
        {
            this.diemTrenBenTrai = diemTrenBenTrai;
            this.diemDuoiBenPhai = diemDuoiBenPhai;
        }

        // Tính di?n tích hình ch? nh?t
        public double TinhDienTich()
        {
            double chieuDai = Math.Abs(diemDuoiBenPhai.X - diemTrenBenTrai.X);
            double chieuRong = Math.Abs(diemTrenBenTrai.Y - diemDuoiBenPhai.Y);
            return chieuDai * chieuRong;
        }

        // Ki?m tra hai hình ch? nh?t có giao nhau hay không
        public bool KiemTraGiaoNhau(HinhChuNhat hcn)
        {
            // L?y t?a ?? các ?i?m c?a hình ch? nh?t hi?n t?i
            double x1_min = this.diemTrenBenTrai.X;
            double x1_max = this.diemDuoiBenPhai.X;
            double y1_max = this.diemTrenBenTrai.Y;
            double y1_min = this.diemDuoiBenPhai.Y;

            // L?y t?a ?? các ?i?m c?a hình ch? nh?t ???c truy?n vào
            double x2_min = hcn.diemTrenBenTrai.X;
            double x2_max = hcn.diemDuoiBenPhai.X;
            double y2_max = hcn.diemTrenBenTrai.Y;
            double y2_min = hcn.diemDuoiBenPhai.Y;

            // Ki?m tra ?i?u ki?n không giao nhau
            // N?u m?t hình ? hoàn toàn bên trái, bên ph?i, bên trên, ho?c bên d??i hình kia
            if (x1_max < x2_min || x2_max < x1_min || y1_max < y2_min || y2_max < y1_min)
            {
                return false; // Không giao nhau
            }

            return true; // Có giao nhau
        }

        public override string ToString()
        {
            return $"HCN[Trên trái: {diemTrenBenTrai}, D??i ph?i: {diemDuoiBenPhai}]";
        }
    }
}
