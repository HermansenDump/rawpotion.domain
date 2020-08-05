using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Types;

namespace Rawpotion.Domain.GraphQL
{
    [ExtendObjectType(Name = "Query")]
    public class GroupQueries
    {
        public IEnumerable<Group> GetGroups(string[] ids, [Service] IGroupRepository repository) =>
            repository.GetGroups();

        public IEnumerable<Group> GetGroups([Service] IGroupRepository repository) =>
            repository.GetGroups();
    }
}