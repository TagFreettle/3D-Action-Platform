using UnityEngine;
using System.Collections;

public class TestExplosionScript : MonoBehaviour
{
    void Start()
    {
 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "MainCharacterPlayer")
        {
            Destroy(collision.gameObject);
        }
    }
}