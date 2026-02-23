using System.Collections;
using TMPro;
using UnityEngine;


public class Disposal : MonoBehaviour
{
    public TextMeshPro TextMeshPro;
    public Explosion Explosion;
    public float totalValue;
    public float maxValue;
    public float quota;
    public Animator animator;
    public TextMeshProUGUI money;

    void Update()
    {
        TextMeshPro.text = totalValue.ToString("$0.00");
        money.text = maxValue.ToString("$0.00");

        if(totalValue >= quota)
        {
            StartCoroutine("stopTruck");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            totalValue += Explosion.value;
            Destroy(other.gameObject);

            if (totalValue >= quota)
            {
                animator.SetBool("Full", true);

                maxValue += totalValue;

                

            }
            else
            {
                animator.SetBool("Full", false);
            }
        }
    }

    public IEnumerator stopTruck()
    {
        yield return new WaitForSecondsRealtime(1);

        totalValue = 0;
        animator.SetBool("Full", false );
    }

}
