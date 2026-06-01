# 🍕 PizzaApp

Полнофункциональное приложение пиццерии на ASP.NET Core MVC.

## 🚀 Функционал

- 📋 Каталог пиццы с описанием и ценами
- 🛒 Корзина покупок
- 📦 Оформление заказов
- 💾 Хранение заказов в базе данных
- 🎨 Современный интерфейс на Bootstrap 5

## 📋 Требования

- .NET 8.0 SDK
- Visual Studio Code или Visual Studio

## 🛠️ Установка и запуск

```bash
# 1. Клонировать репозиторий
git clone https://github.com/2zazikk/PizzaApp.git
cd PizzaApp

# 2. Восстановить зависимости
dotnet restore

# 3. Создать базу данных
dotnet ef migrations add InitialCreate
dotnet ef database update

# 4. Запустить приложение
dotnet run
```

## 📍 Адрес приложения

Откройте в браузере: `https://localhost:5001`

## 📁 Структура проекта

```
├── Controllers/       # Контроллеры (Home, Pizza, Order)
├── Models/           # Модели данных (Pizza, Order, OrderItem)
├── Services/         # Бизнес-логика (PizzaService)
├── Views/            # Razor шаблоны
├── Program.cs        # Конфигурация приложения
└── appsettings.json # Настройки
```

## 💡 Возможные улучшения

- [ ] Аутентификация и авторизация
- [ ] Админ-панель
- [ ] Интеграция платежей (Stripe)
- [ ] Email уведомления
- [ ] Рейтинг и отзывы

## 📝 Лицензия

MIT
