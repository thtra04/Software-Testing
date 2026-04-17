package com.lab10.base;

import io.restassured.builder.RequestSpecBuilder;
import io.restassured.builder.ResponseSpecBuilder;
import io.restassured.filter.log.RequestLoggingFilter;
import io.restassured.filter.log.ResponseLoggingFilter;
import io.restassured.http.ContentType;
import io.restassured.response.ValidatableResponse;
import io.restassured.specification.RequestSpecification;
import io.restassured.specification.ResponseSpecification;
import org.testng.annotations.BeforeClass;

import java.util.HashMap;
import java.util.Map;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.lessThan;

public class ApiBaseTest {
    protected RequestSpecification requestSpec;
    protected ResponseSpecification responseSpec;

    @BeforeClass(alwaysRun = true)
    public void setupApiSpec() {
        requestSpec = new RequestSpecBuilder()
                .setBaseUri("https://reqres.in")
                .setBasePath("/api")
                .setContentType(ContentType.JSON)
                .addHeader("Accept", "application/json")
                .addFilter(new RequestLoggingFilter())
                .addFilter(new ResponseLoggingFilter())
                .build();

        responseSpec = new ResponseSpecBuilder()
                .expectContentType(ContentType.JSON)
                .expectResponseTime(lessThan(3000L))
                .build();
    }

    protected String getAuthToken() {
        Map<String, String> login = new HashMap<>();
        login.put("email", "eve.holt@reqres.in");
        login.put("password", "cityslicka");

        return given(requestSpec)
                .body(login)
                .when()
                .post("/login")
                .then()
                .statusCode(200)
                .extract()
                .jsonPath()
                .getString("token");
    }


    public RequestSpecification getRequestSpec() {
        return requestSpec;
    }

    public ResponseSpecification getResponseSpec() {
        return responseSpec;
    }
    protected ValidatableResponse login(String email, String password) {
        Map<String, String> body = new HashMap<>();
        if (email != null && !email.isBlank()) {
            body.put("email", email);
        }
        if (password != null && !password.isBlank()) {
            body.put("password", password);
        }

        return given(requestSpec)
                .body(body)
                .when()
                .post("/login")
                .then();
    }
}
