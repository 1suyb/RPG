using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/AnimationData")]
public class AnimationDataSO : ScriptableObject
{
    [field:SerializeField] public string Name { get; private set; }
    [field:SerializeField] public string Tag { get; private set; }
    [field:SerializeField] public int Hash { get; private set; }
    

    public void SetHash()
    {
        if(Name!="")
            Hash = Animator.StringToHash(Name);
    }
}
