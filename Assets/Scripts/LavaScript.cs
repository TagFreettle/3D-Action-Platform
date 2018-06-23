using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour {
    private

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // This is called
    void OnCollisionEnter(Collision collisionObject)
    {
        Debug.Log("Collision Detected.");
        if (collisionObject.gameObject.CompareTag("Player"))
        {
            // Detected player collision
            PlayerCharacterScript PlayerCharacterScriptObject;
            PlayerCharacterScriptObject = collisionObject.gameObject.GetComponent<PlayerCharacterScript>();
            PlayerCharacterScriptObject.CurrentHealth -= 1;
            Debug.Log("Player Health Decremented.");
        }
    }
}
