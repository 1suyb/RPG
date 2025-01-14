using UnityEngine;
using UnityEngine.UI;

public class FloatingHpBar : FloatingUIBase
{
    [SerializeField] private Image image;
    public void InitOnCreate(Camera camera)
    {
        _camera = camera;
    }

    public void InitOnActivate(Transform target)
    {
        _target = target;
        _isUIActive = true;
    }

    public void Release()
    {
        _isUIActive = false;
    }

    public void SetHpBar(float hpPercent)
    {
        image.fillAmount = hpPercent;
    }
}
