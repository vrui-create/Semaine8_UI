using UnityEngine;
using UnityEngine.UI;

public class S_Slide_Volume : MonoBehaviour
{
    GameObject Objet_Sound_Manager;
    public Slider volumeSlider;
    S_Sound sound_Manager;


    void Start()
    {
        volumeSlider = GetComponent<Slider>();








        Objet_Sound_Manager = GameObject.Find("@Sound");
        if (Objet_Sound_Manager != null)
        {
            sound_Manager = Objet_Sound_Manager.GetComponent<S_Sound>();
        }
        volumeSlider.value = sound_Manager.audioSource_GameObject.volume;


    }

    public void Slide_ChangeVolume(float value)
    {
        if(sound_Manager!=null)sound_Manager.ChangeVolume(value);
        else Debug.LogWarning("sound_Manager not found in the scene.");
        print("Volume changed to: " + value);
    }
}
