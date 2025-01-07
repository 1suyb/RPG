using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterAnimationDataSet")]
public class CharacterAnimationDataSO : ScriptableObject
{
    [field:SerializeField] public AnimationDataSO IsMove { get; private set; }
    [field:SerializeField] public AnimationDataSO IsAir { get; private set; }
    [field:SerializeField] public AnimationDataSO IsDodge { get; private set; }
    [field:SerializeField] public AnimationDataSO IsFall { get; private set; }
    [field:SerializeField] public AnimationDataSO IsDie { get; private set; }
    [field:SerializeField] public AnimationDataSO MoveX { get; private set; }
    [field:SerializeField] public AnimationDataSO MoveZ { get; private set; }
}
