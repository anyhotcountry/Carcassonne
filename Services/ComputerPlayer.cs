using Windows.UI;

namespace Carcassonne.Services
{
    public class ComputerPlayer : IPlayer
    {
        public bool IsInteractive => false;

        public Color Colour => Colors.Red;
    }
}