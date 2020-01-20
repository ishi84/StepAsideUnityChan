using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRenderer : MonoBehaviour {

    private GameObject mainCamera;
    private float cameraPos;
    private float myPos;

    // Use this for initialization
    void Start () {
        this.mainCamera = GameObject.Find("Main Camera");
        this.myPos = this.transform.position.z;
    }
    
    // Update is called once per frame
    void Update () {
        this.cameraPos = mainCamera.transform.position.z;
        if (this.cameraPos > this.myPos) {
            Destroy(this.gameObject);
        }
    }
}
