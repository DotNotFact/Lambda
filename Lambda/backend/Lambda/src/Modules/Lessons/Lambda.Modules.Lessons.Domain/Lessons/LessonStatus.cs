﻿namespace Lambda.Modules.Lessons.Domain.Lessons;

public enum LessonStatus
{
    Draft = 0,           // Черновик: Урок находится в стадии разработки и не готов к публикации.
    Reviewing = 1,       // На проверке: Урок находится на стадии проверки или рецензирования.
    Published = 2,       // Опубликован: Урок доступен для просмотра и участия.

    Scheduled = 3,       // Запланирован: Урок назначен на определенное время в будущем.
    InProgress = 4,      // В процессе: Урок в данный момент проводится.
    Paused = 5,          // Приостановлен: Урок временно остановлен и может быть возобновлен.
    Completed = 6,       // Завершен: Урок успешно завершен.

    Canceled = 7,        // Отменен: Урок был отменен и не будет проведен.
    Rescheduled = 8,     // Перенесен: Урок был перенесен на другое время.
    Failed = 9,          // Провален: Урок не был завершен успешно (например, из-за технических проблем).
}
