# 🟢 AWS Rekognition + .NET 8 + SQL Server + Angular 17 Setup Guide (Windows)

This guide explains how to create a free AWS account, configure Rekognition, install required tools, and prepare your Windows environment to run a .NET 8 backend with SQL Server and an Angular 17 frontend.

---

## BACKEND

### ✅ 1. Create a Free AWS Account

1. Visit: [https://aws.amazon.com/free](https://aws.amazon.com/free)
2. Click “Create a Free Account.”
3. Fill in your email, password, and account details.
4. Add billing info (credit/debit card, no charge if using Free Tier).
5. Complete phone/SMS verification.
6. Select Basic Support Plan (Free).
7. Wait for account activation.

---

### ✅ 2. Enable Amazon Rekognition

1. Log in to the AWS Console.
2. Search for **"Rekognition"** and open the service.
3. Select your region (e.g., `us-east-1`).

> **Free Tier:** 5,000 images/month for 12 months.

---

### ✅ 3. Create an IAM User

1. Go to **IAM Console**.
2. Click **Users > Add Users**.
3. Username: `rekognition-user`
4. Enable **Programmatic access**.
5. Attach policy: `AmazonRekognitionFullAccess`
6. Create user and save **Access Key ID** and **Secret Access Key**.

---

### ✅ 4. Install AWS CLI

1. Download from: [https://aws.amazon.com/cli/](https://aws.amazon.com/cli/)
2. Run the installer with default options.
3. Confirm installation:

    ```sh
    aws --version
    ```

---

### ✅ 5. Configure AWS CLI

Open Command Prompt and run:

```sh
aws configure
```

Input your credentials:

- **AWS Access Key ID:** `<your key>`
- **AWS Secret Access Key:** `<your secret>`
- **Default region:** `us-east-1`
- **Default output format:** `json`

---

### ✅ 6. Install .NET 8 SDK

1. Download from: [https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)
2. Select **.NET 8 SDK (64-bit) for Windows**
3. Run the installer
4. Verify installation:

    ```sh
    dotnet --version
    ```

5. Install EF Core CLI tool:

    ```sh
    dotnet tool install --global dotnet-ef
    ```

---

### ✅ 7. Install SQL Server

1. Download SQL Server Developer Edition:  
   [https://www.microsoft.com/en-us/sql-server/sql-server-downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
2. Install with default settings.
3. Also install SQL Server Management Studio (SSMS):  
   [https://aka.ms/ssmsfullsetup](https://aka.ms/ssmsfullsetup)

---

### ✅ 8. Run the Migrations

```sh
dotnet ef database update
```

---

### ✅ 9. Set Up Your Project

- Ensure your .NET 8 backend uses the correct connection string for SQL Server.
- Ensure AWS credentials are available for Rekognition calls.
- Use dependency injection for Rekognition clients and SQL DBContext.

---

## FRONTEND

### 🚀 Running Angular 17 Project on Windows

#### ✅ 1. Install Node.js (v18.x or newer)

Angular 17 requires Node.js version 18.x or 20.x.

1. Download from: [https://nodejs.org](https://nodejs.org)
2. Install the LTS version and keep the default options.
3. After installation, verify:

    ```sh
    node -v
    npm -v
    ```

---

#### ✅ 2. Install Angular CLI

Install Angular CLI globally using npm:

```sh
npm install -g @angular/cli@17
```

Check if it installed correctly:

```sh
ng version
```

---

#### ✅ 3. Install Project Dependencies

Navigate to your Angular project folder:

```sh
cd path/to/your-project
```

Install all dependencies:

```sh
npm install
```

---

#### ✅ 4. Run the Project

Start the development server:

```sh
ng serve
```

The app will be available at:  
[http://localhost:4200](http://localhost:4200)

---

### 📝 Notes

- Make sure you are using Node 18 or later. You can switch versions using [nvm for Windows](https://github.com/coreybutler/nvm-windows) if needed.
- The `package.json` must be correctly configured with Angular 17 dependencies.

---

**POWERED BY [MIKAEL RIBEIRO](https://github.com/mikkaiser) AND [MARCOS SOARES](https://github.com/markimpdl)**