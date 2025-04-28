using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;   // Speed of the player
    public float rotationSpeed = 1000f; // How fast the player turns - smoothly
    private float targetYaw; // Target angle for rotation around Y-axis
    [SerializeField] Camera playerCamera;   // Camera following the player

    private void Start()
    {
        targetYaw = transform.eulerAngles.y; // Saving the starting angle
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        // Inputs for going forward and backward

        if (Input.GetKey(KeyCode.W))
            move += transform.forward;
        
        if (Input.GetKey(KeyCode.S))
            move -= transform.forward;

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
}
