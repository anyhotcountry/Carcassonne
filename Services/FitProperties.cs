namespace Carcassonne.Services
{
    public class FitProperties
    {
        public Rotation Rotation { get; set; } = Rotation.None;

        public int X { get; set; }

        public int Y { get; set; }

        public int Score { get; set; }
    }
}