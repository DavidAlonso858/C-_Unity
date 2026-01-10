using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //   private GameObject player;

    // Pasar el jugador que quiero que siga
    [SerializeField]
    private Transform player;
    [SerializeField]

    // La velocidad a la que sigue al jugador
    private float speed;
    void Awake()
    {
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }
        transform.LookAt(player);
        // transform.rotation -> Quaternion (trabajar con ejes imaginarios)
        // bloquea el giro en X y Z para que no mire al suelo
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}