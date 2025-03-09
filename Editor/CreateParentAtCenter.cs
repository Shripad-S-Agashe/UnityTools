using UnityEngine;
using UnityEditor;
using System.Reflection;

public static class CreateEmptyParentAtCenter
{
    [MenuItem("GameObject/Create Empty Parent at Center", false, 0)]
    private static void CreateEmptyParent(MenuCommand command)
    {
        // Ensure the function is called only once per selection
        if (command.context)
        {
            EditorApplication.update -= ExecuteOnce;
            EditorApplication.update += ExecuteOnce;
            return;
        }

        Transform[] selectedTransforms = Selection.transforms;
        if (selectedTransforms.Length == 0)
        {
            Debug.LogWarning("No objects selected!");
            return;
        }

        // Calculate the bounds center
        Bounds bounds = new Bounds(selectedTransforms[0].position, Vector3.zero);
        foreach (Transform t in selectedTransforms)
        {
            Renderer renderer = t.GetComponent<Renderer>();
            if (renderer != null)
            {
                bounds.Encapsulate(renderer.bounds);
            }
            else
            {
                bounds.Encapsulate(t.position);
            }
        }

        Vector3 center = bounds.center;

        // Create the new parent GameObject at the calculated center
        GameObject newParent = new GameObject("Empty Parent (Centered)");
        newParent.transform.position = center;

        // Set the parent of the new GameObject to match the original parent of the first selected object
        newParent.transform.SetParent(selectedTransforms[0].parent, true);

        // Parent all selected objects to the new parent
        foreach (Transform t in selectedTransforms)
        {
            Undo.SetTransformParent(t, newParent.transform, "Create Empty Parent at Center");
        }

        // Select the new parent in the Hierarchy
        Selection.activeTransform = newParent.transform;

        // Automatically enable rename mode
        EditorApplication.delayCall += () => RenameObject(newParent);
    }

    private static void ExecuteOnce()
    {
        EditorApplication.update -= ExecuteOnce;
        CreateEmptyParent(new MenuCommand(null));
    }

    private static void RenameObject(GameObject obj)
    {
        // Use reflection to call the internal method SetRenameOverlay
        var editorAssembly = typeof(Editor).Assembly;
        var sceneHierarchyWindowType = editorAssembly.GetType("UnityEditor.SceneHierarchyWindow");
        var setRenameOverlayMethod = sceneHierarchyWindowType.GetMethod("SetRenameOverlay", BindingFlags.Instance | BindingFlags.NonPublic);

        if (setRenameOverlayMethod != null)
        {
            var focusedWindow = EditorWindow.focusedWindow;
            if (focusedWindow != null && focusedWindow.GetType() == sceneHierarchyWindowType)
            {
                setRenameOverlayMethod.Invoke(focusedWindow, new object[] { obj.GetInstanceID(), null, true });
            }
        }
        else
        {
            Debug.LogWarning("Unable to find SetRenameOverlay method. The rename operation will not be triggered.");
        }
    }
}
