using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_buoi4
{
    internal class Program
    {
        static double Power(double x, int n)
        {
            if (n == 0)
                return 1.0;
            else if (n > 0)
                return x * Power(x, n - 1);
            else
                return Power(x, n + 1) / x;
        }

        static void TestBai1()
        {
            Console.Clear();
            Console.WriteLine("=== BÀI 1: KIỂM THỬ HÀM POWER ===\n");

            TestReport report = new TestReport("BÀI 1 - HÀM POWER");

            // Test case 1: n = 0
            double result1 = Power(2, 0);
            Console.WriteLine($"Test 1: Power(2, 0) = {result1}");
            bool pass1 = result1 == 1.0;
            Console.WriteLine($"Kỳ vọng: 1, Kết quả: {(pass1 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 1: n = 0", "Power(2, 0)", "1", result1.ToString(), pass1);

            // Test case 2: n > 0
            double result2 = Power(2, 3);
            Console.WriteLine($"Test 2: Power(2, 3) = {result2}");
            bool pass2 = result2 == 8.0;
            Console.WriteLine($"Kỳ vọng: 8, Kết quả: {(pass2 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 2: n > 0", "Power(2, 3)", "8", result2.ToString(), pass2);

            // Test case 3: n > 0 với số khác
            double result3 = Power(5, 2);
            Console.WriteLine($"Test 3: Power(5, 2) = {result3}");
            bool pass3 = result3 == 25.0;
            Console.WriteLine($"Kỳ vọng: 25, Kết quả: {(pass3 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 3: n > 0 khác", "Power(5, 2)", "25", result3.ToString(), pass3);

            // Test case 4: n < 0
            double result4 = Power(2, -2);
            Console.WriteLine($"Test 4: Power(2, -2) = {result4}");
            bool pass4 = Math.Abs(result4 - 0.25) < 0.0001;
            Console.WriteLine($"Kỳ vọng: 0.25, Kết quả: {(pass4 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 4: n < 0", "Power(2, -2)", "0.25", result4.ToString(), pass4);

            // Test case 5: n < 0 với số khác
            double result5 = Power(10, -1);
            Console.WriteLine($"Test 5: Power(10, -1) = {result5}");
            bool pass5 = Math.Abs(result5 - 0.1) < 0.0001;
            Console.WriteLine($"Kỳ vọng: 0.1, Kết quả: {(pass5 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 5: n < 0 khác", "Power(10, -1)", "0.1", result5.ToString(), pass5);

            // Test case 6: x = 1
            double result6 = Power(1, 5);
            Console.WriteLine($"Test 6: Power(1, 5) = {result6}");
            bool pass6 = result6 == 1.0;
            Console.WriteLine($"Kỳ vọng: 1, Kết quả: {(pass6 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 6: x = 1", "Power(1, 5)", "1", result6.ToString(), pass6);

            // Hiển thị tổng kết
            report.HienThiTongQuat();

            // Xuất báo cáo
            Console.WriteLine("\nBạn có muốn xuất báo cáo? (Y/N): ");
            string choice = Console.ReadLine();
            if (choice != null && choice.ToUpper() == "Y")
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                report.XuatBaoCaoCSV($"BaoCao_Bai1_{timestamp}.csv");
                report.XuatBaoCaoText($"BaoCao_Bai1_{timestamp}.txt");
            }
        }

        static void TestBai2()
        {
            Console.Clear();
            Console.WriteLine("=== BÀI 2: KIỂM THỬ CLASS POLYNOMIAL ===\n");

            TestReport report = new TestReport("BÀI 2 - CLASS POLYNOMIAL");

            try
            {
                // Test case 1: Đa thức bậc 2: 3x^2 + 2x + 1
                Console.WriteLine("Test 1: Đa thức P(x) = 3x^2 + 2x + 1");
                List<int> coeffs1 = new List<int> { 1, 2, 3 }; // a0=1, a1=2, a2=3
                Polynomial p1 = new Polynomial(2, coeffs1);

                double x1 = 2;
                int result1 = p1.Cal(x1);
                int expected1 = 3 * 2 * 2 + 2 * 2 + 1; // = 12 + 4 + 1 = 17
                Console.WriteLine($"P({x1}) = {result1}");
                bool pass1 = result1 == expected1;
                Console.WriteLine($"Kỳ vọng: {expected1}, Kết quả: {(pass1 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 1: Đa thức bậc 2", "P(2) với a=[1,2,3]", expected1.ToString(), result1.ToString(), pass1);

                // Test case 2: Đa thức bậc 3: 2x^3 - 3x^2 + x - 5
                Console.WriteLine("Test 2: Đa thức P(x) = 2x^3 - 3x^2 + x - 5");
                List<int> coeffs2 = new List<int> { -5, 1, -3, 2 }; // a0=-5, a1=1, a2=-3, a3=2
                Polynomial p2 = new Polynomial(3, coeffs2);

                double x2 = 1;
                int result2 = p2.Cal(x2);
                int expected2 = 2 * 1 * 1 * 1 - 3 * 1 * 1 + 1 - 5; // = 2 - 3 + 1 - 5 = -5
                Console.WriteLine($"P({x2}) = {result2}");
                bool pass2 = result2 == expected2;
                Console.WriteLine($"Kỳ vọng: {expected2}, Kết quả: {(pass2 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 2: Đa thức bậc 3", "P(1) với a=[-5,1,-3,2]", expected2.ToString(), result2.ToString(), pass2);

                // Test case 3: Đa thức bậc 1: 5x + 3
                Console.WriteLine("Test 3: Đa thức P(x) = 5x + 3");
                List<int> coeffs3 = new List<int> { 3, 5 }; // a0=3, a1=5
                Polynomial p3 = new Polynomial(1, coeffs3);

                double x3 = 4;
                int result3 = p3.Cal(x3);
                int expected3 = 5 * 4 + 3; // = 20 + 3 = 23
                Console.WriteLine($"P({x3}) = {result3}");
                bool pass3 = result3 == expected3;
                Console.WriteLine($"Kỳ vọng: {expected3}, Kết quả: {(pass3 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 3: Đa thức bậc 1", "P(4) với a=[3,5]", expected3.ToString(), result3.ToString(), pass3);

                // Test case 4: Đa thức bậc 0: hằng số 7
                Console.WriteLine("Test 4: Đa thức P(x) = 7 (hằng số)");
                List<int> coeffs4 = new List<int> { 7 }; // a0=7
                Polynomial p4 = new Polynomial(0, coeffs4);

                double x4 = 10;
                int result4 = p4.Cal(x4);
                int expected4 = 7;
                Console.WriteLine($"P({x4}) = {result4}");
                bool pass4 = result4 == expected4;
                Console.WriteLine($"Kỳ vọng: {expected4}, Kết quả: {(pass4 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 4: Hằng số", "P(10) với a=[7]", expected4.ToString(), result4.ToString(), pass4);

                // Test case 5: Test với x = 0
                Console.WriteLine("Test 5: Đa thức P(x) = x^2 + 2x + 3 tại x = 0");
                List<int> coeffs5 = new List<int> { 3, 2, 1 }; // a0=3, a1=2, a2=1
                Polynomial p5 = new Polynomial(2, coeffs5);

                double x5 = 0;
                int result5 = p5.Cal(x5);
                int expected5 = 3; // Chỉ còn hệ số tự do
                Console.WriteLine($"P({x5}) = {result5}");
                bool pass5 = result5 == expected5;
                Console.WriteLine($"Kỳ vọng: {expected5}, Kết quả: {(pass5 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 5: x = 0", "P(0) với a=[3,2,1]", expected5.ToString(), result5.ToString(), pass5);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}\n");
            }

            // Test case 6: Kiểm tra ngoại lệ "Invalid Data"
            Console.WriteLine("Test 6: Kiểm tra ngoại lệ khi n+1 != số lượng hệ số");
            bool pass6 = false;
            try
            {
                List<int> coeffsInvalid = new List<int> { 1, 2, 3 }; // 3 phần tử
                Polynomial pInvalid = new Polynomial(4, coeffsInvalid); // n=4 yêu cầu 5 phần tử
                Console.WriteLine("Kết quả: FAIL (Không có ngoại lệ)\n");
                report.ThemTestCase("Test 6: Exception Invalid Data", "n=4, a.Count=3", "ArgumentException", "Không có exception", false);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ngoại lệ: {ex.Message}");
                pass6 = ex.Message == "Invalid Data";
                Console.WriteLine($"Kết quả: {(pass6 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 6: Exception Invalid Data", "n=4, a.Count=3", "Invalid Data", ex.Message, pass6);
            }

            // Test case 7: Kiểm tra ngoại lệ với n+1 lớn hơn số lượng hệ số
            Console.WriteLine("Test 7: Kiểm tra ngoại lệ khi thiếu hệ số");
            bool pass7 = false;
            try
            {
                List<int> coeffsInvalid2 = new List<int> { 1, 2 }; // 2 phần tử
                Polynomial pInvalid2 = new Polynomial(3, coeffsInvalid2); // n=3 yêu cầu 4 phần tử
                Console.WriteLine("Kết quả: FAIL (Không có ngoại lệ)\n");
                report.ThemTestCase("Test 7: Exception thiếu hệ số", "n=3, a.Count=2", "ArgumentException", "Không có exception", false);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ngoại lệ: {ex.Message}");
                pass7 = ex.Message == "Invalid Data";
                Console.WriteLine($"Kết quả: {(pass7 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 7: Exception thiếu hệ số", "n=3, a.Count=2", "Invalid Data", ex.Message, pass7);
            }

            // Hiển thị tổng kết
            report.HienThiTongQuat();

            // Xuất báo cáo
            Console.WriteLine("\nBạn có muốn xuất báo cáo? (Y/N): ");
            string choice = Console.ReadLine();
            if (choice != null && choice.ToUpper() == "Y")
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                report.XuatBaoCaoCSV($"BaoCao_Bai2_{timestamp}.csv");
                report.XuatBaoCaoText($"BaoCao_Bai2_{timestamp}.txt");
            }
        }

        static void TestBai3()
        {
            Console.Clear();
            Console.WriteLine("=== BÀI 3: KIỂM THỬ CLASS RADIX ===\n");

            TestReport report = new TestReport("BÀI 3 - CLASS RADIX");

            try
            {
                // Test case 1: Chuyển 10 sang nhị phân (cơ số 2)
                Console.WriteLine("Test 1: Chuyển 10 sang cơ số 2 (nhị phân)");
                Radix r1 = new Radix(10);
                string result1 = r1.ConvertDecimalToAnother(2);
                string expected1 = "1010";
                Console.WriteLine($"10 (cơ số 10) = {result1} (cơ số 2)");
                bool pass1 = result1 == expected1;
                Console.WriteLine($"Kỳ vọng: {expected1}, Kết quả: {(pass1 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 1: Sang nhị phân", "10 -> cơ số 2", expected1, result1, pass1);

                // Test case 2: Chuyển 255 sang thập lục phân (cơ số 16)
                Console.WriteLine("Test 2: Chuyển 255 sang cơ số 16 (thập lục phân)");
                Radix r2 = new Radix(255);
                string result2 = r2.ConvertDecimalToAnother(16);
                string expected2 = "FF";
                Console.WriteLine($"255 (cơ số 10) = {result2} (cơ số 16)");
                bool pass2 = result2 == expected2;
                Console.WriteLine($"Kỳ vọng: {expected2}, Kết quả: {(pass2 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 2: Sang hex", "255 -> cơ số 16", expected2, result2, pass2);

                // Test case 3: Chuyển 64 sang bát phân (cơ số 8)
                Console.WriteLine("Test 3: Chuyển 64 sang cơ số 8 (bát phân)");
                Radix r3 = new Radix(64);
                string result3 = r3.ConvertDecimalToAnother(8);
                string expected3 = "100";
                Console.WriteLine($"64 (cơ số 10) = {result3} (cơ số 8)");
                bool pass3 = result3 == expected3;
                Console.WriteLine($"Kỳ vọng: {expected3}, Kết quả: {(pass3 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 3: Sang bát phân", "64 -> cơ số 8", expected3, result3, pass3);

                // Test case 4: Chuyển 100 sang cơ số 5
                Console.WriteLine("Test 4: Chuyển 100 sang cơ số 5");
                Radix r4 = new Radix(100);
                string result4 = r4.ConvertDecimalToAnother(5);
                string expected4 = "400";
                Console.WriteLine($"100 (cơ số 10) = {result4} (cơ số 5)");
                bool pass4 = result4 == expected4;
                Console.WriteLine($"Kỳ vọng: {expected4}, Kết quả: {(pass4 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 4: Sang cơ số 5", "100 -> cơ số 5", expected4, result4, pass4);

                // Test case 5: Chuyển 31 sang cơ số 16
                Console.WriteLine("Test 5: Chuyển 31 sang cơ số 16");
                Radix r5 = new Radix(31);
                string result5 = r5.ConvertDecimalToAnother(16);
                string expected5 = "1F";
                Console.WriteLine($"31 (cơ số 10) = {result5} (cơ số 16)");
                bool pass5 = result5 == expected5;
                Console.WriteLine($"Kỳ vọng: {expected5}, Kết quả: {(pass5 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 5: 31 sang hex", "31 -> cơ số 16", expected5, result5, pass5);

                // Test case 6: Chuyển 1000 sang cơ số 12
                Console.WriteLine("Test 6: Chuyển 1000 sang cơ số 12");
                Radix r6 = new Radix(1000);
                string result6 = r6.ConvertDecimalToAnother(12);
                string expected6 = "6B4";
                Console.WriteLine($"1000 (cơ số 10) = {result6} (cơ số 12)");
                bool pass6 = result6 == expected6;
                Console.WriteLine($"Kỳ vọng: {expected6}, Kết quả: {(pass6 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 6: Sang cơ số 12", "1000 -> cơ số 12", expected6, result6, pass6);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}\n");
            }

            // Test case 7: Kiểm tra ngoại lệ "Incorrect Value" khi số âm
            Console.WriteLine("Test 7: Kiểm tra ngoại lệ khi số âm");
            bool pass7 = false;
            try
            {
                Radix rInvalid1 = new Radix(-5);
                Console.WriteLine("Kết quả: FAIL (Không có ngoại lệ)\n");
                report.ThemTestCase("Test 7: Exception số âm", "Radix(-5)", "ArgumentException", "Không có exception", false);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ngoại lệ: {ex.Message}");
                pass7 = ex.Message == "Incorrect Value";
                Console.WriteLine($"Kết quả: {(pass7 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 7: Exception số âm", "Radix(-5)", "Incorrect Value", ex.Message, pass7);
            }

            // Test case 8: Kiểm tra ngoại lệ "Invalid Radix" khi radix < 2
            Console.WriteLine("Test 8: Kiểm tra ngoại lệ khi radix < 2");
            bool pass8 = false;
            try
            {
                Radix r = new Radix(10);
                string result = r.ConvertDecimalToAnother(1);
                Console.WriteLine("Kết quả: FAIL (Không có ngoại lệ)\n");
                report.ThemTestCase("Test 8: Exception radix < 2", "radix = 1", "ArgumentException", "Không có exception", false);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ngoại lệ: {ex.Message}");
                pass8 = ex.Message == "Invalid Radix";
                Console.WriteLine($"Kết quả: {(pass8 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 8: Exception radix < 2", "radix = 1", "Invalid Radix", ex.Message, pass8);
            }

            // Test case 9: Kiểm tra ngoại lệ "Invalid Radix" khi radix > 16
            Console.WriteLine("Test 9: Kiểm tra ngoại lệ khi radix > 16");
            bool pass9 = false;
            try
            {
                Radix r = new Radix(10);
                string result = r.ConvertDecimalToAnother(17);
                Console.WriteLine("Kết quả: FAIL (Không có ngoại lệ)\n");
                report.ThemTestCase("Test 9: Exception radix > 16", "radix = 17", "ArgumentException", "Không có exception", false);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ngoại lệ: {ex.Message}");
                pass9 = ex.Message == "Invalid Radix";
                Console.WriteLine($"Kết quả: {(pass9 ? "PASS" : "FAIL")}\n");
                report.ThemTestCase("Test 9: Exception radix > 16", "radix = 17", "Invalid Radix", ex.Message, pass9);
            }

            // Hiển thị tổng kết
            report.HienThiTongQuat();

            // Xuất báo cáo
            Console.WriteLine("\nBạn có muốn xuất báo cáo? (Y/N): ");
            string choice = Console.ReadLine();
            if (choice != null && choice.ToUpper() == "Y")
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                report.XuatBaoCaoCSV($"BaoCao_Bai3_{timestamp}.csv");
                report.XuatBaoCaoText($"BaoCao_Bai3_{timestamp}.txt");
            }
        }

        static void TestBai4()
        {
            Console.Clear();
            Console.WriteLine("=== BÀI 4: KIỂM THỬ CLASS HÌNH CHỮ NHẬT ===\n");

            TestReport report = new TestReport("BÀI 4 - CLASS HÌNH CHỮ NHẬT");

            // Test case 1: Tính diện tích hình chữ nhật
            Console.WriteLine("Test 1: Tính diện tích hình chữ nhật");
            Diem d1 = new Diem(0, 4);  // Điểm trên bên trái
            Diem d2 = new Diem(5, 0);  // Điểm dưới bên phải
            HinhChuNhat hcn1 = new HinhChuNhat(d1, d2);
            double dienTich1 = hcn1.TinhDienTich();
            double expected1 = 20.0; // 5 * 4 = 20
            Console.WriteLine($"{hcn1}");
            Console.WriteLine($"Diện tích: {dienTich1}");
            bool pass1 = dienTich1 == expected1;
            Console.WriteLine($"Kỳ vọng: {expected1}, Kết quả: {(pass1 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 1: Diện tích 5x4", "HCN (0,4)-(5,0)", expected1.ToString(), dienTich1.ToString(), pass1);

            // Test case 2: Tính diện tích hình vuông
            Console.WriteLine("Test 2: Tính diện tích hình vuông (3x3)");
            Diem d3 = new Diem(1, 4);  // Điểm trên bên trái
            Diem d4 = new Diem(4, 1);  // Điểm dưới bên phải
            HinhChuNhat hcn2 = new HinhChuNhat(d3, d4);
            double dienTich2 = hcn2.TinhDienTich();
            double expected2 = 9.0; // 3 * 3 = 9
            Console.WriteLine($"{hcn2}");
            Console.WriteLine($"Diện tích: {dienTich2}");
            bool pass2 = dienTich2 == expected2;
            Console.WriteLine($"Kỳ vọng: {expected2}, Kết quả: {(pass2 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 2: Hình vuông 3x3", "HCN (1,4)-(4,1)", expected2.ToString(), dienTich2.ToString(), pass2);

            // Test case 3: Hai hình chữ nhật giao nhau
            Console.WriteLine("Test 3: Kiểm tra hai hình chữ nhật giao nhau");
            Diem d5 = new Diem(0, 4);
            Diem d6 = new Diem(5, 0);
            HinhChuNhat hcn3 = new HinhChuNhat(d5, d6);
            
            Diem d7 = new Diem(3, 6);
            Diem d8 = new Diem(7, 2);
            HinhChuNhat hcn4 = new HinhChuNhat(d7, d8);
            
            bool giaoNhau1 = hcn3.KiemTraGiaoNhau(hcn4);
            Console.WriteLine($"HCN 1: {hcn3}");
            Console.WriteLine($"HCN 2: {hcn4}");
            Console.WriteLine($"Có giao nhau: {giaoNhau1}");
            bool pass3 = giaoNhau1 == true;
            Console.WriteLine($"Kỳ vọng: True, Kết quả: {(pass3 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 3: Giao nhau", "HCN1 & HCN2", "True", giaoNhau1.ToString(), pass3);

            // Test case 4: Hai hình chữ nhật không giao nhau (hoàn toàn tách rời)
            Console.WriteLine("Test 4: Kiểm tra hai hình chữ nhật không giao nhau (tách rời)");
            Diem d9 = new Diem(0, 2);
            Diem d10 = new Diem(2, 0);
            HinhChuNhat hcn5 = new HinhChuNhat(d9, d10);
            
            Diem d11 = new Diem(5, 7);
            Diem d12 = new Diem(8, 5);
            HinhChuNhat hcn6 = new HinhChuNhat(d11, d12);
            
            bool giaoNhau2 = hcn5.KiemTraGiaoNhau(hcn6);
            Console.WriteLine($"HCN 1: {hcn5}");
            Console.WriteLine($"HCN 2: {hcn6}");
            Console.WriteLine($"Có giao nhau: {giaoNhau2}");
            bool pass4 = giaoNhau2 == false;
            Console.WriteLine($"Kỳ vọng: False, Kết quả: {(pass4 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 4: Tách rời", "HCN tách rời", "False", giaoNhau2.ToString(), pass4);

            // Test case 5: Hai hình chữ nhật chạm cạnh (không giao nhau thực sự)
            Console.WriteLine("Test 5: Kiểm tra hai hình chữ nhật chạm cạnh");
            Diem d13 = new Diem(0, 3);
            Diem d14 = new Diem(3, 0);
            HinhChuNhat hcn7 = new HinhChuNhat(d13, d14);
            
            Diem d15 = new Diem(3, 3);
            Diem d16 = new Diem(6, 0);
            HinhChuNhat hcn8 = new HinhChuNhat(d15, d16);
            
            bool giaoNhau3 = hcn7.KiemTraGiaoNhau(hcn8);
            Console.WriteLine($"HCN 1: {hcn7}");
            Console.WriteLine($"HCN 2: {hcn8}");
            Console.WriteLine($"Có giao nhau: {giaoNhau3}");
            bool pass5 = giaoNhau3 == false;
            Console.WriteLine($"Kỳ vọng: False, Kết quả: {(pass5 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 5: Chạm cạnh", "HCN chạm cạnh", "False", giaoNhau3.ToString(), pass5);

            // Test case 6: Một hình chữ nhật nằm hoàn toàn trong hình kia
            Console.WriteLine("Test 6: Một hình chữ nhật nằm hoàn toàn trong hình kia");
            Diem d17 = new Diem(0, 10);
            Diem d18 = new Diem(10, 0);
            HinhChuNhat hcn9 = new HinhChuNhat(d17, d18);
            
            Diem d19 = new Diem(2, 6);
            Diem d20 = new Diem(5, 3);
            HinhChuNhat hcn10 = new HinhChuNhat(d19, d20);
            
            bool giaoNhau4 = hcn9.KiemTraGiaoNhau(hcn10);
            Console.WriteLine($"HCN lớn: {hcn9}");
            Console.WriteLine($"HCN nhỏ: {hcn10}");
            Console.WriteLine($"Có giao nhau: {giaoNhau4}");
            bool pass6 = giaoNhau4 == true;
            Console.WriteLine($"Kỳ vọng: True, Kết quả: {(pass6 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 6: Nằm trong", "HCN nhỏ trong HCN lớn", "True", giaoNhau4.ToString(), pass6);

            // Test case 7: Hai hình chữ nhật giống hệt nhau
            Console.WriteLine("Test 7: Hai hình chữ nhật giống hệt nhau");
            Diem d21 = new Diem(1, 5);
            Diem d22 = new Diem(4, 2);
            HinhChuNhat hcn11 = new HinhChuNhat(d21, d22);
            
            Diem d23 = new Diem(1, 5);
            Diem d24 = new Diem(4, 2);
            HinhChuNhat hcn12 = new HinhChuNhat(d23, d24);
            
            bool giaoNhau5 = hcn11.KiemTraGiaoNhau(hcn12);
            Console.WriteLine($"HCN 1: {hcn11}");
            Console.WriteLine($"HCN 2: {hcn12}");
            Console.WriteLine($"Có giao nhau: {giaoNhau5}");
            bool pass7 = giaoNhau5 == true;
            Console.WriteLine($"Kỳ vọng: True, Kết quả: {(pass7 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 7: Trùng nhau", "2 HCN giống hệt", "True", giaoNhau5.ToString(), pass7);

            // Hiển thị tổng kết
            report.HienThiTongQuat();

            // Xuất báo cáo
            Console.WriteLine("\nBạn có muốn xuất báo cáo? (Y/N): ");
            string choice = Console.ReadLine();
            if (choice != null && choice.ToUpper() == "Y")
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                report.XuatBaoCaoCSV($"BaoCao_Bai4_{timestamp}.csv");
                report.XuatBaoCaoText($"BaoCao_Bai4_{timestamp}.txt");
            }
        }

        static void TestBai5()
        {
            Console.Clear();
            Console.WriteLine("=== BÀI 5: KIỂM THỬ QUẢN LÝ HỌC VIÊN ===\n");

            TestReport report = new TestReport("BÀI 5 - QUẢN LÝ HỌC VIÊN");
            TrungTamGiaSu trungTam = new TrungTamGiaSu();

            // Tạo danh sách học viên
            HocVien hv1 = new HocVien("HV001", "Nguyễn Văn A", "Hà Nội", new List<double> { 8.5, 9.0, 8.0 });
            HocVien hv2 = new HocVien("HV002", "Trần Thị B", "Hồ Chí Minh", new List<double> { 7.0, 6.5, 7.5 });
            HocVien hv3 = new HocVien("HV003", "Lê Văn C", "Đà Nẵng", new List<double> { 9.0, 8.5, 9.5 });
            HocVien hv4 = new HocVien("HV004", "Phạm Thị D", "Huế", new List<double> { 8.0, 4.5, 7.0 });
            HocVien hv5 = new HocVien("HV005", "Hoàng Văn E", "Cần Thơ", new List<double> { 8.2, 8.8, 8.5 });
            HocVien hv6 = new HocVien("HV006", "Vũ Thị F", "Hải Phòng", new List<double> { 6.0, 7.0, 6.5 });

            trungTam.ThemHocVien(hv1);
            trungTam.ThemHocVien(hv2);
            trungTam.ThemHocVien(hv3);
            trungTam.ThemHocVien(hv4);
            trungTam.ThemHocVien(hv5);
            trungTam.ThemHocVien(hv6);

            // Test case 1: Hiển thị danh sách tất cả học viên
            Console.WriteLine("Test 1: Hiển thị danh sách tất cả học viên");
            List<HocVien> danhSach = trungTam.LayDanhSachHocVien();
            Console.WriteLine($"Tổng số học viên: {danhSach.Count}");
            foreach (HocVien hv in danhSach)
            {
                Console.WriteLine($"  {hv}");
            }
            bool pass1 = danhSach.Count == 6;
            Console.WriteLine($"Kết quả: {(pass1 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 1: Số lượng HV", "6 học viên", "6", danhSach.Count.ToString(), pass1);

            // Test case 2: Tính điểm trung bình của học viên
            Console.WriteLine("Test 2: Tính điểm trung bình của học viên HV001");
            double dtb1 = hv1.TinhDiemTrungBinh();
            double expectedDtb1 = (8.5 + 9.0 + 8.0) / 3;
            Console.WriteLine($"Điểm TB của {hv1.HoTen}: {dtb1:F2}");
            bool pass2 = Math.Abs(dtb1 - expectedDtb1) < 0.01;
            Console.WriteLine($"Kỳ vọng: {expectedDtb1:F2}, Kết quả: {(pass2 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 2: Điểm TB HV001", "Điểm [8.5,9.0,8.0]", expectedDtb1.ToString("F2"), dtb1.ToString("F2"), pass2);

            // Test case 3: Kiểm tra học viên đủ điều kiện nhận học bổng (HV001)
            Console.WriteLine("Test 3: Kiểm tra HV001 có đủ điều kiện học bổng");
            bool duDK1 = hv1.DuDieuKienHocBong();
            Console.WriteLine($"{hv1.HoTen} - TB: {hv1.TinhDiemTrungBinh():F2}");
            Console.WriteLine($"Đủ điều kiện: {duDK1}");
            bool pass3 = duDK1 == true;
            Console.WriteLine($"Kỳ vọng: True (TB >= 8.0, không có môn < 5.0), Kết quả: {(pass3 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 3: HV001 đủ ĐK HB", "TB=8.5, min=8.0", "True", duDK1.ToString(), pass3);

            // Test case 4: Kiểm tra học viên KHÔNG đủ điều kiện (TB < 8.0)
            Console.WriteLine("Test 4: Kiểm tra HV002 không đủ điều kiện (TB < 8.0)");
            bool duDK2 = hv2.DuDieuKienHocBong();
            Console.WriteLine($"{hv2.HoTen} - TB: {hv2.TinhDiemTrungBinh():F2}");
            Console.WriteLine($"Đủ điều kiện: {duDK2}");
            bool pass4 = duDK2 == false;
            Console.WriteLine($"Kỳ vọng: False (TB < 8.0), Kết quả: {(pass4 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 4: HV002 không đủ ĐK", "TB=7.0 < 8.0", "False", duDK2.ToString(), pass4);

            // Test case 5: Kiểm tra học viên KHÔNG đủ điều kiện (có môn < 5.0)
            Console.WriteLine("Test 5: Kiểm tra HV004 không đủ điều kiện (có môn 4.5 < 5.0)");
            bool duDK4 = hv4.DuDieuKienHocBong();
            Console.WriteLine($"{hv4.HoTen} - TB: {hv4.TinhDiemTrungBinh():F2}");
            Console.WriteLine($"Đủ điều kiện: {duDK4}");
            bool pass5 = duDK4 == false;
            Console.WriteLine($"Kỳ vọng: False (có môn < 5.0), Kết quả: {(pass5 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 5: HV004 có môn < 5", "Có môn 4.5", "False", duDK4.ToString(), pass5);

            // Test case 6: Kiểm tra học viên đủ điều kiện (HV003)
            Console.WriteLine("Test 6: Kiểm tra HV003 có đủ điều kiện học bổng");
            bool duDK3 = hv3.DuDieuKienHocBong();
            Console.WriteLine($"{hv3.HoTen} - TB: {hv3.TinhDiemTrungBinh():F2}");
            Console.WriteLine($"Đủ điều kiện: {duDK3}");
            bool pass6 = duDK3 == true;
            Console.WriteLine($"Kỳ vọng: True, Kết quả: {(pass6 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 6: HV003 đủ ĐK HB", "TB=9.0, min=8.5", "True", duDK3.ToString(), pass6);

            // Test case 7: Tìm danh sách học viên nhận học bổng
            Console.WriteLine("Test 7: Tìm danh sách học viên đủ điều kiện nhận học bổng");
            List<HocVien> dsHocBong = trungTam.TimHocVienNhanHocBong();
            Console.WriteLine($"Số học viên đủ điều kiện: {dsHocBong.Count}");
            foreach (HocVien hv in dsHocBong)
            {
                Console.WriteLine($"  {hv} - Đủ ĐK: {hv.DuDieuKienHocBong()}");
            }
            // HV001, HV003, HV005 đủ điều kiện (TB >= 8.0 và không có môn < 5.0)
            bool pass7 = dsHocBong.Count == 3;
            Console.WriteLine($"Kỳ vọng: 3 học viên, Kết quả: {(pass7 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 7: Tìm HV HB", "Tìm HV đủ ĐK", "3", dsHocBong.Count.ToString(), pass7);

            // Test case 8: Xác định học viên nhận học bổng (method khác)
            Console.WriteLine("Test 8: Xác định học viên nhận học bổng");
            List<HocVien> dsXacDinh = trungTam.XacDinhHocVienNhanHocBong();
            Console.WriteLine($"Số học viên được xác định: {dsXacDinh.Count}");
            bool checkHV001 = false, checkHV003 = false, checkHV005 = false;
            foreach (HocVien hv in dsXacDinh)
            {
                if (hv.MaSo == "HV001") checkHV001 = true;
                if (hv.MaSo == "HV003") checkHV003 = true;
                if (hv.MaSo == "HV005") checkHV005 = true;
            }
            bool allFound = checkHV001 && checkHV003 && checkHV005 && dsXacDinh.Count == 3;
            bool pass8 = allFound;
            Console.WriteLine($"Kỳ vọng: HV001, HV003, HV005, Kết quả: {(pass8 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 8: Xác định HV HB", "3 HV cụ thể", "HV001,HV003,HV005", $"Count={dsXacDinh.Count}", pass8);

            // Test case 9: Kiểm tra học viên có điểm trung bình đúng 8.0
            Console.WriteLine("Test 9: Học viên có TB = 8.0 (HV007: 8.0, 8.0, 8.0 -> TB = 8.0)");
            HocVien hv7 = new HocVien("HV007", "Test G", "Nha Trang", new List<double> { 8.0, 8.0, 8.0 });
            trungTam.ThemHocVien(hv7);
            bool duDK7 = hv7.DuDieuKienHocBong();
            Console.WriteLine($"{hv7.HoTen} - TB: {hv7.TinhDiemTrungBinh():F2}");
            Console.WriteLine($"Đủ điều kiện: {duDK7}");
            bool pass9 = duDK7 == true;
            Console.WriteLine($"Kỳ vọng: True (TB = 8.0 đạt điều kiện), Kết quả: {(pass9 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 9: TB = 8.0 (biên)", "TB=8.0", "True", duDK7.ToString(), pass9);

            // Test case 10: Kiểm tra học viên có môn đúng 5.0
            Console.WriteLine("Test 10: Học viên có môn = 5.0 (biên)");
            HocVien hv8 = new HocVien("HV008", "Test H", "Quy Nhơn", new List<double> { 8.5, 9.0, 5.0 });
            bool duDK8 = hv8.DuDieuKienHocBong();
            Console.WriteLine($"{hv8.HoTen} - TB: {hv8.TinhDiemTrungBinh():F2}");
            Console.WriteLine($"Đủ điều kiện: {duDK8}");
            bool pass10 = duDK8 == true;
            Console.WriteLine($"Kỳ vọng: True (môn = 5.0 được chấp nhận), Kết quả: {(pass10 ? "PASS" : "FAIL")}\n");
            report.ThemTestCase("Test 10: Môn = 5.0 (biên)", "min=5.0", "True", duDK8.ToString(), pass10);

            // Hiển thị tổng kết
            report.HienThiTongQuat();

            // Xuất báo cáo
            Console.WriteLine("\nBạn có muốn xuất báo cáo? (Y/N): ");
            string choice = Console.ReadLine();
            if (choice != null && choice.ToUpper() == "Y")
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                report.XuatBaoCaoCSV($"BaoCao_Bai5_{timestamp}.csv");
                report.XuatBaoCaoText($"BaoCao_Bai5_{timestamp}.txt");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔════════════════════════════════════════╗");
                Console.WriteLine("║        MENU BÀI TẬP BUỔI 4            ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.WriteLine();
                Console.WriteLine("  1. Bài 1 - Hàm Power (Lũy thừa đệ quy)");
                Console.WriteLine("  2. Bài 2 - Class Polynomial (Đa thức)");
                Console.WriteLine("  3. Bài 3 - Class Radix (Chuyển đổi cơ số)");
                Console.WriteLine("  4. Bài 4 - Class HinhChuNhat (Hình chữ nhật)");
                Console.WriteLine("  5. Bài 5 - Quản lý Học viên và Học bổng");
                Console.WriteLine("  0. Thoát");
                Console.WriteLine();
                Console.Write("Chọn bài (0-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        TestBai1();
                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        break;

                    case "2":
                        TestBai2();
                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        break;

                    case "3":
                        TestBai3();
                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        break;

                    case "4":
                        TestBai4();
                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        break;

                    case "5":
                        TestBai5();
                        Console.WriteLine("\nNhấn phím bất kỳ để quay lại menu...");
                        Console.ReadKey();
                        break;

                    case "0":
                        Console.WriteLine("\nTạm biệt!");
                        return;

                    default:
                        Console.WriteLine("\nLựa chọn không hợp lệ! Nhấn phím bất kỳ để thử lại...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
