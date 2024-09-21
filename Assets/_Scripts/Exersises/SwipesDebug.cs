using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class SwipesDebug : MonoBehaviour
{
    private Vector2 swipeStartPosition;
    private Vector2 swipeEndPosition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int touchCount = Input.touchCount;

        if (touchCount < 1)
            return;

        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                // Handle touch start
                Debug.Log("Touch " + 0 + " started at position " + touch.position);
                swipeStartPosition = touch.position;
                break;
            case TouchPhase.Ended:
                // Handle touch end
                Debug.Log("Touch " + 0 + " ended at position " + touch.position);
                swipeEndPosition = touch.position;
                PrintSwipe();
                break;
        }
    }

    private void PrintSwipe()
    {
        float xMove = Mathf.Abs(swipeStartPosition.x - swipeEndPosition.x);
        float yMove = Mathf.Abs(swipeStartPosition.y - swipeEndPosition.y);
        if (xMove > 100 || yMove > 100)
        {
            if (xMove > yMove)
            {
                if(swipeEndPosition.x - swipeStartPosition.x > 0)
                {
                    Debug.Log("Right");
                }
                else
                {
                    Debug.Log("Left");
                }
            }
            else
            {
                if (swipeEndPosition.y - swipeStartPosition.y > 0)
                {
                    Debug.Log("Up");
                }
                else
                {
                    Debug.Log("Down");
                }
            }
        }
    }
}
