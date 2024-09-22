﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class WebcamCapture2 : MonoBehaviour
{
    public RawImage displayImage;
    private WebCamTexture webCamTexture;
    private Texture2D capturedImage;

    void Start()
    {
        webCamTexture = new WebCamTexture();
        displayImage.texture = webCamTexture;
        webCamTexture.Play();
    }

    void OnDestroy()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            webCamTexture.Stop();
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("sheeeese");
            CaptureAndSaveImage();
        }
    }

    public void CaptureAndSaveImage()
    {
        StartCoroutine(CaptureAndSave());
    }

    private IEnumerator CaptureAndSave()
    {
        // Wait for the end of the frame to ensure the webcam feed is updated
        yield return new WaitForEndOfFrame();

        // Create a new Texture2D with the webcam resolution
        capturedImage = new Texture2D(webCamTexture.width, webCamTexture.height);
        
        // Read the pixels from the webcam feed into the texture
        capturedImage.SetPixels(webCamTexture.GetPixels());
        capturedImage.Apply();

        // Encode the texture to PNG
        byte[] bytes = capturedImage.EncodeToPNG();

        // Save the PNG to the persistent data path
        string filePath = Path.Combine(Application.persistentDataPath, "capturedImage.png");
        File.WriteAllBytes(filePath, bytes);
        Debug.Log("Image saved to: " + filePath);
    }
}