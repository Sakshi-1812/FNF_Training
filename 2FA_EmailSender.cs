Certainly! Below is a complete implementation of the `EmailSender` class that can be used in your ASP.NET Core application to send emails. This implementation uses the **SendGrid** service for sending emails, but you can adapt it to any other email service provider as needed.

### Step 1: Install SendGrid NuGet Package

If you haven't already, install the SendGrid NuGet package in your project:

```bash
dotnet add package SendGrid
```

### Step 2: Create the EmailSender Class

Create a new class called `EmailSender.cs` in the `Services` folder of your project. Here’s the complete code for the `EmailSender` class:

```csharp
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;

namespace ProjectWebApp.Services
{
    public class EmailSender
    {
        private readonly string _apiKey;

        public EmailSender(IConfiguration configuration)
        {
            // Fetch the SendGrid API key from appsettings.json
            _apiKey = configuration["SendGrid:ApiKey"];
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("your-email@example.com", "Your Name"); // Replace with your sender email and name
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);

            // Optionally handle the response here (e.g., check for success)
            if (!response.IsSuccessStatusCode)
            {
                // Log or throw an exception based on your needs
            }
        }
    }
}
```

### Step 3: Update appsettings.json

Ensure that your `appsettings.json` file contains the SendGrid API key under the `SendGrid` section:

```json
{
  "SendGrid": {
    "ApiKey": "YOUR_SENDGRID_API_KEY" // Replace with your actual SendGrid API key
  },
  // Other settings...
}
```

### Step 4: Register EmailSender in Startup.cs

In your `Startup.cs` file, register the `EmailSender` service in the `ConfigureServices` method:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Other service registrations...

    services.AddTransient<EmailSender>(); // Register EmailSender for dependency injection

    // Other service registrations...
}
```

### Step 5: Using EmailSender in AccountController

Now, you can use the `EmailSender` class in your `AccountController` as follows:

```csharp
public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly EmailSender _emailSender;

    public AccountController(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        EmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = emailSender;
    }

    // Your action methods...
}
```

### Conclusion

With this implementation, the `EmailSender` class is now set up to send emails using SendGrid, and it is properly registered for dependency injection in your ASP.NET Core application. Make sure to replace `"your-email@example.com"` and `"Your Name"` with your actual email address and name, and ensure that your SendGrid API key is correctly set in the `appsettings.json` file.

This should resolve the dependency injection error you encountered earlier. If you have any further questions or issues, feel free to ask!
