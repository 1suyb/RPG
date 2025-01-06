public interface ILoadable
{
    public void Load(int id);
}

public interface IManager
{
    public void Init();
    public void Release();
}