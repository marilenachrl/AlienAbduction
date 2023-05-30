using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public GameObject lightObject;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(collision.TryGetComponent(out SwitchLight Light))
            {
                Light.spotLight = lightObject;
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent(out SwitchLight Light))
            {
                Light.spotLight = null;
            }
        }
    }
}
