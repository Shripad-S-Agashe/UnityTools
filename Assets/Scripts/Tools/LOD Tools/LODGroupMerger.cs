using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#endif

public class LODGroupMerger : MonoBehaviour
{
    [SerializeField] private bool deleteOriginalModels = true; // Option to delete original LOD groups
    [SerializeField] private string savePath = "Assets/GeneratedMeshes"; // Folder where meshes will be saved
    [SerializeField] private string meshBaseName = "MergedMesh"; // Base name for saved meshes

    // Public properties to allow editor scripts to access these values
    public string SavePath { get { return savePath; } set { savePath = value; } }
    public string MeshBaseName { get { return meshBaseName; } set { meshBaseName = value; } }

    public void MergeLODGroups()
    {
        // Use the current game object as the parent
        GameObject parentObject = this.gameObject;
        LODGroup[] lodGroups = parentObject.GetComponentsInChildren<LODGroup>();
        if (lodGroups.Length == 0)
        {
            Debug.LogError("No LODGroups found inside the current object.");
            return;
        }

        Dictionary<int, List<MeshFilter>> lodMeshFilters = new Dictionary<int, List<MeshFilter>>();
        int maxLODLevels = 0;

        // Collect all meshes per LOD level
        foreach (LODGroup lodGroup in lodGroups)
        {
            LOD[] lods = lodGroup.GetLODs();
            maxLODLevels = Mathf.Max(maxLODLevels, lods.Length);

            for (int i = 0; i < lods.Length; i++)
            {
                if (!lodMeshFilters.ContainsKey(i))
                {
                    lodMeshFilters[i] = new List<MeshFilter>();
                }

                foreach (Renderer renderer in lods[i].renderers)
                {
                    if (renderer.TryGetComponent(out MeshFilter meshFilter))
                    {
                        lodMeshFilters[i].Add(meshFilter);
                    }
                }
            }
        }

#if UNITY_EDITOR
        // Ensure the save directory exists
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            AssetDatabase.Refresh();
        }
#endif

        // Create the merged LOD group object
        GameObject mergedLODObject = new GameObject($"{meshBaseName}_Merged");
        mergedLODObject.transform.SetParent(parentObject.transform);
        LODGroup newLODGroup = mergedLODObject.AddComponent<LODGroup>();
        List<LOD> newLODs = new List<LOD>();

        for (int i = 0; i < maxLODLevels; i++)
        {
            if (!lodMeshFilters.ContainsKey(i) || lodMeshFilters[i].Count == 0)
            {
                if (i > 0)
                {
                    lodMeshFilters[i] = new List<MeshFilter>(lodMeshFilters[i - 1]);
                }
                else
                {
                    continue;
                }
            }

            Mesh combinedMesh = CombineMeshes(lodMeshFilters[i]);

#if UNITY_EDITOR
            string meshName = $"{meshBaseName}_LOD{i}.asset";
            string meshPath = Path.Combine(savePath, meshName);
            meshPath = AssetDatabase.GenerateUniqueAssetPath(meshPath);
            AssetDatabase.CreateAsset(combinedMesh, meshPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Mesh savedMesh = AssetDatabase.LoadAssetAtPath<Mesh>(meshPath);
#else
            Mesh savedMesh = combinedMesh;
#endif

            GameObject lodObj = new GameObject($"LOD_{i}");
            lodObj.transform.SetParent(mergedLODObject.transform);
            MeshFilter mf = lodObj.AddComponent<MeshFilter>();
            MeshRenderer mr = lodObj.AddComponent<MeshRenderer>();

            mf.mesh = savedMesh;
            mr.sharedMaterial = lodMeshFilters[i][0].GetComponent<MeshRenderer>().sharedMaterial;

            // ----- Pivot Fix: Recenter the mesh -----
            Vector3 meshPivot = savedMesh.bounds.center;
            Vector3[] verts = savedMesh.vertices;
            for (int j = 0; j < verts.Length; j++)
            {
                verts[j] -= meshPivot;
            }
            savedMesh.vertices = verts;
            savedMesh.RecalculateBounds();
            lodObj.transform.position = meshPivot;
            // ----------------------------------------

            newLODs.Add(new LOD(1f / (i + 1), new Renderer[] { mr }));
        }

        newLODGroup.SetLODs(newLODs.ToArray());
        newLODGroup.RecalculateBounds();

        if (deleteOriginalModels)
        {
            foreach (LODGroup oldLodGroup in lodGroups)
            {
                DestroyImmediate(oldLodGroup.gameObject);
            }
        }

        Debug.Log($"LOD Group successfully merged! Total LOD Levels: {maxLODLevels}.\nMeshes saved in: {savePath}");
    }

    private Mesh CombineMeshes(List<MeshFilter> meshFilters)
    {
        CombineInstance[] combine = new CombineInstance[meshFilters.Count];

        for (int i = 0; i < meshFilters.Count; i++)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
        }

        Mesh combinedMesh = new Mesh();
        combinedMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
        combinedMesh.CombineMeshes(combine, true, true);
        return combinedMesh;
    }
}
