# 📚 BookStore Management API

A **.NET 6 GraphQL-based backend** for managing authors, books, and users, secured with **JWT authentication** and backed by **PostgreSQL**.  
This project is structured using a **Service–Repository layered architecture** for clean separation of concerns, scalability, and testability.

---

## 🚀 Features

- **GraphQL API** powered by [HotChocolate](https://chillicream.com/docs/hotchocolate)  
- **JWT Authentication & Authorization** for secure access  
- **Entity Framework Core (PostgreSQL)** as ORM and database provider  
- **Layered architecture** with clear separation of responsibilities:
  - `Repositories` — Data access logic
  - `Services` — Business logic and domain rules
  - `GraphQL` — Queries and Mutations layer
- **Automatic EF Migrations** on startup (for development)
- **Extensible** for new entities or features

---

## 🧱 Tech Stack

| Component | Technology |
|------------|-------------|
| **Framework** | .NET 6 |
| **Database** | PostgreSQL |
| **ORM** | Entity Framework Core |
| **API** | GraphQL (HotChocolate) |
| **Authentication** | JWT (JSON Web Tokens) |
| **Migrations** | EF Core Migrations |
| **Language** | C# 10 |

---

## 🗂️ Project Structure

```
BookStoreManagement/
├── AIM.BookStoreManagement.API/        # Main API entry point
│   ├── Program.cs                      # App startup and middleware pipeline
│   ├── appsettings.json                # Configuration
│   └── GraphQL/                        # GraphQL Queries and Mutations
│
├── AIM.BookStoreManagement.DB/         # EF Core DbContext and Migrations
│   └── Context/                        # AppDbContext
│
├── AIM.BookStoreManagement.Application/
│   └── Services/                       # Business logic services
│
├── AIM.BookStoreManagement.Infrastructure/
│   └── Repository/                     # Data access logic (EF repositories)
│
└── AIM.BookStoreManagement.Dto/        # Data transfer objects (DTOs)
```

---

## 🔐 Authentication

All GraphQL **queries** and **mutations** are protected using JWT-based authorization.  
A valid token must be provided in the `Authorization` header:

```
Authorization: Bearer <your-token-here>
```

### 🔑 Test Login Credentials

| Username | Password |
|-----------|-----------|
| `aim_admin` | `Test@321` |

After successful login via the `login` mutation, you’ll receive a JWT token to authorize subsequent requests.

---

## 🧩 GraphQL Endpoints

The GraphQL endpoint is available at:

```
https://localhost:5001/graphql
```

Use tools like **Banana Cake Pop**, **Altair**, or **Postman** to explore the schema.

### Example — Login Mutation

```graphql
mutation {
  login(login: {
    userName: "aim_admin",
    password: "Test@321"
  }) {
    token
    userInfo {
      id
      userName
      role
    }
  }
}
```

### Example — Fetch All Authors

```graphql
query {
  authors {
    id
    name
    books {
      title
      year
    }
  }
}
```

### Example — Add a New Book

```graphql
mutation {
  addBook(input: {
    title: "The Pragmatic Programmer",
    year: 1999,
    pages: 352,
    authorId: "b32fa6d2-58c4-4f3a-8303-6cb70f31f103"
  }) {
    id
    title
    year
    author {
      name
    }
  }
}
```

---

## 🧰 Setup Instructions

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/your-org/BookStoreManagement.git
cd BookStoreManagement
```

### 2️⃣ Configure Environment

Update your connection string in `Program.cs` or as an environment variable:

```bash
setx ConnectionString "Host=localhost;Database=BookStore;Username=postgres;Password=yourpassword"
```

Alternatively, you can update it inside `appsettings.json`.

### 3️⃣ Run the Application

```bash
dotnet run --project AIM.BookStoreManagement.API
```

The app will:
- Apply any pending EF migrations automatically  
- Start the GraphQL server at `https://localhost:5001/graphql`

### 4️⃣ Verify API

Open your browser or a GraphQL client and navigate to:

```
https://localhost:5001/graphql
```

---

## 🧪 Migrations

To create and apply migrations manually:

```bash
dotnet ef migrations add InitialCreate --project AIM.BookStoreManagement.DB
dotnet ef database update --project AIM.BookStoreManagement.DB
```

---

## 🧠 Architecture Overview

```
[GraphQL Layer]
   ↓
[Service Layer]
   ↓
[Repository Layer]
   ↓
[PostgreSQL Database]
```

- **GraphQL Layer:** Handles API queries and mutations, maps requests to service methods.  
- **Service Layer:** Contains core business logic and validation.  
- **Repository Layer:** Interacts with the database through EF Core.  
- **DB Context:** Defines entity relationships and migrations.

---

## ⚙️ Configuration Highlights

- **Automatic migrations** run on startup for development convenience.
- **CORS policy** allows frontend access from development hosts.
- **JWT token validation** is configured via middleware to secure endpoints.
- **Authorization middleware** ensures role- and policy-based access.

---

## 🧾 License

This project is licensed under the **MIT License** — see the [LICENSE](LICENSE) file for details.

---

## 👨‍💻 Contributors

- **Your Name** — Backend Developer  
- **AIM Team** — Architecture & Review  

---

## 📞 Support

For issues or suggestions:
- Open an issue in the GitHub repository  
- Or contact the maintainer: `dev-team@yourdomain.com`

---

> _BookStore Management — built with ❤️ using .NET 6 and GraphQL_
