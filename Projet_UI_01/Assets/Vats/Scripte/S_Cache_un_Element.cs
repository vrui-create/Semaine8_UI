using UnityEngine;

public class S_Cache_un_Element : MonoBehaviour
{
    [SerializeField] bool cache_Lobjet;
    [SerializeField] GameObject RefObjet;
    public void Cache_Objet_Ref()
    {
        if (RefObjet != null)
        {
            if(RefObjet.activeSelf) RefObjet.SetActive(false);
            else RefObjet.SetActive(true);
        } 
        else Debug.LogError("votre objet n'est pas existant");
    }
    void Start()
    {
        if (cache_Lobjet && RefObjet != null)
        {
            RefObjet.SetActive(false);
        }
    }
    

}
