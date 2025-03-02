using System.ComponentModel;

namespace Lambda.Modules.Users.Domain.Entities.Enums;

public enum AttendanceStatus
{
    [Description("Присутствует")]
    Present,
    [Description("Отсутствует")]
    Absent,
    [Description("Опоздал")]
    Late
}