using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardController : MonoBehaviour {

	public Text titleText;

    public CardData cardData;

	private int value;

	// Use this for initialization
	void Start () {
	
	}

	public void SetValues(int p_value) {
		Debug.Log ("[CardController] SetValues()");

        this.cardData = new CardData(p_value);

		if (titleText != null) {
			titleText.text = this.cardData.Value.ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class CardData {

    private int value;

    public int Value {
        get {
            return value;
        }
    }

    public CardData(int p_value) {
        value = p_value;
    }
}
