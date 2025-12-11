using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Inventaire : MonoBehaviour
{
    //[SerializeField] GridLayoutGroup _Liste;
    [SerializeField] GameObject Prefable_Iteam;
    [SerializeField] Transform _contentTransform;
    [SerializeField] int Argent_Poche;
    List<S_Iteam> Liste_Iteam = new List<S_Iteam>();

    public void Add_Iteam_Grille(Sprite Vimage, string Vname)
    {
        bool Stack_Iteam = false;
        string nameIteam;
        if (Prefable_Iteam != null && Liste_Iteam !=null)
        {
            for (int i=0; i< Liste_Iteam.Count; i++)
            {

                if (Liste_Iteam[i]._UIText.text == Vname)
                {
                    Stack_Iteam = true;                     //On a trouver qu'il y a bien un iteam avec le même nom. Alors on rend Stack_Iteam en true
                    Liste_Iteam[i].Add_Stack_Iteam();
                    break;
                }
            }

            if(Stack_Iteam==false)       // Si un stack est en cours, alors pas besoin dans créer d'autre Iteam.
            {
                GameObject RR = Instantiate(Prefable_Iteam, _contentTransform);

                S_Iteam REF_ITEAM = RR.GetComponent<S_Iteam>();
                REF_ITEAM.Intialisation_Iteam(Vimage, Vname);
                Liste_Iteam.Add(REF_ITEAM);
            }
        }
        else Debug.LogError("Votre Prefable_Iteam n'est pas référentiel");
    }
}
