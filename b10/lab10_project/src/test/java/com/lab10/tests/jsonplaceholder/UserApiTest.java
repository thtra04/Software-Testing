package com.lab10.tests.jsonplaceholder;

import org.testng.annotations.Test;

import static io.restassured.RestAssured.given;
import static io.restassured.module.jsv.JsonSchemaValidator.matchesJsonSchemaInClasspath;
import static org.hamcrest.Matchers.equalTo;

public class UserApiTest extends JsonPlaceholderBaseTest {

    @Test
    public void testGetAllUsers() {
        given(requestSpec)
                .when()
                .get("/users")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body("size()", equalTo(10));
    }

    @Test
    public void testGetUserByIdAndValidateSchema() {
        given(requestSpec)
                .when()
                .get("/users/1")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body(matchesJsonSchemaInClasspath("schemas/jsonplaceholder-user-schema.json"))
                .body("id", equalTo(1));
    }
}
