Приложение "CalendarPicker"

Использует :

- ASP.NET Core (WebAPI) 3.1
- knockout.js 3.5.1

Что делает :

- с помощью POST-метода WebAPI api/v1/StoredDates/AddDateSelection можно добавлять выбранные даты в файл DateSelection
- с помощью GET-метода WebAPI api/v1/StoredDates/GetDateSelections можно просмотреть, какие даты были добавлены

Как можно потестировать WebAPI:

- в приложение добавлен swaggerUI - https://localhost:5001/swagger/index.html
- добавлен тест CalendarPicker.Tests

Структура приложения :

- CalendarPicker\Controllers\StoredDatesController.cs - WebAPI контроллер
- CalendarPicker\Model\DateSelection.cs - модель данных
- CalendarPicker\Model\DateSelectionRepository.cs - репозиторий для работы с моделью
- CalendarPicker\wwwroot\index.html - веб-страница с календарем

Демонстрация работы : 
https://calendarpicker.azurewebsites.net/
