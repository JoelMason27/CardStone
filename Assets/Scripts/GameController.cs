using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject card;

	// Use this for initialization
	void Start () {
		AddCard ();
	}

	void AddCard() {
		GameObject _card = Instantiate (card, Vector3.zero, Quaternion.identity) as GameObject;
		AddToCanvas (_card);
		CardController _cc = _card.GetComponent<CardController> ();
		_cc.SetValues(Random.Range(0, 10));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void AddToCanvas(GameObject p_object){
		p_object.transform.SetParent((GameObject.FindGameObjectWithTag ("Canvas")).transform);
	}

}