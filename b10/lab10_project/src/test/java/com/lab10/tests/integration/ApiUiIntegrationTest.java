package com.lab10.tests.integration;

import com.lab10.base.ApiBaseTest;
import com.lab10.base.UiBaseTest;
import com.lab10.pages.CartPage;
import com.lab10.pages.InventoryPage;
import com.lab10.pages.LoginPage;
import org.testng.Assert;
import org.testng.SkipException;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import static io.restassured.RestAssured.given;

public class ApiUiIntegrationTest extends UiBaseTest {
    private boolean apiReady;
    private String token;

    @BeforeMethod(alwaysRun = true)
    public void apiPrecondition() {
        ApiBaseTest api = new ApiBaseTest();
        api.setupApiSpec();
        try {
            token = given(api.getRequestSpec())
                    .body("{\"email\":\"eve.holt@reqres.in\",\"password\":\"cityslicka\"}")
                    .when()
                    .post("/login")
                    .then()
                    .statusCode(200)
                    .extract()
                    .jsonPath()
                    .getString("token");
            apiReady = token != null && !token.isBlank();
            System.out.println("[API Token] " + token);
        } catch (Exception e) {
            apiReady = false;
        }
    }

    @Test
    public void testLoginUiWhenApiPreconditionPass() {
        if (!apiReady) {
            throw new SkipException("API login fail -> skip UI test");
        }

        LoginPage loginPage = new LoginPage(getDriver()).open();
        InventoryPage inventoryPage = loginPage.loginAs("standard_user", "secret_sauce");

        Assert.assertTrue(getDriver().getCurrentUrl().contains("inventory"));
        Assert.assertEquals(getDriver().getTitle(), "Swag Labs");
        Assert.assertTrue(inventoryPage.isLoaded(), "Trang inventory phải load được");
    }

    @Test
    public void testApiHealthThenCheckoutFlow() {
        ApiBaseTest api = new ApiBaseTest();
        api.setupApiSpec();
        boolean isApiAlive;
        try {
            given(api.getRequestSpec()).when().get("/users").then().statusCode(200);
            isApiAlive = true;
        } catch (Exception e) {
            isApiAlive = false;
        }

        if (!isApiAlive) {
            throw new SkipException("Reqres API không sống -> skip UI flow");
        }

        InventoryPage inventory = new LoginPage(getDriver())
                .open()
                .loginAs("standard_user", "secret_sauce");

        inventory.addFirstItemToCart();
        inventory.addFirstItemToCart();
        Assert.assertTrue(inventory.getCartItemCount() >= 1, "Badge giỏ hàng phải tăng sau khi add sản phẩm");

        CartPage cartPage = inventory.goToCart();
        Assert.assertTrue(cartPage.getItemCount() >= 1, "Giỏ hàng phải có sản phẩm");
    }
}
