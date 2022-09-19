using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameState = false;
    public float delay = 1;
    public GameObject completeLevelUI;


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
}
