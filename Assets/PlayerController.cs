using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 300f; // Derece/sn (ne kadar hızlı dönecek)
    private float targetYaw; // Hedef açı
    [SerializeField] Camera playerCamera;

    private void Start()
    {
        targetYaw = transform.eulerAngles.y; // Başlangıç açısını kaydet
    }

    // void Update()
    // {
    //     Vector3 position = transform.position;
    //     if (Input.GetKey(KeyCode.W))
    //     {
    //         position.z += 0.1f;
    //     }
    //     if (Input.GetKeyDown(KeyCode.A))
    //     {
    //         transform.Rotate(Vector3.up, -90f);
    //     }
    //     if (Input.GetKeyDown(KeyCode.D))
    //     {
    //         transform.Rotate(Vector3.up, 90f);
    //     }

    //     transform.position = position;
    // }

    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            move += transform.forward;
        if (Input.GetKey(KeyCode.S))
            move -= transform.forward;

        transform.position += move * moveSpeed * Time.deltaTime;

        // Dönüş inputları
        if (Input.GetKeyDown(KeyCode.A))
            targetYaw -= 90f;
        if (Input.GetKeyDown(KeyCode.D))
            targetYaw += 90f;

        // // Mevcut dönüşü hedef açıya doğru yaklaştır
        // float currentYaw = transform.eulerAngles.y;
        // currentYaw = Mathf.MoveTowardsAngle(currentYaw, targetYaw, rotationSpeed * Time.deltaTime);
        // transform.eulerAngles = new Vector3(0f, currentYaw, 0f);

        transform.eulerAngles = new Vector3(0f, targetYaw, 0f);

    }
}
