using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dots : MonoBehaviour
{
    public GameObject[] DotsObjects;
    public Camera Camera;

    private RectTransform[] rectTransforms;


    // Start is called before the first frame update
    void Start()
    {
        rectTransforms = new RectTransform[DotsObjects.Length];
        for(int i = 0; i < DotsObjects.Length; i++)
        {
            rectTransforms[i] = DotsObjects[i].GetComponent<RectTransform>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        int touchCount = Input.touchCount;

        if (touchCount != 1)
            return;

        Touch touch = Input.GetTouch(0);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransforms[0], touch.position, Camera, out Vector2 localPoint);
        if (rectTransforms[0].rect.Contains(localPoint))
        {
            DotsObjects[0].SetActive(false);
        }
        else
        {
            Debug.Log(localPoint);
        }
    }
}
