using System.Collections.Generic;

namespace TowersOfHanoi.Application.Users.Queries
{
    public interface IGetHistoryListQuery
    {
        List<UserListItemResponseDto> Execute();
    }
}
