public interface ILoadable
{
    public void Load(int id);
}

public interface IManager
{
    public void InitOnCreate();
    public void Release();
}