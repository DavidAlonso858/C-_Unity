using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Movement")]
    [SerializeField]
    private float speed;

    [SerializeField]
    private float distanceToPlayer;

    [Header("Enemy Attack")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] posRotBullet;
    [SerializeField]
    private float timeBetweenBullets;

    private GameObject player; // saber donde esta el jugador

    private void Awake()
    {
        // nombre exacto del nombre de la nave
        player = GameObject.FindGameObjectWithTag("Xwing");

        // Metodo que sirve para llamar a otro metodo infinitamente a traves de una serie de intervalos
        InvokeRepeating(nameof(Attack), 1, timeBetweenBullets);

    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }
        // para que el enemigo mire al jugador todo el tiempo
        transform.LookAt(player.transform.position);

        FollowPlayer();
    }

    private void FollowPlayer()
    {
        // Distancia entre enemigo y player (en metros)
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance > distanceToPlayer)
        {
            transform.Translate(speed * Vector3.forward * Time.deltaTime);
        }
    }

    private void Attack()
    {
        // posiciones de las 4 balas que iran rotando
        for (int i = 0; i < posRotBullet.Length; i++)
        {
            Instantiate(bulletPrefab, posRotBullet[i].position, posRotBullet[i].rotation);
        }
    }


}
