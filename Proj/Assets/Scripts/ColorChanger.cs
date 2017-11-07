using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

    public Sprite sprite1; 
    public Sprite sprite2; 
    public bool isAlive;
    public int cellx;
    public int celly;
    

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        if (spriteRenderer.sprite == null) 
            spriteRenderer.sprite = sprite1; 
    }

    public void ChangeSprite()
    {
        cellx = Mathf.RoundToInt(this.transform.position.x);
        celly = Mathf.RoundToInt(this.transform.position.y);
        if (spriteRenderer.sprite == sprite1) 
        {
            spriteRenderer.sprite = sprite2;
            isAlive = true;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
            isAlive = false;
        }
        GridGenerator.arraydab[cellx, celly] = isAlive;
    }
}
