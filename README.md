# MoviesApi

<div align="center">
<img src="https://user-images.githubusercontent.com/118696036/233659231-d8cf7a1e-9fc8-43ac-9eb5-528ecbf868ea.png" />
<img src="https://user-images.githubusercontent.com/118696036/233659252-852a9caf-6e56-481f-9165-dd7a885d800b.png" />
<img src="https://user-images.githubusercontent.com/118696036/233659266-c9a0e329-edf2-4273-97ed-c981bb25cdac.png" />
</div>

#
## 🌐 Status
<p>Finished project ✅</p>

#
## 🧰 Prerequisites

- .NET 6.0 or +

- Connection string to SQLServer in MoviesApi/appsettings.json named as Default

#
## <img src="https://icon-library.com/images/database-icon-png/database-icon-png-13.jpg" width="20" /> Database

_Create a database in SQLServer that contains the table created from the following script:_

```sql
CREATE TABLE [Movies] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(255) NULL,
    [Genre] nvarchar(20) NULL,
    [ReleaseDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Movies] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Stars] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(80) NOT NULL,
    [Surname] nvarchar(80) NOT NULL,
    [Nationality] nvarchar(50) NULL,
    [BirthDate] datetime2 NOT NULL,
    [WonOscar] bit NOT NULL,
    CONSTRAINT [PK_Stars] PRIMARY KEY ([Id])
);
GO
```

#
## 🔧 Installation

`$ git clone https://github.com/lcsmota/MoviesApi.git`

`$ cd MoviesApi/`

`$ dotnet restore`

`$ dotnet run`

