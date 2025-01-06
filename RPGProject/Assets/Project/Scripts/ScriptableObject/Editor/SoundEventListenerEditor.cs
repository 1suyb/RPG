using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SoundEventListenrSO))]
public class SoundEventListenerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        SoundEventListenrSO soundEventListenrSO = (SoundEventListenrSO)target;
        
        GUILayout.Label("SFX Clips");
        if(soundEventListenrSO.SfxDict != null)
        {
            foreach (var sfx in soundEventListenrSO.SfxDict)
            {
                EditorGUILayout.TextArea($"{sfx.Key.ToString()} | {sfx.Value.name}");;
            }
        }
        
        GUILayout.Label("BGM Clips");
        if(soundEventListenrSO.BgmDict != null)
        {
            foreach (var sfx in soundEventListenrSO.BgmDict)
            {
                EditorGUILayout.TextArea($"{sfx.Key.ToString()} | {sfx.Value.name}");;
            }
        }
        
        if(GUILayout.Button("MakeDict"))
        {
            soundEventListenrSO.MakeDict();
        }
    }
}
