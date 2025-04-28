using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] ColorDataSO _colorDataSO;
    private ChosenColor _chosenColor;

    void Start()
    {
        _chosenColor = (ChosenColor)FindFirstObjectByType(typeof(ChosenColor));
    }

    void OnMouseDown()
    {
        _colorDataSO.SetFirstMaterial(_chosenColor.GetMaterialOfFirstPalette());
        _colorDataSO.SetSecondMaterial(_chosenColor.GetMaterialOfSecondPalette());
        _colorDataSO.SetThirdMaterial(_chosenColor.GetMaterialOfThirdPalette());

        SceneManager.LoadSceneAsync("MainGame");
    }
}
