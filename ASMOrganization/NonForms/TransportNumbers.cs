using ASMOrganization.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMOrganization.NonForms
{
    public static class TransportNumbers
    {
        public static double DistanceThreshold = 1.5; // default values
        public static int MaxDistance = 30;
        public static string OverriddenZones = "Nephi, Teancum, Enos";
        public static void Save(double newThreshold, int newMax, string newOverride)
        {
            Settings.Default.DistanceThreshold = newThreshold;
            Settings.Default.MaxDistance = newMax;
            Settings.Default.OverriddenZones = newOverride;
            Settings.Default.Save();
        }

        public static void Load()
        {
            DistanceThreshold = Settings.Default.DistanceThreshold;
            MaxDistance = Settings.Default.MaxDistance;
            OverriddenZones = Settings.Default.OverriddenZones;
        }

    }
}
