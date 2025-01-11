namespace ResourcePath
{
    public class SO
    {
        public const string SoundEvent = "Data/Event/SoundEvent";
        public const string LoadingEvent = "Data/Event/LoadingEvent";
    }

    public class BasePrefab
    {
        public const string Projectile = "Prefabs/Projectile/Projectile";
    }

    public class Prefab
    {
        public static string Projectile(string fileName) => $"Prefabs/Projectile/{fileName}";
    }

}