﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    private void Start() {
        gameObject.tag = "interactable";
    }
    public string loreSnippet = "";

}
