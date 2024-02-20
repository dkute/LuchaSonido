using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    public static MinigameController Instance;
    public ButtonB[] btns;

    static int gameMax;
    static float gameTime;

    static List<int> userList, gameList;

    public static bool GameisWorking;

    // Use this for initialization
    private void Start()
    {
        Instance = this;

        gameMax = 3;
        gameTime = 0.5f;

        StartCoroutine(MinigameControl());
    }
    
public void PlayerAction(ButtonB b)
    {
        userList.Add(b.id);

        if (userList[userList.Count-1] != gameList [userList.Count-1])
        {
            Start();
            Debug.Log("Loose");
        }
        else if(userList.Count == gameList.Count)
        {
            Debug.Log("Next Level");
            StartCoroutine(MinigameControl());
        }
    } 
    IEnumerator MinigameControl()
    {
        Debug.Log("Prepare");
        yield return new WaitForSeconds(1);
        GameisWorking = true;
        userList = new List<int>();
        gameList = new List<int>();

        for (int i = 0; i < gameMax; i++)
        {

            int rand = Random.Range(0, 4);
            gameList.Add(rand);
            btns[rand].Action();

            yield return new WaitForSeconds(gameTime);
        }
        gameTime -= 1f;
        gameMax++;
        GameisWorking = false;
    }
}
