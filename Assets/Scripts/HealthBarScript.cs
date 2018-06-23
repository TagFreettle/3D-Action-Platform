using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour {
    public GameObject PlayerGameObject;
    private PlayerCharacterScript PlayerCharacterScriptObject;
    public GameObject HealthBar;
    public GameObject HealthBarOverlay;
    private RectTransform HelathBarRectTransform;
    private RectTransform HealthBarOverlayRectTransform;

    // Use this for initialization
    void Start () {
        // Get objects that aren't set by me in the Unity editor.
        PlayerCharacterScriptObject = PlayerGameObject.GetComponent<PlayerCharacterScript>();

        HelathBarRectTransform = HealthBar.GetComponent<RectTransform>();
        HealthBarOverlayRectTransform = HealthBarOverlay.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        HealthBarOverlayRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PlayerCharacterScriptObject.CurrentHealth/PlayerCharacterScriptObject.MaxHealth*HelathBarRectTransform.sizeDelta.x);

    }
}
