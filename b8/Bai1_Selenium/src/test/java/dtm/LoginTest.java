package dtm;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.*;

import java.time.Duration;

public class LoginTest {

    WebDriver driver;
    WebDriverWait wait;

    @BeforeMethod
    public void setUp() {
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver();
        driver.manage().window().maximize();
        wait = new WebDriverWait(driver, Duration.ofSeconds(10));
        driver.get("https://www.saucedemo.com");
    }

    // Hàm tiện ích: điền form và click login
    private void doLogin(String username, String password) {
        if (username != null) {
            driver.findElement(By.id("user-name")).sendKeys(username);
        }
        if (password != null) {
            driver.findElement(By.id("password")).sendKeys(password);
        }
        driver.findElement(By.id("login-button")).click();
    }

    // Hàm tiện ích: lấy text thông báo lỗi (dùng Explicit Wait)
    private String getErrorMessage() {
        WebElement error = wait.until(
                ExpectedConditions.visibilityOfElementLocated(
                        By.cssSelector("[data-test='error']")));
        return error.getText();
    }

    @Test(description = "Dang nhap thanh cong - chuyen huong den /inventory.html")
    public void testLoginSuccess() {
        doLogin("standard_user", "secret_sauce");

        wait.until(ExpectedConditions.urlContains("inventory"));
        String currentUrl = driver.getCurrentUrl();
        Assert.assertTrue(currentUrl.contains("inventory.html"),
                "Sau khi dang nhap thanh cong, URL phai chua 'inventory.html' nhung la: " + currentUrl);
    }

    @Test(description = "Dang nhap sai mat khau - hien thong bao loi")
    public void testLoginWrongPassword() {
        doLogin("standard_user", "wrong_password");

        String errorText = getErrorMessage();
        Assert.assertTrue(errorText.toLowerCase().contains("username and password do not match") ||
                errorText.toLowerCase().contains("username"),
                "Thong bao loi khong dung khi nhap sai mat khau. Thuc te: " + errorText);
    }

    @Test(description = "Bo trong username - hien 'Username is required'")
    public void testLoginEmptyUsername() {
        doLogin(null, "secret_sauce");

        String errorText = getErrorMessage();
        Assert.assertTrue(errorText.contains("Username is required"),
                "Thong bao loi phai la 'Username is required' nhung la: " + errorText);
    }

    @Test(description = "Bo trong password - hien 'Password is required'")
    public void testLoginEmptyPassword() {
        doLogin("standard_user", null);

        String errorText = getErrorMessage();
        Assert.assertTrue(errorText.contains("Password is required"),
                "Thong bao loi phai la 'Password is required' nhung la: " + errorText);
    }

    @Test(description = "Dang nhap bang locked_out_user - hien thong bao bi khoa")
    public void testLoginLockedUser() {
        doLogin("locked_out_user", "secret_sauce");

        String errorText = getErrorMessage();
        Assert.assertTrue(errorText.toLowerCase().contains("sorry, this user has been locked out"),
                "Thong bao loi phai chua 'Sorry, this user has been locked out' nhung la: " + errorText);
    }

    @AfterMethod
    public void tearDown() {
        if (driver != null) {
            driver.quit();
        }
    }
}
