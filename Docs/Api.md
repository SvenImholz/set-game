# Auth

## Register
```http
POST /api/auth/register
```
### Register Request
```json
{
    "firstName": "Sven",
    "lastName": "Imholz",
    "email": "svenimholz@icloud.com",
    "password": "Test1234!"
}
```

### Register Response
```
200 OK
```
```json
{
    "id": "",
    "firstName": "Sven",
    "lastName": "Imholz",
    "email": "svenimholz@icloud.com",
    "token": ""
}
```

## Login
```http
POST /api/auth/login
```

### Login Request
```json
{
    "email": "svenimholz@icloud.com",
    "password": "Test1234!"
}
```

