using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    public GameObject[] noeud;

    public Pathfinding(GameObject[] noeud)
    {
        this.noeud = noeud;
    }
    public void trouveChemin(int startX, int startY, int endX, int endY)
    {
        GameObject startNode, endNode = null;
        startNode = new GameObject();
        foreach (var n in noeud)
        {
            Noeud v = n.GetComponent<Noeud>();
            if (startX == v.x && startY == v.y)
            {
                startNode = n;
            }
            if (endX == v.x && endY == v.y)
            {
                endNode = n;
            }
            int a = 1;
        }

        foreach (var n in noeud) {

            Noeud v = n.GetComponent<Noeud>();
            v.coutG = 10000; // infini
            int fCost = v.CalculateFCost();
            v.cameFromNode = null;
          
        }
        startNode.GetComponent<Noeud>().coutG = 0;
        startNode.GetComponent<Noeud>().coutH = CalculDistance(startNode, endNode);
        startNode.GetComponent<Noeud>().CalculateFCost();
        bool endNotFound = true;

        

    }
    private int CalculDistance(GameObject a, GameObject b) // hCost
    {
        //int xDistance = Mathf.Abs(a.x - b.x);
        //int yDistance = Mathf.Abs(a.y - b.y);
        //int remaining = Math.Abs(xDistance - yDistance);
        //return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
        return -1;
    }
}
