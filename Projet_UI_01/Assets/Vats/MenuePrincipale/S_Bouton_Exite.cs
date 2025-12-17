using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class S_Game_Principale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //veiller a implémenter c'est 2 erreur avec clickDroit>
{
    [SerializeField] bool Securiser {set; get; }
    GameObject transform_Central;
    RectTransform rectTransform_Origine;
    RectTransform rectTransform;
    S_Game_Principale[] Stack_Script;
    string Action_Animation;
    Animator zz;

    void Start()
    {
        
        zz = GetComponent<Animator>();
        Securiser = false;
        if (zz == null) Debug.LogWarning($"Attention un animator n'est pas présent, veiller a vêrifier dans {this}");

        transform_Central = GameObject.Find("Target_Center");
        if (transform_Central != null) 
        {
            Debug.Log("trouver");
            rectTransform = rectTransform_Origine = GetComponent<RectTransform>();
        }
        else Debug.LogError("non trouver");

    }
    public void UI_Lance_Animation(string rr)
    {
        if(Securiser==false)
        {
            switch (rr)
            {
                case "Scene_Vats":
                    Action_Animation = "Eject_Carte"; //la en note quelle ordre en strig a distribuer au autres carte
                    zz.SetTrigger("Trigger_Bouton_Agrandir");
                    StartCoroutine("Delay_enlever_les_carte");
                    break;

                case "Remêttre_les_cartes":
                    Action_Animation = "Ré-integre_la_carte"; //la en note quelle ordre en strig a distribuer au autres carte
                    StartCoroutine("Delay_enlever_les_carte");
                    break;

                case "Ré_integre_la_carte":
                    Debug.Log("I win");
                    zz.SetTrigger("Trigger_Bouton_Ajouter");
                    break;

                case "Eject_Carte":
                    Securiser = true;
                    zz.SetTrigger("Trigger_Bouton_delete");
                    Invoke("securiserBool", 2);
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
            yield return new WaitForSecondsRealtime(0.1f);
            Stack_Script[i].UI_Lance_Animation(Action_Animation);
            i++;
        }
        Securiser = false;
    }

    void pourchasseTarget()
    {
        if(transform_Central!=null)
            //rectTransform.SetPosition(Vector2.Lerp(this.transform.position, transform_Central.transform.position, Time.deltaTime * 3));
        //this.transform.position = Vector2.Lerp(this.transform.position, transform_Central.transform.position, Time.deltaTime * 3);
    }
    private void Update()
    {
        pourchasseTarget();
    }

    public void UI_Load_Game()
    {
        SceneManager.LoadScene("Scene_Vats");
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
