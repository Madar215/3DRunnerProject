using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDebug : MonoBehaviour
{
    private float initialDistance;

    private float currentDistance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int touchCount = Input.touchCount;

        if (touchCount < 2)
            return;

        Touch firstTouch = Input.GetTouch(0);
        Touch secondTouch = Input.GetTouch(1);

        if(firstTouch.phase == TouchPhase.Began|| secondTouch.phase == TouchPhase.Began)
        {
            initialDistance = Vector2.Distance(firstTouch.position, secondTouch.position);
        }
        if(firstTouch.phase == TouchPhase.Moved &&  secondTouch.phase == TouchPhase.Moved)
        {
            currentDistance = Vector2.Distance(firstTouch.position,secondTouch.position);
            PrintPinch();
        }
    
    }
    private void PrintPinch()
    {
        if (currentDistance > initialDistance)
        {
            Debug.Log("Pinching In");
        }
        else if (currentDistance < initialDistance) 
        {
            Debug.Log("Pinching Out");
        }
        initialDistance = currentDistance;
    }
 
}
