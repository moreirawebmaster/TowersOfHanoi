using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TowersOfHanoi.CrossCutting;
using TowersOfHanoi.Domain.Users;

namespace TowersOfHanoi.Application.Users.Queries
{
    public class GetHistoryListQuery : IGetHistoryListQuery
    {
        private readonly IRepository<User> _repository;

        public GetHistoryListQuery(IRepository<User> repository)
        {
            _repository = repository;
        }

        public List<UserListItemResponseDto> Execute()
        {
            var users = _repository.Query
                .AsNoTracking()
                .Select(x => new UserListItemResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();

            return users;
        }
    }
}
