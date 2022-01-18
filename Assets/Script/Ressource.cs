using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressource : MonoBehaviour
{
    public Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    public Sprite[] allGroundSprites;
    public Sprite[] allCharacterSprites;    

    public static Ressource instance;

    void Awake()
    {
        instance = this;

        //GROUND
        sprites.Add("plaine", allGroundSprites[0]);
        sprites.Add("eau", allGroundSprites[1]);
        sprites.Add("montagne", allGroundSprites[2]);
        sprites.Add("neige", allGroundSprites[3]);

        //CHARACTER
        sprites.Add("mage", allCharacterSprites[0]);
    }    
}
