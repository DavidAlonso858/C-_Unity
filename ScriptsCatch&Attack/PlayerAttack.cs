using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    // AQUI VA EL PREFAB NO UN MOVIMIENTO DE LA ESCENA
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;

    public Transform bulletPos;

    void Awake()
    {

    }

    void Update()
    {
        // Si pulso el boton izquierdo del raton -> disparo
        // 0 -> boton izquierdo
        // 1 -> boton derecho
        // 2 -> boton rueda del raton
        if (Input.GetMouseButtonDown(0))
        {
            // crea un clon de un prefab en la escena
            Instantiate(bulletPrefab, bulletPos.position, bulletPos.rotation);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Instantiate(bulletPrefab2, bulletPos.position, bulletPos.rotation);
        }
    }
}