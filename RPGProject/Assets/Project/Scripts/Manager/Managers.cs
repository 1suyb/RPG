using Manager;

public class Managers : SingletonBase<Managers>
{
    private SceneManager _sceneManager = new SceneManager();
    private InfoManager _infoManager = new InfoManager();
    private FactoryManager _factoryManager = new FactoryManager();
    public static SceneManager SceneManager => Instance._sceneManager;
    public static InfoManager InfoManager => Instance._infoManager;
    public static FactoryManager FactoryManager => Instance._factoryManager;
    
    private void Awake()
    {
        if(Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    protected override void InitOnCreate()
    {
        _sceneManager.InitOnCreate();
        _infoManager.InitOnCreate();
        _factoryManager.InitOnCreate();
    }
}
