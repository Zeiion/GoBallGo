using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Menu_ChooseGame");  //加载场景 游戏
    }

    public void PlayGame_R()
    {
        SceneManager.LoadScene("PlayGame_R");  //加载场景 游戏 跑酷普通模式
    }

    public void PlayGame_I()
    {
        SceneManager.LoadScene("PlayGame_I");  //加载场景 游戏 跑酷无限模式
    }

    public void PlayGame_pz()
    {
        SceneManager.LoadScene("PG_pz");  //加载场景 游戏 单球迷宫
    }

    public void PlayGame_db()
    {
        SceneManager.LoadScene("PG_db");  //加载场景 游戏 双球控制
    }

    public void PlayGame_tb()
    {
        SceneManager.LoadScene("PG_tb");  //加载场景 游戏 三球控制
    }

    public void PlayGame_bs()
    {
        SceneManager.LoadScene("PG_Basket");  //加载场景 游戏 三球控制
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Menu_Settings"); //加载场景 游戏选择界面
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");  //加载场景 回到主菜单
    }

    public void QuitGame()
    {
        Application.Quit();  //退出游戏
    }
}
