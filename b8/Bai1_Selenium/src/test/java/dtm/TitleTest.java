package dtm;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;
import org.testng.Assert;
import org.testng.annotations.*;

public class TitleTest {

    WebDriver driver;

    @BeforeMethod
    public void setUp() {
        WebDriverManager.chromedriver().setup();
        driver = new ChromeDriver();
        driver.manage().window().maximize();
        driver.get("https://www.saucedemo.com");
    }

    @Test(description = "Kiem thu tieu de trang chu")
    public void testTitle() {
        String expectedTitle = "Swag Labs";
        String actualTitle = driver.getTitle();
        Assert.assertEquals(actualTitle, expectedTitle, "Tieu de trang khong dung!");
    }

    @Test(description = "Kiem thu URL trang chu")
    public void testURL() {
        String actualUrl = driver.getCurrentUrl();
        Assert.assertTrue(actualUrl.contains("saucedemo"), "URL khong hop le!");
    }

    @Test(description = "Kiem thu nguon trang (page source)")
    public void testPageSource() {
        String pageSource = driver.getPageSource();
        Assert.assertNotNull(pageSource, "Nguon trang bi null!");
        Assert.assertTrue(pageSource.contains("Swag Labs"),
                "Nguon trang khong chua noi dung mong doi!");
        Assert.assertTrue(pageSource.toLowerCase().contains("<html"),
                "Nguon trang khong phai dinh dang HTML hop le!");
    }

    @Test(description = "Kiem thu form dang nhap co hien thi hay khong")
    public void testLoginFormDisplayed() {
        WebElement usernameField = driver.findElement(By.id("user-name"));
        WebElement passwordField = driver.findElement(By.id("password"));
        WebElement loginButton = driver.findElement(By.id("login-button"));

        Assert.assertTrue(usernameField.isDisplayed(),
                "O nhap ten dang nhap khong hien thi!");
        Assert.assertTrue(passwordField.isDisplayed(),
                "O nhap mat khau khong hien thi!");
        Assert.assertTrue(loginButton.isDisplayed(),
                "Nut dang nhap khong hien thi!");
    }

    @Test(description = "Kiem thu placeholder cua o nhap ten dang nhap")
    public void testUsernamePlaceholder() {
        WebElement usernameField = driver.findElement(By.id("user-name"));
        String placeholder = usernameField.getAttribute("placeholder");
        Assert.assertEquals(placeholder, "Username",
                "Placeholder o ten dang nhap khong dung!");
    }

    @Test(description = "Kiem thu dang nhap sai hien thong bao loi")
    public void testLoginWithWrongCredentials() {
        driver.findElement(By.id("user-name")).sendKeys("wrong_user");
        driver.findElement(By.id("password")).sendKeys("wrong_pass");
        driver.findElement(By.id("login-button")).click();

        WebElement errorMessage = driver.findElement(
                By.cssSelector("[data-test='error']"));
        Assert.assertTrue(errorMessage.isDisplayed(),
                "Thong bao loi khong hien thi khi dang nhap sai!");
        Assert.assertTrue(errorMessage.getText().toLowerCase().contains("username"),
                "Noi dung thong bao loi khong dung!");
    }

    @Test(description = "Kiem thu dang nhap thanh cong chuyen huong trang")
    public void testLoginSuccessRedirect() {
        driver.findElement(By.id("user-name")).sendKeys("standard_user");
        driver.findElement(By.id("password")).sendKeys("secret_sauce");
        driver.findElement(By.id("login-button")).click();

        String currentUrl = driver.getCurrentUrl();
        Assert.assertTrue(currentUrl.contains("inventory"),
                "Sau khi dang nhap khong chuyen den trang inventory!");
    }

    @AfterMethod
    public void tearDown() {
        driver.quit();
    }
}
