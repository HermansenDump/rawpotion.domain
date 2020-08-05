using System;
using System.Collections.Generic;
using System.Linq;

namespace Rawpotion.Domain.GraphQL
{
    public interface IGroupRepository
    {
        Group AddGroup(Group group);
        IQueryable<Group> GetGroups();
        IEnumerable<Group> GetGroups(IEnumerable<string> ids);
    }

    public class GroupRepository : IGroupRepository
    {
        private readonly List<Group> _groups;

        public GroupRepository()
        {
            _groups = new List<Group>();
        }

        public Group AddGroup(Group group)
        {
            group.Id = Guid.NewGuid().ToString();
            _groups.Add(group);
            return group;
        }

        public IQueryable<Group> GetGroups() => _groups.AsQueryable();

        public IEnumerable<Group> GetGroups(IEnumerable<string> ids) => ids
            .Select(id => _groups.FirstOrDefault(g => g.Id == id))
            .Where(gp => gp != null);
    }
}