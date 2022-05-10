using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerMenu : MonoBehaviour
{
    public string mainMenu;

    public Image blackScreen;

    public float blackScreenFade;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, blackScreenFade *Time.deltaTime));
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
