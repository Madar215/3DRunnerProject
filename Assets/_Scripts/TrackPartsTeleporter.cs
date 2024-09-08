using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPartsTeleporter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            transform.position = new Vector3(0, -0.7f, 12.5f);
            Debug.Log("AAAAAA");
        }
    }
}
