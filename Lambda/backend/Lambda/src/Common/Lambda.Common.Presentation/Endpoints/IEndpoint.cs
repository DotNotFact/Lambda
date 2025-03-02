using Microsoft.AspNetCore.Routing;

namespace Lambda.Common.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
