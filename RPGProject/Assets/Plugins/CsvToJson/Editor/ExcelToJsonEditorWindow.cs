using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ExceltoJson
{
    public class ExcelToJsonEditorWindow : EditorWindow
    {
        private string _excelFileFolderpath = "Assets/Project/Data/ExcelData";
        private string _jsonSavePath = "Assets/Resources/Data/Json";
        private string _classSavePath = "Assets/Project/Scripts/DataScripts";
        private string _enumFileName = "InfoEnum";

        [MenuItem("Tools/CsvToJson")]
        public static void ShowWindow() {
            EditorWindow.GetWindow<ExcelToJsonEditorWindow>("CSV To Json");
        }

        private void OnGUI() {
            GUILayout.Label("Path Setting", EditorStyles.boldLabel);
            _excelFileFolderpath = EditorGUILayout.TextField("CSV File Folder Path:", _excelFileFolderpath);
            _jsonSavePath = EditorGUILayout.TextField("Json Save Path:", _jsonSavePath);
            _classSavePath = EditorGUILayout.TextField("Class Save Path:", _classSavePath);
            _enumFileName = EditorGUILayout.TextField("Enum File Name:", _enumFileName);

            if(GUILayout.Button("Convert")) {
                ExcelToJson converter = new ExcelToJson(_excelFileFolderpath, _jsonSavePath, _classSavePath, _enumFileName);
                converter.Convert();
            }
            EditorGUILayout.Space();
            GUILayout.Label("Current Status:");
            GUILayout.Label($"CSV File Folder Path: {_excelFileFolderpath}");
            GUILayout.Label($"Json Save Path: {_jsonSavePath}");
            GUILayout.Label($"Class Save Path: {_classSavePath}");
            GUILayout.Label($"Enum File Name: {_enumFileName}");
        }
    }

}
