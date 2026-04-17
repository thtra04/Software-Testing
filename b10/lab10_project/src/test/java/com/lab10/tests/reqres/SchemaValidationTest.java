package com.lab10.tests.reqres;

import com.lab10.base.ApiBaseTest;
import org.testng.annotations.Test;

import static io.restassured.RestAssured.given;
import static io.restassured.module.jsv.JsonSchemaValidator.matchesJsonSchemaInClasspath;

public class SchemaValidationTest extends ApiBaseTest {

    @Test
    public void testUserListSchema() {
        given(requestSpec)
                .queryParam("page", 1)
                .when()
                .get("/users")
                .then()
                .statusCode(200)
                .body(matchesJsonSchemaInClasspath("schemas/user-list-schema.json"));
    }

    @Test
    public void testSingleUserSchema() {
        given(requestSpec)
                .when()
                .get("/users/2")
                .then()
                .statusCode(200)
                .body(matchesJsonSchemaInClasspath("schemas/user-schema.json"));
    }

    @Test
    public void testCreateUserSchema() {
        given(requestSpec)
                .body("{\"name\":\"morpheus\",\"job\":\"leader\"}")
                .when()
                .post("/users")
                .then()
                .statusCode(201)
                .body(matchesJsonSchemaInClasspath("schemas/create-user-schema.json"));
    }
}
