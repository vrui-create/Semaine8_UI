using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Boutton_Add_Iteam : MonoBehaviour
{
    [SerializeField] GameObject _Target_Inventaire;
    [SerializeField] Sprite _sprite;
    [SerializeField] string _name;


    public void Commande_Inventaire()
    {
        if (_Target_Inventaire !=null && _sprite != null && _name != "")
        {
            S_Inventaire s_Inventaire = _Target_Inventaire.GetComponent<S_Inventaire>();
            s_Inventaire.Add_Iteam_Grille(_sprite, _name);
        }
    }

}
