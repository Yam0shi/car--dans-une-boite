using UnityEngine;

public class CollectibleGeneration : MonoBehaviour
{
    [SerializeField] Collectible myCollectible;
    [SerializeField] bool spawnOrNot;
    [SerializeField] int YoN;
    void Start()
    {
        YoN = (int)Random.Range(0, 2);
        if(YoN == 0)
        {
            spawnOrNot = false;
        }
        else
        {
            spawnOrNot = true;
        }

        if(spawnOrNot )
        {
            LoadItem(myCollectible);
        }
    }
    void LoadItem(Collectible data)
    {
        foreach (Transform child in transform)
        {
            if (Application.isEditor) DestroyImmediate(child.gameObject);
            else Destroy(child.gameObject);
        }

        GameObject visuals = Instantiate(data.apparence);
        visuals.transform.SetParent(transform);
        visuals.transform.localPosition = Vector3.zero;
        visuals.transform.rotation = Quaternion.identity;
        visuals.tag = "Item";
    }
}
