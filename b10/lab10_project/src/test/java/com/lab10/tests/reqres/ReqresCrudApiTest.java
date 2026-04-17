package com.lab10.tests.reqres;

import com.lab10.base.ApiBaseTest;
import com.lab10.models.CreateUserRequest;
import io.restassured.response.Response;
import org.testng.Assert;
import org.testng.annotations.Test;

import java.util.HashMap;
import java.util.Map;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.*;

public class ReqresCrudApiTest extends ApiBaseTest {

    @Test
    public void testCreateUser() {
        CreateUserRequest request = new CreateUserRequest("Kim Nam Em", "QA Engineer");

        given(requestSpec)
                .body(request)
                .when()
                .post("/users")
                .then()
                .spec(responseSpec)
                .statusCode(201)
                .body("name", equalTo(request.getName()))
                .body("job", equalTo(request.getJob()))
                .body("id", notNullValue())
                .body("createdAt", notNullValue());
    }

    @Test
    public void testPutUser() {
        Map<String, Object> body = new HashMap<>();
        body.put("name", "Kim Nam Em");
        body.put("job", "Senior QA");

        given(requestSpec)
                .body(body)
                .when()
                .put("/users/2")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body("job", equalTo("Senior QA"))
                .body("updatedAt", notNullValue());
    }

    @Test
    public void testPatchUser() {
        Map<String, Object> body = new HashMap<>();
        body.put("job", "Automation Tester");

        given(requestSpec)
                .body(body)
                .when()
                .patch("/users/2")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body("job", equalTo("Automation Tester"))
                .body("updatedAt", notNullValue());
    }

    @Test
    public void testDeleteUser() {
        given(requestSpec)
                .when()
                .delete("/users/2")
                .then()
                .statusCode(204)
                .body(is(emptyOrNullString()));
    }

    @Test
    public void testCreateThenGetConfirmationPattern() {
        CreateUserRequest request = new CreateUserRequest("Temporary User", "Intern");
        Response createResponse = given(requestSpec)
                .body(request)
                .when()
                .post("/users");

        createResponse.then().statusCode(201);
        String createdId = createResponse.jsonPath().getString("id");
        Assert.assertNotNull(createdId, "ID sau khi tạo user không được null");

        given(requestSpec)
                .when()
                .get("/users/2")
                .then()
                .spec(responseSpec)
                .statusCode(200)
                .body("data.id", equalTo(2));
    }
}
