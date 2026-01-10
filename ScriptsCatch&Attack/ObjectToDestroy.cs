using UnityEngine;


// Script que va a ir en el elemento que quiero destruit por colision
public class ObjectToDestroy : MonoBehaviour
{
    public Material mat;

    // array de materiales a elegir [SerializeField] private Material[] mats;

    // Metodo que se invoca automaticamente cuando hay una colision


 
    private void OnCollisionEnter(Collision collision)
    {
        // collision.collider.gameObject me devuelve el gameObject con el que está chocando
        if (collision.collider.gameObject.CompareTag("BulletYellow"))
        {
            // destruyo el objeto que lleva este script
            Destroy(gameObject);
        }
        else if (collision.collider.gameObject.CompareTag("BulletPurple"))
        {
            // Cambio el material al cubo
            GetComponent<Renderer>().material = mat;

            // pilla un material aleatorio dentro de un array de materiales
            //  GetComponent<Renderer>().material = mats[Random.Range(0, mats.Length - 1)];
        }

        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            // destruyo el objeto que lleva este script
            Destroy(gameObject);
        }

    }
}
