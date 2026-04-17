package dtm;

import org.openqa.selenium.By;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.*;
import java.time.Duration;

public class LoginTest {
    private WebDriverWait wait;

    @BeforeMethod(alwaysRun = true)
    public void setUp() {
        DriverFactory.initDriver("chrome");
        wait = new WebDriverWait(DriverFactory.getDriver(), Duration.ofSeconds(10));
        DriverFactory.getDriver().get("https://www.saucedemo.com");
    }

    @Test(groups = { "smoke", "regression" }, description = "[smoke] Dang nhap hop le")
    public void testLoginSuccess() {
        DriverFactory.getDriver().findElement(By.id("user-name")).sendKeys("standard_user");
        DriverFactory.getDriver().findElement(By.id("password")).sendKeys("secret_sauce");
        DriverFactory.getDriver().findElement(By.id("login-button")).click();
        wait.until(ExpectedConditions.urlContains("inventory"));
        Assert.assertTrue(DriverFactory.getDriver().getCurrentUrl().contains("inventory.html"),
                "URL phai chua inventory.html!");
    }

    @Test(groups = { "regression" }, description = "[regression] Dang nhap sai mat khau")
    public void testLoginWrongPassword() {
        DriverFactory.getDriver().findElement(By.id("user-name")).sendKeys("standard_user");
        DriverFactory.getDriver().findElement(By.id("password")).sendKeys("wrong_pass");
        DriverFactory.getDriver().findElement(By.id("login-button")).click();
        String err = wait.until(ExpectedConditions.visibilityOfElementLocated(By.cssSelector("[data-test='error']")))
                .getText();
        Assert.assertTrue(err.toLowerCase().contains("username"), "Loi khong dung: " + err);
    }

    @Test(groups = { "regression" }, description = "[regression] Bo trong username")
    public void testLoginEmptyUsername() {
        DriverFactory.getDriver().findElement(By.id("password")).sendKeys("secret_sauce");
        DriverFactory.getDriver().findElement(By.id("login-button")).click();
        String err = wait.until(ExpectedConditions.visibilityOfElementLocated(By.cssSelector("[data-test='error']")))
                .getText();
        Assert.assertTrue(err.contains("Username is required"), "Phai hien Username is required: " + err);
    }

    @Test(groups = { "sanity", "regression" }, description = "[sanity] locked_out_user")
    public void testLoginLockedUser() {
        DriverFactory.getDriver().findElement(By.id("user-name")).sendKeys("locked_out_user");
        DriverFactory.getDriver().findElement(By.id("password")).sendKeys("secret_sauce");
        DriverFactory.getDriver().findElement(By.id("login-button")).click();
        String err = wait.until(ExpectedConditions.visibilityOfElementLocated(By.cssSelector("[data-test='error']")))
                .getText();
        Assert.assertTrue(err.toLowerCase().contains("locked out"), "Phai chua locked out: " + err);
    }

    @AfterMethod(alwaysRun = true)
    public void tearDown() {
        DriverFactory.quitDriver();
    }
}