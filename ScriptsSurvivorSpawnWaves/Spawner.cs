using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemy;
    [SerializeField]
    private float spawnlimit;
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private int[] chance;

    private int spawnCount;

    private void Awake()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

    }

    IEnumerator Spawn()
    {
        spawnCount = 0;
        while (spawnCount < spawnlimit)
        {
            int random = Random.Range(0, 100);
            for (int i = 0; i < enemy.Length; i++)
            {
                if (random < chance[i])
                {
                    Instantiate(enemy[i], transform.position, transform.rotation);
                    spawnCount++;
                    break;
                }
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public void StartSpawn(int _spawnLimit, float _spawnTime)
    {
        spawnlimit = _spawnLimit;
        spawnTime = _spawnTime;
        StartCoroutine(Spawn());
    }

}
