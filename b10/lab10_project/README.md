# LAB 10 - API TESTING VỚI REST ASSURED + TÍCH HỢP UI-API

## Cấu trúc dự án
- `ApiBaseTest`: cấu hình chung cho Reqres API
- `UiBaseTest`: cấu hình Selenium WebDriver
- `ReqresGetApiTest`: bài 1 GET cơ bản
- `ReqresCrudApiTest`: bài 2 CRUD
- `SchemaValidationTest`: bài 3 JSON Schema Validation
- `AuthorizationAndErrorHandlingTest`: bài 4 authorization + data-driven error handling
- `PerformanceAssertionTest`: bài 5 SLA monitoring
- `ApiUiIntegrationTest`: bài 6 tích hợp API + UI với SauceDemo
- `PostApiTest`, `CommentApiTest`, `UserApiTest`: bài 7 JSONPlaceholder

## Cách chạy
```bash
mvn clean test
```

## Sinh Allure report
```bash
mvn clean test
allure serve target/allure-results
```

## Ghi chú
- Project này bám sát yêu cầu bài lab trong file PDF.
- Một số API public như Reqres/JsonPlaceholder có thể thay đổi hành vi nhẹ theo thời điểm chạy.
- Test UI dùng Chrome headless thông qua Selenium + WebDriverManager.
