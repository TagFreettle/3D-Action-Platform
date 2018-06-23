using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedMovementScript : MonoBehaviour {

    public Vector3 Position1 = new Vector3(0, 0, 0); // The first target position of the object
    public Vector3 Position2 = new Vector3(0, 5, 0); // The second target position of the object
    public float TweenTime = 5; // The time it takes to gradually transition from one position to another
    public float PauseTime = 0; // The time the movement pauses after reaching a target position

    private bool CurrentPostitionTargetAtSecondPosition = true; // Set to true if we're supposed to move from the second position to the first, and false if vice versa
    private bool PauseState = false; // Determines if we are supposed to pause the movement for a while
    private float CurrentTime = 0; // The current time in the tweening/pausing state

    // Use this for initialization
    void Start () {
        CurrentTime = 0;
        this.gameObject.transform.position = Position1;
    }
	
	// Update is called once per frame
	void Update () {
        CurrentTime = CurrentTime + Time.deltaTime;
        if (PauseState == false)
        {
            if (CurrentPostitionTargetAtSecondPosition == true)
            {
                this.gameObject.transform.position = Vector3.Lerp(Position2, Position1, CurrentTime / TweenTime);
            } else
            {
                this.gameObject.transform.position = Vector3.Lerp(Position1, Position2, CurrentTime / TweenTime);
            }
            if (CurrentTime > TweenTime)
            {
                PauseState = true;
                CurrentTime = 0;
                CurrentPostitionTargetAtSecondPosition = !CurrentPostitionTargetAtSecondPosition;
            }
        }
        else
        {
            if (CurrentTime > PauseTime)
            {
                PauseState = false;
                CurrentTime = 0;
            }
        }
    }
}
