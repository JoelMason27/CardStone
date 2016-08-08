using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

	public virtual void OnDrop(PointerEventData eventData) {
        Debug.Log("[DropZone] OnDrop()");

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null) {
            d.originalParent = this.transform;
        }
    }
}
