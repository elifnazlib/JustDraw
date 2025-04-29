using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;   // Speed of the player
    public float rotationSpeed = 1000f;   // How fast the player turns - smoothly
    private float targetYaw;   // Target angle for rotation around Y-axis
    public int colorChangeCount = 0;   // For setting the first chosen color when game starts
    private CameraController _cameraController;

    private void Start()
    {
        targetYaw = transform.eulerAngles.y;   // Saving the starting angle
        _cameraController = (CameraController)FindFirstObjectByType(typeof(CameraController));
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

            // Inputs for turning right or left

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
    }
}
