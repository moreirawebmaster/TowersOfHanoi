using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TowersOfHanoi.CrossCutting;
using TowersOfHanoi.Domain.Histories;

namespace TowersOfHanoi.Application.Histories.Queries
{
    public class GetHistoryListQuery : IGetHistoryListQuery
    {
        private readonly IRepository<History> _repository;

        public GetHistoryListQuery(IRepository<History> repository)
        {
            _repository = repository;
        }

        public async Task<List<HistoryListItemResponseDto>> Execute(HistoryListRequestDto dto)
        {
            var hsitories = await _repository.Query.Include(x => x.User)
                .AsNoTracking()
                .Where(x=>x.User.Id == dto.UserId)
                .Select(x => new HistoryListItemResponseDto
                {
                    UserName = x.User.Name,
                    Start = x.Start,
                    End = x.End
                }).ToListAsync();

            return hsitories;
        }
    }
}
