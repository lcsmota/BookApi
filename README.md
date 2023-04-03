# BookApi
<div align="center">
<img src="https://user-images.githubusercontent.com/118696036/229594324-9f8a3e7a-1eac-48ba-ab54-801413fee6cf.png" width="1500px" />
<img src="https://user-images.githubusercontent.com/118696036/229594338-1305fccb-3764-470f-9594-6c82bf7d8c27.png" width="1500px" />
<img src="https://user-images.githubusercontent.com/118696036/229594350-e9d04f96-1c1b-4d19-99cb-78276a9c13bb.png" width="1500px" />
</div>

#
## <img src="https://icon-library.com/images/database-icon-png/database-icon-png-13.jpg" width="20" /> Database

_Create a database in SQLServer that contains the table created from the following script:_

```
CREATE DATABASE [BookApiDapper]

USE [BookApiDapper]

CREATE TABLE [dbo].[Authors](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Name] VARCHAR(60) NOT NULL,
    [Nationality] VARCHAR(50) NULL,
    [Occupation] VARCHAR(70) NOT NULL
);
GO

CREATE TABLE [dbo].[Books](
    [Id] INT PRIMARY KEY IDENTITY(1, 1),
    [Title] VARCHAR(255) NOT NULL,
    [Publisher] VARCHAR(120) NOT NULL,
    [Pages] SMALLINT NOT NULL,
    [ISBN] VARCHAR(14) NOT NULL,
    [PublishedAt] DATETIME NOT NULL,
    [AuthorId] INT NOT NULL,

    CONSTRAINT [FK_Books_Authors] FOREIGN KEY([AuthorId])
        REFERENCES [dbo].[Authors]([Id])
);
GO
```

### Relationships
```
+----------------+          +--------------+
|    Authors     |          |    Books     |
+----------------+          +--------------+
|  Id            |          | Id           |
|  Name          |          | Title        |
|  Nationality   |          | Publisher    |
|  Occupation    |          | Pages        |
|                |          | ISBN         |
|                |<-------->| PublishedAt  |
|                | 1       *| AuthorId     |
+----------------+          +--------------+
```

## 🌐 Status
<p>Finished project ✅</p>

#
## 🧰 Prerequisites

- .NET 6.0 or +

- Connection string to SQLServer in BookApi/appsettings.json named as Default
#
## 🔧 Installation

`$ git clone https://github.com/lcsmota/BookApi.git`

`$ cd BookApi/`

`$ dotnet restore`

`$ dotnet run`

