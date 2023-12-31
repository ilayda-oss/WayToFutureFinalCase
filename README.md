# WayToFutureFinalCase
Eczacıbaşı Bilişim Way To Future Staj Programı | .Net Bitirme Ödevi
# WebApi Users Management

Bu proje, WebApi projesinde kullanıcıları yönetmek için kullanılır.

## Kullanım

Kullanıcıların listesini, belirli bir kullanıcıyı veya kullanıcı oluşturmayı, güncellemeyi ve silmeyi sağlayan CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştirmek için aşağıdaki metotları kullanabilirsiniz:

- `GetAllUsers` (GET): Tüm kullanıcıları getirir.
- `GetUserById` (GET): Belirli bir kullanıcıyı ID'ye göre getirir.
- `CreateUser` (POST): Yeni bir kullanıcı oluşturur.
- `UpdateUser` (PUT): Bir kullanıcıyı günceller.
- `DeleteUser` (DELETE): Bir kullanıcıyı siler.
- `GetUsersByName` (GET): İsimlerine göre kullanıcıları getirir.
- `GetUsersSortedByRole` (GET): Rollerine göre kullanıcıları sıralar ve getirir.

Aşağıda örnek kullanımlar gösterilmiştir:

- Tüm kullanıcıları getirmek için:
    ```
    GET /api/users
    ```

- Belirli bir kullanıcıyı ID'ye göre getirmek için:
    ```
    GET /api/users/{id}
    ```

- Yeni bir kullanıcı oluşturmak için:
    ```
    POST /api/users
    ```
    Request Body:
    ```
     {
        Name = "John Doe", 
        Email = "john.doe@example.com",
        Role = "Administrator"
      }
    ```

- Bir kullanıcıyı güncellemek için:
    ```
    PUT /api/users/{id}
    ```
    Request Body:
    ```
    {
        "id": {id},
        "name": "Updated Name",
        "email": "updated.email@example.com"
    }
    ```

- Bir kullanıcıyı silmek için:
    ```
    DELETE /api/users/{id}
    ```

- İsimlerine göre kullanıcıları getirmek için:
    ```
    GET /api/users/list?name={name}
    ```

- Rollere göre sıralanmış kullanıcıları getirmek için:
    ```
    GET /api/users/list/sort
    ```


