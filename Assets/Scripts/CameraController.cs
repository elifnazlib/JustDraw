using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    public float rotationSpeed = 50f;
    
    private float rotationAroundX = 0f;  // For vertical movement of the camera
    private float rotationAroundY = 0f;  // For horizontal movement of the camera

    [SerializeField] Transform playerBody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor in the center of the view
    }
    
    // Update is called once per frame
    void Update()
    {
        // Camera follows the player's position and can look around

        transform.position = new Vector3(playerBody.position.x, 9f, playerBody.position.z);
        rotationAroundY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationAroundX += Input.GetAxis("Mouse Y") * (-1) * mouseSensitivity * Time.deltaTime;

        rotationAroundX = Mathf.Clamp(rotationAroundX, -90f, 50f);
        
        transform.localEulerAngles = new Vector3(rotationAroundX, rotationAroundY, 0f);
    }
}
