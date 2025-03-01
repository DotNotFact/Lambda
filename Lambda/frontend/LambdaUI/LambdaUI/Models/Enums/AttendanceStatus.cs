using System.ComponentModel;

namespace LambdaUI.Models.Enums;

public enum AttendanceStatus
{
    [Description("Присутствует")]
    Present,
    [Description("Отсутствует")]
    Absent,
    [Description("Опоздал")]
    Late
}