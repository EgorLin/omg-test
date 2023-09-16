# Пояснение к тестовому заданию

Перечисление дополнительных добавленных и измененных файлов

## Общее
- [File Manager](/Assets/App/Scripts/Libs/FileManager/FileManager.cs)

	Создан класс, который кеширует ассеты, предотвращая повторную загрузку

- [Tests](/Assets/App/Tests/EditMode)

	Созданы юнит тесты для ТЗ-методов

- [Service Level Selection](/Assets/App/Scripts/Infrastructure/LevelSelection/ServiceLevelSelection.cs)

	Добавлены публичные свойства максимального и предыдущего уровня для HandlerSetupFillwords.cs

## Fillwords

- [Fillwords Resource Paths](/Assets/App/Scripts/Scenes/SceneFillwords/Consts/FillwordsResourcePaths.cs)

	Создан класс содержащий пути файлов

- [Handler Setup Fillwords](/Assets/App/Scripts/Scenes/SceneFillwords/States/Setup/HandlerSetupFillwords.cs)

	Добавлена функциональность пропуска невалидных уровней

## Word Search

- [Word Search Resource Paths](/Assets/App/Scripts/Scenes/SceneWordSearch/Consts/WordSearchResourcePaths.cs)

	Создан класс содержащий пути файлов

## Scene Chess

- [Chess Unit Move Directions](/Assets/App/Scripts/Scenes/SceneChess/Features/ChessField/Types/ChessUnitMoveDirection.cs)

	Создан тип с направлениями движения шахматной фигуры

- [Chess Unit Moves](/Assets/App/Scripts/Scenes/SceneChess/Features/ChessField/Piece/ChessUnitMoves)

	Создана папка, содержащая класс с созданием движения фигур, класс и интерфейс для каждой фигуры