**Server listenning at  [https://localhost:7267/swagger](https://localhost:7267/swagger) or [https://localhost:7267/api/v1/Movies](https://localhost:7267/api/v1/Movies) and [https://localhost:7267/api/v1/Stars](https://localhost:7267/api/v1/Stars)**

#
# 📫  Routes for Movies
### Return all objects (Movies)
```http
  GET https://localhost:7267/api/v1/Movies
```
⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/233643804-6e58d265-1840-4d77-9364-09afc48a418e.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/233647424-5d286123-770d-4094-9d26-7c42d73a8c22.png" />

#
### Return only one object (Movie)

```http
  GET https://localhost:7267/api/v1/Movies/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/233643828-f20af306-c368-40cc-a30b-b7ca13b05b7a.png" />
<img src="https://user-images.githubusercontent.com/118696036/233644050-3018fd84-135c-4616-8fe9-561f5a9890b4.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/233647442-4e85e155-d0bf-4c31-9242-151051a00a4b.png" />
<img src="https://user-images.githubusercontent.com/118696036/233647459-a825769d-42e0-435a-85f3-3808b6f53932.png" />

#
### Insert a new object (Movie)

```http
  POST https://localhost:7267/api/v1/Movies
```
📨  **body:**
```json
{
  "title": "Pacific Rim",
  "genre": "Science Fiction",
  "releaseDate": "2013-07-12T13:09:54.105Z"
}
```

🧾  **response:**
```json
{
    "id": 8,
    "title": "Pacific Rim",
    "genre": "Science Fiction",
    "releaseDate": "2013-07-12T13:09:54.105Z"
}
```

⚙️  **Status Code:**
```http
  (201) - Created
  (400) - Bad Request
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/233645391-9b2c4362-9bf6-47b7-99a0-4a6895fd7582.png" />
<img src="https://user-images.githubusercontent.com/118696036/233645622-3907bbd4-5be8-4986-8d24-5cf6e69a8019.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/233648032-76b07c10-7c64-4d36-9900-8bfbcd1271e1.png" />
<img src="https://user-images.githubusercontent.com/118696036/233648047-8690ea53-6f4d-4e99-844c-7e731e86c731.png" />
<img src="https://user-images.githubusercontent.com/118696036/233648062-03dec039-cefa-4afd-a16f-0db813417714.png" />

#
### Update an object (Movie)

```http
  PUT https://localhost:7267/api/v1/Movies/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```json
{
  "id": 8,
  "title": "Pacific Rim",
  "genre": "Science Fiction",
  "releaseDate": "2013-07-12T13:09:54.105Z"
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (400) - Bad Request
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/233646233-f652c117-a663-4f77-b03f-36bd6c870301.png" />
<img src="https://user-images.githubusercontent.com/118696036/233646401-89bb55d6-575b-469c-a5c2-b75de564dc27.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/233648612-666acadb-1098-4c39-aec8-916037ccaff7.png" />
<img src="https://user-images.githubusercontent.com/118696036/233648627-c0ef8dc6-86e9-4d6d-b2b9-c356257cd3f0.png" />
<img src="https://user-images.githubusercontent.com/118696036/233648636-5822cce3-220e-4e83-8c1b-ffc09b008b69.png" />

#
### Delete an object (Movie)
```http
  DELETE https://localhost:7267/api/v1/Movies/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to delete|

📨  **body:**

🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/233646643-c97b96e6-01b8-47b0-96bf-3fd517873df8.png" />
<img src="https://user-images.githubusercontent.com/118696036/233644050-3018fd84-135c-4616-8fe9-561f5a9890b4.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/233648880-87b44669-173d-497f-a193-b52982684c31.png" />
<img src="https://user-images.githubusercontent.com/118696036/233647459-a825769d-42e0-435a-85f3-3808b6f53932.png" />

#
#
# 📫  Routes for Stars
### Return all objects (Stars)
```http
  GET https://localhost:7267/api/v1/Stars
```
⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/233649753-9fad5d47-fcd6-4d93-a9e1-0c3f613ecb1d.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/233656158-91c5f902-6972-4efd-818d-cc0bd7bcd8f0.png" />

#
### Return only one object (Star)

```http
  GET https://localhost:7267/api/v1/Stars/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/233649767-87f5cfb5-d36e-4419-bdd3-7e29f865eee6.png" />
<img src="https://user-images.githubusercontent.com/118696036/233649784-e1087116-dc92-4703-bc80-68d962d6a1bc.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/233656163-b061bed1-3bb0-4b06-b1b0-b0f7b61a0843.png" />
<img src="https://user-images.githubusercontent.com/118696036/233656175-d0ed56b2-a982-4c76-b2dd-b9e241b15c16.png" />

#
### Insert a new object (Star)

```http
  POST https://localhost:7267/api/v1/Stars
```
📨  **body:**
```json
{
  "name": "Charles",
  "surname": "Hunnam",
  "nationality": "English",
  "birthDate": "1980-04-10T13:40:58.735Z",
  "wonOscar": false
}
```

🧾  **response:**
```json
{
    "id": 4,
    "name": "Charles",
    "surname": "Hunnam",
    "nationality": "English",
    "birthDate": "1980-04-10T13:40:58.735Z",
    "wonOscar": false
}
```

⚙️  **Status Code:**
```http
  (201) - Created
  (400) - Bad Request
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/233652243-6fca9c11-632d-45a2-b475-da2c4c09f6f3.png" />
<img src="https://user-images.githubusercontent.com/118696036/233652258-e19dd907-6833-4d78-a049-0a001a6700ab.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/233656653-94e045fc-ee35-41b4-9e92-72ee76cdefa0.png" />
<img src="https://user-images.githubusercontent.com/118696036/233656665-16036358-d24b-4d19-a01b-f425f0c3b6e4.png" />
<img src="https://user-images.githubusercontent.com/118696036/233656671-c75e106e-882c-4971-aeef-f13d9901293e.png" />

#
### Update an object (Star)

```http
  PUT https://localhost:7267/api/v1/Stars/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```json
{
  "id": 4,
  "name": "Charles",
  "surname": "Hunnam",
  "nationality": "English",
  "birthDate": "1980-04-10T13:40:58.735Z",
  "wonOscar": false
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (400) - Bad Request
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/233655428-0bb93c62-ec87-4dbc-a36a-3fd197151127.png" />
<img src="https://user-images.githubusercontent.com/118696036/233655455-9102ef5d-f28e-4cf9-9c66-3312d838b2f7.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/233657275-504ddbc0-7fbd-466d-9157-29243fab2dde.png" />
<img src="https://user-images.githubusercontent.com/118696036/233657291-3e55d196-5712-44b2-8c04-ec123a4c8e13.png" />
<img src="https://user-images.githubusercontent.com/118696036/233657303-afc33666-1072-49d3-ac55-332ea7f70bda.png" />

#
### Delete an object (Star)
```http
  DELETE https://localhost:7267/api/v1/Stars/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to delete|

📨  **body:**

🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/233655741-a284126a-ecf4-4100-90e7-e3ee9c88b770.png" />
<img src="https://user-images.githubusercontent.com/118696036/233649784-e1087116-dc92-4703-bc80-68d962d6a1bc.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/233657559-461ee273-4721-4c71-bf29-f43ead481543.png" />
<img src="https://user-images.githubusercontent.com/118696036/233656175-d0ed56b2-a982-4c76-b2dd-b9e241b15c16.png" />

#
## 🔨 Tools used

<div>
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="80" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="80" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg" width=80/>
</div>

# 🖥️ Technologies and practices used
- [x] C# 10
- [x] .NET CORE 6
- [x] SQL SERVER
- [x] Entity Framework 7
- [x] Code First
- [x] Swagger
- [x] Fluent Validation
- [x] Repository Pattern
- [x] Unit Of Work Pattern
- [x] Dependency injection
- [x] POO

# 📖 Features
Registration, Listing, Update and Removal
