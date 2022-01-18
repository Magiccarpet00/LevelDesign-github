using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    
    public SpriteRenderer spriteRenderer;
    public string typeGround;

    public void drawSprite(string s)
    {
        spriteRenderer.sprite = Ressource.instance.sprites[s];
    }

}
