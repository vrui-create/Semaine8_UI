using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Retour : MonoBehaviour
{
    S_Game_Principale[] Lol;

    public void DestroyPrefable()
    {
        Lol = FindObjectsOfType<S_Game_Principale>();
        for (int i = 0; i < Lol.Length; i++)
        {
            Lol[i].UI_Lance_Animation("Ré_integre_la_carte");
        }
        Destroy(gameObject);

    }
    public void UI_Load_Game()
    {
        SceneManager.LoadScene("Scene_Vats");
    }
    public void UI_ExitGame()
    {
        Application.Quit();
    }
}
