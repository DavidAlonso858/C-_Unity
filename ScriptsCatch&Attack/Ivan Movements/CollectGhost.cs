using UnityEngine;

public class CollectGhost : MonoBehaviour
{
    public int numGhosts;

    void Awake()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            numGhosts++;
            Destroy(other.gameObject);
        }
    }
    
}