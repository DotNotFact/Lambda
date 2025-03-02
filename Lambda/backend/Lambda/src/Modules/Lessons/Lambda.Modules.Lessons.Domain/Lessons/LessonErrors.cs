using Lambda.Common.Domain;

namespace Lambda.Modules.Lessons.Domain.Lessons;

public static class LessonErrors
{
    public static Error NotFound(Guid eventId) =>
        Error.NotFound("Lessons.NotFound", $"The event with the identifier {eventId} was not found");

    public static readonly Error StartDateInPast = Error.Problem(
        "Lessons.StartDateInPast",
        "The event start date is in the past");

    public static readonly Error EndDatePrecedesStartDate = Error.Problem(
        "Lessons.EndDatePrecedesStartDate",
        "The event end date precedes the start date");

    public static readonly Error NoTicketsFound = Error.Problem(
        "Lessons.NoTicketsFound",
        "The event does not have any ticket types defined");

    public static readonly Error NotDraft = Error.Problem("Lessons.NotDraft", "The event is not in draft status");


    public static readonly Error AlreadyCanceled = Error.Problem(
        "Lessons.AlreadyCanceled",
        "The event was already canceled");


    public static readonly Error AlreadyStarted = Error.Problem(
        "Lessons.AlreadyStarted",
        "The event has already started");
}
