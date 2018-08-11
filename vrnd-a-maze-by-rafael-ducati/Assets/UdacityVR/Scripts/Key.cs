using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	// TODO: Create variables to reference the game objects we need access to
	// Declare a GameObject named 'keyPoofPrefab' and assign the 'KeyPoof' prefab to the field in Unity
	public GameObject keyPoofPrefab;

	// Declare a Door named 'door' and assign the top level 'Door' game object to the field in Unity
	public GameObject door;

	public float speedRotationKey = 100;

	void Update () {
		// OPTIONAL-CHALLENGE: Animate the key rotating
		// TIP: You could use a method from the Transform class
		transform.Rotate(Vector3.forward, speedRotationKey * Time.deltaTime);
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + (Mathf.Sin (Time.time * 5.0f) / 50f), this.transform.position.z);

	}

	
	public void OnKeyClicked () {
		/// Called when the 'Key' game object is clicked
		/// - Unlocks the door (handled by the Door class)
		/// - Displays a poof effect (handled by the 'KeyPoof' prefab)
		/// - Plays an audio clip (handled by the 'KeyPoof' prefab)
		/// - Removes the key from the scene


		// TODO: Unlock the door, display the poof effect, and remove the key from the scene
		// Use 'door' to call the Door.Unlock() method
		door.GetComponent<Door>().Unlock();
		door.GetComponent<Door>().foundKey = true; // testing var pass to another script
		door.GetComponent<Door>().testMsg = "Passing testMsg"; // testing var pass to another script

		
		// Use Instantiate() to create a clone of the 'KeyPoof' prefab at this coin's position and with the 'KeyPoof' prefab's rotation
		Vector3 keyPos = transform.position;
		GameObject newKeyPoof = (GameObject)Object.Instantiate(keyPoofPrefab, new Vector3(keyPos[0], keyPos[1], keyPos[2]) , Quaternion.Euler(-90, 0, 0));
		Debug.Log ("'foundKey' its " + door.GetComponent<Door>().foundKey);
		Debug.Log ("'testMsg' its " + door.GetComponent<Door>().testMsg);
		// Use Destroy() to delete the key after for example 0.5 seconds
		Destroy (this.gameObject, 0.5f);
	}
}
