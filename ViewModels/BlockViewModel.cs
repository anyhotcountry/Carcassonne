namespace Carcassonne.ViewModels
{
    public class BlockViewModel
    {
        public BlockViewModel(int left, int top, int width, int height, SideType leftSide, SideType rightSide, SideType topSide, SideType bottomSide)
        {
            Left = left;
            Top = top;
            Width = width;
            Height = height;
            LeftSide = leftSide;
            RightSide = rightSide;
            TopSide = topSide;
            BottomSide = bottomSide;
        }

        public int Left { get; private set; }

        public int Top { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public SideType LeftSide { get; private set; }

        public SideType RightSide { get; private set; }

        public SideType TopSide { get; private set; }

        public SideType BottomSide { get; private set; }
    }
    public enum SideType
    {
        City,
        Road,
        Field,
        River
    }
}