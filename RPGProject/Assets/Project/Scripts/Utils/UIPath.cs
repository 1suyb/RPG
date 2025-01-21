using System.Collections.Generic;

public enum UIType
{
    MainMenu,
    Inventory,
}

public class UIPath
{
    public const string RootCanvas = "Prefabs/UI/RootCanvas";

    public static readonly Dictionary<UIType, string> Path = new Dictionary<UIType, string>()
    {
        { UIType.MainMenu, "Prefabs/UI/MainMenu" },
        { UIType.Inventory, "Prefabs/UI/Inventory" }
    };
}