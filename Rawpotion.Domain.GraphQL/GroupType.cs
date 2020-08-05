using HotChocolate.Types;

namespace Rawpotion.Domain.GraphQL
{
    public class GroupType : ObjectType<Group>, IGroup
    {
        protected override void Configure(IObjectTypeDescriptor<Group> descriptor) =>
            descriptor
                .Field(t => t.Id)
                .Type<NonNullType<IdType>>();
    }
}