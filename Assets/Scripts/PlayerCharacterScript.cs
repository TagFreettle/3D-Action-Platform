using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour {
    public float MaxHealth { get; set; } /* Maximum health */
    public float CurrentHealth { get; set; }
    private bool Alive = true;

    /// <summary>
    /// Test Summary
    /// </summary>
    public float Speed = 6.0F;
    public float JumpSpeed = 9.0F; // Movement speeds
    public float Gravity = 20.0F; // Gravity of object

    private float Zoom = 8;
    private Vector3 moveDirection = Vector3.zero;

    private GameObject CameraObject;
    private GameObject CameraRotationObject;
    private GameObject HUDCanvas;

    // Use this for initialization
    void Start() {
        CameraObject = this.gameObject.transform.Find("Camera").gameObject;

        // Initalize the camera rotation object.
        CameraRotationObject = new GameObject("CameraRotationObject");
        CameraRotationObject.transform.parent = this.transform;
        CameraRotationObject.transform.position = this.transform.position;
        CameraRotationObject.transform.rotation = this.transform.rotation;

        MaxHealth = 8;
        CurrentHealth = 4;
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // Check if the character is grounded and if so do the following actions.
        if (controller.isGrounded)
        {
            // Move the character.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= Speed;
        
            if (Input.GetButton("Jump"))
                moveDirection.y = JumpSpeed;

        }


        // Move the character in the y axis
        moveDirection.y -= Gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        // Rotate the camera rotation object.
        if (Input.GetMouseButton(1) == true) {
            CameraRotationObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")*9, 0));
        }

        // Rotate the camera
        CameraObject.transform.SetPositionAndRotation(CameraRotationObject.transform.position - (CameraRotationObject.transform.forward * Zoom) + new Vector3(0, 2, 0), CameraRotationObject.transform.rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MainCharacterPlayer")
        {
            //Destroy(collision.gameObject);
        }
    }

    // Do damage to the character.
    void DoDamage(float damageValue)
    {
        CurrentHealth = CurrentHealth - damageValue;
        if (CurrentHealth == 0f)
        {
            KillCharacter(); // You have no health.
        }
    }

    // Restore health for the character.
    void DoHealing(float healValue)
    {
        CurrentHealth = CurrentHealth + healValue;
    }

    // Cause the character to be defeated automatically.
    void KillCharacter()
    {
        CurrentHealth = 0;
        Alive = false;
    }
}
