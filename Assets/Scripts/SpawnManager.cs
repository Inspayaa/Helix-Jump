using UnityEngine;
using Unity.VisualScripting;

public class SpawnManager : MonoBehaviour
{
    private CharacterSelector characterSelector;
    private GameObject spawnObject;
    private Rigidbody spawnRb;
    private TrailRenderer trailRenderer;
    private string objectName;
    private string objectTag;

    // Start is called before the first frame update
    void Start()
    {
        characterSelector = FindObjectOfType<CharacterSelector>();
        spawnObject = characterSelector.characters[characterSelector.selectedCharacter];
        spawnRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        trailRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<TrailRenderer>();
        objectName = "Player";
        objectTag = "Player";


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateMoreBalls()
    {
        Vector3 offSet = new Vector3(-2, 0, 2);
        Vector3 spawnPos = GameObject.FindGameObjectWithTag("Player").transform.position + offSet;

        GameObject playerGO = Instantiate(spawnObject, spawnPos, spawnObject.transform.rotation, spawnObject.transform.parent);

        playerGO.name = objectName;
        playerGO.tag = objectTag;

        playerGO.AddComponent<SphereCollider>();
        playerGO.AddComponent<Rigidbody>().constraints = spawnRb.constraints;
        playerGO.AddComponent<PlayerController>();
        playerGO.AddComponent<TrailRenderer>();
        playerGO.GetComponent<TrailRenderer>().time = 1;
        playerGO.GetComponent<TrailRenderer>().widthCurve = trailRenderer.widthCurve;
        playerGO.AddComponent<TrailRenderer>().widthMultiplier = trailRenderer.widthMultiplier;
    }
}
