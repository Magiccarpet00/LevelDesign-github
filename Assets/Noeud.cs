using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noeud : MonoBehaviour
{

    public int x;
    public int y;

    public List<GameObject> voisins = new List<GameObject>();
    public static float X_OFFSET = 1f;
    public static float Y_OFFSET = 1.6f;

    // On va ptet utilse ce type de bool mais pas sur
    public bool utiliser;
    public bool depart;
    public bool arrivee;
    public bool bientotArrivee;

    [HideInInspector]
    public bool arriveePotentiel;    
    public bool surCheminCritique;
    [HideInInspector]
    public bool estNoeudDisjoint;

    [HideInInspector]
    public float coutG, coutF, coutH;
    public Noeud cameFromNode;

    public void Awake()
    {
        Renomage();  // renome le nom du noeud avec les coordonnes X;Y
        RegarderVoisins();
        
        //DefinireArriver()

    }

    public void Renomage()
    {
        this.name = "noeud " + x + ";" + y;
    }

    public void RegarderVoisins()
    {
        Vector2 posCheckVoisin1 = new Vector2(transform.position.x + X_OFFSET*2, transform.position.y);             //droite droite
        Vector2 posCheckVoisin2 = new Vector2(transform.position.x + X_OFFSET, transform.position.y - Y_OFFSET);    //droite bas
        Vector2 posCheckVoisin3 = new Vector2(transform.position.x - X_OFFSET, transform.position.y - Y_OFFSET);    //gauche bas
        Vector2 posCheckVoisin4 = new Vector2(transform.position.x - X_OFFSET*2, transform.position.y);             //gauche gauche
        Vector2 posCheckVoisin5 = new Vector2(transform.position.x - X_OFFSET, transform.position.y + Y_OFFSET);    //gauche haut
        Vector2 posCheckVoisin6 = new Vector2(transform.position.x + X_OFFSET, transform.position.y + Y_OFFSET);    //droite haut

        float radiusCircle = 0.2f;
        Collider2D collider_voisin1 = Physics2D.OverlapCircle(posCheckVoisin1, radiusCircle);
        Collider2D collider_voisin2 = Physics2D.OverlapCircle(posCheckVoisin2, radiusCircle);
        Collider2D collider_voisin3 = Physics2D.OverlapCircle(posCheckVoisin3, radiusCircle);
        Collider2D collider_voisin4 = Physics2D.OverlapCircle(posCheckVoisin4, radiusCircle);
        Collider2D collider_voisin5 = Physics2D.OverlapCircle(posCheckVoisin5, radiusCircle);
        Collider2D collider_voisin6 = Physics2D.OverlapCircle(posCheckVoisin6, radiusCircle);

        if (collider_voisin1 != null)
        {
            if (collider_voisin1.CompareTag("noeud"))
            {
                this.voisins.Add(collider_voisin1.gameObject);
            }
        }

        if (collider_voisin2 != null)
        {
            if (collider_voisin2.CompareTag("noeud"))
            {
                this.voisins.Add(collider_voisin2.gameObject);
            }
        }

        if (collider_voisin3 != null)
        {
            if (collider_voisin3.CompareTag("noeud"))
            {
                this.voisins.Add(collider_voisin3.gameObject);
            }
        }

        if (collider_voisin4 != null)
        {
            if (collider_voisin4.CompareTag("noeud"))
            {
                this.voisins.Add(collider_voisin4.gameObject);
            }
        }

        if (collider_voisin5 != null)
        {
            if (collider_voisin5.CompareTag("noeud"))
            {
                this.voisins.Add(collider_voisin5.gameObject);
            }
        }

        if (collider_voisin6 != null)
        {
            if (collider_voisin6.CompareTag("noeud"))
            {
                this.voisins.Add(collider_voisin6.gameObject);
            }
        }

    }

    public void DefinireArriver(int _x, int _y)
    {
        bool voisinTrouver = false;

        for (int i = 0; i < voisins.Count; i++)
        {
            Noeud v = voisins[i].GetComponent<Noeud>();
            if (v.x == _x && v.y == _y)
            {
                v.arrivee = true;
                voisinTrouver = true;
            }
        }

        if(voisinTrouver == false)
        {
            Debug.Log("DefinireArriver() n'a pas trouver de voisin");
        }
    }

    public float CalculateFCost()
    {
        return coutG + coutH;
    }

}
