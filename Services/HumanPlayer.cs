using Windows.UI;

namespace Carcassonne.Services
{
    public class HumanPlayer : IPlayer
    {
        public bool IsInteractive => true;

        public Color Colour => Colors.Blue;

        public int FollowersCount { get; set; } = 7;
    }
}