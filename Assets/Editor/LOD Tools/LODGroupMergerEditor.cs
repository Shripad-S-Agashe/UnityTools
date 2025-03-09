using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LODGroupMerger))]
public class LODGroupMergerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector properties
        DrawDefaultInspector();

        LODGroupMerger merger = (LODGroupMerger)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Save Location", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Save Path:", merger.SavePath);

        if (GUILayout.Button("Select Save Folder"))
        {
            string selectedPath = EditorUtility.OpenFolderPanel("Select Save Folder", Application.dataPath, "");
            if (!string.IsNullOrEmpty(selectedPath))
            {
                // Convert absolute path to a relative path
                string relativePath = "Assets" + selectedPath.Replace(Application.dataPath, "").Replace("\\", "/");
                merger.SavePath = relativePath;
                EditorUtility.SetDirty(merger); // Mark as dirty to save the change
            }
        }

        EditorGUILayout.Space();
        if (GUILayout.Button("Merge LOD Groups"))
        {
            merger.MergeLODGroups();
        }
    }
}
