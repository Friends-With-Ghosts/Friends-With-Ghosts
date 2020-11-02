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

    private ColorAdjustments colorAdjustments;
    
    public GameObject stage1;
    public GameObject stage2;


    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(blackout());
        profile = volume.sharedProfile;
        if (!profile.TryGet<ColorAdjustments>(out var colorAdjustments))
        {
            colorAdjustments = profile.Add<ColorAdjustments>(false);
        }

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
        if(Input.GetKeyDown(KeyCode.P)){
            StartBlackout();
        }
    }

    public void SwitchLights(){
        lightsGroup.SetActive(!lightsGroup.activeSelf);
        // lightsSFX.Play();
        // FindObjectOfType<AudioManager>().Play("screech");
    }

    public void CamEffect(){
        DOTween.To(()=> lensDistortion.intensity.value, x=> lensDistortion.intensity.value = x, 0.5f, 1);
    }

    public void Stage1Active(){
        stage1.SetActive(true);
        stage2.SetActive(false);
    }

    public void Stage2Active(){
        stage1.SetActive(false);
        stage2.SetActive(true);
    }

    IEnumerator blackout(){
        Debug.Log("Start blackout");
        SwitchLights();
        FindObjectOfType<AudioManager>().Play("screech");
        Stage2Active();
        yield return new WaitForSeconds(3f);
        SwitchLights();
        
        Debug.Log("End blackout");
    }

    public void StartBlackout(){
        StartCoroutine(blackout());
    }

}
