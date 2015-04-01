using UnityEngine;
using System.Collections;

public class CoinHolderInstance : MonoBehaviour {

	void Awake () {
		if(GameObject.Find ("CoinCount") == null) {
			GameObject coinCount = new GameObject ("CoinCoint");
			coinCount.AddComponent <GetCoins> ();
			//Instantiate (coinCount);
		}
	}

}
