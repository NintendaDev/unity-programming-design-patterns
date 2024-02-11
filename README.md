# Примеры реализации игровых паттернов в Unity

## 1. Assets\Patterns Realizations Examples\Example 01. Weapon Types (Template Method)

Паттерн "Шаблонный метод"

Разные виды оружия стреляют либо бесконечными патронами, либо конечными

## 2. Assets\Patterns Realizations Examples\Example 02. Seller (Strategy)

Паттерн "Стратегия"

Продавец продает игроку разные вещи в зависимости от его возраста

## 3. Assets\Patterns Realizations Examples\Example 03. Ball Game (Strategy & Template Method)

Паттерны "Стратегия", "Медиатор" и "Шаблонный метод"

Игра в шарики. Игрок выигрывает если лопнет все шарики, либо если только лопнет шарики одного цвета. Перед началом игры можно выбрать правила.
Загрузка сцен и передача между ними настроек организована через ZenjectSceneLoader.

## 4. Assets\Patterns Realizations Examples\Example 04. Robot Kyle (Finite State Machine)

Паттерн "Состояние"

Робот Кайл патрулирует точки маршрута и в момент прибытия в точку выполняет одно из 3 случайных действий:
- ожидание
- танец
- физическая тренировка на полу

## 5. Assets\Patterns Realizations Examples\Example 05. Robot Jamo (Finite State machine)

Паттерн "Состояние", иерархическая машина состояний

Реализован контроль роботом Джамо со стороны игрока на основе иерархии состояний.

## 6. Assets\Patterns Realizations Examples\Example 06. UI Clicker (Mediator)

Паттерн "Медиатор"

Простой кликер. Есть две кнопки: получить урон и прокачать опыт. При увеличении опыта растет уровень игрока. А с ростом уровня увеличивается максимальный объем здоровья.

При повышении уровня утраченное здоровье полностью восполняется. Если уровень здоровья равен 0, то игра заканчивается и предлагается игроку перезапустить игру.

Данные в UI передаются с помощью паттерна "Медиатор".

## 7. Assets\Patterns Realizations Examples\Example 07. Different Design UI (Fabric, Mediator)

Паттерны "Фабрика" и "Медиатор"

В UI отображаются иконки денег и энергии. С помощью фабрики можно поменять дизайн иконок и их цвет.

## 8. Assets\Patterns Realizations Examples\Example 08. Character Constructor (Decorator, Fluent Builder, Fabric)

Паттерны "Декоратор", Fluent Builder и "Фабрика"

Конструктор персонажа на основе выбора расы, специализации и способностей.
Есть три атрибута: сила, ловкость и интеллект. 
Есть три расы: человек, эльф и орк.

Указанные атрибуты уникальны для каждой расы. Настраивается через конфигурацию. 
Для каждой расы можно выбрать специализацию: вор, маг или варвар.

Так же есть скилы: шахматист, бодибилдер и мастер утренней зарядки.

В точке входа сцены создаются несколько персонажей и выводится информация в консоль.

## 9. Assets\Patterns Realizations Examples\Example 09. Enemies Grid Killer  (Visiter, Fabric, Mediator)

Паттерны "Визитер", "Фабрика" и "Медиатор"

Есть 4 типа врагов: человек, эльф, орк и робот.

За убийство каждого типа врага начисляется определенное количество очков.
Спавнер создает врагов по заданной сетке. При этом учитывает занята ли в текущем моменте ячейка.

А также учитывает общий вес сгенерированных врагов. Если вес всех врагов на сцене больше определенного порога, то создание врагов останавливается.
Для каждого типа врага свой определенный вес.

