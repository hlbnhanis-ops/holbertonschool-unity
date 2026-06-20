// Editor/AssignTeleportLayer.cs
using UnityEngine;
using UnityEditor;

public class AssignTeleportLayer : EditorWindow
{
    [MenuItem("Tools/Assign Teleportable Layer")]
    static void Assign()
    {
        if (Selection.activeGameObject == null)
        {
            Debug.LogWarning("Aucun objet sélectionné.");
            return;
        }

        int layer = LayerMask.NameToLayer("Teleportable");
        if (layer == -1)
        {
            Debug.LogError("Le layer 'Teleportable' n'existe pas. Créez-le dans Project Settings → Tags and Layers.");
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
