using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using Microsoft.AspNetCore.Builder;

namespace Rawpotion.Domain.GraphQL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRawpotionGraphQL(this IServiceCollection services) =>
            services
                .AddSingleton<IGroupRepository, GroupRepository>()
                .AddGraphQL(sp => SchemaBuilder.New()
                    .AddAuthorizeDirectiveType()
                    .AddServices(sp)
                    .AddQueryType(d => d.Name("Query"))
                    .AddMutationType(d => d.Name("Mutation"))
                    .AddType<GroupType>()
                    .AddType<GroupQueries>()
                    .AddType<GroupMutations>()
                    .Create());

        public static IApplicationBuilder UseRawpotionGraphQL(this IApplicationBuilder app) =>
            app
                .UseGraphQL("/graphql")
                .UseVoyager("/graphql")
                .UsePlayground("/graphql");
    }
}