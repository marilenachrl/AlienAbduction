using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchLight : MonoBehaviour
{
    public GameObject spotLight = null;
    private bool lightOn;

    public void isPressed()
    {
        if(spotLight != null)
        {
            lightOn = !spotLight.activeInHierarchy;
            spotLight.SetActive(lightOn);
        }   
    }

    public void OnLight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isPressed();
        }
  
    }






}
