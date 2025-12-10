using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_Iteam : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _UIText;
    [SerializeField] GameObject _ChangeImage;
    [SerializeField] Sprite _ChangeSprite;
    [SerializeField] string _Name_Iteam;


    public void Intialisation_Iteam(Sprite _Image, string Name_Iteam)
    {
        if (_Image != null && Name_Iteam != null && Name_Iteam != "")
        {
            _ChangeImage.GetComponent<Image>().sprite = _ChangeSprite;
            _UIText.text = _Name_Iteam;
        }
    }
    public void USE()
    {
        Destroy(gameObject);
    }
}
