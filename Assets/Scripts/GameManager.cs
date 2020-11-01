using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public GameObject lightsGroup;
    

    public AudioSource lightsSFX;

    public Camera cam;

    

    public Volume volume;
    public VolumeProfile profile;
    private LensDistortion lensDistortion;


    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            SwitchLights();
        }
        if(Input.GetKeyDown(KeyCode.C)){
            CamEffect();
        }
    }

    public void SwitchLights(){
        lightsGroup.SetActive(!lightsGroup.activeSelf);
        // lightsSFX.Play();
        FindObjectOfType<AudioManager>().Play("screech");
    }

    public void CamEffect(){
        DOTween.To(()=> lensDistortion.intensity.value, x=> lensDistortion.intensity.value = x, 0.5f, 1);
    }

}
