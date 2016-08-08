using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardController : MonoBehaviour {

	public Text titleText;

	private int value;

	// Use this for initialization
	void Start () {
	
	}

	public void SetValues(int p_value) {
		Debug.Log ("[CardController] SetValues()");

		value = p_value;

		if (titleText != null) {
			titleText.text = value.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
