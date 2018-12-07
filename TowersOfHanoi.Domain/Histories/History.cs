using TowersOfHanoi.Domain.Common;
using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Domain.Histories
{
    public class History : AbstractEntity
    {
        public string Start { get; set; }
        public string End { get; set; }
        public virtual User User { get; set; }

        public bool IsValid() => User != null;
    }
}