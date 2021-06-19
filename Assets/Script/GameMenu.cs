using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public Transform pig;
    public Vector3 T = new Vector3(-2, -0.8f, 0);
    public Vector3 C = new Vector3(-2, -2, 0);
    public Vector3 Q = new Vector3(-2, -3.2f, 0);

    private void Start()
    {
        pig.position = T;
    }

    private void Update()
    {
        MenuUD();
        MenuCh();
    }

    private void MenuUD()
    {
        if (Input.GetKeyDown(KeyCode.S) && pig.position == T)
        {
            pig.position = C;
            print("到C");
        }
        else if(Input.GetKeyDown(KeyCode.S) && pig.position == C)
        {
            pig.position = Q;
            print("到Q");
        }
        else if (Input.GetKeyDown(KeyCode.S) && pig.position == Q)
        {
            pig.position = T;
            print("到T");
        }

        if (Input.GetKeyDown(KeyCode.W) && pig.position == T)
        {
            pig.position = Q;
            print("到Q");
        }
        else if (Input.GetKeyDown(KeyCode.W) && pig.position == C)
        {
            pig.position = T;
            print("到T");
        }
        else if (Input.GetKeyDown(KeyCode.W) && pig.position == Q)
        {
            pig.position = C;
            print("到C");
        }
    }

    private void MenuCh()
    {
        if (Input.GetKeyDown(KeyCode.J) && pig.position == C)
        {
            Invoke("DelayStartGame", 1.5f);
        }
    }

    public void DelayStartGame()
    {
        SceneManager.LoadScene("大地圖");
    }
}
