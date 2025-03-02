﻿using Lambda.Modules.Lessons.Application.Lessons.GetLesson; 
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MediatR;
using Lambda.Common.Presentation.Endpoints;

namespace Lambda.Modules.Lessons.Presentation.Lessons;

internal sealed class GetLesson : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("lessons/{id}", async (Guid id, ISender sender) =>
        {
            LessonResponse? lesson = await sender.Send(new GetLessonQuery(id));
            return lesson is null ? Results.NotFound() : Results.Ok(lesson);
        })
        .WithTags(Tags.Lessons);
    }
}
