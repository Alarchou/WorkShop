using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
   private bool gameOver = false;

   public void Lose(string reason)
    {
        if (gameOver) return;

        gameOver = true;

        Debug.Log("Défaite : " + reason);

        //Screamer + Reload
    }
}
