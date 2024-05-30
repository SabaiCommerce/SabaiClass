Expressjs connect to db

- library | driver - mongoose, nuget + 
- url/uri - connection string - DbContext
- database server - up and running - docker

```sql
CREATE TABLE students (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Gender ENUM('M', 'F') NOT NULL,
    ClassName VARCHAR(255) NOT NULL
);

```