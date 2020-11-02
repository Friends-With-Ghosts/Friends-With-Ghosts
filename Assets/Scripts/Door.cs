using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{

    public bool isLocked = false;
    public bool isOpenable= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(isOpenable);
        if(isOpenable){
            if(Input.GetKeyDown(KeyCode.F)){
                transform.DOLocalRotate(Quaternion.Euler(-90,90,-90).eulerAngles, 0.5f);
                isOpenable = false;
            }
        } else if(!isOpenable) {
            if(Input.GetKeyDown(KeyCode.F)){
                transform.DOLocalRotate(Quaternion.Euler(-90,0,-90).eulerAngles, 0.5f);
                isOpenable = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Open me");
            if(!isLocked){
                isOpenable = true;
            }
        }
    }


}
