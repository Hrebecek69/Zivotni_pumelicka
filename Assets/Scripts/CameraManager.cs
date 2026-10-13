using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    /*////////////////////////////////////////   
            kód pro funkční kameru
    /*////////////////////////////////////////
    [SerializeField] private CinemachineCamera cinemachineCamera;
    [SerializeField] private GameObject cameraTarget;
    [SerializeField] private float cameraDragSpeed;

    [SerializeField] private float zoomSpeed;
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;

        if (mainCamera == null)
        {
            Debug.Log("Camera nebyla nalezena/vytvořena");
        }
    }

    private void Update()
    {
        HandleDrag();
        HandleZoom();
    }

    private void HandleDrag()
    {
        if (Mouse.current.middleButton.isPressed)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            Vector3 move = new Vector3(
                -mouseDelta.x * cameraDragSpeed * Time.deltaTime,
                0,
                -mouseDelta.y * cameraDragSpeed * Time.deltaTime);

            cameraTarget.transform.Translate(move, Space.World);
        }
    }

    private void HandleZoom()
    {
        float scroll = Mouse.current.scroll.y.ReadValue();

        float currentSize = cinemachineCamera.Lens.OrthographicSize;
        float newSize = currentSize - (scroll * zoomSpeed);

        cinemachineCamera.Lens.OrthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
    }
}
