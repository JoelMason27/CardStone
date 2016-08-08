using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

    public Transform originalParent = null;
    public bool draggable = true;
    public int tilt;
    private GameObject placeholder = null;

    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnBeginDrag(PointerEventData dragEvent) {
        Debug.Log("[Draggable] OnBeginDrag()");

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);

        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        originalParent = this.transform.parent;
        transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData dragEvent) {
        if (!draggable) { return; }

		transform.position = dragEvent.position;

        int newSiblingIndex = originalParent.childCount;

        for (int i = 0; i < originalParent.childCount; i++) {
            if (this.transform.position.x < originalParent.GetChild(i).transform.position.x){
                newSiblingIndex = i;
                if(placeholder.transform.GetSiblingIndex() < newSiblingIndex) {
                    newSiblingIndex--;
                }
                break;
            }
        }
        placeholder.transform.SetSiblingIndex(newSiblingIndex);

        rb.rotation = Quaternion.Euler(dragEvent.delta.y * -tilt, dragEvent.delta.x * -tilt, 0.0f);
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("[Draggable] OnEndDrag()");
        transform.SetParent(originalParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Destroy(placeholder);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
    }
	
}
