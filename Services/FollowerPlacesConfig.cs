using System.Collections.Generic;

namespace Carcassonne.Services
{
    public static class FollowerPlacesConfig
    {
        private static IDictionary<string, IList<FollowerPoint>> Positions = new Dictionary<string, IList<FollowerPoint>>
        {
            ["01cccc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["01ccfc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), new FollowerPoint(0, -1, EdgeTypes.Field) },
            ["01ccrc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), new FollowerPoint(0, -1, EdgeTypes.Road), new FollowerPoint(-0.5, -1, EdgeTypes.Field), new FollowerPoint(0.5, -1, EdgeTypes.Field) },
            ["01ccrc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), new FollowerPoint(0, -1, EdgeTypes.Road), new FollowerPoint(-0.5, -1, EdgeTypes.Field), new FollowerPoint(0.5, -1, EdgeTypes.Field) },
            ["01fcfc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City), new FollowerPoint(0, -1, EdgeTypes.Field), new FollowerPoint(0, 1, EdgeTypes.Field) },
            ["01rrrr00"] = new[] { new FollowerPoint(0, 1, EdgeTypes.Road), new FollowerPoint(0, -1, EdgeTypes.Road), new FollowerPoint(1, 0, EdgeTypes.Road), new FollowerPoint(1, 0, EdgeTypes.Road), new FollowerPoint(0.5, 1, EdgeTypes.Field), new FollowerPoint(-0.5, 1, EdgeTypes.Field), new FollowerPoint(0.5, -1, EdgeTypes.Field), new FollowerPoint(-0.5, -1, EdgeTypes.Field) },
            ["02cffc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.Field), new FollowerPoint(0, 1, EdgeTypes.City), new FollowerPoint(-1, 0, EdgeTypes.City) },
            ["02cffc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["02crrc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["02fcfc10"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["02ffrf01"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["03ccfc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["03cfcf00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["03cffc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["03cfrr00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["03crrc00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["03crrf00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["03crrr00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["04crfr00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["04ffff01"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["04frrr00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["05cfff00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["08rfrf00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) },
            ["09ffrr00"] = new[] { new FollowerPoint(0, 0, EdgeTypes.City) }
        };
    }
}