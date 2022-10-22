using UnityEngine;

public class HelixManager : MonoBehaviour
{

    public GameObject[] helixRings;
    public float ySpawn = 0.0f;
    public float ringDistance = 5.0f;

    public int numberOfRings;

    // Start is called before the first frame update
    void Start()
    {
        numberOfRings = GameManager.currentLevelIndex + 5;
        // Spawn rings
        for (int i = 0; i < numberOfRings; i++)
        {
            if (i == 0)
                SpawnRing(0);

            else
                SpawnRing(Random.Range(1, helixRings.Length - 1));
        }

        // Spawn the last ring
        SpawnRing(helixRings.Length - 1);

    }


    public void SpawnRing(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringDistance;
    }
}
