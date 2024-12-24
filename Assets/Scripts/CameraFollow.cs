using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update]
    [SerializeField] GameObject player;
    [SerializeField] float maxHeight;
    [SerializeField] float minHeight;
    [SerializeField] float maxWidth;
    [SerializeField] float minWidth;
    void Start()
    {
        
    }
    private void Awake()
    {
        if (player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }
    void Follow()
    {
        float height = player.transform.position.x;
        float width = player.transform.position.y;
        this.gameObject.transform.position = new Vector3(Mathf.Clamp(height,minHeight, maxHeight), Mathf.Clamp(width,minWidth, maxWidth), -10);
    }
}
