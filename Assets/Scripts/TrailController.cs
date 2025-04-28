using UnityEngine;

public class TrailController : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField] GameObject trailPrefab;
    [SerializeField] GameObject player;
    private Material firstMaterial;
    private Material secondMaterial;
    private Material thirdMaterial;
    [SerializeField] Material defaultMaterial;
    private bool isReleased = false;
    [SerializeField] ColorDataSO colorDataSO;

    void Start()
    {
        firstMaterial = colorDataSO.GetFirstMaterial();
        secondMaterial = colorDataSO.GetSecondMaterial();
        thirdMaterial = colorDataSO.GetThirdMaterial();
        
        _playerController = (PlayerController)FindFirstObjectByType(typeof(PlayerController));
        if (_playerController.colorChangeCount == 0)
        {
            trailPrefab.GetComponent<TrailRenderer>().material = firstMaterial;
        }
        _playerController.colorChangeCount++;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && isReleased == false)
        {
            isReleased = true;
            GameObject clone = Instantiate(trailPrefab, transform.parent, false);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y + 0.0005f, clone.transform.position.z);
            transform.SetParent(null, true);
            clone.GetComponent<TrailRenderer>().material = firstMaterial;
        }
        if (Input.GetKeyDown(KeyCode.K) && isReleased == false)
        {
            isReleased = true;
            GameObject clone = Instantiate(trailPrefab, transform.parent, false);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y + 0.0005f, clone.transform.position.z);
            transform.SetParent(null, true);
            clone.GetComponent<TrailRenderer>().material = secondMaterial;
        }
        if (Input.GetKeyDown(KeyCode.L) && isReleased == false)
        {
            isReleased = true;
            GameObject clone = Instantiate(trailPrefab, transform.parent, false);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y + 0.0005f, clone.transform.position.z);
            transform.SetParent(null, true);
            clone.GetComponent<TrailRenderer>().material = thirdMaterial;
        }
    }
}
