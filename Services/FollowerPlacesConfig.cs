using System.Collections.Generic;

namespace Carcassonne.Services
{
    public static class FollowerPlacesConfig
    {
        public static IDictionary<string, IList<FollowerPoint>> Positions { get; } = new Dictionary<string, IList<FollowerPoint>>
        {
            ["01cccc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), },
            ["01ccfc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), new FollowerPoint(0, -0.7, EdgeTypes.Field), },
            ["01ccrc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), new FollowerPoint(0, -0.7, EdgeTypes.Road), new FollowerPoint(0.3, -0.72, EdgeTypes.Field), new FollowerPoint(-0.4, -0.72, EdgeTypes.Field), },
            ["01ccrc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), new FollowerPoint(0, -0.7, EdgeTypes.Road), new FollowerPoint(0.3, -0.72, EdgeTypes.Field), new FollowerPoint(-0.4, -0.72, EdgeTypes.Field), },
            ["01fcfc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), new FollowerPoint(0, -0.74, EdgeTypes.Field), new FollowerPoint(0, 0.84, EdgeTypes.Field), },
            ["01rrrr00"] = new[] { new FollowerPoint(-0.52, 0.6, EdgeTypes.Field), new FollowerPoint(0.6, 0.6, EdgeTypes.Field), new FollowerPoint(-0.52, -0.6, EdgeTypes.Field), new FollowerPoint(0.6, -0.6, EdgeTypes.Field), new FollowerPoint(0.14, 0.66, EdgeTypes.Road), new FollowerPoint(-0.6, 0, EdgeTypes.Road), new FollowerPoint(0, -0.68, EdgeTypes.Road), new FollowerPoint(0.68, 0, EdgeTypes.Road), },
            ["02cffc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Field), new FollowerPoint(-0.88, 0, EdgeTypes.City), new FollowerPoint(0, 0.8, EdgeTypes.City), },
            ["02cffc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Field), new FollowerPoint(-0.6, 0.6, EdgeTypes.City), },
            ["02crrc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Field), new FollowerPoint(0.36, -0.48, EdgeTypes.Road), new FollowerPoint(-0.6, 0.6, EdgeTypes.City), new FollowerPoint(0.64, -0.64, EdgeTypes.Field), },
            ["02fcfc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), new FollowerPoint(0, -0.74, EdgeTypes.Field), new FollowerPoint(0, 0.84, EdgeTypes.Field), },
            ["02ffrf01"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Cloister), new FollowerPoint(0.6, 0.48, EdgeTypes.Field), new FollowerPoint(0, -0.68, EdgeTypes.Road), },
            ["03ccfc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), new FollowerPoint(0, -0.7, EdgeTypes.Field), },
            ["03cfcf00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Field), new FollowerPoint(0, -0.72, EdgeTypes.City), new FollowerPoint(0, 0.76, EdgeTypes.City), },
            ["03cffc00"] = new[] { new FollowerPoint(-0.6, 0.6, EdgeTypes.City), new FollowerPoint(0, 0, EdgeTypes.Field), },
            ["03cfrr00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Field), new FollowerPoint(0, 0.84, EdgeTypes.City), new FollowerPoint(-0.26, -0.32, EdgeTypes.Road), new FollowerPoint(-0.6, -0.6, EdgeTypes.Field), },
            ["03crrc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Field), new FollowerPoint(0.36, -0.48, EdgeTypes.Road), new FollowerPoint(-0.6, 0.6, EdgeTypes.City), new FollowerPoint(0.64, -0.64, EdgeTypes.Field), },
            ["03crrf00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Field), new FollowerPoint(0, 0.84, EdgeTypes.City), new FollowerPoint(0.28, -0.2, EdgeTypes.Road), },
            ["03crrr00"] = new[] { new FollowerPoint(0, 0.76, EdgeTypes.City), new FollowerPoint(0, 0.08, EdgeTypes.Field), new FollowerPoint(-0.68, -0.06, EdgeTypes.Road), new FollowerPoint(0.72, -0.14, EdgeTypes.Road), new FollowerPoint(-0.6, -0.6, EdgeTypes.Field), new FollowerPoint(0.6, -0.6, EdgeTypes.Field), new FollowerPoint(0, -0.8, EdgeTypes.Road) },
            ["04crfr00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Road), new FollowerPoint(0, 0.84, EdgeTypes.City), new FollowerPoint(-0.2, 0.2, EdgeTypes.Field), new FollowerPoint(0, -0.5, EdgeTypes.Field), },
            ["04ffff01"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Cloister), new FollowerPoint(-0.54, -0.54, EdgeTypes.Field), },
            ["04frrr00"] = new[] { new FollowerPoint(-0.68, -0.06, EdgeTypes.Road), new FollowerPoint(0.72, -0.14, EdgeTypes.Road), new FollowerPoint(-0.6, -0.6, EdgeTypes.Field), new FollowerPoint(0.6, -0.6, EdgeTypes.Field), new FollowerPoint(0, -0.8, EdgeTypes.Road), new FollowerPoint(0, 0.6, EdgeTypes.Road), },
            ["05cfff00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Field), new FollowerPoint(0, 0.8, EdgeTypes.City), },
            ["08rfrf00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Road), new FollowerPoint(0.08, 0, EdgeTypes.Field), new FollowerPoint(-0.48, 0, EdgeTypes.Field), },
            ["09ffrr00"] = new[] { new FollowerPoint(-0.06, -0.02, EdgeTypes.Road), new FollowerPoint(0.04, 0.3, EdgeTypes.Field), new FollowerPoint(-0.54, -0.54, EdgeTypes.Field), }
        };
    }
}