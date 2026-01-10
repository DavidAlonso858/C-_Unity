using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float currentHealth;

    [Header("UI")]
    [SerializeField]
    private Image acornlife;
    [SerializeField]
    private float amountLife;

    // Que necesito otra variable para hacer "guay" la muerte de la ardilla
    [SerializeField]
    private float forceJumpDeath;

    private Animator anim;
    private SquirrelMovement playerMovement;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<SquirrelMovement>();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    // Desde aqui gestionamos el damage al player
    // Metodo publico porque se va a llamar desde el script del enemigo 
    public void TakeDamage(int amountDamage)
    {
        // Si la ardilla esta muerta no le puedes quitar mas damage
        if (anim.GetBool("Hurt") == true || currentHealth <= 0) return;

        currentHealth -= amountDamage;
        // Actualizamos la imagen de la vida en funcion de la cantidad que tengamos
        acornlife.fillAmount = currentHealth / maxHealth;

        // Reproducimos la animacion de damage
        anim.SetBool("Hurt", true);

        // Mientras la ardilla esta sufriendo damage no quiero que se mueva 
        playerMovement.ResetVelocity();

        if (currentHealth <= 0)
        {
            Death();
            return;
        }

        // Con esto nos aseguramos de que la animacion de damage se reproduzca correctamente 
        Invoke(nameof(AnimHurtToFalse), 1);
    }

    private void AnimHurtToFalse()
    {
        anim.SetBool("Hurt", false);
    }

    private void Death()
    {
        // Desactivo el collider de la ardilla
        GetComponent<CircleCollider2D>().enabled = false;
        // Hacemos que al morir de un pequenio salto hacia arriba
        // al no tener collider se colara por el suelo y desaparecera
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * forceJumpDeath);
    }
}
