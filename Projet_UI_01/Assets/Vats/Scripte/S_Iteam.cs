using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_Iteam : MonoBehaviour
{
    public TextMeshProUGUI _UIText;
    [SerializeField] TextMeshProUGUI _Compteur;
    [SerializeField] GameObject _ChangeImage;
    
    [SerializeField] GameObject[] CacheUI; //Cache tous les élément indésirable
    public int Stack_Iteam = 1;

    public void Intialisation_Iteam(Sprite _Image, string Name_Iteam)
    {
        if (_Image != null && Name_Iteam != null && Name_Iteam != "")
        {
            _ChangeImage.GetComponent<Image>().sprite = _Image;
            _UIText.text = Name_Iteam;
        }
    }
    public void USE_Iteam()
    {
        if (Stack_Iteam > 1)
        {
            Stack_Iteam--;
            _Compteur.text = $"Quantité: 0{Stack_Iteam}X";
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Add_Stack_Iteam()//ERREUR ICI
    {
        if(Stack_Iteam < 3)
        {
            if (_Compteur != null)
            {
                Stack_Iteam++;
                _Compteur.text = $"Quantité: 0{Stack_Iteam}X";
            }
        }
    }
    public void DescriptionIteam(GameObject UI_Description)
    {
        UI_Description.SetActive(true);
        for (int i = 0; i < CacheUI.Length; i++)
        {
            CacheUI[i].gameObject.SetActive(false);
        }
        GameObject @Boutique = GameObject.Find("@Boutique").GetComponent<GameObject>();
        if (@Boutique != null)  Boutique.SetActive(false);
    }
}
