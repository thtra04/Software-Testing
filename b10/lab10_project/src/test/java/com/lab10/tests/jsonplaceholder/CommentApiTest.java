package com.lab10.tests.jsonplaceholder;

import org.testng.annotations.Test;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.*;

public class CommentApiTest extends JsonPlaceholderBaseTest {

    @Test
    public void testGetCommentsForPost1() {
        given(requestSpec)
                .when()
                .get("/posts/1/comments")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body("size()", equalTo(5))
                .body("postId", everyItem(equalTo(1)))
                .body("id", everyItem(notNullValue()))
                .body("name", everyItem(not(isEmptyOrNullString())))
                .body("email", everyItem(containsString("@")))
                .body("body", everyItem(not(isEmptyOrNullString())));
    }
}
