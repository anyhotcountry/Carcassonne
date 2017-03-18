namespace Carcassonne.Services.Models
{
    using System.Collections.Generic;

    public class TileDefinition
    {
        public string Filename { get; set; }

        public IList<Edge> Edges { get; set; }

        public int Cloisters { get; set; }

        public int Pennants { get; set; }

        public int Count { get; set; }

        public bool IsStarting { get; set; }

        public IList<Follower> Followers { get; set; }
    }
}