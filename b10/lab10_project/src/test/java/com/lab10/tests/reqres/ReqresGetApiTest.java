package com.lab10.tests.reqres;

import com.lab10.base.ApiBaseTest;
import org.testng.annotations.Test;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.*;

public class ReqresGetApiTest extends ApiBaseTest {

    @Test
    public void testGetUsersPage1() {
        given(requestSpec)
                .queryParam("page", 1)
                .when()
                .get("/users")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body("page", equalTo(1))
                .body("total_pages", greaterThan(0))
                .body("data.size()", greaterThanOrEqualTo(1));
    }

    @Test
    public void testGetUsersPage2() {
        given(requestSpec)
                .queryParam("page", 2)
                .when()
                .get("/users")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body("page", equalTo(2))
                .body("data.id", everyItem(notNullValue()))
                .body("data.email", everyItem(notNullValue()))
                .body("data.first_name", everyItem(not(isEmptyOrNullString())))
                .body("data.last_name", everyItem(not(isEmptyOrNullString())))
                .body("data.avatar", everyItem(not(isEmptyOrNullString())));
    }

    @Test
    public void testGetUserById3() {
        given(requestSpec)
                .when()
                .get("/users/3")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body("data.id", equalTo(3))
                .body("data.email", endsWith("@reqres.in"))
                .body("data.first_name", not(isEmptyOrNullString()));
    }

    @Test
    public void testGetUserNotFound() {
        given(requestSpec)
                .when()
                .get("/users/9999")
                .then()
                .statusCode(404)
                .body("$", anEmptyMap());
    }
}
