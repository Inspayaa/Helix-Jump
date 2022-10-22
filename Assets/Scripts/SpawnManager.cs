using UnityEngine;
using Unity.VisualScripting;

public class SpawnManager : MonoBehaviour
{
    private CharacterSelector characterSelector;
    private GameObject spawnObject;
    private Transform playerTransform;
    private Rigidbody spawnRb;
    private TrailRenderer trailRenderer;

    // Start is called before the first frame update
    void Start()
    {
        characterSelector = FindObjectOfType<CharacterSelector>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        spawnObject = characterSelector.characters[characterSelector.selectedCharacter];
        spawnRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        trailRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateMoreBalls()
    {
        Vector3 offSet = new Vector3(-2, 0, 2);
        Vector3 spawnPos = playerTransform.position + offSet;
        string objectName = "Player";
        string objectTag = "PlayerClone";

        GameObject playerGO = Instantiate(spawnObject, spawnPos, spawnObject.transform.rotation, spawnObject.transform.parent);
        playerGO.transform.parent = playerTransform;
        playerGO.name = objectName;
        playerGO.tag = objectTag;
        playerGO.AddComponent<SphereCollider>();
        playerGO.AddComponent<Rigidbody>().constraints = spawnRb.constraints;
        playerGO.AddComponent<PlayerController>();
        playerGO.AddComponent<TrailRenderer>();
        playerGO.GetComponent<TrailRenderer>().time = 1;
        playerGO.GetComponent<TrailRenderer>().widthCurve = trailRenderer.widthCurve;
        playerGO.GetComponent<TrailRenderer>().widthMultiplier = trailRenderer.widthMultiplier;
    }
}
