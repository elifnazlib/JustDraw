using UnityEngine;
using UnityEngine.SceneManagement;

// This script controls the player movement and rotation in the game.
// It allows the player to move forward, backward, and turn left or right using keyboard inputs.
// The player is restricted to a certain area defined by boundaries.
// When the game ends, the player's mesh renderer is disabled, and pressing 'N' will return to the menu scene.
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;   // Speed of the player
    public float rotationSpeed = 1000f;   // How fast the player turns - smoothly
    private float targetYaw;   // Target angle for rotation around Y-axis
    public int colorChangeCount = 0;   // For setting the first chosen color when game starts
    private CameraController _cameraController;   // Reference to the CameraController script

    private void Start()
    {
        targetYaw = transform.eulerAngles.y;   // Saving the starting angle
        _cameraController = (CameraController)FindFirstObjectByType(typeof(CameraController));   // Getting the CameraController script
    }

    void Update()
    {
        if (_cameraController.isGameEnded == false)
        {
            Vector3 move = Vector3.zero;

            // Inputs for going forward and backward
            // Player cannot exceed the boundaries

            if (Input.GetKey(KeyCode.W))
            {
                if (transform.position.x > 44f)
                {
                    transform.position = new Vector3(43.8f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x < -44f)
                {
                    transform.position = new Vector3(-43.8f, transform.position.y, transform.position.z);
                }
                else if (transform.position.z > 44f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 43.8f);
                }
                else if (transform.position.z < -44f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, -43.8f);
                }
                else move += transform.forward;
            }


            if (Input.GetKey(KeyCode.S))
            {
                if (transform.position.x > 44f)
                {
                    transform.position = new Vector3(43.8f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x < -44f)
                {
                    transform.position = new Vector3(-43.8f, transform.position.y, transform.position.z);
                }
                else if (transform.position.z > 44f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 43.8f);
                }
                else if (transform.position.z < -44f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, -43.8f);
                }
                else move -= transform.forward;
            }


            transform.position += moveSpeed * Time.deltaTime * move;

            // Inputs for rotating right or left

            if (Input.GetKeyDown(KeyCode.A))
                targetYaw -= 90f;

            if (Input.GetKeyDown(KeyCode.D))
                targetYaw += 90f;


            // Rotate the current angle to the target angle smoothly

            float currentYaw = transform.eulerAngles.y;
            currentYaw = Mathf.MoveTowardsAngle(currentYaw, targetYaw, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0f, currentYaw, 0f);
        }
        else
        {
            Transform nose = transform.Find("nose");
            // transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            // transform.GetComponent<MeshRenderer>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            nose.GetComponent<MeshRenderer>().enabled = false;
        }

        
        // If the game ends, pressing 'N' will return to the menu scene and unlock the cursor

        if (Input.GetKeyDown(KeyCode.N) && _cameraController.isGameEnded == true)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadSceneAsync("Menu");
        }
    }
}
