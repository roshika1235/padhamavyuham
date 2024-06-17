using UnityEngine;


public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float minFOV = 15f;
    public float maxFOV = 90f;

    void Update()
    {
        float scrollData;
#if UNITY_EDITOR
        scrollData = Input.GetAxis("Mouse ScrollWheel");
#elif UNITY_ANDROID || UNITY_IOS
        // Implement touch zoom logic for mobile here, if needed
        scrollData = 0f;
#endif
        if (scrollData != 0.0f)
        {
            Camera.main.fieldOfView -= scrollData * zoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFOV, maxFOV);
        }
    }
}

