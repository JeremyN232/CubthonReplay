using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameState = false;
    bool Replay = false;
    public float delay = 2;
    public GameObject player;
    public GameObject completeLevelUI;

    public void Update()
    {
        if (Replay)
        {
            RunReplay();
        }
    }
    public void completeLevel(){
        completeLevelUI.SetActive(true);
    }
    
    public void EndGame()
    {
        if (gameState == false)
        {
            gameState = true;
            Debug.Log("Game Over");
            Invoke("Restart", delay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void RunReplay()
    {
        if (CommandLog.commands.Count == 0)
        {
            return;
        }

        Command command = CommandLog.commands.Peek();
        if(Time.timeSinceLevelLoad >= command.timestamp)
        {
            command = CommandLog.commands.Dequeue();
            command.comPlayer = player.GetComponent<Rigidbody>();
            Invoker invoker = new Invoker();
            invoker.disableLog = true;
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }


}
