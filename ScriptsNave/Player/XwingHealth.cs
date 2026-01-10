using UnityEngine.UI; // para la class Image
using UnityEngine;

public class XwingHealth : MonoBehaviour
{
    [SerializeField]
    private float maxhealth; // Salud Maxima
    [SerializeField]
    private float currentHealth; // la Salud Actual
    [SerializeField]
    private float damageBullet; // El daño que me hace la bala enemiga
    [SerializeField]
    private Image lifeBar;

    [SerializeField]
    private ParticleSystem deathExplosion, smallExplosion;

    [SerializeField]
    private GameManager gameManager;

    private void Awake()
    {
        smallExplosion.Stop();
        deathExplosion.Stop();
        currentHealth = maxhealth;
        lifeBar.fillAmount = 1;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void Death()
    {
        gameManager.GameOver();
        deathExplosion.Play();
        // le decimos a la camara que ya no tiene padre
        Camera.main.transform.SetParent(null);
        Destroy(gameObject, 1.2f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            smallExplosion.Play();
            Debug.Log("Estoy chocando");
            currentHealth -= damageBullet;
            lifeBar.fillAmount = currentHealth / maxhealth; // actualizar la barra de vida 
            Destroy(other.gameObject); // destruir la bala al chocar 100%
            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }


}
