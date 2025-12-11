using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Boutton_Add_Iteam : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _Custom_Text_Button_self;
    [SerializeField] GameObject _Custom_Bouton_sprite_self;
    private Sprite _sprite;
    private string _name;

    private void Start()
    {
        _sprite = _Custom_Bouton_sprite_self.GetComponent<Image>().sprite;
        _name = GetComponentInChildren<TextMeshProUGUI>().text;
    }


    public void Commande_Inventaire(GameObject _Target_Inventaire)
    {
        if (_Target_Inventaire != null && _sprite != null && _name != "")
        {
            S_Inventaire s_Inventaire = _Target_Inventaire.GetComponent<S_Inventaire>();
            if (s_Inventaire != null) s_Inventaire.Add_Iteam_Grille(_sprite, _name);
            else Debug.LogError("Votre Reference _Target_Inventaire est introuvable dans la fonction Commande_Inventaire");
        }
        else Debug.LogError("Votre référence ne posséder pas S_Inventaire");
    }

}
