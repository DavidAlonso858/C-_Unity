using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private Transform[] posRotEnemy; // posiciones donde van a spawnear los enemigos

    [SerializeField]
    private float timeBeetwenEnemies;


    private void Awake()
    {
        // la primera vez y las siguientes veces van a coincidir por eso el mismo nombre 2 veces
        // infinitamente en las 4 posiciones aleatorias
        InvokeRepeating(nameof(CreateEnemy), timeBeetwenEnemies, timeBeetwenEnemies);
    }

    private void Update()
    {

    }

    private void CreateEnemy()
    {
        int randomNumber = Random.Range(0, posRotEnemy.Length);
        GameObject cloneEnemy = Instantiate(enemyPrefab, posRotEnemy[randomNumber].position, posRotEnemy[randomNumber].rotation);
    }

}
