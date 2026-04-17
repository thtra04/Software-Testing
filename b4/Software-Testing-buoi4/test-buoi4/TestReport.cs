using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_buoi4
{
    public class TestReport
    {
        private List<TestCase> testCases;
        private string baiTap;

        public TestReport(string baiTap)
        {
            this.baiTap = baiTap;
            this.testCases = new List<TestCase>();
        }

        public void ThemTestCase(string testName, string input, string expected, string actual, bool pass)
        {
            testCases.Add(new TestCase
            {
                TestName = testName,
                Input = input,
                Expected = expected,
                Actual = actual,
                Status = pass ? "PASS" : "FAIL",
                ExecutedTime = DateTime.Now
            });
        }

        public void XuatBaoCaoCSV(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Header
                    writer.WriteLine($"BÁO CÁO KI?M TH? - {baiTap}");
                    writer.WriteLine($"Ngày th?c hi?n: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    writer.WriteLine($"T?ng s? test cases: {testCases.Count}");
                    writer.WriteLine($"S? test PASS: {testCases.Count(t => t.Status == "PASS")}");
                    writer.WriteLine($"S? test FAIL: {testCases.Count(t => t.Status == "FAIL")}");
                    writer.WriteLine($"T? l? PASS: {(testCases.Count > 0 ? (testCases.Count(t => t.Status == "PASS") * 100.0 / testCases.Count).ToString("F2") : "0")}%");
                    writer.WriteLine();

                    // Table header
                    writer.WriteLine("STT,Tên Test Case,Input,K?t qu? k? v?ng,K?t qu? th?c t?,Tr?ng thái,Th?i gian th?c hi?n");

                    // Table data
                    for (int i = 0; i < testCases.Count; i++)
                    {
                        var tc = testCases[i];
                        writer.WriteLine($"{i + 1},\"{tc.TestName}\",\"{tc.Input}\",\"{tc.Expected}\",\"{tc.Actual}\",{tc.Status},{tc.ExecutedTime:HH:mm:ss}");
                    }
                }

                Console.WriteLine($"\n? Báo cáo ?ã ???c xu?t ra file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n? L?i khi xu?t báo cáo: {ex.Message}");
            }
        }

        public void XuatBaoCaoText(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("??????????????????????????????????????????????????????????????????");
                    writer.WriteLine($"?  BÁO CÁO KI?M TH? - {baiTap.PadRight(40)} ?");
                    writer.WriteLine("??????????????????????????????????????????????????????????????????");
                    writer.WriteLine();
                    writer.WriteLine($"Ngày th?c hi?n: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                    writer.WriteLine($"T?ng s? test cases: {testCases.Count}");
                    writer.WriteLine($"S? test PASS: {testCases.Count(t => t.Status == "PASS")}");
                    writer.WriteLine($"S? test FAIL: {testCases.Count(t => t.Status == "FAIL")}");
                    writer.WriteLine($"T? l? PASS: {(testCases.Count > 0 ? (testCases.Count(t => t.Status == "PASS") * 100.0 / testCases.Count).ToString("F2") : "0")}%");
                    writer.WriteLine();
                    writer.WriteLine("????????????????????????????????????????????????????????????????");
                    writer.WriteLine();

                    for (int i = 0; i < testCases.Count; i++)
                    {
                        var tc = testCases[i];
                        writer.WriteLine($"Test Case #{i + 1}: {tc.TestName}");
                        writer.WriteLine($"  Input:          {tc.Input}");
                        writer.WriteLine($"  K? v?ng:        {tc.Expected}");
                        writer.WriteLine($"  Th?c t?:        {tc.Actual}");
                        writer.WriteLine($"  Tr?ng thái:     {tc.Status}");
                        writer.WriteLine($"  Th?i gian:      {tc.ExecutedTime:HH:mm:ss}");
                        writer.WriteLine();
                    }

                    writer.WriteLine("????????????????????????????????????????????????????????????????");
                    writer.WriteLine($"K?t thúc báo cáo");
                }

                Console.WriteLine($"\n? Báo cáo text ?ã ???c xu?t ra file: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n? L?i khi xu?t báo cáo: {ex.Message}");
            }
        }

        public void HienThiTongQuat()
        {
            Console.WriteLine("\n" + new string('?', 60));
            Console.WriteLine("T?NG K?T KI?M TH?");
            Console.WriteLine(new string('?', 60));
            Console.WriteLine($"T?ng s? test: {testCases.Count}");
            Console.WriteLine($"PASS: {testCases.Count(t => t.Status == "PASS")} | FAIL: {testCases.Count(t => t.Status == "FAIL")}");
            Console.WriteLine($"T? l? PASS: {(testCases.Count > 0 ? (testCases.Count(t => t.Status == "PASS") * 100.0 / testCases.Count).ToString("F2") : "0")}%");
            Console.WriteLine(new string('?', 60));
        }
    }

    public class TestCase
    {
        public string TestName { get; set; }
        public string Input { get; set; }
        public string Expected { get; set; }
        public string Actual { get; set; }
        public string Status { get; set; }
        public DateTime ExecutedTime { get; set; }
    }
}
