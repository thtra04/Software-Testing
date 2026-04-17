package dtm;

import org.openqa.selenium.By;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.*;
import java.time.Duration;
import java.util.List;

public class CartTest {
    private WebDriverWait wait;

    @BeforeMethod(alwaysRun = true)
    public void setUp() {
        DriverFactory.initDriver("chrome");
        wait = new WebDriverWait(DriverFactory.getDriver(), Duration.ofSeconds(10));
        DriverFactory.getDriver().get("https://www.saucedemo.com");
        DriverFactory.getDriver().findElement(By.id("user-name")).sendKeys("standard_user");
        DriverFactory.getDriver().findElement(By.id("password")).sendKeys("secret_sauce");
        DriverFactory.getDriver().findElement(By.id("login-button")).click();
        wait.until(ExpectedConditions.urlContains("inventory"));
    }

    @Test(groups = { "smoke", "regression" }, description = "[smoke] Them 1 san pham - badge = 1")
    public void testAddItemToCart() {
        DriverFactory.getDriver().findElement(By.cssSelector(".inventory_item button")).click();
        String badge = wait.until(ExpectedConditions.visibilityOfElementLocated(By.className("shopping_cart_badge")))
                .getText();
        Assert.assertEquals(badge, "1", "Badge phai la 1, thuc te: " + badge);
    }

    @Test(groups = { "regression" }, description = "[regression] Them 2 san pham - badge = 2")
    public void testAddTwoItemsToCart() {
        List<org.openqa.selenium.WebElement> btns = DriverFactory.getDriver()
                .findElements(By.cssSelector(".inventory_item button"));
        btns.get(0).click();
        btns.get(1).click();
        String badge = wait.until(ExpectedConditions.visibilityOfElementLocated(By.className("shopping_cart_badge")))
                .getText();
        Assert.assertEquals(badge, "2", "Badge phai la 2, thuc te: " + badge);
    }

    @Test(groups = { "regression" }, description = "[regression] Trang gio hang hien san pham")
    public void testCartPageShowsItems() {
        DriverFactory.getDriver().findElement(By.cssSelector(".inventory_item button")).click();
        DriverFactory.getDriver().findElement(By.className("shopping_cart_link")).click();
        wait.until(ExpectedConditions.urlContains("cart"));
        int count = DriverFactory.getDriver().findElements(By.className("cart_item")).size();
        Assert.assertTrue(count > 0, "Trang gio hang phai co san pham!");
    }

    @Test(groups = { "regression" }, description = "[regression] Xoa san pham - badge bien mat")
    public void testRemoveItemFromCart() {
        DriverFactory.getDriver().findElement(By.cssSelector(".inventory_item button")).click();
        DriverFactory.getDriver().findElement(By.cssSelector(".inventory_item button")).click();
        boolean hasBadge = !DriverFactory.getDriver().findElements(By.className("shopping_cart_badge")).isEmpty();
        Assert.assertFalse(hasBadge, "Badge phai bien mat sau khi xoa!");
    }

    @AfterMethod(alwaysRun = true)
    public void tearDown() {
        DriverFactory.quitDriver();
    }
}