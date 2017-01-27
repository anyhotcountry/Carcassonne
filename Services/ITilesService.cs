using System.Collections.Generic;
using System.Threading.Tasks;

namespace Carcassonne.Services
{
    public interface ITilesService
    {
        Task LoadTiles();

        void PlaceTile(Tile tile, FitProperties properties);

        IEnumerable<FitProperties> GetPossibilities(Tile tile);

        Tile NextTile();
    }
}