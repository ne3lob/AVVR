using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundWithPlayerCollider : MonoBehaviour
{
    [SerializeField] public Camera cam;

    private void Update()
    {
        Rotate();
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            cam.cullingMask |= 1 << LayerMask.NameToLayer("Not");
            Debug.Log("trigger");
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Not"));
            Debug.Log("trigger");
        }
    }

    private void Rotate()
    {
        this.transform.Rotate(0, 5 * Time.deltaTime, 0);
    }
}