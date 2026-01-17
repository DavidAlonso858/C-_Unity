using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    [SerializeField] private Slider sliderHealth;

    [SerializeField] private float inmuneTime;
    private bool inmune = false;

    [SerializeField] private AudioClip clipDeath, clipHurt;
    AudioSource audioS; // la fuente de audio del jugador a la cual le asignaremos los clips

    private void Awake()
    {
        sliderHealth.value = sliderHealth.maxValue = currentHealth = maxHealth;
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !inmune)
        {
            // recibo daño
            GetDamage();
        }
    }

    public void GetDamage()
    {
        inmune = false;
        currentHealth--;
        sliderHealth.value = currentHealth;
        if (currentHealth <= 0)
        {
            // MUERTE
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerShooting>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Animator>().Play("Death");
            audioS.clip = clipDeath;
        }
        else
        {
            audioS.clip = clipHurt;
        }
        audioS.Play();

        Invoke(nameof(InmuneOff), inmuneTime);
    }

    public void InmuneOff()
    {
        inmune = false;
    }
    public void RestartLevel()
    {
        GameManager.instance.GameOver();
    }

}
