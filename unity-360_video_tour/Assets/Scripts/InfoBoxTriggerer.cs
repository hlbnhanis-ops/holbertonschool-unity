using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoBoxTriggerer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public List<(GameObject Obj, Vector3 BasePos)> Childs = new();

    void Start()
    {
        foreach (Transform child in transform)
        {
            Childs.Add((child.gameObject, new Vector3(
                // SET CHILD LOCAL POSITIONS TO POSITIVE
                child.gameObject.transform.localPosition.x < 0 ? -child.gameObject.transform.localPosition.x : child.gameObject.transform.localPosition.x,
                child.gameObject.transform.localPosition.y < 0 ? -child.gameObject.transform.localPosition.y : child.gameObject.transform.localPosition.y,
                child.gameObject.transform.localPosition.z < 0 ? -child.gameObject.transform.localPosition.z : child.gameObject.transform.localPosition.z
            )));
            child.gameObject.transform.localPosition = Vector3.zero;
            child.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = Vector3.one * 1.4f;

        Camera cam = Camera.main;

        Vector3 viewport = cam.WorldToViewportPoint(transform.position);

        float signX = viewport.x < 0.5f ? 1f : -1f;
        float signY = viewport.y < 0.5f ? 1f : -1f;

        foreach (var child in Childs)
        {
            Vector3 basePos = child.BasePos;

            child.Obj.transform.localPosition = new Vector3(
                basePos.x * signX,
                basePos.y * signY,
                basePos.z
            );

            child.Obj.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        foreach (var child in Childs)
        {
            child.Obj.SetActive(false);
            child.Obj.transform.localPosition = Vector3.zero;
        }
            
    }
}