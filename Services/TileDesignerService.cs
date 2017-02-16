using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Geometry;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI;

namespace Carcassonne.Services
{
    public class TileDesignerService : ITileDesignerService
    {
        public async Task<string> DrawTile()
        {
            var device = CanvasDevice.GetSharedDevice();
            var offscreen = new CanvasRenderTarget(device, 500, 500, 96);
            using (var ds = offscreen.CreateDrawingSession())
            {
                DrawCity(ds);
            }

            var tilesFolder = await EnsureFolderExists();
            var path = Path.Combine(tilesFolder.Path, "tile.png");
            await offscreen.SaveAsync(path);
            return path;
        }

        private void DrawCity(CanvasDrawingSession drawingSession)
        {
            var sqrt2 = (float)Math.Sqrt(2);
            var side = 250;
            var radius = side * sqrt2;
            var fieldColour = Color.FromArgb(255, 145, 161, 99);
            var brown = Color.FromArgb(255, 124, 84, 59);
            var darkGray = Color.FromArgb(255, 50, 50, 50);
            drawingSession.Clear(fieldColour);
            var stroke = new CanvasStrokeStyle { DashStyle = CanvasDashStyle.Dot };
            drawingSession.FillEllipse(side, -side, radius, radius, Colors.Chocolate);
            drawingSession.DrawEllipse(side, -side, radius, radius, Colors.Black, 30);
            drawingSession.DrawEllipse(side, -side, radius, radius, darkGray, 30, stroke);
            drawingSession.DrawEllipse(side, -side, radius, radius, darkGray, 15);
        }

        private async Task<StorageFolder> EnsureFolderExists()
        {
            var folders = await ApplicationData.Current.LocalFolder.GetFoldersAsync();
            var tilesFolder = folders.FirstOrDefault(f => f.Name == "Tiles");
            if (tilesFolder == null)
            {
                tilesFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Tiles");
            }

            return tilesFolder;
        }
    }
}