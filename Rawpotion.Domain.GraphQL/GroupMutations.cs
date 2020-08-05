using HotChocolate;
using HotChocolate.Types;

namespace Rawpotion.Domain.GraphQL
{
    [ExtendObjectType(Name = "Mutation")]
    public class GroupMutations
    {
        public Group AddGroup(Group group, [Service] IGroupRepository repository) => 
            repository.AddGroup(group);
    }
}