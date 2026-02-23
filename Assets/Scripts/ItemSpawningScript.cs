using UnityEngine;


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
        GameObject rnditem = items[item];
        if (willSpawn == true)
            Instantiate(rnditem, transform.position,transform.rotation);
        rnditem.AddComponent<Explosion>();

    }

    
}
