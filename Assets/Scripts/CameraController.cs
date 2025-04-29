using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 300f;
    public float rotationSpeed = 50f;

    private float rotationAroundX = 0f;  // For vertical movement of the camera
    private float rotationAroundY = 0f;  // For horizontal movement of the camera

    [SerializeField] Transform playerBody;

    public bool isGameEnded = false;    // For checking if the game is ended

    private Vector3 startPosition;
    private Vector3 endPosition = new Vector3(0, 85f, 0);

    private Quaternion startRotation;
    private Quaternion endRotation = Quaternion.Euler(90f, 0f, 0f);

    private float desiredDuration = 5f; // Duration of the lerp
    private float elapsedTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor in the center of the view
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            // Ending the game

            isGameEnded = true;
            startPosition = transform.position;
            startRotation = transform.rotation;
        }

        if (isGameEnded == false)
        {
            // Camera follows the player's position and can look around

            transform.position = new Vector3(playerBody.position.x, 9f, playerBody.position.z);
            rotationAroundY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            rotationAroundX += Input.GetAxis("Mouse Y") * (-1) * mouseSensitivity * Time.deltaTime;

            rotationAroundX = Mathf.Clamp(rotationAroundX, -90f, 50f);

            transform.localEulerAngles = new Vector3(rotationAroundX, rotationAroundY, 0f);
        }

        if (isGameEnded == true)
        {
            // When game ends, the camera lerps and looks down from the top
            
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            transform.SetPositionAndRotation(Vector3.Lerp(startPosition, endPosition, percentageComplete), Quaternion.Slerp(startRotation, endRotation, percentageComplete));
        }
    }
}
