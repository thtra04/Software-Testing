package dtm;

import org.openqa.selenium.By;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.*;
import java.time.Duration;

public class CheckoutTest {
    private WebDriverWait wait;

    @BeforeMethod(alwaysRun = true)
    public void setUp() {
        DriverFactory.initDriver("chrome");
        wait = new WebDriverWait(DriverFactory.getDriver(), Duration.ofSeconds(15));
        DriverFactory.getDriver().get("https://www.saucedemo.com");
        DriverFactory.getDriver().findElement(By.id("user-name")).sendKeys("standard_user");
        DriverFactory.getDriver().findElement(By.id("password")).sendKeys("secret_sauce");
        DriverFactory.getDriver().findElement(By.id("login-button")).click();
        wait.until(ExpectedConditions.urlContains("inventory"));
        DriverFactory.getDriver().findElement(By.cssSelector(".inventory_item button")).click();
        DriverFactory.getDriver().findElement(By.className("shopping_cart_link")).click();
        wait.until(ExpectedConditions.urlContains("cart"));
    }

    @Test(groups = { "smoke", "regression" }, description = "[smoke] Click Checkout - den checkout-step-one")
    public void testCheckoutButtonNavigates() {
        wait.until(ExpectedConditions.elementToBeClickable(By.id("checkout"))).click();
        wait.until(ExpectedConditions.urlContains("checkout-step-one"));
        Assert.assertTrue(DriverFactory.getDriver().getCurrentUrl().contains("checkout-step-one"),
                "Phai chuyen den checkout-step-one!");
    }

    @Test(groups = { "regression" }, description = "[regression] Dien thong tin - den buoc 2")
    public void testFillCustomerInfo() {
        wait.until(ExpectedConditions.elementToBeClickable(By.id("checkout"))).click();
        wait.until(ExpectedConditions.elementToBeClickable(By.id("first-name"))).sendKeys("Nguyen");
        wait.until(ExpectedConditions.elementToBeClickable(By.id("last-name"))).sendKeys("Van A");
        wait.until(ExpectedConditions.elementToBeClickable(By.id("postal-code"))).sendKeys("70000");
        wait.until(ExpectedConditions.elementToBeClickable(By.id("continue"))).click();
        wait.until(ExpectedConditions.urlContains("checkout-step-two"));
        Assert.assertTrue(DriverFactory.getDriver().getCurrentUrl().contains("checkout-step-two"),
                "Phai den checkout-step-two!");
    }

    @Test(groups = { "regression" }, description = "[regression] Bo trong first name - loi")
    public void testCheckoutEmptyFirstName() {
        wait.until(ExpectedConditions.elementToBeClickable(By.id("checkout"))).click();
        wait.until(ExpectedConditions.elementToBeClickable(By.id("last-name"))).sendKeys("Van A");
        wait.until(ExpectedConditions.elementToBeClickable(By.id("postal-code"))).sendKeys("70000");
        wait.until(ExpectedConditions.elementToBeClickable(By.id("continue"))).click();
        String err = wait.until(ExpectedConditions.visibilityOfElementLocated(
                By.cssSelector("[data-test='error']"))).getText();
        Assert.assertTrue(err.contains("First Name is required"), "Phai hien First Name is required: " + err);
    }

    @Test(groups = { "regression" }, description = "[regression] Hoan tat don hang")
    public void testCompleteOrder() {
        wait.until(ExpectedConditions.elementToBeClickable(By.id("checkout"))).click();
        wait.until(ExpectedConditions.elementToBeClickable(By.id("first-name"))).sendKeys("Nguyen");
        wait.until(ExpectedConditions.elementToBeClickable(By.id("last-name"))).sendKeys("Van A");
        wait.until(ExpectedConditions.elementToBeClickable(By.id("postal-code"))).sendKeys("70000");
        wait.until(ExpectedConditions.elementToBeClickable(By.id("continue"))).click();
        wait.until(ExpectedConditions.urlContains("checkout-step-two"));
        wait.until(ExpectedConditions.elementToBeClickable(By.id("finish"))).click();
        wait.until(ExpectedConditions.urlContains("checkout-complete"));
        String h = wait.until(ExpectedConditions.visibilityOfElementLocated(By.className("complete-header"))).getText();
        Assert.assertEquals(h, "Thank you for your order!", "Tieu de hoan tat khong dung: " + h);
    }

    @AfterMethod(alwaysRun = true)
    public void tearDown() {
        DriverFactory.quitDriver();
    }
}