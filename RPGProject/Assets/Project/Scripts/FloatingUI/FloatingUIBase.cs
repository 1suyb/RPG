using UnityEngine;

public class FloatingUIBase : MonoBehaviour
{
    protected Transform _target;
    protected Camera _camera;
    protected bool _isUIActive;
    public void UpdateUI()
    {
        Vector3 screenPosition = _camera.WorldToScreenPoint(_target.position);
        if(screenPosition.x>0 && screenPosition.x<Screen.width && screenPosition.y>0 && screenPosition.y<Screen.height && _isUIActive)
        {
            if(!gameObject.activeSelf)
                gameObject.SetActive(true);
            transform.position = screenPosition;
        }
        else
        {
            if(gameObject.activeSelf)
                gameObject.SetActive(false);
        }
    }
}
