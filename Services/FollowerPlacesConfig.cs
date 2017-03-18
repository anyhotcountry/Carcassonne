using System.Collections.Generic;

namespace Carcassonne.Services
{
    public static class FollowerPlacesConfig
    {
        public static IDictionary<string, IList<FollowerPoint>> Positions { get; } = new Dictionary<string, IList<FollowerPoint>>
        {
            ["01cccc10"] = new[] { new FollowerPoint(0, 0, FeatureTypes.City, 0), },
            ["01ccfc10"] = new[] { new FollowerPoint(0, 0, FeatureTypes.City, 0), new FollowerPoint(0, -0.7, FeatureTypes.Field, 0), },
            ["01ccrc00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.City, 0), new FollowerPoint(0, -0.7, FeatureTypes.Road, 0), new FollowerPoint(0.3, -0.72, FeatureTypes.Field, 0), new FollowerPoint(-0.4, -0.72, FeatureTypes.Field, 0), },
            ["01ccrc10"] = new[] { new FollowerPoint(0, 0, FeatureTypes.City, 0), new FollowerPoint(0, -0.7, FeatureTypes.Road, 0), new FollowerPoint(0.3, -0.72, FeatureTypes.Field, 0), new FollowerPoint(-0.4, -0.72, FeatureTypes.Field, 0), },
            ["01fcfc00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.City, 0), new FollowerPoint(0, -0.74, FeatureTypes.Field, 0), new FollowerPoint(0, 0.84, FeatureTypes.Field, 0), },
            ["01rrrr00"] = new[] { new FollowerPoint(-0.52, 0.6, FeatureTypes.Field, 0), new FollowerPoint(0.6, 0.6, FeatureTypes.Field, 0), new FollowerPoint(-0.52, -0.6, FeatureTypes.Field, 0), new FollowerPoint(0.6, -0.6, FeatureTypes.Field, 0), new FollowerPoint(0.14, 0.66, FeatureTypes.Road, 0), new FollowerPoint(-0.6, 0, FeatureTypes.Road, 0), new FollowerPoint(0, -0.68, FeatureTypes.Road, 0), new FollowerPoint(0.68, 0, FeatureTypes.Road, 0), },
            ["02cffc00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Field, 0), new FollowerPoint(-0.88, 0, FeatureTypes.City, 0), new FollowerPoint(0, 0.8, FeatureTypes.City, 0), },
            ["02cffc10"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Field, 0), new FollowerPoint(-0.6, 0.6, FeatureTypes.City, 0), },
            ["02crrc10"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Field, 0), new FollowerPoint(0.36, -0.48, FeatureTypes.Road, 0), new FollowerPoint(-0.6, 0.6, FeatureTypes.City, 0), new FollowerPoint(0.64, -0.64, FeatureTypes.Field, 0), },
            ["02fcfc10"] = new[] { new FollowerPoint(0, 0, FeatureTypes.City, 0), new FollowerPoint(0, -0.74, FeatureTypes.Field, 0), new FollowerPoint(0, 0.84, FeatureTypes.Field, 0), },
            ["02ffrf01"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Cloister, 0), new FollowerPoint(0.6, 0.48, FeatureTypes.Field, 0), new FollowerPoint(0, -0.68, FeatureTypes.Road, 0), },
            ["03ccfc00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.City, 0), new FollowerPoint(0, -0.7, FeatureTypes.Field, 0), },
            ["03cfcf00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Field, 0), new FollowerPoint(0, -0.72, FeatureTypes.City, 0), new FollowerPoint(0, 0.76, FeatureTypes.City, 0), },
            ["03cffc00"] = new[] { new FollowerPoint(-0.6, 0.6, FeatureTypes.City, 0), new FollowerPoint(0, 0, FeatureTypes.Field, 0), },
            ["03cfrr00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Field, 0), new FollowerPoint(0, 0.84, FeatureTypes.City, 0), new FollowerPoint(-0.26, -0.32, FeatureTypes.Road, 0), new FollowerPoint(-0.6, -0.6, FeatureTypes.Field, 0), },
            ["03crrc00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Field, 0), new FollowerPoint(0.36, -0.48, FeatureTypes.Road, 0), new FollowerPoint(-0.6, 0.6, FeatureTypes.City, 0), new FollowerPoint(0.64, -0.64, FeatureTypes.Field, 0), },
            ["03crrf00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Field, 0), new FollowerPoint(0, 0.84, FeatureTypes.City, 0), new FollowerPoint(0.28, -0.2, FeatureTypes.Road, 0), new FollowerPoint(0.56, -0.56, FeatureTypes.Field, 0), },
            ["03crrr00"] = new[] { new FollowerPoint(0, 0.76, FeatureTypes.City, 0), new FollowerPoint(0, 0.08, FeatureTypes.Field, 0), new FollowerPoint(-0.68, -0.06, FeatureTypes.Road, 0), new FollowerPoint(0.72, -0.14, FeatureTypes.Road, 0), new FollowerPoint(-0.6, -0.6, FeatureTypes.Field, 0), new FollowerPoint(0.6, -0.6, FeatureTypes.Field, 0), new FollowerPoint(0, -0.8, FeatureTypes.Road, 0) },
            ["04crfr00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Road, 0), new FollowerPoint(0, 0.84, FeatureTypes.City, 0), new FollowerPoint(-0.2, 0.2, FeatureTypes.Field, 0), new FollowerPoint(0, -0.5, FeatureTypes.Field, 0), },
            ["04ffff01"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Cloister, 0), new FollowerPoint(-0.54, -0.54, FeatureTypes.Field, 0), },
            ["04frrr00"] = new[] { new FollowerPoint(-0.68, -0.06, FeatureTypes.Road, 0), new FollowerPoint(0.72, -0.14, FeatureTypes.Road, 0), new FollowerPoint(-0.6, -0.6, FeatureTypes.Field, 0), new FollowerPoint(0.6, -0.6, FeatureTypes.Field, 0), new FollowerPoint(0, -0.8, FeatureTypes.Road, 0), new FollowerPoint(0, 0.6, FeatureTypes.Road, 0), },
            ["05cfff00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Field, 0), new FollowerPoint(0, 0.8, FeatureTypes.City, 0), },
            ["08rfrf00"] = new[] { new FollowerPoint(0, 0, FeatureTypes.Road, 0), new FollowerPoint(0.56, 0, FeatureTypes.Field, 0), new FollowerPoint(-0.6, 0, FeatureTypes.Field, 0), },
            ["09ffrr00"] = new[] { new FollowerPoint(-0.06, -0.02, FeatureTypes.Road, 0), new FollowerPoint(0.04, 0.3, FeatureTypes.Field, 0), new FollowerPoint(-0.54, -0.54, FeatureTypes.Field, 0), }
        };
    }
}