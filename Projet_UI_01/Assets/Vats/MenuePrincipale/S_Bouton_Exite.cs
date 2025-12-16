using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class S_Game_Principale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //veiller a implémenter c'est 2 erreur avec clickDroit>
{
    Animator zz;
    bool Securiser = false;
    S_Game_Principale[] Stack_Script;
    void Start()
    {
        zz = GetComponent<Animator>();
        
        //zz.speed = Random.Range(0.8f, 1.0f);
        if (zz == null) Debug.LogWarning($"Attention un animator n'est pas présent, veiller a vêrifier dans {this}");
    }
    void Update()
    {
        
    }

    public void UI_Lance_Animation(string rr)
    {
        if(Securiser==false)
        { 
            switch(rr)
            {
                case "Scene_Vats":
                    StartCoroutine("Delay_enlever_les_carte");

                    Invoke("UI_Load_Game", 3);
                    break;

                case "Eject_Carte":
                    zz.SetTrigger("Trigger_Bouton_delete");
                    break;
            }
        }
    }

    private IEnumerator Delay_enlever_les_carte()
    {
        Stack_Script = FindObjectsOfType<S_Game_Principale>();
        
        int i = 0;
        while (i < Stack_Script.Length && Stack_Script[i] != this)
        {
            Stack_Script[i].UI_Lance_Animation("Eject_Carte");
            i++;
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }

    void UI_Rend_Visible_la_carte()
    {

    }
    void UI_Rend_Invisible_la_carte()
    {
        
    }

    public void UI_Load_Game(string name_Scene)
    {
        if(name_Scene != null && name_Scene == "Scene_Vats") SceneManager.LoadScene(name_Scene);
    }

    public void UI_ExitGame()
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        zz.SetBool("Bool_Mouse_Surevol", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        zz.SetBool("Bool_Mouse_Surevol", false);
    }
}
