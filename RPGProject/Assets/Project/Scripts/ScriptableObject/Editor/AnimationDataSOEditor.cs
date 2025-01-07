using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AnimationDataSO))]
public class AnimationDataSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        AnimationDataSO animationDataSo = (AnimationDataSO)target;

        if (GUILayout.Button("MakeHash"))
        {
            animationDataSo.SetHash();
        }
    }
}
