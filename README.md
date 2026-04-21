  🎓 Student Management System API

A robust and scalable **ASP.NET Core Web API** for managing student records with secure authentication and clean architecture.

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
🚀 Key Features

✔ 🔐 JWT Authentication & Authorization  
✔ 📚 Full CRUD Operations (Create, Read, Update, Delete)  
✔ 🧱 Layered Architecture (Controller, Service, Repository)  
✔ ⚠️ Global Exception Handling Middleware  
✔ 📄 Swagger API Documentation  
✔ 🗄️ SQL Server Database Integration  

---

🛠️ Tech Stack

- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- JWT Authentication  
- Swagger (OpenAPI)  

---
 📂 Project Structure
Controllers/      → API endpoints
Services/         → Business logic
Repositories/     → Data access layer
Models/           → Entity models
DTOs/             → Data transfer objects
Middleware/       → Global exception handling
Data/             → DbContext

---

 🔐 Authentication Flow

1. User logs in with credentials  
2. Server validates user  
3. JWT token is generated  
4. Token is used to access secured APIs  

---

🔑  Credentials

Use the following credentials to test the API:
Post/api/Auth/login

- Username: admin  
- Password: 123

--------

▶️ How to Run the Project

1. Clone the repository  
2. Open in Visual Studio  
3. Update database
4. Run the project  
5. Open Swagger:
https://localhost:7250/swagger⁠


---

 📌 API Endpoints

| Method | Endpoint              | Description         |
|-------|----------------------|--------------------|
| POST  | /api/Auth/login      | User login         |
| GET   | /api/Student         | Get all students   |
| POST  | /api/Student         | Add student        |
| PUT   | /api/Student/{id}    | Update student     |
| DELETE| /api/Student/{id}    | Delete student     |

---

 💡 Highlights

- Clean and maintainable code structure  
- Industry-standard architecture  
- Secure API using JWT  
- Scalable backend design  

---

👩‍💻 Author

**Hemangi Jangale**  
📧 hemangijangale8110@gmail.com  

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

⭐ Feedback

If you like this project, feel free to ⭐ the repository!
