using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    public Text endTime;
    public Text endScore;
    int ending = 3;

    public PlayerController pCon;
    public Timer timer;


    // Start is called before the first frame update
    void Update()
    {

        endTime.text = timer.currentTime.ToString();
        endScore.text = ending.ToString();
    }
}
