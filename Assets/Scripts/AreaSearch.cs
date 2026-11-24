using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSearch : MonoBehaviour
{
    private GameObject[,] fogGrid = new GameObject[6, 7];
    private HashSet<(int x, int y)> pendingTiles = new HashSet<(int x, int y)>();

    public Transform gridParent;

    public GameObject exploreIconPrefab;

    public float disappearDelay = 2f;

    void Start()
    {
        InitializeFogFromHierarchy();
    }

    void InitializeFogFromHierarchy()
    {
        if (gridParent == null)
        {
            Debug.LogError("Není přiřazen gridParent!");
            return;
        }

        for (int x = 0; x < gridParent.childCount; x++)
        {
            Transform xParent = gridParent.GetChild(x);

            for (int y = 0; y < xParent.childCount; y++)
            {
                Transform fogChild = xParent.GetChild(y);

                if (x < 6 && y < 7)
                {
                    GameObject fogObj = fogChild.gameObject;
                    fogGrid[x, y] = fogObj;

                    FogTile tile = fogObj.GetComponent<FogTile>();
                    if (tile == null)
                    {
                        tile = fogObj.AddComponent<FogTile>();
                    }

                    tile.xCoord = x;
                    tile.yCoord = y;
                    tile.areaSearchManager = this;
                }
            }
        }
    }

    public void OnFogTileClicked(int x, int y, GameObject clickedFog)
    {
        // Pokud už se tento tile maže nebo neexistuje, ignoruj další kliknutí
        if (clickedFog == null || fogGrid[x, y] == null || pendingTiles.Contains((x, y)))
        {
            return;
        }

        Debug.Log($"Kliknuto na mlhu [{x}, {y}] – zmizí za {disappearDelay} s.");
        pendingTiles.Add((x, y));

        if (exploreIconPrefab != null)
        {
            Instantiate(exploreIconPrefab, clickedFog.transform.position + Vector3.up * 0.1f, Quaternion.identity);
        }

        StartCoroutine(RemoveTileAfterDelay(x, y, clickedFog, disappearDelay));
    }

    private IEnumerator RemoveTileAfterDelay(int x, int y, GameObject targetFog, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (targetFog != null)
        {
            Destroy(targetFog);
        }

        fogGrid[x, y] = null;
        pendingTiles.Remove((x, y));
        Debug.Log($"Mlha [{x}, {y}] byla odstraněna.");
    }
}