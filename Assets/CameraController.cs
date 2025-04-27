using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 15f;
    public float rotationSpeed = 50f;
    
    private float rotationAroundX = 0f;  // Kamera'nın dikey hareketi için değişken
    private float rotationAroundY = 0f;  // Kamera'nın yatay hareketi için değişken

    [SerializeField] Transform playerBody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        Cursor.lockState = CursorLockMode.Locked; // Mouse'u ekranın ortasına kitler
    }

    void Update()
    {
        transform.position = new Vector3(playerBody.position.x, playerBody.position.y + 20f, playerBody.position.z);
        rotationAroundY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationAroundX += Input.GetAxis("Mouse Y") * (-1) * mouseSensitivity * Time.deltaTime;

        rotationAroundX = Mathf.Clamp(rotationAroundX, -90f, 90f);
        
        transform.localEulerAngles = new Vector3(rotationAroundX, rotationAroundY, 0f);
    }
}
