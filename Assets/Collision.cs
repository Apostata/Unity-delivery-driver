using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

  bool hasPackage;
  [SerializeField] int packagesDelivered = 0;
  [SerializeField] float destroyDelay = 0.5f;
  [SerializeField] Color32 carDefaultColorColor = new Color32(255, 255, 255, 255);
  [SerializeField] Color32 carLoadedColor = new Color32(250, 0, 186, 255);

  SpriteRenderer spriteRenderer;

  void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }
  void OnCollisionEnter2D(Collision2D other) {
    Debug.Log("Collision with " + other.gameObject.name);
  }

  void OnTriggerEnter2D(Collider2D other) {
    // if is a trigger from a package 
    if(other.CompareTag("Package") && !hasPackage) {
      Debug.Log("package collected");
      hasPackage = true;
      spriteRenderer.color = carLoadedColor;
      Destroy(other.gameObject, destroyDelay);
    }

    if(other.CompareTag("Customer") && hasPackage) {
      Debug.Log("package delivered");
      hasPackage = false;
      spriteRenderer.color = carDefaultColorColor;
      packagesDelivered++;

      if(packagesDelivered >= 10) {
        Debug.Log("You win!");
      }
    }
  }
}
