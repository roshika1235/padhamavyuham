using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;
    public Camera cam1;
    public Camera cam2;

    void Start()
    {
        cam1.gameObject.AddComponent<CinemachineBrain>();
        cam2.gameObject.AddComponent<CinemachineBrain>();

        cam1.GetComponent<CinemachineBrain>().enabled = true;
        cam2.GetComponent<CinemachineBrain>().enabled = true;

        // Initially set the cameras to follow their respective players
        vcam1.Priority = 10;
        vcam2.Priority = 10;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            vcam1.Priority = 20;
            vcam2.Priority = 10;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            vcam1.Priority = 10;
            vcam2.Priority = 20;
        }
    }
}

