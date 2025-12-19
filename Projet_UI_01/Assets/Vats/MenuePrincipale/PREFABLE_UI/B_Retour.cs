using UnityEngine;
using UnityEngine.SceneManagement;

public class B_Retour : MonoBehaviour
{
    S_Game_Principale[] Lol;
    public GameObject Objet_Destroy;
    bool securiser = false;

    void Start()
    {
        Invoke("secure_event_boutton", 2f);
    }

    public void DestroyPrefable()
    {
        if(securiser)
        {
            Lol = FindObjectsOfType<S_Game_Principale>();
            for (int i = 0; i < Lol.Length;)
            {
                Lol[i].Deplacement_au_centre = false;
                Lol[i].Action_Animation = "Ré_integre_la_carte";
                Lol[i].UI_Lance_Animation("Ré_integre_la_carte");
                i++;
            }
            if (Objet_Destroy != null) Destroy(Objet_Destroy);
        }

    }
    void secure_event_boutton()
    {
        securiser = true;
    }

    public void UI_Load_Game()
    {
        SceneManager.LoadScene("Main");
        //SceneManager.LoadScene("Scene_Vats");
    }
    public void UI_ExitGame()
    {
        Application.Quit();
    }
}
