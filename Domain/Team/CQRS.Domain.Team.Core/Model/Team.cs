namespace CQRS.Domain.Team.Core.Model
{
    public class Team : ModelBase
    {
        public string Name { get; set; }
        public int NumberOfPlayers { get; set; }
    }
}
