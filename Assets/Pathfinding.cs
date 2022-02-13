using System;
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
    public List<GameObject> trouveChemin(int startX, int startY, int endX, int endY)
    {

        GameObject startNode, endNode = null;
        startNode = new GameObject();

        List<GameObject> openList = new List<GameObject> { startNode }; // Notation pour rajouter un noeud, stylé
        List<GameObject> closedList = new List<GameObject>();

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
        }

        foreach (var n in noeud)
        {
            Noeud v = n.GetComponent<Noeud>();
            v.coutG = 10000; // infini
            float fCost = v.CalculateFCost();
            v.cameFromNode = null;
        }
        startNode.GetComponent<Noeud>().coutG = 0;
        startNode.GetComponent<Noeud>().coutH = CalculDistance(startNode, endNode);
        startNode.GetComponent<Noeud>().CalculateFCost();
        bool endNotFound = true;

        // boucle principale on va déplier toute notre liste de noeuds à étudier, la remplir, et sortir les noeuds déjà étudiés
        while (openList.Count > 0 && endNotFound) // on devra trouver une autre condition d'arrêt
        {
            GameObject currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                // on est arrivé !!
                endNotFound = false;
                return CalculChemin(endNode);
            }
            openList.Remove(currentNode); // on enlève le noeud à l'étude des noeuds à étudier ... 
            closedList.Add(currentNode); // .. et on le rajoute à la liste des noeuds déjà étudiés

            List<GameObject> nodes = currentNode.GetComponent<Noeud>().voisins; // --'
            foreach (GameObject neighborNode in nodes)
            {
                float tentativeGCost = currentNode.GetComponent<Noeud>().coutG + CalculDistance(currentNode, neighborNode);
                if (tentativeGCost < neighborNode.GetComponent<Noeud>().coutG)
                {
                    neighborNode.GetComponent<Noeud>().cameFromNode = currentNode.GetComponent<Noeud>();
                    neighborNode.GetComponent<Noeud>().coutG = tentativeGCost;
                    neighborNode.GetComponent<Noeud>().coutH = CalculDistance(neighborNode, endNode);
                    neighborNode.GetComponent<Noeud>().CalculateFCost();

                    if (!openList.Contains(neighborNode))
                    {
                        openList.Add(neighborNode);
                    }
                }
            }            
        }
        return new List<GameObject>(); // si on a R
    }



    /** 
     * A faire par Félix ;) 
     * */
    public List<GameObject> CalculChemin(GameObject endNode)
    {
        List<GameObject> cheminCritique = new List<GameObject>();

        cheminCritique = Recursif(endNode, cheminCritique);

        return cheminCritique;
    }

    public List<GameObject> Recursif(GameObject noeud, List<GameObject> _cheminCritique)
    {
        if(noeud.GetComponent<Noeud>().cameFromNode == null)
        {
            return _cheminCritique;
        }
        else
        {
            _cheminCritique.Add(noeud.gameObject);
            Recursif(noeud.GetComponent<Noeud>().cameFromNode.gameObject, _cheminCritique);
            return _cheminCritique;
        }
    }

    public GameObject GetLowestFCostNode(List<GameObject> openList)
    {
        GameObject pn = openList[0];
        for (int i = 1; i < openList.Count; i++)
        {
            if (openList[i].GetComponent<Noeud>().coutF < pn.GetComponent<Noeud>().coutF)
            {
                pn = openList[i];
            }
        }
        return pn;
    }

    public float CalculDistance(GameObject a, GameObject b) // hCost
    {
        Vector2 distance= a.transform.position - b.transform.position;
        float i = distance.magnitude;
        return i;
    }
}

