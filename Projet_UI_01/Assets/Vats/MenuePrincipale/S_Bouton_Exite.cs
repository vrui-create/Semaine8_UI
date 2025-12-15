using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Game_Principale : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void UI_Lance_Anime(Animator zz)
    {
        if (zz != null)
        {
            zz.SetTrigger("Mouse_Survoler");
        }

    }




    public void UI_Load_Game(string name_Scene)
    {
        if(name_Scene != null && name_Scene == "Scene_Vats") SceneManager.LoadScene(name_Scene);
    }

    public void UI_ExitGame()
    {
        Application.Quit();
    }
}
