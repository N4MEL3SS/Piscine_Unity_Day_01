using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraFollowScript_ex01 : MonoBehaviour
{
    public playerScript_ex01[] player;
    public int currentIndex = 0;
    public string nextScene;
    
    // Start is called before the first frame update
    private void Start()
    {
        SwitchPlayer(currentIndex);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!EndGame()) 
        {
            CheckCurrentPlayer();
            FollowPlayer();
            RestartScene();
        } 
        else
            Message();
    }

    private void CheckCurrentPlayer()
    {
        if (Input.GetKeyDown ("1"))
            SwitchPlayer (0);
        else if (Input.GetKeyDown ("2"))
            SwitchPlayer (1);
        else if (Input.GetKeyDown ("3"))
            SwitchPlayer (2);
        else if (Input.GetKeyDown("q"))
            SwitchPlayer (--currentIndex);
        else if (Input.GetKeyDown("e"))
            SwitchPlayer (++currentIndex % 3);
    }

    private void SwitchPlayer(int index)
    {
        if (index < 0)
            index = 2;
        for (int i = 0; i < player.Length; i++)
        {
            if (index == i)
                player[i].setMove (true);
            else
                player[i].setMove (false);
        }
        currentIndex = index;
    }

    private void FollowPlayer()
    {
        transform.position = new Vector3 (player[currentIndex].transform.position.x,
            player[currentIndex].transform.position.y  + 0.5f, transform.position.z);
    }

    private static void RestartScene() 
    {
        if (Input.GetKeyDown ("r"))
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
    }

    private void Message()
    {
        player[0].endGame = true;
        player[1].endGame = true;
        player[2].endGame = true;
        if(nextScene != "null")
        {
            Debug.Log("Goto nextLevel BRO)");
            SceneManager.LoadScene(nextScene);
        }
        else
            Debug.Log ("Congratulation!!! You Winner this game BRO!");
    }

    private bool EndGame()
    {
        return player.All(player => player.checkedBoxAligned);
    }
}
