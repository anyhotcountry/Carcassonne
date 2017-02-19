using Windows.UI;

namespace Carcassonne.Services
{
    public class ComputerPlayer : IPlayer
    {
        public bool IsInteractive => false;

        public Color Colour => Colors.Red;

        public int FollowersCount { get; set; } = 7;
    }
}