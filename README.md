# .NET API

Modulbank Homework #3

# База данных на PostgreSQL со сгенерированными тестовыми данными:
![image](https://user-images.githubusercontent.com/40365973/56867781-fedebd80-6a02-11e9-8a69-dc1a8f200c3d.png)

# Получение информации о пользователе
URL: `http://localhost:5000/api/users/id` id - пользователя

Method: `GET`

![image](https://user-images.githubusercontent.com/40365973/56867868-6f3a0e80-6a04-11e9-9170-90290edc0a52.png)

# Добавление пользователя в базу данных

URL: `http://localhost:5000/api/users/append`

Method: `POST`

Headears: `Content-Type :application/json`

Body:
```json
{
	"username" : "Username",
	"city" : "City"
}
```
![image](https://user-images.githubusercontent.com/40365973/56867899-ff785380-6a04-11e9-8904-86195b6d0098.png)
![image](https://user-images.githubusercontent.com/40365973/56867915-32bae280-6a05-11e9-83bc-74aabf050188.png)

# Добавление пользователя методом ленивого ученика

URL: `http://localhost:5000/api/users/lazyappend`

Method: `POST`

Headears: `Content-Type :application/json`

Body:
```json
{
	"username" : "Username",
	"city" : "City"
}
```
![image](https://user-images.githubusercontent.com/40365973/56867942-731a6080-6a05-11e9-8f46-41e59b012aa3.png)
![image](https://user-images.githubusercontent.com/40365973/56867957-95ac7980-6a05-11e9-9659-3743d7b6b7a6.png)
