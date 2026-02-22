using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSpawningScript : MonoBehaviour
{
    public GameObject[] items;
    public bool willSpawn;
    public Transform spawner;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int rnd = Random.Range(0, 10);

        if (rnd <= 8)
        {
            willSpawn = true;
        }
        else 
            willSpawn = false;

        Vector3 itemPosition = spawner.position;

        int item = Random.Range(0, items.Length);

        if (willSpawn == true)
            Instantiate(items[item], transform.position,transform.rotation);

    }

    
}
