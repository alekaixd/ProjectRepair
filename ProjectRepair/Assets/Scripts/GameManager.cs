using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField]public GameObject waterLevel;

    public GameObject[] breakPoints;
    public GameObject startMenu;
    public GameObject endMenu;
    public TextMeshProUGUI scoreText;
    public AudioSource waterAudio;
    public int pipesToBreak = 2;
    public float waterToAdd = 0;
    public int score = 0;
    public int pipesBroken = 0;

    private Transform waterTransform;
    private float waterAdded = 0;
    private bool gameActive = false;
    private bool isAudioPlaying = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        waterTransform = waterLevel.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive == true)
        {
            if (waterAdded <= waterToAdd)
            {
                waterTransform.position = new Vector2(waterTransform.position.x, waterTransform.position.y + 0.01f);
                waterAdded += 0.01f;
            }

            if (waterAdded >= 10)
            {
                gameActive = false;
                endMenu.SetActive(true);
                scoreText.text = "Your Score: " + score;
                pipesBroken = 0;
                for (int i = 0; i < breakPoints.Length; i++)
                {
                    GameObject pipe = breakPoints[i];
                    pipe.GetComponent<BreakPoint>().isActive = false;
                }
            }

            if (pipesBroken >= 1 && isAudioPlaying == false)
            {
                waterAudio.Play();
                isAudioPlaying = true;
            }
            else if (pipesBroken <= 0 && isAudioPlaying == true)
            {
                waterAudio.Stop();
                isAudioPlaying = false;
            }
        }
        
    }

    private IEnumerator BreakPipes()
    {
        // get random pipe and "break" it
        for(int i = 0; i < pipesToBreak; i++)
        {
            GameObject pipe = breakPoints[Random.Range(0, 17)];
            if (pipe.GetComponent<BreakPoint>().isActive)
            {
                i--;
            }
            else
            {
                pipe.GetComponent<BreakPoint>().isActive = true;
            }
            Debug.Log(pipe.name);
        }
        //breakPoints[Random.Range(0, 16)].GetComponent<BreakPoint>().isActive = true;

        yield return new WaitForSeconds(3.0f);

        if(gameActive == true)
        {
            StartCoroutine(BreakPipes());
        }
        

    }

    public void StartGame()
    {
        gameActive = true;
        startMenu.SetActive(false);
        StartCoroutine(BreakPipes());
    }

    public void RelaodScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
