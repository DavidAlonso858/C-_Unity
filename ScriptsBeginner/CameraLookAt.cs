using UnityEngine;

// Metodo para que se fija la mirada donde lo indique
public class CameraLookAt : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("Transform Player: " + player);
    }

    // Update is called once per frame
    void Update()
    {
        // Llamo al componente transform de la camara
        // Uso el metodo LookAt para que mire siempre al jugador
        transform.LookAt(player);
    }
}
