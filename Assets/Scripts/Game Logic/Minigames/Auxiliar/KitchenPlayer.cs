using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPlayer : MonoBehaviour
{
    public bool End {get; set;}
    public bool Death {get; set;}


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fin")
        {
            End = true;
        }

        if (other.tag == "Muerte")
        {
            Death = true;
        }
    }
}
