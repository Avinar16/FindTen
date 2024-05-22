using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    [SerializeField]
    public ScoreCounter score_counter;
    [SerializeField]
    public Timer timer;
    [SerializeField]
    GameObject GridToSpawn;
    GameObject Grid;
    [SerializeField]
    private int GridOffset;
    private void Start()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        else if(gameManager == this)
        {
            Destroy(gameObject);
        }
        StartGame();

    }
    public void StartGame()
    {
        Grid = Instantiate(GridToSpawn);
        Grid.transform.position = Grid.transform.position - new Vector3(0, GridOffset, 0);


        timer.StartTimer();
    }
    public void EndGame()
    {
        Destroy(Grid);
        score_counter.SetRecord();
        score_counter.ResetScore();
    }
}
