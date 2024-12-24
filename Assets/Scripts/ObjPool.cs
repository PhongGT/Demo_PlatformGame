using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{
    public static ObjPool instance;
    private List<GameObject> pooledObjs = new List<GameObject>();
    private int amount = 10;
    [SerializeField] private GameObject prefab;

    private void Awake()
    {
        if (instance == null)
        { instance = this; }
    }    void Start()
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObjs.Add(obj);
        }
    }
    public GameObject GetPooledObj()
    {
        for (int i = 0; i < pooledObjs.Count; i++)
        {
            if (!pooledObjs[i].activeInHierarchy)
            {
                return pooledObjs[i];
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
