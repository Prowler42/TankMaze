using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel :BasePanel<LosePanel>
{
    public CustomGUIButton btnGoBack;
    public CustomGUIButton btnRetry;
    void Start()
    {
        btnGoBack.clickEvent += ()=>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("BeginScene");
        };
        btnRetry.clickEvent += () =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");
        };
        HidePanel();
    }

}
