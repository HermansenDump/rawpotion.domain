using HotChocolate.AspNetCore.Authorization;

namespace Rawpotion.Domain.GraphQL
{
    public interface IGroup {}
    
    [Authorize]
    public class Group : IGroup
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}