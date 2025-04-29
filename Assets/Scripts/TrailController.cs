using UnityEngine;

/*
This script is attached to the trail prefab in the game.
It allows the player to create trails of different colors by pressing the number keys 1, 2, or 3.
The trails are instantiated as clones of the previous trail prefab and are assigned a material based on the player's choice.
The trail's position is slightly adjusted to avoid z-fighting with the previous trails.
*/
public class TrailController : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField] GameObject trailPrefab;
    [SerializeField] GameObject player;
    private Material firstMaterial;
    private Material secondMaterial;
    private Material thirdMaterial;
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
        
        if (Input.GetKeyDown(KeyCode.Alpha1) && isReleased == false)
        {
            isReleased = true;
            GameObject clone = Instantiate(trailPrefab, transform.parent, false);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y + 0.0005f, clone.transform.position.z);
            transform.SetParent(null, true);
            clone.GetComponent<TrailRenderer>().material = firstMaterial;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isReleased == false)
        {
            isReleased = true;
            GameObject clone = Instantiate(trailPrefab, transform.parent, false);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y + 0.0005f, clone.transform.position.z);
            transform.SetParent(null, true);
            clone.GetComponent<TrailRenderer>().material = secondMaterial;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isReleased == false)
        {
            isReleased = true;
            GameObject clone = Instantiate(trailPrefab, transform.parent, false);
            clone.transform.position = new Vector3(clone.transform.position.x, clone.transform.position.y + 0.0005f, clone.transform.position.z);
            transform.SetParent(null, true);
            clone.GetComponent<TrailRenderer>().material = thirdMaterial;
        }
    }
}
