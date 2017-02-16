using System.Threading.Tasks;

namespace Carcassonne.Services
{
    public interface ITileDesignerService
    {
        Task<string> DrawTile();
    }
}