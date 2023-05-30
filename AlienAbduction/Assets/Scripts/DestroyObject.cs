using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Citizen")
        {
            Destroy(collision.gameObject);

            SpawnObject.newScore();

        }
    }



}
