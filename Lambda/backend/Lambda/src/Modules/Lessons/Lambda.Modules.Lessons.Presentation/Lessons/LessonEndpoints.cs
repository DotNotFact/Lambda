using Microsoft.AspNetCore.Routing;

namespace Lambda.Modules.Lessons.Presentation.Lessons;

public class LessonEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateLesson.MapEndpoint(app);
        GetLesson.MapEndpoint(app);
    }
}
