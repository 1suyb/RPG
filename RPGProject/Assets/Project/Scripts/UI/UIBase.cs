using UnityEngine;

public class UIBase : MonoBehaviour
{
    public void Open()
    {
        this.gameObject.SetActive(true);
        OpenProcedure();
    }
    public virtual void OpenProcedure(){}

    public void Close()
    {
        CloseProcedure();
        this.gameObject.SetActive(false);
    }
    public virtual void CloseProcedure(){}
    
}