**Server listenning at  [https://localhost:7001/swagger](https://localhost:7001/swagger) or [https://localhost:7001/api/v1/Books](https://localhost:7001/api/v1/Books) and [https://localhost:7250/api/v1/Brands](https://localhost:7250/api/v1/Brands)**
#

# 📫  Routes for Book

### Return all objects (Books)
```http
  GET https://localhost:7001/api/v1/Books
```
⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229597323-1811653f-fa22-4649-968e-1d50d4ab983d.png" />
<img src="https://user-images.githubusercontent.com/118696036/229598758-66633744-9e96-41d8-b278-759016894df2.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229597341-1077465c-3a79-4d4c-aae2-9117305f6e34.png" />
<img src="https://user-images.githubusercontent.com/118696036/229598263-4ea35f9f-9485-4b8b-9f3d-987168a980f7.png" />

#
### Return only one object (Book)

```http
  GET https://localhost:7001/api/v1/Books/${id}
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
<img src="https://user-images.githubusercontent.com/118696036/229598221-ddba0eb8-1803-4e82-9e0d-8fdadcdfe5f4.png" />
<img src="https://user-images.githubusercontent.com/118696036/229598758-66633744-9e96-41d8-b278-759016894df2.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229598236-3beae5b6-b22b-4b6f-bf7c-24800ab3a20b.png" />
<img src="https://user-images.githubusercontent.com/118696036/229598247-a0b0a0f7-c84f-43e6-ad54-a10c7a543ba8.png" />
<img src="https://user-images.githubusercontent.com/118696036/229598263-4ea35f9f-9485-4b8b-9f3d-987168a980f7.png" />

#
### Insert a new object (Book)

```http
  POST https://localhost:7001/api/v1/Books
```
📨  **body:**
```
{
  "title": "Microsoft .Net: Architecting Applications for the Enterprise",
  "publisher": "Microsoft Press; 2nd ed",
  "pages": 394,
  "isbn": "0735685355",
  "publishedAt": "2014-08-18T18:47:02.346Z",
  "authorId": 5
}
```

🧾  **response:**
```
{
  "id": 1006,
  "title": "Microsoft .Net: Architecting Applications for the Enterprise",
  "publisher": "Microsoft Press; 2nd ed.",
  "pages": 394,
  "isbn": "0735685355",
  "publishedAt": "2014-08-18T18:47:02.346Z",
  "authorId": 1005
}
```

⚙️  **Status Code:**
```http
  (201) - Created
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229602155-b0c95054-d5e7-4e74-b2e5-c22054b28576.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229602169-ca3cd10c-4aa4-4482-93cc-259ecc971162.png" />
<img src="https://user-images.githubusercontent.com/118696036/229602176-ae813795-9f08-4ac6-bd18-7f0d967aca30.png" />

#
### Update an object (Book)

```http
  PUT https://localhost:7001/api/v1/Books/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```
{
  "title": "Modern Web Development: Understanding domains, technologies, and user experience",
  "publisher": "Microsoft Press; 1ª ed.",
  "pages": 448,
  "isbn": "978-1509300013",
  "publishedAt": "2016-02-03T18:47:02.346Z",
  "authorId": 1005
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229605674-7f26e999-4d18-4dd6-a1aa-98d3cb7ad95a.png" />
<img src="https://user-images.githubusercontent.com/118696036/229598758-66633744-9e96-41d8-b278-759016894df2.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229605657-8d8d247f-9df0-4966-901d-96851a3393aa.png" />
<img src="https://user-images.githubusercontent.com/118696036/229605668-a6dd7e03-0605-428e-8c43-01dec86c838b.png" />
<img src="https://user-images.githubusercontent.com/118696036/229598263-4ea35f9f-9485-4b8b-9f3d-987168a980f7.png" />

#
### Delete an object (Book)
```http
  DELETE https://localhost:7001/api/v1/Books/${id}
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
<img src="https://user-images.githubusercontent.com/118696036/229606775-f55b188f-6e2a-4017-8597-2f318103b684.png" />
<img src="https://user-images.githubusercontent.com/118696036/229598758-66633744-9e96-41d8-b278-759016894df2.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229606794-e96d142d-fbf6-4a57-8f1d-b9e962789a07.png" />
<img src="https://user-images.githubusercontent.com/118696036/229598263-4ea35f9f-9485-4b8b-9f3d-987168a980f7.png" />

#
#
# 📫  Routes for Author

### Return all objects (Authors)
```http
  GET https://localhost:7001/api/v1/Authors
```
⚙️  **Status Code:**
```http
  (200) - OK
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229608421-05cf5231-f449-4970-82d8-5f8ab420e618.png" />
<img src="https://user-images.githubusercontent.com/118696036/229609471-6844cec0-86c8-4105-9838-5a183402b2b1.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229608440-20289eda-0db5-4d68-80d0-b40da69d1b87.png" />
<img src="https://user-images.githubusercontent.com/118696036/229609481-b7cefeda-7d3d-4e81-970c-73cecbddabb2.png" />

#
### Return only one object (Author)

```http
  GET https://localhost:7001/api/v1/Authors/${id}
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
<img src="https://user-images.githubusercontent.com/118696036/229609096-e0c680d6-f14a-4adc-9004-deb077a5ade8.png" />
<img src="https://user-images.githubusercontent.com/118696036/229609471-6844cec0-86c8-4105-9838-5a183402b2b1.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229609082-c921dd43-ff2a-42c2-8413-ad118ab0455c.png" />
<img src="https://user-images.githubusercontent.com/118696036/229609481-b7cefeda-7d3d-4e81-970c-73cecbddabb2.png" />

#
### Return author with books

```http
  GET https://localhost:7001/api/v1/Authors/${id}/multipleresults
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to view|

⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229610740-bfb05e44-bf30-46e9-b96a-53fd0b467708.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229610758-57bbf7e7-8388-4ff9-8006-0bcb07397944.png" />
<img src="https://user-images.githubusercontent.com/118696036/229610772-a943a4f7-0fa3-4ab5-85db-7bd68e52d07f.png" />

#
### Return all authors with books

```http
  GET https://localhost:7001/api/v1/Authors/multiplemapping
```

⚙️  **Status Code:**
```http
  (200) - OK
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229611669-9bcd224c-d1d8-40d3-b471-113c948cda6b.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229611962-d4fff6dd-450e-4877-b238-c6f720e18b14.png" />

#
### Insert a new object (Author)

```http
  POST https://localhost:7001/api/v1/Authors
```
📨  **body:**
```
{
  "name": "Dino Esposito",
  "nationality": "Italy",
  "occupation": "CTO and long-time trainer"
}
```

🧾  **response:**
```
{
  "id": 1006,
  "name": "Dino Esposito",
  "nationality": "Italy",
  "occupation": "CTO and long-time trainer",
  "books": []
}
```

⚙️  **Status Code:**
```http
  (201) - Created
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229612994-7b5a761c-ea32-4715-8e1f-57c9662e5e34.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229613107-a40716b9-c8ee-4ff0-b83b-a8da0da6f846.png" />
<img src="https://user-images.githubusercontent.com/118696036/229613085-36c49129-1dc6-44a0-bf15-2b2d815f193f.png" />

#
### Update an object (Author)

```http
  PUT https://localhost:7001/api/v1/Authors/${id}
```

| Parameter   | Type       | Description                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Mandatory**. The ID of the object you want to update|

📨  **body:**
```
{
  "name": "Dino Esposito",
  "nationality": "Italy",
  "occupation": "Web, software architecture and digital intelligence"
}
```
🧾  **response:**

⚙️  **Status Code:**
```http
  (204) - No Content
  (404) - Not Found
```

#### 📬  Postman
<img src="https://user-images.githubusercontent.com/118696036/229614341-112c7ab6-65c6-4630-a5e0-a9f0488e987b.png" />
<img src="https://user-images.githubusercontent.com/118696036/229609471-6844cec0-86c8-4105-9838-5a183402b2b1.png" />


#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229614353-a1b93df3-2922-47f9-a694-56fa9626c474.png" />
<img src="https://user-images.githubusercontent.com/118696036/229614360-d87a09cb-b6eb-4c92-94ac-29a94f69f296.png" />
<img src="https://user-images.githubusercontent.com/118696036/229609481-b7cefeda-7d3d-4e81-970c-73cecbddabb2.png" />

#
### Delete an object (Author)
```http
  DELETE https://localhost:7250/api/v1/Brands/${id}
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
<img src="https://user-images.githubusercontent.com/118696036/229615222-c42bbfbb-58d9-443e-9978-76446ce0c9a8.png" />
<img src="https://user-images.githubusercontent.com/118696036/229609471-6844cec0-86c8-4105-9838-5a183402b2b1.png" />

#### 📝  Swagger
<img src="https://user-images.githubusercontent.com/118696036/229615234-e00e08f5-03fc-45cb-a638-bae3d9af5e34.png" />
<img src="https://user-images.githubusercontent.com/118696036/229609481-b7cefeda-7d3d-4e81-970c-73cecbddabb2.png" />

#
## 🔨 Tools used

<div>
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" width="80" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" width="80" />
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-plain-wordmark.svg" width=80/>
</div>

## 🖥️ Technologies and practices used
- [x] C# 10
- [x] .NET CORE 6
- [x] SQL SERVER
- [x] Dapper
- [x] Swagger
- [x] DTOs
- [x] Repository Pattern
- [x] Dependency Injection
- [x] POO

## 📖 Features
Registration, Listing, Update and Removal
