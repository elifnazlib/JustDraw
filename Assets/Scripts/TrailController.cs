using UnityEngine;

public class TrailController : MonoBehaviour
{
    [SerializeField] GameObject trailPrefab;
    [SerializeField] GameObject player;
    [SerializeField] Material greenMaterial;
    private bool isReleased = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && isReleased == false)
        {
            isReleased = true;
            GameObject clone = Instantiate(trailPrefab, transform.parent, false);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y + 0.0005f, clone.transform.position.z);
            transform.SetParent(null, true);
            clone.GetComponent<TrailRenderer>().material = greenMaterial;
        }
    }
}
