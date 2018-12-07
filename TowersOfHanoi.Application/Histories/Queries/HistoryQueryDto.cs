namespace TowersOfHanoi.Application.Histories.Queries
{
    public class HistoryListRequestDto
    {
        public int UserId { get; set; }
    }

    public class HistoryListItemResponseDto
    {
        public string UserName { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}
