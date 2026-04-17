package com.lab10.pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

import java.util.List;

public class CartPage {
    private final WebDriver driver;
    private final By items = By.className("cart_item");

    public CartPage(WebDriver driver) {
        this.driver = driver;
    }

    public int getItemCount() {
        List<?> elements = driver.findElements(items);
        return elements.size();
    }
}
