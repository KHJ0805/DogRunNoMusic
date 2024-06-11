using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    public float speed = 2f;
    public float spawntime =0.1f;
    public List<GameObject> mapList;
    public List<GameObject> objectList;
    float mapzDistance = 10;
    public static MapManager instance;
    public float originalSpeed;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        originalSpeed = speed;
        for (int i = 0; i < mapList.Count; i++)
        {
            GameObject go = Instantiate(mapList[i]);
            go.transform.position = new Vector3(0, 0, i * mapzDistance);
        }
        InvokeRepeating("SpawnObject", 0f, 1.5f);

    }
    private void Update()
    {
        if (speed < 20f)
        {
            speed += Time.deltaTime * spawntime;
        }
        else
        {
            speed = 20f;
        }


    }
    public void SpawnArea(float z = 0f)
    {

        int index = Random.Range(0, mapList.Count);
        GameObject go = Instantiate(mapList[index]);
        go.transform.position = new Vector3(0, 0, z + mapzDistance * 3);
    }
    public void SpawnObject()
    {

        int index = Random.Range(0, objectList.Count);
        GameObject go = Instantiate(objectList[index]);

    }

}
