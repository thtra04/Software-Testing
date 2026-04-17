package com.lab10.pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class InventoryPage {
    private final WebDriver driver;
    private final By title = By.className("title");
    private final By firstAddButton = By.cssSelector("button.btn_inventory");
    private final By cartBadge = By.className("shopping_cart_badge");
    private final By cartLink = By.className("shopping_cart_link");

    public InventoryPage(WebDriver driver) {
        this.driver = driver;
    }

    public boolean isLoaded() {
        return driver.getCurrentUrl().contains("inventory") && driver.findElement(title).getText().contains("Products");
    }

    public void addFirstItemToCart() {
        driver.findElement(firstAddButton).click();
    }

    public int getCartItemCount() {
        return Integer.parseInt(driver.findElement(cartBadge).getText());
    }

    public CartPage goToCart() {
        driver.findElement(cartLink).click();
        return new CartPage(driver);
    }
}
