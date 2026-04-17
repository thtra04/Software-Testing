package com.lab10.tests.reqres;

import com.lab10.base.ApiBaseTest;
import io.restassured.response.ValidatableResponse;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import java.util.HashMap;
import java.util.Map;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.containsString;
import static org.hamcrest.Matchers.not;
import static org.hamcrest.Matchers.emptyOrNullString;

public class AuthorizationAndErrorHandlingTest extends ApiBaseTest {

    @Test
    public void testLoginSuccess() {
        login("eve.holt@reqres.in", "cityslicka")
                .statusCode(200)
                .body("token", not(emptyOrNullString()));
    }

    @Test
    public void testLoginMissingPassword() {
        login("eve.holt@reqres.in", null)
                .statusCode(400)
                .body("error", containsString("Missing password"));
    }

    @Test
    public void testLoginMissingEmail() {
        login(null, "cityslicka")
                .statusCode(400)
                .body("error", containsString("Missing email or username"));
    }

    @Test
    public void testRegisterSuccess() {
        Map<String, String> body = new HashMap<>();
        body.put("email", "eve.holt@reqres.in");
        body.put("password", "pistol");

        given(requestSpec)
                .body(body)
                .when()
                .post("/register")
                .then()
                .statusCode(200)
                .body("id", org.hamcrest.Matchers.notNullValue())
                .body("token", not(emptyOrNullString()));
    }

    @Test
    public void testRegisterMissingPassword() {
        given(requestSpec)
                .body(Map.of("email", "sydney@fife"))
                .when()
                .post("/register")
                .then()
                .statusCode(400)
                .body("error", containsString("Missing password"));
    }

    @DataProvider(name = "loginScenarios")
    public Object[][] loginScenarios() {
        return new Object[][]{
                {"eve.holt@reqres.in", "cityslicka", 200, null},
                {"eve.holt@reqres.in", "", 400, "Missing password"},
                {"", "cityslicka", 400, "Missing email or username"},
                {"notexist@reqres.in", "wrongpass", 400, "user not found"},
                {"invalid-email", "pass123", 400, "user not found"}
        };
    }

    @Test(dataProvider = "loginScenarios")
    public void testLoginScenarios(String email, String password, int expectedStatus, String expectedError) {
        ValidatableResponse response = login(email, password).statusCode(expectedStatus);
        if (expectedError != null) {
            response.body("error", containsString(expectedError));
        }
    }
}
