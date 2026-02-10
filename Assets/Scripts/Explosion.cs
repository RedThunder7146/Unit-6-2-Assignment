using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Explosion : MonoBehaviour
{




    public float value = 1000;
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public Rigidbody rb;
    float cubesPivotDiastance;
    Vector3 cubesPivot;
    public TextMeshPro text;
    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    public Material material;
    float timer = 3;
    public DebrisDestruction exploded;
    

    void Start()
    {
        cubesPivotDiastance = cubeSize * cubesInRow / 2;

        cubesPivot = new Vector3(cubesPivotDiastance, cubesPivotDiastance, cubesPivotDiastance);

    }


    void Update() 
    {


        if (value <= 0)
        {
            explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            float destruction = 100 * rb.linearVelocity.magnitude*10;

            destruction *= 100;

            destruction = Mathf.Ceil(destruction);
            value -= destruction/ 100;

            print(value);

            text.text = value.ToString("$0.00");
        }
    }

    public void explode()
    {

        
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        Destroy(gameObject);

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.GetComponent<MeshRenderer>().material = material;
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        piece.AddComponent<DebrisDestruction>();
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

        timer -= Time.deltaTime;


        if (timer <= 0)
        {
            print("Timer has hit 0");
            piece.SetActive(false);
        }
    }
}