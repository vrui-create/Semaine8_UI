using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class S_Game_Principale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler //veiller a implémenter c'est 2 erreur avec clickDroit>
{
    [SerializeField] bool Securiser {set; get; }
    GameObject Target_move;
    Transform Self;

    [SerializeField]S_Game_Principale[] Stack_Script;
    [SerializeField] GameObject Ref_Prefable;
    bool Deplacement_au_centre;
    string Action_Animation;
    Rigidbody2D _rb;
    Animator zz;

    void Start()
    {
        if (zz == null) Debug.LogWarning($"Attention un animator n'est pas présent, veiller a vêrifier dans {this}");
        Target_move = GameObject.Find("Target_Center");
        _rb = GetComponent <Rigidbody2D>();
        zz = GetComponent<Animator>();
        Self = this.transform;
        Deplacement_au_centre = false;
        Securiser = false;
    }
    public void UI_Lance_Animation(string rr)
    {
        if (Securiser == false)
        {
            switch (rr)
            {
                case "Scene_Vats":
                    Action_Animation = "Eject_Carte"; //la en note quelle ordre en strig a distribuer au autres carte

                    Deplacement_au_centre = true;
                    zz.SetTrigger("Trigger_Bouton_Agrandir");
                    StartCoroutine("Delay_enlever_les_carte");
                    break;

                case "S":
                    Action_Animation = "Eject_Carte";
                    Deplacement_au_centre = true;
                    StartCoroutine("Delay_enlever_les_carte");
                    break;

                case "Remêttre_les_cartes":
                    Action_Animation = "Ré_integre_la_carte"; //la en note quelle ordre en strig a distribuer au autres carte
                    StartCoroutine("Delay_enlever_les_carte");
                    break;

                case "Ré_integre_la_carte":
                    zz.SetTrigger("Trigger_Bouton_Ajouter");
                    break;

                case "Eject_Carte":
                    Securiser = true;
                    zz.SetTrigger("Trigger_Bouton_delete");
                    Invoke("securiserBool", 2);
                    break;
            }
        }
        else Debug.LogError("securiser activer");
    }
    
    private IEnumerator Delay_enlever_les_carte()
    {
        int i = 0;
        /*
        Stack_Script = FindObjectsOfType<S_Game_Principale>();*/

        while (i < Stack_Script.Length && Stack_Script[i] != this)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            if (Stack_Script[i] !=this)
            {
                Stack_Script[i].UI_Lance_Animation(Action_Animation);
            }
            i++;
                
        }
        Securiser = false;

    }

    void pourchasseTarget()
    {
        if (Target_move != null && Deplacement_au_centre)
        {
            float ERT = Vector2.Distance(Target_move.transform.position, Self.position);
            if(ERT <= 120)
                zz.SetTrigger("Trigger_Bouton_Agrandir");
            _rb.position = Vector2.Lerp(this.transform.position, Target_move.transform.position, Time.deltaTime * 8);
        }
    }

    public void instance_Prefable()
    {
        GameObject OP = GameObject.Find("Canvas");
        GameObject RR = GameObject.Instantiate(Ref_Prefable, OP.transform);
    }


    private void Update()
    {
        pourchasseTarget();
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
