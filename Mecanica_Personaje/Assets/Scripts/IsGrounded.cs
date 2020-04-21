using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{

    //Variables
    [HideInInspector] public bool is_grouned;

    
    void Awake()
    {

        is_grouned = false;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player") is_grouned = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") is_grouned = false;
    }
}
