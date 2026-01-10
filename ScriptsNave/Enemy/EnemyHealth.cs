using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float damageBulletPlayer;
    [SerializeField]
    private ParticleSystem bigExplosion, smallExplosion;
    [SerializeField]
    private Image lifeBar;

    private void Awake()
    {
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
        bigExplosion.Stop();
        smallExplosion.Stop();
    }

    private void Update()
    {

    }

    private void Death()
    {
        bigExplosion.Play();
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPlayer"))
        {
            currentHealth -= damageBulletPlayer;
            lifeBar.fillAmount = currentHealth / maxHealth;
            smallExplosion.Play();
            Destroy(other.gameObject);

            if (currentHealth <= 0) Death();
        }

    }


}
