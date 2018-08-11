using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Coin : MonoBehaviour {

	// TODO: Create variables to reference the game objects we need access to
	// Declare a GameObject named 'coinPoofPrefab' and assign the 'CoinPoof' prefab to the field in Unity
	public GameObject coinPoofPrefab;

	public float speedRotation = 100f;

	public static bool collectCoins;

	private static int count;

	public Text countText;

	private static string commentary;

	public Text countCommentary;
	
	public void Start () {
		count = 0;
		SetTexts ();
		
	}


	public void Update () {
		// OPTIONAL-CHALLENGE: Animate the coin rotating
		// TIP: You could use a method from the Transform class
		transform.Rotate(Vector3.up, speedRotation * Time.deltaTime);
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + (Mathf.Sin (Time.time * 5.0f) / 50f), this.transform.position.z);

	}


	public void OnCoinClicked () {
		/// Called when the 'Coin' game object is clicked - OK
		/// Displays a poof effect (handled by the 'CoinPoof' prefab) - OK
		/// Plays an audio clip (handled by the 'CoinPoof' prefab) - OK
		/// Removes the coin from the scene - OK
		/// Prints to the console when the method is called - OK

		count++;

		SetTexts ();

		collectCoins = true;

		Debug.Log("count: " + count + "/7");

		Vector3 coinPos = transform.position;
		Debug.Log("posicao da moeda: " + coinPos);
		// TODO: Display the poof effect and remove the coin from the scene - OK
		// Use Instantiate() to create a clone of the 'CoinPoof' prefab at this coin's position and with the 'CoinPoof' prefab's rotation - OK
		GameObject newPoof = (GameObject)Object.Instantiate(coinPoofPrefab, new Vector3(coinPos[0], coinPos[1], coinPos[2]) , Quaternion.Euler(-90, 0, 0));
		// Use Destroy() to delete the coin after for example 0.5 seconds - OK		
		Destroy (this.gameObject, 0.5f);

	}

	public void SetTexts () {
		// shows different comments at final signpost, depending on quanity of clicked coins
		switch (count)
		{
		  case 1:
		      commentary = "You did it.";
		      break;
		  case 2:
		      commentary = "Keep going!";
		      break;
		  case 3:
		      commentary = "Awesome.";
		      break;
		  case 4:
		      commentary = "You win.";
		      break;
		  case 5:
		      commentary = "Very good.";
		      break;
		  case 6:
		      commentary = "Congrats.";
		      break;
		  case 7:
		      commentary = "Perfect!";
		      break;
		  default:
		      commentary = "Who needs money? ;)";
		      break;
		}

		countText.text = "Coins: " + count.ToString() + "/7 ";
		countCommentary.text = commentary;

	}
}

