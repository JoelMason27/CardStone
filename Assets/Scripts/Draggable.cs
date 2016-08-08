using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler {

	void OnBeginDrag(PointerEventData dragEvent) {

	}

	public void OnDrag(PointerEventData dragEvent) {
		this.transform.position = dragEvent.position;
	}
	
}
