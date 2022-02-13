using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingBruteForce {

    public GameObject[] noeud;

    public GameObject noeudDepart;
    public GameObject noeudArriver;
    public GameObject noeudPrefab;

    //List des noeud en dehord de la fonction
    List<Noeud> cheminCritique = new List<Noeud>();

    public PathfindingBruteForce(GameObject[] noeud, GameObject noeudPrefab)
    {
        this.noeud = noeud;
        this.noeudPrefab = noeudPrefab;
    }

    public void setUp(int startX, int startY, int endX, int endY)
    {
        for (int i = 0; i < noeud.Length; i++)
        {
            if ((noeud[i].GetComponent<Noeud>().x == startX) && (noeud[i].GetComponent<Noeud>().y == startY))
            {
                noeudDepart = noeud[i];                
            }

            if ((noeud[i].GetComponent<Noeud>().x == endX) && (noeud[i].GetComponent<Noeud>().y == endY))
            {
                noeudArriver = noeud[i];                
            }
        }

        foreach (GameObject noeud in noeudArriver.GetComponent<Noeud>().voisins)
        {
            noeud.GetComponent<Noeud>().bientotArrivee = true;
        }


        bruteForce();

        
    }

    public void bruteForce()
    {
        foreach (Noeud vieuxNoeud in cheminCritique)
        {
            vieuxNoeud.utiliser = false;            
        }

        noeudDepart.GetComponent<Noeud>().depart = true;
        noeudDepart.GetComponent<Noeud>().utiliser = true;
        noeudArriver.GetComponent<Noeud>().arrivee = true;
        noeudArriver.GetComponent<Noeud>().utiliser = true;

        Noeud currentNoeud = noeudDepart.GetComponent<Noeud>();
        cheminCritique.Clear();
        cheminCritique.Add(currentNoeud);

        for (int i = 0; i < 3; i++)
        {
            int rng = Random.Range(0, currentNoeud.voisins.Count);
            Noeud prochainVoisin = currentNoeud.voisins[rng].GetComponent<Noeud>();

            if (prochainVoisin.utiliser == true) 
            {                
                bruteForce();
                return;
            }
            else
            {
                cheminCritique.Add(prochainVoisin);
                currentNoeud.utiliser = true;
                currentNoeud = prochainVoisin;
            }
        }

        if (currentNoeud.bientotArrivee == true)
        {
            Debug.Log("c'est fini");
            cheminCritique.Add(noeudArriver.GetComponent<Noeud>());
            foreach (Noeud noeud in cheminCritique)
            {
                Debug.Log(noeud);
                GameObject.Instantiate(noeudPrefab, noeud.GetComponentInParent<Transform>().transform);
            }
        }
        else
        {
            bruteForce();
            return;
        }

    }

}
