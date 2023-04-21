using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]public GameObject waterLevel;
    private Transform waterTransform;
    public float waterToAdd = 0;
    private float waterAdded = 0;
    // Start is called before the first frame update
    void Start()
    {
        waterTransform = waterLevel.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waterAdded <= waterToAdd)
        {
            waterTransform.position = new Vector2(waterTransform.position.x, waterTransform.position.y + 0.01f);
            waterAdded += 0.01f;
        }

        if (Input.GetKeyDown("space"))
        {
            waterToAdd += 1.0f;
        }
    }
}
