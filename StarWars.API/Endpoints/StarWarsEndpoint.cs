using System;
using Microsoft.AspNetCore.Mvc;
using StarWars.API.Services;

namespace StarWars.API.Endpoints
{
    public static class StarWarsEndpoint
    {
        public static RouteGroupBuilder StarWarsEndpoints(
            this RouteGroupBuilder route, string routePrefix)
        {
            route.MapGet($"{routePrefix}/getmovies", async (
               [FromServices] IStarWarsService starWarsService,
                CancellationToken cancellationToken) =>
            {
                var _movies = await starWarsService.GetMoviesAsync(
                    cancellationToken);

                if (_movies is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(_movies);

            }).WithName($"GetMoviesAsync{routePrefix}")
             .Produces(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound);

            route.MapGet($"{routePrefix}/getcharacters", async (

              [FromServices] IStarWarsService starWarsService,
               CancellationToken cancellationToken) =>
                {
                    var characters = await starWarsService.GetCharactersAsync(cancellationToken);

                    if (characters is null)

                    {
                        return Results.NotFound();
                    }
                    return Results.Ok(characters);
                }).WithName($"GetCharactersAsync{routePrefix}")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            route.MapGet($"{routePrefix}/getplanets", async (

              [FromServices] IStarWarsService starWarsService,
               CancellationToken cancellationToken) =>
            {
                var planets = await starWarsService.GetPlanetsAsync(cancellationToken);

                if (planets is null)

                {
                    return Results.NotFound();
                }
                return Results.Ok(planets);
            }).WithName($"GetPlanetsAsync{routePrefix}")
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            return route;
        }
    }
}

