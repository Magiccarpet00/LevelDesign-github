using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dictionary<string, GameObject> Characters = new Dictionary<string, GameObject>();
    public GameObject CharacterPrefab;
    public GameObject CharacterSelected;

    private void Start()
    {
        CreateCharacter(new Vector2(2f, 2f), "mage");
    }

    public void CreateCharacter(Vector2 pos ,string characterType)
    {
        GameObject newCharacter = Instantiate(CharacterPrefab, pos, Quaternion.identity);
        SpriteRenderer sprite = newCharacter.AddComponent<SpriteRenderer>();
        sprite.sprite = Ressource.instance.sprites[characterType];
        Characters.Add(characterType, newCharacter);
    }

    public void SelectCharacter(string typeCharacter)
    {
        CharacterSelected = Characters[typeCharacter];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
        }
    }
}
