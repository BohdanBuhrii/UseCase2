# UseCase2
Integration connectors with 3rd party services or APIs to extend application functionality. The functionality is written using ChatGPT-4.

## 1. Application Description

StripeAPI is a web-based application built on .NET 6.0, designed to interact with Stripe's various services, specifically its balance and balance transaction services. Through its user-friendly endpoints, the application provides users with easy access to account balance details and lists of balance transactions. With robust error handling using middleware, the application ensures seamless communication with the Stripe platform, making financial data retrieval straightforward and efficient.

The application, using modern coding practices, promotes security by using dependency injection and the .NET Secret Manager for sensitive information. By embracing the principles of modularity and separation of concerns, StripeAPI ensures maintainability, scalability, and robustness.

## 2. Running the Application Locally

1. **Prerequisites:**
   - Install [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0).
   - Clone the repository to your local machine.

2. **Set Up Secret Manager:**
   Navigate to the project root directory in the terminal and execute the following command to set your Stripe API key:
   ```bash
   dotnet user-secrets set "Stripe:ApiKey" "YOUR_STRIPE_API_KEY"
   ```

3. **Run the Application:**
   Navigate to the project root directory and run the following command to start the application:
   ```bash
   dotnet run
   ```

## 3. Example URLs

1. **Retrieve Account Balance:**
   Navigate to or use a tool like `curl` or `Postman` to make a GET request:
   ```
   http://localhost:5000/stripe/balance
   ```

2. **List Balance Transactions with Pagination:**
   Navigate to or use a tool like `curl` or `Postman` to make a GET request. You can adjust the `limit` and `startingAfter` parameters as needed:
   ```
   http://localhost:5000/stripe/balance-transactions?limit=10&startingAfter=txn_1J2L1cLbr7Y5X5Xe8i8Xad
   ```

