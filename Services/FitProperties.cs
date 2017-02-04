namespace Carcassonne.Services
{
    public class FitProperties
    {
        public Rotation Rotation { get; set; } = Rotation.None;

        public Point Point { get; set; }

        public int Score { get; set; }
    }
}