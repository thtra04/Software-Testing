package com.lab10.tests.reqres;

import com.lab10.base.ApiBaseTest;
import io.qameta.allure.Step;
import org.testng.Assert;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import java.util.HashMap;
import java.util.Map;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.lessThan;
import static org.hamcrest.Matchers.notNullValue;

public class PerformanceAssertionTest extends ApiBaseTest {

    @DataProvider(name = "slaData")
    public Object[][] slaData() {
        return new Object[][]{
                {"GET", "/users", 200, 2000L},
                {"GET", "/users/2", 200, 1500L},
                {"POST", "/users", 201, 3000L},
                {"POST", "/login", 200, 2000L},
                {"DELETE", "/users/2", 204, 1000L}
        };
    }

    @Test(dataProvider = "slaData")
    public void testSlaForEndpoints(String method, String endpoint, int expectedStatus, long maxMs) {
        callApiWithSla(method, endpoint, expectedStatus, maxMs);
    }

    @Step("Gọi {method} {endpoint} - SLA: {maxMs}ms")
    public void callApiWithSla(String method, String endpoint, int expectedStatus, long maxMs) {
        Map<String, Object> body = new HashMap<>();
        body.put("name", "performance-user");
        body.put("job", "tester");
        body.put("email", "eve.holt@reqres.in");
        body.put("password", "cityslicka");

        switch (method) {
            case "GET":
                given(requestSpec).when().get(endpoint).then().statusCode(expectedStatus).time(lessThan(maxMs));
                break;
            case "POST":
                if (endpoint.equals("/login")) {
                    given(requestSpec).body(Map.of("email", "eve.holt@reqres.in", "password", "cityslicka"))
                            .when().post(endpoint).then().statusCode(expectedStatus).time(lessThan(maxMs)).body("token", notNullValue());
                } else {
                    given(requestSpec).body(Map.of("name", "performance-user", "job", "tester"))
                            .when().post(endpoint).then().statusCode(expectedStatus).time(lessThan(maxMs)).body("id", notNullValue());
                }
                break;
            case "DELETE":
                given(requestSpec).when().delete(endpoint).then().statusCode(expectedStatus).time(lessThan(maxMs));
                break;
            default:
                Assert.fail("Method không hỗ trợ: " + method);
        }
    }

    @Test
    public void testAverageMinMaxForUsersEndpoint() {
        long min = Long.MAX_VALUE;
        long max = Long.MIN_VALUE;
        long total = 0L;

        for (int i = 1; i <= 10; i++) {
            long elapsed = given(requestSpec)
                    .when()
                    .get("/users")
                    .time();
            System.out.println("[Run " + i + "] GET /users = " + elapsed + "ms");
            min = Math.min(min, elapsed);
            max = Math.max(max, elapsed);
            total += elapsed;
        }

        long avg = total / 10;
        System.out.println("[Perf] min=" + min + "ms, max=" + max + "ms, avg=" + avg + "ms");
        Assert.assertTrue(avg < 3000, "Average response time vượt SLA 3000ms");
    }
}
