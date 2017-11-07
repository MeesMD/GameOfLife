using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

    private GameObject gameObject;
    //public static bool Objecthit = false;

    void Start()
    {
        gameObject = GetComponent<GameObject>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    hit.collider.GetComponent<ColorChanger>().ChangeSprite();
                }
            }
        }
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.cyan);
    }
}
