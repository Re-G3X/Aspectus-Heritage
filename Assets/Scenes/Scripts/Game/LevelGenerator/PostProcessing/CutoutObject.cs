using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutoutObject : MonoBehaviour {
    [SerializeField] private Transform targetObject;

    [SerializeField] private LayerMask wallMask;

    private Camera mainCamera;

    private void Awake() {
        mainCamera = GetComponent<Camera>();
    }

    private void Update() {
        var cutoutPos = mainCamera.WorldToViewportPoint(targetObject.position);
        cutoutPos.y /= Screen.width / Screen.height;

        var offset = targetObject.position - transform.position;
        var hitObjects = Physics2D.RaycastAll(transform.position, offset, 100, wallMask);
        //Debug.Log("Got Objects: " + hitObjects.Length);
        foreach (var hitObject in hitObjects) {
            var square = hitObject.transform.Find("Square");
            if (!square) continue;
            var materials = square.transform.GetComponent<Renderer>().materials;
            foreach (var material in materials) {
                material.SetVector("_CutoutPos", cutoutPos);
                material.SetFloat("_CutoutSize", 0.1f);
                material.SetFloat("_FalloffSize", 0.05f);
            }
        }
    }
}