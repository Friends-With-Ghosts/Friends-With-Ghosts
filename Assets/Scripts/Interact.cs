using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{

    public Canvas canvas;

    public GameObject loreText;
    private TextMeshProUGUI loreTextMesh;

    bool loreReadable = false;
    public bool readingLore = false;

    string loreString = "";

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
        loreTextMesh = loreText.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!readingLore && loreReadable) {
            if(Input.GetKeyDown(KeyCode.F)){
                canvas.enabled = true;
                loreTextMesh.SetText(loreString);
                Time.timeScale = 0;
                readingLore = true;
            }
            
        } else if(readingLore || !loreReadable) {
            if(Input.GetKeyDown(KeyCode.F)){
                canvas.enabled = false;
                loreTextMesh.SetText("");
                Time.timeScale = 1;
                readingLore = false;
            }
            
        }
            
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if(other.gameObject.tag == "interactable"){
            loreReadable = true; 
            loreString = other.gameObject.GetComponent<Interactable>().loreSnippet;

        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "interactable"){
            loreReadable = false;
        }
    }

    
}
