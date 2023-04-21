using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]public GameObject waterLevel;
    public GameObject[] breakPoints;
    private Transform waterTransform;
    public float waterToAdd = 0;
    private float waterAdded = 0;
    public int pipesToBreak = 2;
    // Start is called before the first frame update
    void Start()
    {
        waterTransform = waterLevel.GetComponent<Transform>();
        StartCoroutine(BreakPipes());
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

    private IEnumerator BreakPipes()
    {
        // get random pipe and "break" it
        for(int i = 0; i < pipesToBreak; i++)
        {
            GameObject pipe = breakPoints[Random.Range(0, 16)];
            pipe.GetComponent<BreakPoint>().isActive = true;
            Debug.Log(pipe.name);
        }
        //breakPoints[Random.Range(0, 16)].GetComponent<BreakPoint>().isActive = true;

        yield return new WaitForSeconds(3.0f);
        StartCoroutine(BreakPipes());

    }
}
