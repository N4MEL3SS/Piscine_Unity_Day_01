using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraFollowScript_ex00 : MonoBehaviour
{
    public playerScript_ex00[] player;
    public int currentIndex = 0;

    // Start is called before the first frame update
    private void Start()
    {
        SwitchPlayer(currentIndex);
    }

    // Update is called once per frame
    private void Update()
    {
        CheckCurrentPlayer();
        FowardPlayer();
        RestartScene();
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

    private void SwitchPlayer (int index)
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
    
    void FowardPlayer()
    {
        transform.position = new Vector3 (player[currentIndex].transform.position.x,
            player[currentIndex].transform.position.y  + 0.5f, transform.position.z);
    }

    private static void RestartScene() 
    {
        if (Input.GetKeyDown ("r"))
            SceneManager.LoadScene ("ex00");
    }
}
