using UnityEngine;

public class ChosenColor : MonoBehaviour
{
    [SerializeField] GameObject palette1;
    [SerializeField] GameObject palette2;
    [SerializeField] GameObject palette3;
    [SerializeField] Material defaultMaterial;

    public void SetColorOfFirstPalette(Material material)
    {
        palette1.GetComponent<MeshRenderer>().material = material;
    }

    public void SetColorOfSecondPalette(Material material)
    {
        palette2.GetComponent<MeshRenderer>().material = material;
    }

    public void SetColorOfThirdPalette(Material material)
    {
        palette3.GetComponent<MeshRenderer>().material = material;
    }


    public Material GetMaterialOfFirstPalette()
    {
        return palette1.GetComponent<MeshRenderer>().material;
    }

    public Material GetMaterialOfSecondPalette()
    {
        return palette2.GetComponent<MeshRenderer>().material;
    }

    public Material GetMaterialOfThirdPalette()
    {
        return palette3.GetComponent<MeshRenderer>().material;
    }
}
