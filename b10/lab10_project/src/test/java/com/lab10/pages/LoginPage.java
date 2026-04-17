package com.lab10.pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class LoginPage {
    private final WebDriver driver;
    private final By userName = By.id("user-name");
    private final By password = By.id("password");
    private final By loginButton = By.id("login-button");

    public LoginPage(WebDriver driver) {
        this.driver = driver;
    }

    public LoginPage open() {
        driver.get("https://www.saucedemo.com/");
        return this;
    }

    public InventoryPage loginAs(String username, String pwd) {
        driver.findElement(userName).sendKeys(username);
        driver.findElement(password).sendKeys(pwd);
        driver.findElement(loginButton).click();
        return new InventoryPage(driver);
    }
}
