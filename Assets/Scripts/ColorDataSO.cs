using UnityEngine;

// This scriptable object stores three materials that can be used in the game.

[CreateAssetMenu(fileName = "ColorDataSO", menuName = "ColorDataSO")]
public class ColorDataSO : ScriptableObject
{
    private Material material1;
    private Material material2;
    private Material material3;

    public Material GetFirstMaterial()
    {
        return material1;
    }

    public Material GetSecondMaterial()
    {
        return material2;
    }

    public Material GetThirdMaterial()
    {
        return material3;
    }


    public void SetFirstMaterial(Material material)
    {
        material1 = material;
    }

    public void SetSecondMaterial(Material material)
    {
        material2 = material;
    }

    public void SetThirdMaterial(Material material)
    {
        material3 = material;
    }
}
