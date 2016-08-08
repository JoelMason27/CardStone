using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TableDropZone : DropZone {

    public override void OnDrop(PointerEventData eventData)
    {
        Debug.Log("[TableDropZone] OnDrop()");
        base.OnDrop(eventData);

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        CardData c = d.GetComponent<CardController>().cardData;
        
        if (this.transform.childCount == 0) // if this is empty
        {
            Debug.Log("[TableDropZone] OnDrop() slotting new card");
            // Mark this as no longer draggable - it has been slotted here
            d.draggable = false;
        } 
        else if (c.Value > (this.transform.GetChild(0).gameObject as GameObject).GetComponent<CardController>().cardData.Value) // the card is larger than the current
        {
            Debug.Log("[TableDropZone] OnDrop() slotting new card");
            Destroy(this.transform.GetChild(0).gameObject); // destroy the current card
            d.draggable = false;
        } 
        else // the card dragged on is not sufficiently larger
        {
            Debug.Log("[TableDropZone] OnDrop() destroying new card");
            Destroy(d.gameObject);
        }
    }
}
