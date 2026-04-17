package dtm;

/**
 * Tính phí ship dựa trên trọng lượng, vùng giao hàng và tư cách thành viên.
 *
 * Quy tắc:
 * - trongLuong <= 0 → IllegalArgumentException
 * - vung = "noi_thanh" : base = 15 000; nếu trongLuong > 5 thêm
 * (trongLuong-5)*2000
 * - vung = "ngoai_thanh" : base = 25 000; nếu trongLuong > 3 thêm
 * (trongLuong-3)*3000
 * - else (tỉnh khác) : base = 50 000; nếu trongLuong > 2 thêm
 * (trongLuong-2)*5000
 * - laMember = true → giảm 10% (nhân 0.9)
 *
 * Số quyết định: D1 D2 D3 D4 D5 D6 D7 = 7 → CC = 7 + 1 = 8
 */
public class PhiShip {

    public static double tinhPhiShip(double trongLuong, String vung, boolean laMember) {
        // D1
        if (trongLuong <= 0) {
            throw new IllegalArgumentException("Trong luong phai > 0");
        }

        double phi;

        // D2
        if (vung.equals("noi_thanh")) {
            phi = 15_000;
            // D3
            if (trongLuong > 5) {
                phi += (trongLuong - 5) * 2_000;
            }
            // D4
        } else if (vung.equals("ngoai_thanh")) {
            phi = 25_000;
            // D5
            if (trongLuong > 3) {
                phi += (trongLuong - 3) * 3_000;
            }
        } else {
            phi = 50_000;
            // D6
            if (trongLuong > 2) {
                phi += (trongLuong - 2) * 5_000;
            }
        }

        // D7
        if (laMember) {
            phi = phi * 0.9;
        }

        return phi;
    }
}
