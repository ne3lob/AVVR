using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceObject : MonoBehaviour
{
    public GameObject target;

    public float speed ;
    private SyntHTable syntHTableScript;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        syntHTableScript = GameObject.Find("======== VR MANAGMENT ========").GetComponent<SyntHTable>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = syntHTableScript.speedTurn;
        transform.RotateAround(target.transform.position, Vector3.up, speed  * Time.deltaTime);
    }
}
