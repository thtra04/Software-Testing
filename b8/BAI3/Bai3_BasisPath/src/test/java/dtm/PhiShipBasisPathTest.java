package dtm;

import org.testng.Assert;
import org.testng.annotations.Test;

public class PhiShipBasisPathTest {

    // ------------------------------------------------------------------
    // Path 1 – D1 = TRUE : trọng lượng không hợp lệ (≤ 0)
    // Kỳ vọng: ném IllegalArgumentException
    // ------------------------------------------------------------------
    @Test(expectedExceptions = IllegalArgumentException.class, description = "Path1: D1=T – trongLuong <= 0 → IllegalArgumentException")
    public void testPath1_TrongLuongKhongHopLe() {
        PhiShip.tinhPhiShip(-1, "noi_thanh", false);
    }

    // ------------------------------------------------------------------
    // Path 2 – D1=F, D2=T, D3=F, D7=F
    // Nội thành, ≤ 5 kg, không phải member
    // phi = 15 000
    // ------------------------------------------------------------------
    @Test(description = "Path2: D1=F D2=T D3=F D7=F – nội thành ≤5 kg, không member → 15000")
    public void testPath2_NoiThanh_NheHon5kg_KhongMember() {
        double result = PhiShip.tinhPhiShip(3, "noi_thanh", false);
        Assert.assertEquals(result, 15_000.0, 0.01);
    }

    // ------------------------------------------------------------------
    // Path 3 – D1=F, D2=T, D3=T, D7=F
    // Nội thành, > 5 kg, không phải member
    // phi = 15 000 + (7-5)*2 000 = 19 000
    // ------------------------------------------------------------------
    @Test(description = "Path3: D1=F D2=T D3=T D7=F – nội thành >5 kg, không member → 19000")
    public void testPath3_NoiThanh_NangHon5kg_KhongMember() {
        double result = PhiShip.tinhPhiShip(7, "noi_thanh", false);
        Assert.assertEquals(result, 19_000.0, 0.01);
    }

    // ------------------------------------------------------------------
    // Path 4 – D1=F, D2=T, D3=F, D7=T
    // Nội thành, ≤ 5 kg, là member (giảm 10%)
    // phi = 15 000 * 0.9 = 13 500
    // ------------------------------------------------------------------
    @Test(description = "Path4: D1=F D2=T D3=F D7=T – nội thành ≤5 kg, là member → 13500")
    public void testPath4_NoiThanh_NheHon5kg_LaMember() {
        double result = PhiShip.tinhPhiShip(3, "noi_thanh", true);
        Assert.assertEquals(result, 13_500.0, 0.01);
    }

    // ------------------------------------------------------------------
    // Path 5 – D1=F, D2=F, D4=T, D5=F, D7=F
    // Ngoại thành, ≤ 3 kg, không phải member
    // phi = 25 000
    // ------------------------------------------------------------------
    @Test(description = "Path5: D1=F D2=F D4=T D5=F D7=F – ngoại thành ≤3 kg, không member → 25000")
    public void testPath5_NgoaiThanh_NheHon3kg_KhongMember() {
        double result = PhiShip.tinhPhiShip(2, "ngoai_thanh", false);
        Assert.assertEquals(result, 25_000.0, 0.01);
    }

    // ------------------------------------------------------------------
    // Path 6 – D1=F, D2=F, D4=T, D5=T, D7=F
    // Ngoại thành, > 3 kg, không phải member
    // phi = 25 000 + (5-3)*3 000 = 31 000
    // ------------------------------------------------------------------
    @Test(description = "Path6: D1=F D2=F D4=T D5=T D7=F – ngoại thành >3 kg, không member → 31000")
    public void testPath6_NgoaiThanh_NangHon3kg_KhongMember() {
        double result = PhiShip.tinhPhiShip(5, "ngoai_thanh", false);
        Assert.assertEquals(result, 31_000.0, 0.01);
    }

    // ------------------------------------------------------------------
    // Path 7 – D1=F, D2=F, D4=F, D6=F, D7=F
    // Tỉnh khác, ≤ 2 kg, không phải member
    // phi = 50 000
    // ------------------------------------------------------------------
    @Test(description = "Path7: D1=F D2=F D4=F D6=F D7=F – tỉnh khác ≤2 kg, không member → 50000")
    public void testPath7_TinhKhac_NheHon2kg_KhongMember() {
        double result = PhiShip.tinhPhiShip(1, "tinh_khac", false);
        Assert.assertEquals(result, 50_000.0, 0.01);
    }

    // ------------------------------------------------------------------
    // Path 8 – D1=F, D2=F, D4=F, D6=T, D7=F
    // Tỉnh khác, > 2 kg, không phải member
    // phi = 50 000 + (4-2)*5 000 = 60 000
    // ------------------------------------------------------------------
    @Test(description = "Path8: D1=F D2=F D4=F D6=T D7=F – tỉnh khác >2 kg, không member → 60000")
    public void testPath8_TinhKhac_NangHon2kg_KhongMember() {
        double result = PhiShip.tinhPhiShip(4, "tinh_khac", false);
        Assert.assertEquals(result, 60_000.0, 0.01);
    }
}
