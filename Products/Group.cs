using System;
using System.Linq;

namespace Products
{
    class Group : ICloneable
    {
        public string GroupName { get; set; }

        public Group(string groupName)
        {
            this.GroupName = groupName;
        }

        public override object Clone()
        {
            return new Group(GroupName);
        }
    }
}
