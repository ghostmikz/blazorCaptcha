# Blazor + Cloudflare Turnstile (.NET 10)

This is a test implementation of Cloudflare Turnstile integration within a Blazor application.

## 🔐 Security Configuration

This project uses **.NET User Secrets** to manage sensitive API keys. **Do not** hardcode keys in `appsettings.json` or source code.

### Local Setup
To run this project locally, you must add your Cloudflare credentials to your local secret store:

```bash
# Initialize secrets
dotnet user-secrets init

# Add your Cloudflare keys
dotnet user-secrets set "Cloudflare:SiteKey" "0x4AAAAAACLNN4t7ZDjZJiMe"
dotnet user-secrets set "Cloudflare:SecretKey" "0x4AAAAAACLNN-3e7myRsq_Rr4yzDtC-5H8"
```

## 🚀 How it Works
1. **Frontend:** The Blazor component renders the Turnstile widget using the `SiteKey`.
2. **Challenge:** The user completes the "I am not a robot" challenge.
3. **Backend:** The resulting token is sent to the server and verified against Cloudflare's API using the `SecretKey`.

## 🛠️ Tech Stack
* **Framework:** .NET 10 (Blazor)
* **Captcha:** Cloudflare Turnstile
* **Configuration:** Microsoft.Extensions.Configuration (User Secrets)

## 🏗️ Development
Run the application:
```bash
dotnet watch
```
