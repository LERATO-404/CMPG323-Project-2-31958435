# Device Management System

This is an IoT Device Management System API that help keep track of the whereabouts of all IoT devices deployed by the organization.
Each IoT device is initially categorised and registered before being deployed througout the organization building in predefined zones.

Users of the system/API can register as Admin or User. Administrators can view all IOT devices, update their properties,
add new devices and move them to other zones.

After registration the user can log in with the registered username and password. They will then receive a Token
that will enable them to use the API.

# Table of Contents

1. [ Authentication. ](#Authentication)
	1. [Register a User](#User)
	2. [Register an Admin User](#Admin)
	3. [Login a Registered User](#login)
2. [ Category.](#Cat)
	1. [Create a new Category](#PostCat)
	2. [Get all Categories](#GetAllCat)
	3. [Get specific Category](#oneCat)
	4. [Update an exisitin Category](#PatchCat)
	5. [Delete a Category](#deleteCat)
	6. [Retrieve all devices with a Specific category](#GetDevicesCat)
	7. [Return the number of zones in a specific category](#GetZonesCountCat)
3. [ Zones. ](#zone)
	1. [Create a new Zone](#PostZones)
	2. [Get all Zones](#GetAllZones)
	3. [Get specific Zone](#GetOneZone)
	4. [Update an exisitin Zone](#PatchZone)
	5. [Delete a Zone](#deleteZone)
	6. [Retrieve all devices in zone](#getDeviceZone)
4. [ Device. ](#device)
	1. [Create a new Device](#PostDevice)
	2. [Get all devices](#GetAllDevices)
	3. [Get specific Device](#GetOneDevice)
	4. [Update an exisitin Device](#PatchDevice)
	5. [Delete a Device](#deleteDevice)
5.  [Help and Support](#HaS)


<a name="Authentication"></a>      
## 1.Authentication <br>
 * All URLs referenced in registration and login have the following base:
```url
https://device-management-sys-dev.azurewebsites.net/api/authenticate
```
*Parameters*<br>
---
Parameter | Required/Optional | Description | Type
---| ---| ---| ---
{userId} | `Required` | **Refers to the id of the resource** | Integer 
Username | `Required` | **Refers to the name of the user** | String
Email | `Required` | **Refers to the email address of the user** | String
Password | `Required` | **Refers to the password of the user** | Date

<a name="User"></a>
### Register User <br>
`POST: /api/authenticate/register`<br>
#### To register user role account<br>
---

Request body<br>
```json
{
  "username": "Joe",
  "email": "Joe@gmail.com",
  "password": "joe!123Dow"
}
```
*Responses*
Curl
```
curl -X POST "https://device-management-sys-dev.azurewebsites.net/api/authenticate/register" -H  "accept: */*" -H  
"Content-Type: application/json" -d "{\"username\":\"Joe\",\"email\":\"Joe@gmail.com\",\"password\":\"joe!123Dow\"}"
```
<a name="Admin"></a><br>
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/authenticate/register
or<br>
https://device-management-sys-dev.azurewebsites.net/api/authenticate/register-admin
```
*Server Response*<br>

*Code*: `201 Created`<br>

Response body<br>
```json
{
  "status": "Success",
  "message": "User created successfully!"
}
```

*Error Response*<br>

*Condition* : when the email is wrong<br>
*Code* : `400 Bad Request`<br>
Response body
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-b4e8360c5b78534796c13acfcfbac53d-be2018ab34de3d4b-00",
  "errors": {
    "Email": [
      "The Email field is not a valid e-mail address."
    ]
  }
}
```

<a name="login"></a>
### Login<br>
`POST:/api/authenticate/login`<br>
#### Login to get a token<br>
---

Request body<br>
```json
{
  "username": "user2",
  "password": "User2@Pass"
}
```
*Responses*
Curl
```curl 
-X POST "https://device-management-sys-dev.azurewebsites.net/api/authenticate/login" -H  
"accept: */*" -H  "Content-Type: application/json" -d "{\"username\":\"user2\",\"password\":\"User2@Pass\"}"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/authenticate/login
```

*Success Response*<br>

*Code*: `200`<br>

Response body<br>
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlcjIiLCJqdGkiOiI2NzhhOTYwYi05MGMwLTRmMmUtODk3Yi05NTk0ZmYzNWUwM2IiLCJleHAiOjE2NjI1MzU2NjgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.FB6SyHN8SEfgajlLWlA4vzUeGMhkSx2sMwCFXqoWRMY",
  "expiration": "2022-09-07T07:27:48Z"
}
```


Error Response<br>
*Code* : `401 Unauthorized`<br>
Response body
```json
{
  "type": "https://tools.ietf.org/html/rfc7235#section-3.1",
  "title": "Unauthorized",
  "status": 401,
  "traceId": "00-3d1422ec3196984ca7b657e9d42a19d0-836ca5306f8b8e4f-00"
}
```

<a name="Cat"></a>
## 2.Category<br>
 * All URLs referenced in category have the following base:
```url
https://device-management-sys-dev.azurewebsites.net/api/category
```
**Parameters**
Parameter | Required/Optional | Description | Type
---| ---| ---| ---
{Categoryid} | `Required` | **Refers to the id of the resource** | Integer 
CategoryName | `Required` | **Refers to the name of the category** | String
CategoryDescription | `Optional` | **Refers to the description of the category** | String
Date Created | `Required` | **Refers to the date the category was created** | Date

<a name="PostCat"></a>
### Create a category<br>
`POST: /api/category`<br>
#### To create or post a category<br>
---

Request body<br>
```json
{
  "categoryName": "Safety and Security",
  "categoryDescription": "Help protect valuable assets  like employees from getting injured and makes the workplace (building etc) secure from intruders"
}
```
*Responses*
Curl
```
curl -X POST "https://device-management-sys-dev.azurewebsites.net/api/category" -H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlcjIiLCJqdGkiOiI2NjAyMmNlNS1kODA3LTQ0ZjMtODc3Ni1iYzA4OTM3OThjMTIiLCJleHAiOjE2NjI1MzgwMTEsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.68_q6WbZ6l0slAWYGXZw8OLDNRhYRpqIuqWtoaHrnaU" -H  "Content-Type: application/json" -d "{\"categoryName\":\"Safety and Security\",\"categoryDescription\":\"Help protect valuable assets  like employees from getting injured and makes the workplace (building etc) secure from intruders\"}"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/category
```

Sucess Response<br>

*Code* : `200 OK`<br>

Request body<br>
```json
{
  "categoryID": 3,
  "categoryName": "Safety and Security",
  "categoryDescription": "Help protect valuable assets  like employees from getting injured and makes the workplace (building etc) secure from intruders",
  "dateCreated": "2022-09-07T05:21:14.5533333"
}
```

Error Response<br>
*Condition* : <br>
*Code* : ```400 Bad Request```<br>
Response body
```json
```
<a name="GetAllCat"></a>
### Show all categories<br>
`GET :/api/category`<br>
#### To show all the categories<br>
---


*Responses*<br>
Curl
```
curl -X GET "https://device-management-sys-dev.azurewebsites.net/api/category" -H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlcjIiLCJqdGkiOiI2NjAyMmNlNS1kODA3LTQ0ZjMtODc3Ni1iYzA4OTM3OThjMTIiLCJleHAiOjE2NjI1MzgwMTEsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.68_q6WbZ6l0slAWYGXZw8OLDNRhYRpqIuqWtoaHrnaU"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/category
```

Sucess Response<br>

*Code* : `200 OK`<br>

Request body<br>
```json
[
  {
    "categoryID": 1,
    "categoryName": "HVAC (Heating, Ventilation, and Air conditioning) and lighting",
    "categoryDescription": "HVAC systems use sensor technology to adjust the temperature based on the occupancy and environmental factors and lighting also uses sensor technology to based on occupancy and time of the day, weather condition, and seasonal changes",
    "dateCreated": "2022-09-07T05:07:47.92"
  },
  {
    "categoryID": 2,
    "categoryName": "Voice Controllers",
    "categoryDescription": "Voice controllers provide voice-enabled service like making and answering calls, setting alarms, adjusting lights, getting weather updates, scheduling tasks, and managing your daily to-do list",
    "dateCreated": "2022-09-07T05:16:34.47"
  },
  {
    "categoryID": 3,
    "categoryName": "Safety and Security",
    "categoryDescription": "Help protect valuable assets  like employees from getting injured and makes the workplace (building etc) secure from intruders",
    "dateCreated": "2022-09-07T05:21:14.5533333"
  },
  {
    "categoryID": 4,
    "categoryName": "Smart Workplace Furniture",
    "categoryDescription": "Smart workplace furniture optimises people's experience of their physical workspace, making it more comfortable and easier to focus on their objective. From acoustic pods (enable better small-group communication to agile desks (with sit/stand functionality at a touch of a button and more))",
    "dateCreated": "2022-09-07T05:34:59.0766667"
  }
]
```

<a name="oneCat"></a>
### Show a specifc category<br>
`GET :/api/category/{id}`<br>
#### To show all the categoriesbr>
---

*Responses*<br>
Curl
```
curl -X GET "https://device-management-sys-dev.azurewebsites.net/api/category/1" -H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlcjIiLCJqdGkiOiI2NjAyMmNlNS1kODA3LTQ0ZjMtODc3Ni1iYzA4OTM3OThjMTIiLCJleHAiOjE2NjI1MzgwMTEsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.68_q6WbZ6l0slAWYGXZw8OLDNRhYRpqIuqWtoaHrnaU"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/category/1
```

Sucess Response<br>

*Code*: `200 OK`<br>

Response body<br>
```json
{
  "categoryID": 1,
  "categoryName": "HVAC (Heating, Ventilation, and Air conditioning) and lighting",
  "categoryDescription": "HVAC systems use sensor technology to adjust the temperature based on the occupancy and environmental factors and lighting also uses sensor technology to based on occupancy and time of the day, weather condition, and seasonal changes",
  "dateCreated": "2022-09-07T05:07:47.92"
}
```

<a name="deleteCat"></a>
### Delete a category<br>
`DELETE: /api/category/{id}`<br>
#### To remove a category<br>
---

*Responses*<br>
Curl
```
curl -X DELETE "https://device-management-sys-dev.azurewebsites.net/api/category/5" -H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlcjIiLCJqdGkiOiI2NjAyMmNlNS1kODA3LTQ0ZjMtODc3Ni1iYzA4OTM3OThjMTIiLCJleHAiOjE2NjI1MzgwMTEsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.68_q6WbZ6l0slAWYGXZw8OLDNRhYRpqIuqWtoaHrnaU"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/category/5
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```
Category Id: 5 Deleted
```

Error Response
*Responses*<br>
Curl
```
curl -X DELETE "https://device-management-sys-dev.azurewebsites.net/api/category/6" -H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlcjIiLCJqdGkiOiI2NjAyMmNlNS1kODA3LTQ0ZjMtODc3Ni1iYzA4OTM3OThjMTIiLCJleHAiOjE2NjI1MzgwMTEsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.68_q6WbZ6l0slAWYGXZw8OLDNRhYRpqIuqWtoaHrnaU"
```

Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/category/6
```

*Condition* : when the category id does not exist<br>
*Code* : ```404 Not Found```<br>
Response body
```text
Category Id: 6 was not found
```

<a name="PatchCat"></a>
### Update specifc category details<br>
`PATCH: /api/category/{id}`<br>
#### Update details of a category<br>
---

Request body<br>
*Condition*: Updating only category Id = 3 name
```json
{
	"categoryName": "Security",
    "categoryDescription": "Help protect valuable assets  like employees from getting injured and makes the workplace (building etc) secure from intruders" 
}
```

*Responses*<br>
Curl
```
curl -X PATCH "https://device-management-sys-dev.azurewebsites.net/api/category/3" -H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlcjIiLCJqdGkiOiI2NjAyMmNlNS1kODA3LTQ0ZjMtODc3Ni1iYzA4OTM3OThjMTIiLCJleHAiOjE2NjI1MzgwMTEsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.68_q6WbZ6l0slAWYGXZw8OLDNRhYRpqIuqWtoaHrnaU" -H  "Content-Type: application/json" -d "{\"categoryName\":\"Security\",\"categoryDescription\":\"Help protect valuable assets  like employees from getting injured and makes the workplace (building etc) secure from intruders\"}"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/category/3
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```
{
  "categoryID": 3,
  "categoryName": "Security",
  "categoryDescription": "Help protect valuable assets  like employees from getting injured and makes the workplace (building etc) secure from intruders",
  "dateCreated": "0001-01-01T00:00:00"
}
```

Error Response
**Responses**<br>
Curl
```
curl -X PATCH "https://device-management-sys-dev.azurewebsites.net/api/category/10" -H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoidXNlcjIiLCJqdGkiOiI2NjAyMmNlNS1kODA3LTQ0ZjMtODc3Ni1iYzA4OTM3OThjMTIiLCJleHAiOjE2NjI1MzgwMTEsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.68_q6WbZ6l0slAWYGXZw8OLDNRhYRpqIuqWtoaHrnaU" -H  "Content-Type: application/json" -d "{\"categoryName\":\"Security\",\"categoryDescription\":\"Help protect valuable assets  like employees from getting injured and makes the workplace (building etc) secure from intruders\"}"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/category/10
```

*Condition* : when the category id does not exist<br>
*Code*: ```404 Not Found```<br>
Response body
```text
Category Id: 10 was not found
```

<a name="GetDevicesCat"></a>
### Show all the device in a specifc category<br>
`Get: /api/category/{id}/devices`<br>
#### All the devices in the category specified<br><br>
---

Request body<br>
*Condition*: Show all the devices in category Id = 1 HVAC


*Responses*<br>
Curl
```curl
 -X GET "https://device-management-sys-dev.azurewebsites.net/api/category/1/devices"
 -H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJod
 HRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNl
 cjEiLCJqdGkiOiIwZDA1OWYxMi03YTI1LTQ2ZDktYjEwYS05MDBiYTI5N2RjZjkiLCJleHAiOjE2NjI1ODYwMzYsIm
lzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.mgl9GXB49nMD0v_0uiWIj0KDugjdZNvKw0i9ec7476U"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/category/1/devices
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```json
[
  {
    "deviceId": 1,
    "deviveName": "Google Home Voice Controller",
    "status": "Online",
    "isActive": true,
    "categoryID": 1,
    "category": {
      "categoryID": 1,
      "categoryName": "HVAC (Heating, Ventilation, and Air conditioning) and lighting",
      "categoryDescription": "HVAC systems use sensor technology to adjust the temperature based on the occupancy and environmental factors and lighting also uses sensor technology to based on occupancy and time of the day, weather condition, and seasonal changes",
      "dateCreated": "2022-09-07T05:07:47.92"
    },
    "zoneID": 4,
    "zone": null,
    "dateCreated": "2022-09-07T18:44:11.9366667"
  },
  {
    "deviceId": 10,
    "deviveName": "Go light",
    "status": "Offline",
    "isActive": false,
    "categoryID": 1,
    "category": {
      "categoryID": 1,
      "categoryName": "HVAC (Heating, Ventilation, and Air conditioning) and lighting",
      "categoryDescription": "HVAC systems use sensor technology to adjust the temperature based on the occupancy and environmental factors and lighting also uses sensor technology to based on occupancy and time of the day, weather condition, and seasonal changes",
      "dateCreated": "2022-09-07T05:07:47.92"
    },
    "zoneID": 2,
    "zone": null,
    "dateCreated": "2022-09-07T18:57:58.0466667"
  }
]
```

Error Response<br>
*Condition*: Show all the devices in category Id = 6 (There is no category 6)
*Responses*<br>

*Condition* : when the category id does not exist<br>
*Code*: ```404 Not Found```<br>
Response body
```text
Category Id: 6 was not found
```

<a name="GetZonesCountCat"></a>
### Show the number of zones in a specific category<br>
`Get: /api/category/{id}/zones`<br>
#### All the devices in the category specified<br><br>
---

Request body<br>
*Condition*: Show the number of zones in category Id = 3 Security


*Responses*<br>
Curl
```curl 
-X GET "https://device-management-sys-dev.azurewebsites.net/api/category/3/zones" 
-H  "accept: text/plain" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6Ik
pXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9u
YW1lIjoic3lzVXNlcjEiLCJqdGkiOiIwZDA1OWYxMi03YTI1LTQ2ZDktYjEwYS05MDBiYTI5N2RjZjkiLCJleHAiOjE2NjI1ODYwMzYsImlzcyI6Imh0dHB
zOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.mgl9GXB49nMD0v_0uiWIj0KDugjdZNvKw0i9ec7476U"

```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/category/3/zones
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```json
{
	5
}

```

<a name="zone"></a>
## 3.Zones <br>
* All URLs referenced in zones have the following base:
```url
https://device-management-sys-dev.azurewebsites.net/api/Zones
```

*Parameters*<br>
---
Parameter | Required/Optional | Description | Type
---| ---| ---| ---
{Zoneid} | `Required` | **Refers to the id of the resource** | Integer 
ZoneName | `Required` | **Refers to the id of the resource** | String
ZoneDescription | `Optional` | **Refers to the description of the zone** | String
Date Created | `Required` | **Refers to the date the zone was created** | Date 

<a name="PostZones"></a>
### Create a Zone <br>
`POST: /api/zones`<br>
#### To create or post a zone<br>
---

Request body<br>
```json
{
  "zoneName": "Work Area",
  "zoneDescription": "This is the area where most of the employee's time will be spent, fully concentrated on their work"
}
```
*Responses*
Curl
```curl
 -X POST "https://device-management-sys-dev.azurewebsites.net/api/Zones" -H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNlcjEiLCJqdGkiOiJhYjliMjEzZS1iYzFkLTRiMjAtOTAxNi0wMTAxMzYxMzI4OGMiLCJleHAiOjE2NjI1NjkyNDgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4Ly
IsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.yIF9dCyH3iK_cri7zCQ2ApZtnGxcV12COv6G3NxW788   "
 -H  "Content-Type: application/json" -d "{\"zoneName\":\"Work Area\",
 \"zoneDescription\":\"This is the area where most of the employee's time will be spent, fully concentrated on their work\"}"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/Zones
```

*Server Response*<br>

*Code*: `201 Created`<br>

Response body<br>
```json
{
  "zoneID": 1,
  "zoneName": "Work Area",
  "zoneDescription": "This is the area where most of the employee's time will be spent, fully concentrated on their work",
  "dateCreated": "2022-09-07T13:51:21.12"
}
```

Error Response<br>
*Condition* : When the zone is not entered<br>
*Code* : ```400 Bad Request```<br>
Response body
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-a136a17fc3ceb04d857b6730d7b54f12-5a7ad66cbab28349-00",
  "errors": {
    "ZoneName": [
      "The ZoneName field is required."
    ]
  }
}
```
<a name="GetAllZones"></a>
### Show all zones<br>
`GET :/api/zones`<br>
#### To show all the zones<br>
---


*Responses*<br>
Curl
```curl
 -X GET "https://device-management-sys-dev.azurewebsites.net/api/Zones" 
-H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bW
xzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNlcjEiLCJqdGkiOiJhYjliMjEzZS1iYzFkLTRiMjAtOTAxNi0wMT
AxMzYxMzI4OGMiLCJleHAiOjE2NjI1NjkyNDgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0
OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.yIF9dCyH3iK_cri7zCQ2ApZtnGxcV12COv6G3NxW788   "
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/Zones
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```json
[
  {
    "zoneID": 1,
    "zoneName": "Work Area",
    "zoneDescription": "This is the area where most of the employee's time will be spent, fully concentrated on their work",
    "dateCreated": "2022-09-07T13:51:21.12"
  },
  {
    "zoneID": 2,
    "zoneName": "Collaborative Area",
    "zoneDescription": "This is the area where collaboration or less structured meetings are held, to promote innovative or creative ideas in an informal environment",
    "dateCreated": "2022-09-07T13:59:08.34"
  },
  {
    "zoneID": 3,
    "zoneName": "Quiet/Concentration Area",
    "zoneDescription": "This area is made for one person, and differs from a meeting room which is typically larger and can accommodate several people. Employees can work faster, and produce high-quality work, which has a productive value of its own. Quiet spaces give you time to reflect and analyse situations",
    "dateCreated": "2022-09-07T14:07:44.75"
  },
  {
    "zoneID": 4,
    "zoneName": "Meeting Rooms",
    "zoneDescription": "Meeting rooms are the locations in a workplace where multiple people gather in a closed-off area to discuss and share information ",
    "dateCreated": "2022-09-07T14:10:33.8"
  },
  {
    "zoneID": 5,
    "zoneName": "Breakout Area",
    "zoneDescription": "Area for eating, drinking and mingling with co-workers at lunchtime and throughout the day",
    "dateCreated": "2022-09-07T14:15:11.5766667"
  }
]
```
<a name="GetOneZone"></a>
### Show a specifc zone<br>
`GET :/api/zones/{id}`<br>
#### To show only the specified zones<br>
---

*Responses*<br>
Curl
```curl
 -X GET "https://device-management-sys-dev.azurewebsites.net/api/Zones/1" -H  "accept: */*"
 -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy9
 3cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNlcjEiLCJqdGkiOiJhYjliMjEzZS1iYzFkLTRiMjAtOTAxNi0wMTAxMzYxMzI4OG
 MiLCJleHAiOjE2NjI1NjkyNDgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob
3N0OjQ0MzA4LyJ9.yIF9dCyH3iK_cri7zCQ2ApZtnGxcV12COv6G3NxW788   "
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/Zones/1
```

Sucess Response<br>

*Code*: `200 OK`<br>

Response body<br>
```json
{
  "zoneID": 1,
  "zoneName": "Work Area",
  "zoneDescription": "This is the area where most of the employee's time will be spent, fully concentrated on their work",
  "dateCreated": "2022-09-07T13:51:21.12"
}

```
<a name="deleteZone"></a>
### Delete a zone<br>
`DELETE: /api/zones/{id}`<br>
#### To remove a specific zone<br>
---

*Responses*<br>
Curl
```curl
 -X DELETE "https://device-management-sys-dev.azurewebsites.net/api/Zones/6" -H  "accept: */*" 
-H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93
cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNlcjEiLCJqdGkiOiJhYjliMjEzZS1iYzFkLTRiMjAtOTAxNi0wMTAx
MzYxMzI4OGMiLCJleHAiOjE2NjI1NjkyNDgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsIm
F1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.yIF9dCyH3iK_cri7zCQ2ApZtnGxcV12COv6G3NxW788   "
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/Zones/6
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```
Zone Id: 6 Deleted
```

Error Response
*Responses*<br>
Curl
```curl 
-X DELETE "https://device-management-sys-dev.azurewebsites.net/api/Zones/6" -H  "accept: 
*/*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54
bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNlcjEiLCJqdGkiOiJhYjliMjEzZ
S1iYzFkLTRiMjAtOTAxNi0wMTAxMzYxMzI4OGMiLCJleHAiOjE2NjI1NjkyNDgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0
MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.yIF9dCyH3iK_cri7zCQ2ApZtnGxcV12COv6G3NxW788   "
```

Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/Zones/6
```

*Condition* : when the zone id = 6 does not exist<br>
*Code* : ```404 Not Found```<br>
Response body
```text
Zone Id: 6 was not found
```
<a name="PatchZone"></a>
### Update specifc zone details<br>
`PATCH: /api/zones/{id}`<br>
#### Update details of a zone<br><br>
---

Request body<br>
*Condition*: Updating only zone Id = 4 name From Meeting Room to Meeting Area
```json
{
  "zoneName": "Meeting Area",
  "zoneDescription": "Meeting rooms are the locations in a workplace where multiple people gather in a closed-off area to discuss and share information" 
}
```

*Responses*<br>
Curl
```curl 
-X PATCH "https://device-management-sys-dev.azurewebsites.net/api/Zones/4" -H  "accept: */*" -H
"Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1L
zA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNlcjEiLCJqdGkiOiJhYjliMjEzZS1iYzFkLTRiMjAtOTAxNi0wMTAxMzYxMzI4OGMiLCJleH
AiOjE2NjI1NjkyNDgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.yIF9dCyH3iK
_cri7zCQ2ApZtnGxcV12COv6G3NxW788   " -H  "Content-Type: application/json" -d 
"{\"zoneName\":\"Meeting Area\",\"zoneDescription\":\"Meeting rooms are the locations in a workplace where 
multiple people gather in a closed-off area to discuss and share information\"}"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/Zones/4
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```
{
  "zoneID": 4,
  "zoneName": "Meeting Area",
  "zoneDescription": "Meeting rooms are the locations in a workplace where multiple people gather in a closed-off area to discuss and share information",
  "dateCreated": "0001-01-01T00:00:00"
}
```

Error Response
**Responses**<br>
Curl
```curl
 -X PATCH "https://device-management-sys-dev.azurewebsites.net/api/Zones/14" -H  "accept: */*" -H  
"Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lk
ZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNlcjEiLCJqdGkiOiJhYjliMjEzZS1iYzFkLTRiMjAtOTAxNi0wMTAxMzYxMzI4OGMiLCJleHAiOjE2NjI1
NjkyNDgsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.yIF9dCyH3iK_cri7zCQ2
ApZtnGxcV12COv6G3NxW788   " -H  "Content-Type: application/json" -d "{\"zoneName\":\"Meeting Area\",
\"zoneDescription\":\"Meeting rooms are the locations in a workplace where multiple people gather in a 
closed-off area to discuss and share information\"}"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/Zones/14
```

*Condition* : when the zone id does not exist<br>
*Code*: ```404 Not Found```<br>
Response body
```text
Zone Id: 14 was not found
```

<a name="getDeviceZone"></a>
### Show all the device in a specifc zone<br>
`Get: /api/zones/{id}/devices`<br>
#### Update details of a zone<br><br>
---

Request body<br>
*Condition*: Show all the devices in zone Id = 3 Quite Area


*Responses*<br>
Curl
```curl 
-X GET "https://device-management-sys-dev.azurewebsites.net/api/Zones/3/devices" 
-H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodH
RwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNlcjE
iLCJqdGkiOiIwZDA1OWYxMi03YTI1LTQ2ZDktYjEwYS05MDBiYTI5N2RjZjkiLCJleHAiOjE2NjI1ODYwMzYsIml
zcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.mgl9GXB49nMD0v_0uiWIj0KDugjdZNvKw0i9ec7476U"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/Zones/3/devices
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```json
[
  {
    "deviceId": 8,
    "deviveName": "Air Pollution Monitor",
    "status": "Online",
    "isActive": true,
    "categoryID": 1,
    "category": null,
    "zoneID": 3,
    "zone": {
      "zoneID": 3,
      "zoneName": "Quiet/Concentration Area",
      "zoneDescription": "This area is made for one person, and differs from a meeting room which is typically larger and can accommodate several people. Employees can work faster, and produce high-quality work, which has a productive value of its own. Quiet spaces give you time to reflect and analyse situations",
      "dateCreated": "2022-09-07T14:07:44.75"
    },
    "dateCreated": "2022-09-07T18:56:25.9566667"
  },
  {
    "deviceId": 16,
    "deviveName": "Emergency Alert System",
    "status": "online",
    "isActive": false,
    "categoryID": 3,
    "category": null,
    "zoneID": 3,
    "zone": {
      "zoneID": 3,
      "zoneName": "Quiet/Concentration Area",
      "zoneDescription": "This area is made for one person, and differs from a meeting room which is typically larger and can accommodate several people. Employees can work faster, and produce high-quality work, which has a productive value of its own. Quiet spaces give you time to reflect and analyse situations",
      "dateCreated": "2022-09-07T14:07:44.75"
    },
    "dateCreated": "2022-09-07T19:05:11.9"
  }
]
```


Error Response<br>
*Condition*: Show all the devices in zone Id = 3 (There is no zoneid 6)
*Responses*<br>
Curl
```curl
 -X GET "https://device-management-sys-dev.azurewebsites.net/api/Zones/6/devices" 
-H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJod
HRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNl
cjEiLCJqdGkiOiIwZDA1OWYxMi03YTI1LTQ2ZDktYjEwYS05MDBiYTI5N2RjZjkiLCJleHAiOjE2NjI1ODYwMzYsImlzcyI
6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.mgl9GXB49nMD0v_0uiWIj0KDugjdZNvKw0i9ec7476U"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/Zones/6/devices
```

*Condition* : when the zone id does not exist<br>
*Code*: ```404 Not Found```<br>
Response body
```text
Zone Id: 6 was not found
```

<a name="device"></a>
## 4.Device <br>
* All URLs referenced in zones have the following base:
```url
https://device-management-sys-dev.azurewebsites.net/api/device
```

*Parameters*<br>
---
Parameter | Required/Optional | Description | Type
---| ---| ---| ---
{Deviceid} | `Required` | **Refers to the id of the device** | Integer 
DeviceName | `Required` | **Refers to the id of the device** | String
{Categoryid} | `Required` | **Refers to the id of the device** | Integer 
{Zoneid} | `Required` | **Refers to the id of the device** | Integer 
Status | `Optional` | **Refers to the status of the device** | String
IsActive | `Required` | **Refers to the status of the device** | Boolean
Date Created | `Required` | **Refers to the date the zone was created** | Date 

<a name="PostDevice"></a>
## Create a Device <br>
`POST: /api/device`<br>
### To create or post a device<br>
---

Request body<br>
```json
{
  "deviveName": "Google Home Voice Controller",
  "status": "Online",
  "isActive": true,
  "categoryID": 1,
  "zoneID": 4
}
```
*Responses*
Curl
```
curl -X POST "https://device-management-sys-dev.azurewebsites.net/api/device"
 -H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hc
 y54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNlcjEiLCJqdGkiOiIwZDA1OWYxMi03YTI1
 LTQ2ZDktYjEwYS05MDBiYTI5N2RjZjkiLCJleHAiOjE2NjI1ODYwMzYsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1
 ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.mgl9GXB49nMD0v_0uiWIj0KDugjdZNvKw0i9ec7476U" -H  "Content-Type: application/json" -d 
"{\"deviveName\":\"Google Home Voice Controller\",\"status\":\"Online\",\"isActive\":true,\"categoryID\":1,\"zoneID\":4}"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/device
```

*Server Response*<br>

*Code*: `201 Created`<br>

Response body<br>
```json
{
  "deviceId": 1,
  "deviveName": "Google Home Voice Controller",
  "status": "Online",
  "isActive": true,
  "categoryID": 1,
  "category": null,
  "zoneID": 4,
  "zone": null,
  "dateCreated": "2022-09-07T18:44:11.9366667"
}
```
<a name="GetAllDevices"></a>
## Show all devices<br>
`GET :/api/zones`<br>
### To show all the devices<br>
---


*Responses*<br>
Curl
```
curl -X GET "https://device-management-sys-dev.azurewebsites.net/api/device" 
-H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.
eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIj
oic3lzVXNlcjEiLCJqdGkiOiIwZDA1OWYxMi03YTI1LTQ2ZDktYjEwYS05MDBiYTI5N2RjZjkiLCJleHAiOjE2NjI1ODYwMzYsImlzcyI6
Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.mgl9GXB49nMD0v_0uiWIj0KDugjdZNvKw0i9ec7476U"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/device
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```json
[
  {
    "deviceId": 1,
    "deviveName": "Google Home Voice Controller",
    "status": "Online",
    "isActive": true,
    "categoryID": 1,
    "category": null,
    "zoneID": 4,
    "zone": null,
    "dateCreated": "2022-09-07T18:44:11.9366667"
  },
  {
    "deviceId": 4,
    "deviveName": "Amazon Echo Voice Controller",
    "status": "Online",
    "isActive": true,
    "categoryID": 1,
    "category": null,
    "zoneID": 2,
    "zone": null,
    "dateCreated": "2022-09-07T18:50:14.5933333"
  },
  {
    "deviceId": 6,
    "deviveName": "Footbot Air Quality Monitor",
    "status": "Ready to Connect",
    "isActive": false,
    "categoryID": 2,
    "category": null,
    "zoneID": 1,
    "zone": null,
    "dateCreated": "2022-09-07T18:53:24.73"
  }
]
```
<a name="GetOneDevice"></a>
## Show a specifc Device<br>
`GET :/api/device/{id}`<br>
### To show only the specified device<br>
---

*Responses*<br>
Curl
```
curl -X GET "https://device-management-sys-dev.azurewebsites.net/api/device/1" -H  "accept: */*" -H  
"Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93
cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXNlcjEiLCJqdGkiOiIwZDA1OWYxMi03YTI1LTQ2ZDktYjEwYS05
MDBiYTI5N2RjZjkiLCJleHAiOjE2NjI1ODYwMzYsImlzcyI6Imh0dH
BzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.mgl9GXB49nMD0v_0uiWIj0KDugjdZNvKw0i9ec7476U"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/device/1
```

Sucess Response<br>

*Code*: `200 OK`<br>

Response body<br>
```json
{
  "deviceId": 1,
  "deviveName": "Google Home Voice Controller",
  "status": "Online",
  "isActive": true,
  "categoryID": 1,
  "category": null,
  "zoneID": 4,
  "zone": null,
  "dateCreated": "2022-09-07T18:44:11.9366667"
}
```
<a name="deleteDevice"></a>
## Delete a Device<br>
`DELETE: /api/device/{id}`<br>
### To remove a specific device<br>
---

*Responses*<br>
Curl
```
curl -X DELETE "https://device-management-sys-dev.azurewebsites.net/api/device/6" -H  
"accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodH
RwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lzVXN
lcjEiLCJqdGkiOiIwZDA1OWYxMi03YTI1LTQ2ZDktYjEwYS05MDBiYTI5N2RjZjkiLCJleHAiOjE2NjI1ODYwMzYsIml
zcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.mgl9GXB49nMD0v_0uiWIj0KDugjdZNvKw0i9ec7476U"
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/device/6
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```
Device Id: 6 Deleted
```

Error Response
*Responses*<br>
Curl
```
curl -X DELETE "https://device-management-sys-dev.azurewebsites.net/api/device/30" -
H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.ey
JodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoic3lz
VXNlcjEiLCJqdGkiOiIwZDA1OWYxMi03YTI1LTQ2ZDktYjEwYS05MDBiYTI5N2RjZjkiLCJleHAiOjE2NjI1ODYwMzYsImlz
cyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyJ9.mgl9GXB49nMD0v_0uiWIj0KDugjdZNvKw0i9ec7476U"
```

Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/device/30
```

*Condition* : when the zone id does not exist<br>
*Code* : ```404 Not Found```<br>
Response body
```text
Device Id: 30 was not found
```
<a name="PatchDevice"></a>
## Update specifc device details<br>
`PATCH: /api/device/{id}`<br>
### Update details of a device<br>
---

Request body<br>
*Condition*: Updating only device Id = 22 Status
```json
{
  "deviveName": "Smart schedulling room system",
  "status": "Online",
  "isActive": true,
  "categoryID": 4,
  "zoneID": 4
}
```

*Responses*<br>
Curl
```
curl -X PATCH "https://device-management-sys-dev.azurewebsites.net/api/device/22" 
-H  "accept: */*" -H  "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.
eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjo
ic3lzVXNlcjEiLCJqdGkiOiIwZDA1OWYxMi03YTI1LTQ2ZDktYjEwYS05MDBiYTI5N2RjZjkiLCJleHAiOjE2NjI1OD
YwMzYsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4LyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzA4Ly
J9.mgl9GXB49nMD0v_0uiWIj0KDugjdZNvKw0i9ec7476U" -H  "Content-Type: application/json" 
-d "{\"deviveName\":\"Smart schedulling room system\",\"status\":\"Online\",\"isActive\":true,\"categoryID\":4,\"zoneID\":4}
```
Request URL
```url
https://device-management-sys-dev.azurewebsites.net/api/device/22
```

Sucess Response<br>

*Code* : `200 OK`<br>

Response body<br>
```json
{
  "deviceId": 22,
  "deviveName": "Smart schedulling room system",
  "status": "Online",
  "isActive": true,
  "categoryID": 4,
  "category": null,
  "zoneID": 4,
  "zone": null,
  "dateCreated": "0001-01-01T00:00:00"
}
```

<a name="HaS"></a>
## Help and Support<br>
---
 * marijkec
 * JacquiM
	









