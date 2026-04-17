package com.lab10.tests.jsonplaceholder;

import org.testng.annotations.Test;

import java.util.Map;

import static io.restassured.RestAssured.given;
import static io.restassured.module.jsv.JsonSchemaValidator.matchesJsonSchemaInClasspath;
import static org.hamcrest.Matchers.*;

public class PostApiTest extends JsonPlaceholderBaseTest {

    @Test
    public void testGetAllPosts() {
        given(requestSpec)
                .when()
                .get("/posts")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body("size()", equalTo(100));
    }

    @Test
    public void testGetPostById() {
        given(requestSpec)
                .when()
                .get("/posts/1")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body(matchesJsonSchemaInClasspath("schemas/post-schema.json"))
                .body("id", equalTo(1));
    }

    @Test
    public void testCreatePost() {
        given(requestSpec)
                .body(Map.of("title", "Lab 10 post", "body", "REST Assured practice", "userId", 1))
                .when()
                .post("/posts")
                .then()
                .spec(responseSpec)
                .statusCode(201)
                .body("title", equalTo("Lab 10 post"))
                .body("id", notNullValue());
    }

    @Test
    public void testUpdatePost() {
        given(requestSpec)
                .body(Map.of("id", 1, "title", "Updated title", "body", "Updated body", "userId", 1))
                .when()
                .put("/posts/1")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body("title", equalTo("Updated title"));
    }

    @Test
    public void testDeletePost() {
        given(requestSpec)
                .when()
                .delete("/posts/1")
                .then()
                .statusCode(anyOf(equalTo(200), equalTo(204)));
    }
}
