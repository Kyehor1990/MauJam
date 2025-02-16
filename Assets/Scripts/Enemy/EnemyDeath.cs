using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private GameObject Light;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(Light);
            GetComponent<EnemySight>().enabled = false;
            StartCoroutine(Death());
            animator.SetTrigger("Death");
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.8f);
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
