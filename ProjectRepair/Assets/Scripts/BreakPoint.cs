using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPoint : MonoBehaviour
{
    public bool isActive = false;
    public GameObject waterParticle;
    private GameManager gameManager;
    private int repairCount;
    private CameraShake cameraShake;
    private CameraShake UI_CameraShake;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        UI_CameraShake = GameObject.Find("UI_cam").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == true)
        {
            if (!gameObject.CompareTag("MenuPipe"))
            {
                gameManager.waterToAdd += 0.0005f;
            }
            waterParticle.SetActive(true);
        }

        if(isActive == false)
        {
            waterParticle.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if(isActive == true && gameObject.CompareTag("MenuPipe"))
        {
            cameraShake.shakecamera();
            UI_CameraShake.shakecamera();
            Debug.Log("repair");
            repairCount++;
            // sound effects and particles and maybe shake
            if (repairCount >= 5)
            {
                isActive = false;
                repairCount = 0;
                gameManager.StartGame();
                // repair sound effects
            }
        }

        else if (isActive == true) 
        {
            cameraShake.shakecamera();
            Debug.Log("repair");
            repairCount++;
            gameManager.score += 25;
            // sound effects and particles and maybe shake
            if(repairCount >= 5)
            {
                isActive = false;
                repairCount = 0;
                gameManager.pipesBroken -= 1;
                // repair sound effects
            }
        }
    }
}
