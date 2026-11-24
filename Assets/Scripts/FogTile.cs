using UnityEngine;

public class FogTile : MonoBehaviour
{
    [HideInInspector] public int xCoord;
    [HideInInspector] public int yCoord;
    [HideInInspector] public AreaSearch areaSearchManager;

    // Unity automaticky zavolá tuto funkci, když na objekt klikneš levým tlačítkem myši 
    // (objekt musí mít nějaký Collider, např. Mesh Collider nebo Box Collider)
    private void OnMouseDown()
    {
        if (areaSearchManager != null)
        {
            areaSearchManager.OnFogTileClicked(xCoord, yCoord, gameObject);
        }
    }
}
