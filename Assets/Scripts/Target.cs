using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public AudioSource broke;

    public GameObject destroyedVersion;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        TargetsDestroyed.numberOfDestroyed += 1;
        GameObject fractured = Instantiate(destroyedVersion, transform.position, transform.rotation);
        fractured.transform.Rotate(20, 0, 0);
        Destroy(gameObject);
        broke.Play();
        Destroy(fractured, 2f);

    }
}
