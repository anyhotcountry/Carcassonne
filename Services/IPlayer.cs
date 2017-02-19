using Windows.UI;

namespace Carcassonne.Services
{
    public interface IPlayer
    {
        bool IsInteractive { get; }

        Color Colour { get; }
    }
}