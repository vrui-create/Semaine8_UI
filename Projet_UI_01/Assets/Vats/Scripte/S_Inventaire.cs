using UnityEngine;
using UnityEngine.UI;

public class S_Inventaire : MonoBehaviour
{
    [SerializeField] GridLayoutGroup _Liste;
    [SerializeField] GameObject Prefable_Iteam;

    public void Add_Iteam_Grille(Sprite Vimage, string Vname)
    {
        S_Iteam REF_ITEAM = Prefable_Iteam.GetComponent<S_Iteam>();
        if (REF_ITEAM != null)
        {
            REF_ITEAM.Intialisation_Iteam(Vimage, Vname);
        }
    }
}
