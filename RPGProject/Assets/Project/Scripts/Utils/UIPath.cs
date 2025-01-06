using System.Collections.Generic;

public enum UIType
{
    MainMenu
}

public class UIPath
{
    public const string RootCanvas = "Prefabs/UI/RootCanvas";
    public static readonly Dictionary<UIType, string> Path = new Dictionary<UIType, string>()
    {
        { UIType.MainMenu, "UI/MainMenu" }
    };
}