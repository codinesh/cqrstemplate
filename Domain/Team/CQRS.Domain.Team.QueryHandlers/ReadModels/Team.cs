using CQRS.Common;

namespace CQRS.Domain.Team.QueryHandlers.ReadModels
{
    public class Team : IReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
