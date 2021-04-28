using HCB.Gitlab.Api.v4.Group;
using HCB.Gitlab.Api.v4.Project;

namespace HCB.Gitlab.Api.v4
{
    // A v4 wrapper Client to group the other classes
    public class v4Client
    {
        public readonly GroupApi Group;
        public readonly ProjectApi Project;

        public v4Client(GroupApi group, ProjectApi project)
        {
            this.Group = group;
            this.Project = project;
        }
    }
}