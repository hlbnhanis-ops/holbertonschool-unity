using UnityEngine;
using UnityEditor;
using Oculus.Interaction;

public class AssignGrabbable : EditorWindow
{

    [MenuItem("Tools/Assign Grabbable")]
    static void Assign()
    {
        foreach (var go in Selection.gameObjects)
        {

            var rigidBody = go.GetComponent<Rigidbody>();
            if (rigidBody == null)
            {
                Debug.LogError("L'objet n'a pas de rigidBody!");
                return;
            }

            var grabbable = go.GetComponent<Grabbable>() ?? go.AddComponent<Grabbable>();
            var grab = go.GetComponent<GrabInteractable>() ?? go.AddComponent<GrabInteractable>();
            var colorVisual = go.GetComponent<InteractableColorVisual>() ?? go.AddComponent<InteractableColorVisual>();
            var mpbEditor = go.GetComponent<MaterialPropertyBlockEditor>() ?? go.AddComponent<MaterialPropertyBlockEditor>();

            grabbable.InjectOptionalRigidbody(rigidBody);
            grab.InjectRigidbody(rigidBody);
            grab.InjectOptionalPointableElement(grabbable);
            colorVisual.InjectInteractableView(grab);
            colorVisual.InjectMaterialPropertyBlockEditor(mpbEditor);

            Debug.Log("Setup terminé sur " + go.name);
        }
    }
}
