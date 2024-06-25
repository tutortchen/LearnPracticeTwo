# УП Задание 2
### Брусенцева София 3-21 ИСП-6
### Описание приложения:
**Данное приложение - это система для устройства Терминал в виде банкомата для совершения различных денежных операций. Приложение имеет понятный и интуитивный интерфейс, а управление системой происходит путём нажатия соответствующих кнопок на экране.**

# В приложении имеются следующие страницы:
1. **Главное окно (MainWindow)** - на нем содержится объект класса Frame для перемещения по страницам приложения.
2. **Главная страница (MainPage)** - страница, на которой содержатся главные возможности системы, а именно _Оплата услуг_, _Qiwi кошелёк_ и _Поиск_.
3. **Страница с выбором услуги (ServicesPay)** - страница, следующая после главной страницы. Она содержит возможности, связанные конкретно с теми или иными денежными операциями, например _Сотовая связь_, _Денежные переводы_ и т.д.
4. **Страница сотовая связь** - страница, предоставляющая возможность оплатить сотовую связь, введя номер телефона и выбрав нужную сумму для оплаты.
5. **Страница Qiwi кошелёк** - страница, позволяющая зайти в профиль своего Qiwi кошелька.
6. **Страница поиск** - страница, на которой отображаются все услуги, существующие в системе PhonePay. Имеется строка поиска, позволяющая найти необходимую услугу.

# Описание функций приложения:
1. **Оплата сотовой связи.** При необходимости оплаты сотовой связи, можно ввести номер телефона, а так же выбрать сумму для внесения платежа.
2. **Вход в профиль Qiwi кошелька.** Вход в кошелёк осуществляется по номеру телефона.
3. **Поиск необходимой услуги.** На странице поиска можно выбрать из множества услугу, либо воспользоваться строкой поиска, который ищет услугу по содержанию в названии текста, введённого пользователем.

# Технологии, которые были использованы во время разработки приложения:
- **Язык программирования C#** - использован для создания всей логики приложения.
- **Фреймворк Windows Presentation Foundation (WPF)** - использован для создания интерфейса приложения.
- **База данных SQL** - использована для хранения всех услуг, которые отображаются и используются в системе PhonePay.
- **СУБД DB Browser for SQLite** - использована для удобной работы с БД (Создание БД, создание таблицы и заполнение её данными).

# Описание базы данных:
### Файл базы данных называется PhonePay.db <br/>
Файл базы данных расположен локально в проекте по пути **PhonePay/bin/Debug/net8.0-windows** </br>
В базе данных имеется 1 таблица, в которой содержится колонка с названием **Name**. В этой таблице записаны все существующие услуги в системе PhonePay. <br/>
В дальнейшем, все записи отсюда выгружаются в приложение и названия услуг используются для их отображения.

# Скриншоты приложения:

![Главная страница](https://github.com/Fealerok/PhonePay/blob/main/ScreensForRepository/MainMenu.png)
## Главная страница
</br> </br> </br>

![Страница ввода номера телефона](https://github.com/Fealerok/PhonePay/blob/main/ScreensForRepository/EnterPhonePage.png)
## Страница ввода номера телефона </br>
</br> </br> </br>

![Окно ввода суммы денег](https://github.com/Fealerok/PhonePay/blob/main/ScreensForRepository/EnterMoneyPage.png)
## Окно ввода суммы денег </br>
</br> </br> </br>

![Страница поиска](https://github.com/Fealerok/PhonePay/blob/main/ScreensForRepository/SearchPage.png)
## Страница поиска </br>
</br> </br> </br>

![Страница поиска с визуализацией работы](https://github.com/Fealerok/PhonePay/blob/main/ScreensForRepository/SearchPage(Visualization%20of%20work).png)
## Визуализация работы поиска </br>
