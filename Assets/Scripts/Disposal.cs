using TMPro;
using UnityEngine;

public class Disposal : MonoBehaviour
{
    public TextMeshPro TextMeshPro;
    public Explosion Explosion;
    public float totalValue;
    public float quota;
    public Animator animator;

    void Update()
    {
        TextMeshPro.text = totalValue.ToString("$0");

        if (totalValue >= quota)
        {
            animator.SetBool("Full", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Awning")
        {
            totalValue += Explosion.value;
        }
    }

}
