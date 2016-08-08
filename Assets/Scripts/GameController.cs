using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject card;

	// Use this for initialization
	void Start () {
		AddCards(5);
	}

    void AddCards(int numCards){
        for (int i = 0; i < numCards; i++)
        {
            AddCard();
        }
    }

	void AddCard() {
		GameObject _card = Instantiate (card, Vector3.zero, Quaternion.identity) as GameObject;
		CardController _cc = _card.GetComponent<CardController> ();
		_cc.SetValues(Random.Range(0, 10));
        AddToHand(_card);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void AddToHand(GameObject p_object){
        GameObject hand = (GameObject.FindGameObjectWithTag("Hand"));
        p_object.transform.position = hand.transform.position;
        p_object.transform.rotation = hand.transform.rotation;

        p_object.transform.SetParent(hand.transform);
	}

}