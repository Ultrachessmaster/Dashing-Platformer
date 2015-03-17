using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetCoins : MonoBehaviour {
		private int coins;

		public void getCoins (int coins) {
				this.coins += coins;
				GameObject.FindGameObjectWithTag ("Coin Count").GetComponent <Text> ().text = this.coins.ToString ();
				GameObject.Find ("coinSound").GetComponent <AudioSource> ().Play ();
		}


}
