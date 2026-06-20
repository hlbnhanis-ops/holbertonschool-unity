using UnityEngine;
using UnityEditor;

public class AssignTeleportBlocker : EditorWindow
{

    [MenuItem("Tools/Assign Teleport Blocker Layer")]
    static void Assign()
    {
        if (Selection.activeGameObject == null)
        {
            Debug.LogWarning("Aucun objet selectionné.");
        }

        int layer = LayerMask.NameToLayer("Teleport Blocker");
        if (layer == -1)
        {
            Debug.LogError("Le layer 'Teleport Blocker' n'existe pas!");
            return;
        }

        int count = 0;
        foreach (var col in Selection.activeGameObject.GetComponentsInChildren<Collider>())
        {
            col.gameObject.layer = layer;
            count++;
        }

        Debug.Log($"{count} objet(s) assignés au layer Teleportable.");
    }

}

