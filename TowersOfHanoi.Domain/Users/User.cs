using System.Collections.Generic;
using TowersOfHanoi.Domain.Common;
using TowersOfHanoi.Domain.Histories;

namespace TowersOfHanoi.Domain.Users
{
    public class User : AbstractEntity
    {
        public string Name { get; set; }
        public virtual ICollection<History> History { get; set; }

        public bool IsValid() => !string.IsNullOrEmpty(Name);
    }
}