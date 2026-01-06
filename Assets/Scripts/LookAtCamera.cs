using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private enum Mode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted
    }

    [SerializeField] private Mode mode;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void LateUpdate()
    {
        if (cam == null) return;

        switch (mode)
        {
            case Mode.LookAt:
                transform.LookAt(cam.transform);
                break;

            case Mode.LookAtInverted:
                Vector3 directionFromCamera = transform.position - cam.transform.position;
                transform.LookAt(transform.position + directionFromCamera);
                break;

            case Mode.CameraForward:
                transform.forward = cam.transform.forward;
                break;

            case Mode.CameraForwardInverted:
                transform.forward = -cam.transform.forward;
                break;
        }
    }
}
