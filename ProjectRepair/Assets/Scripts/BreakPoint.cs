using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPoint : MonoBehaviour
{
    public bool isActive = false;
    private GameManager gameManager;
    private int repairCount;
    private CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
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
            cameraShake.shakecamera();
            Debug.Log("repair");
            repairCount++;
            // sound effects and particles and maybe shake
            if(repairCount >= 5)
            {
                isActive = false;
                repairCount = 0;
                
                // repair sound effects
            }
        }
    }
}
