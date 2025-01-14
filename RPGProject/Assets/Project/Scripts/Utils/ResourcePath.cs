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
        public static string FloatingHpBar = "Prefabs/UI/FloatingHpBar";
        public static string FloatingUICanvas = "Prefabs/UI/FloatingUICanvas";
    }

}