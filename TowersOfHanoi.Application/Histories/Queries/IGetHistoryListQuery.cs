using System.Collections.Generic;
using System.Threading.Tasks;

namespace TowersOfHanoi.Application.Histories.Queries
{
    public interface IGetHistoryListQuery
    {
        Task<List<HistoryListItemResponseDto>> Execute(HistoryListRequestDto dto);
    }
}
