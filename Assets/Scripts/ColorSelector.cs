using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    private ChosenColor _chosenColor;

    void Start()
    {
        _chosenColor = (ChosenColor)FindFirstObjectByType(typeof(ChosenColor));
    }

    void OnMouseDown()
    {
        if(transform.parent.name.Equals("FirstPalette"))
        {
            _chosenColor.SetColorOfFirstPalette(transform.GetComponent<MeshRenderer>().material);
        }

        if(transform.parent.name.Equals("SecondPalette"))
        {
            _chosenColor.SetColorOfSecondPalette(transform.GetComponent<MeshRenderer>().material);
        }

        if(transform.parent.name.Equals("ThirdPalette"))
        {
            _chosenColor.SetColorOfThirdPalette(transform.GetComponent<MeshRenderer>().material);
        }
    }
}
