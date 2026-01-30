using ASMOrganization.Properties;
namespace ASMOrganization.NonForms
{
    public static class TransportNumbers // organization purposes
    {
        private static double DistanceThreshold = 1.5; // default values
        private static int MaxDistance = 30;
        private static string OverriddenZones = "Nephi, Teancum, Enos";
        private static bool GoToBHChapel = false;
        public static void Save(double newThreshold, int newMax, string newOverride, bool bhChapel)
        {
            Settings.Default.DistanceThreshold = newThreshold;
            Settings.Default.MaxDistance = newMax;
            Settings.Default.OverriddenZones = newOverride;
            Settings.Default.GoToBHChapel = bhChapel;
            Settings.Default.Save();
        }

        public static void Load()
        {
            DistanceThreshold = Settings.Default.DistanceThreshold;
            MaxDistance = Settings.Default.MaxDistance;
            OverriddenZones = Settings.Default.OverriddenZones;
            GoToBHChapel = Settings.Default.GoToBHChapel;
        }

        public static double GetDistanceThreshold() => DistanceThreshold;
        public static int GetMaxDistance() => MaxDistance;
        public static string GetOverriddenZones() => OverriddenZones;
        public static bool GoToOffice() => !GoToBHChapel;

    }
}
