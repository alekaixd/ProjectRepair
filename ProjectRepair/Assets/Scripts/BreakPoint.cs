using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPoint : MonoBehaviour
{
    public bool isActive = false;
    private GameManager gameManager;
    private int repairCount;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == true)
        {
            gameManager.waterToAdd += 0.0005f;
        }
    }

    private void OnMouseDown()
    {
        if (isActive == true) 
        {
            repairCount++;
            if(repairCount == 5)
            {
                isActive = false;
            }
        }
    }
}
