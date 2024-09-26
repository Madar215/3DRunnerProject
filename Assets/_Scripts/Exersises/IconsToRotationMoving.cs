using DG.Tweening;
using UnityEngine;

public class IconsToRotationMoving : MonoBehaviour
{
    [SerializeField] private IconsParametersScriptableObject _iconsParameters;
    [SerializeField] private IconType _iconType;
    private Vector3 targetPosition;

    private DeviceOrientation _previousOrientation;
    public float duration = 2.0f; // Duration of the movement

    void Start()
    {
        
        _previousOrientation = Input.deviceOrientation;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_previousOrientation != Input.deviceOrientation)
        {
            _previousOrientation = Input.deviceOrientation;
            GetOrientationAndMove();
        }
    }

    void GetOrientationAndMove()
    {
        if (Input.deviceOrientation == DeviceOrientation.Portrait || Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown) 
        {
            if (_iconType == IconType.Heart) 
            {
                targetPosition = new Vector3(_iconsParameters.HeartPortraitX, _iconsParameters.HeartPortraitY, 0);
            }
            else
            {
                targetPosition = new Vector3(_iconsParameters.StarPortraitX, _iconsParameters.StarPortraitY, 0);
            }
        }
        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            if (_iconType == IconType.Heart)
            {
                targetPosition = new Vector3(_iconsParameters.HeartLandscapeX, _iconsParameters.HeartLandscapeY, 0);
            }
            else
            {
                targetPosition = new Vector3(_iconsParameters.StarLandscapeX, _iconsParameters.StarLandscapeY, 0);
            }
        }
        transform.DOMove(targetPosition, duration);
    }

    public enum IconType
    {
        Heart,
        Star
    }
}
