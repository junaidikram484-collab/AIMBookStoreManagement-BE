using AIM.BookStoreManagement.GraphQL.Mutations;
using AIM.BookStoreManagement.GraphQL.Queries;

namespace AIM.BookStoreManagement.Infrastructure;

public static class GraphQlDI
{
    public static void AddGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddAuthorization() // Important: Makes auth data available to resolvers
            .AddQueryType(d => d.Name("Query")) // define the root
            .AddTypeExtension<AuthorQuery>()
            .AddTypeExtension<BookQuery>()
            .AddMutationType(d => d.Name("Mutation"))
            .AddTypeExtension<AuthorMutation>()
            .AddTypeExtension<BookMutation>()
            .AddTypeExtension<AuthMutation>();
    }
}