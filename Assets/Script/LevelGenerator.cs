using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class LevelGenerator : MonoBehaviour
{
    public GameObject cellPrefab;
    public int gridSize;
    public Dictionary<Vector2, GameObject> grid = new Dictionary<Vector2, GameObject>();

    private void Start()
    {
        makeGrid();
        makeGround(new Vector2(0f, 0f), gridSize, gridSize, "plaine");
        StartCoroutine(Blop());
    }

    public void makeGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Vector2 pos = new Vector2(i, j);
                GameObject c = Instantiate(cellPrefab, pos, Quaternion.identity);
                grid.Add(pos, c);
                c.name = "cell (" + i + ":" + j + ")";
                c.transform.parent = gameObject.transform;
            }
        }        
    }

    public void makeGround(Vector2 coinBasGauche, int largeur, int hauteur, string typeGround)
    {
        for (int i = (int)coinBasGauche.x; i < (int)coinBasGauche.x + largeur; i++)
        {
            for (int j = (int)coinBasGauche.y; j < (int)coinBasGauche.y + hauteur; j++)
            {
                Vector2 v = new Vector2(i, j);
                Cell c = grid[v].GetComponent<Cell>();
                c.typeGround = typeGround;
                c.drawSprite(typeGround);                
            }
        }
    }

    public IEnumerator Blop()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 5; i++)
        {
            makeGround(new Vector2(2f, 2f), 1+i, 1, "eau");
            yield return new WaitForSeconds(1f);
        }
    }


    
    
}
