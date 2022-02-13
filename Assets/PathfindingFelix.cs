using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingFelix
{
    public GameObject[] noeud;

    public GameObject noeudDepart;
    public GameObject noeudArriver;

    //List des noeud en dehord de la fonction
    List<Noeud> cheminCritique = new List<Noeud>();

    public PathfindingFelix(GameObject[] noeud)
    {
        this.noeud = noeud;
    }
        
    public List<GameObject> trouveChemin(int startX, int startY, int endX, int endY)
    {
        for (int i = 0; i < noeud.Length; i++)
        {
            if ((noeud[i].GetComponent<Noeud>().x == startX) && (noeud[i].GetComponent<Noeud>().y == startY))
            {
                noeudDepart = noeud[i];
                noeudDepart.GetComponent<Noeud>().depart = true;
                noeudDepart.GetComponent<Noeud>().utiliser = true;
            }

            if ((noeud[i].GetComponent<Noeud>().x == endX) && (noeud[i].GetComponent<Noeud>().y == endY))
            {
                noeudArriver = noeud[i];
                noeudArriver.GetComponent<Noeud>().arrivee = true;
                noeudArriver.GetComponent<Noeud>().utiliser = true;
            }
        }

        PreRecursif2();
        //PreRecursif(); 

        return new List<GameObject>(); // si on a R
    }

    public void PreRecursif()
    {
        //Effasement de la liste
        foreach (Noeud vieuxNoeud in cheminCritique)
        {
            vieuxNoeud.utiliser = false;
            cheminCritique.Remove(vieuxNoeud);
        }

        // Debut de la reche du voisin
        Noeud currentNode;
        currentNode = noeudDepart.GetComponent<Noeud>(); //PROVISOIRE
        cheminCritique.Add(currentNode);
        Recursif(currentNode);
    }


    public void Recursif(Noeud currentNode)
    {
        int nbVoisinVisiter = 0;
        
        foreach (GameObject voisinsPotentiel in currentNode.voisins)
        {
            while (nbVoisinVisiter < currentNode.voisins.Count)
            {
                int rng = Random.Range(0, currentNode.voisins.Count);

                if (voisinsPotentiel.GetComponent<Noeud>().utiliser == true)
                {
                    nbVoisinVisiter++;
                }
                else
                {
                    if (voisinsPotentiel.GetComponent<Noeud>().arrivee == true)
                    {
                        if (cheminCritique.Count == 3)
                        {
                            Debug.Log("FINI");
                            break;
                        }
                        else
                        {
                            PreRecursif();
                        }
                    }
                    else
                    {
                        currentNode = voisinsPotentiel.GetComponent<Noeud>();
                        cheminCritique.Add(currentNode);
                        Recursif(currentNode);
                    }
                }
            }

            if (nbVoisinVisiter == currentNode.voisins.Count) // Cas il n'y a plus de voisin dispo
            {
                Debug.Log("plus de voisin disponible");
                PreRecursif();
            }
        }
    }


    public void Recursif2(Noeud currentNoeud)
    {
        int rng = Random.Range(0, currentNoeud.voisins.Count);
        Noeud prochainVoisin = currentNoeud.voisins[rng].GetComponent<Noeud>();

        if(prochainVoisin.utiliser == true)
        {
            if(prochainVoisin.arrivee == true)
            {                
                if (cheminCritique.Count == 3)
                {
                    Debug.Log("Fin");
                    CreeCheminCritique();
                }
                else
                {
                    PreRecursif2();
                }
            }
            else
            {
                Debug.Log("place occuper par " + prochainVoisin.x + ":" + prochainVoisin.y);
                Recursif2(currentNoeud);
            }
        }
        else
        {
            Debug.Log("voisin trouver " + prochainVoisin.x + ":" + prochainVoisin.y);
            cheminCritique.Add(prochainVoisin);
            prochainVoisin.utiliser = true;
            Recursif2(prochainVoisin);
        }

    }

    public void PreRecursif2()
    {        
        //Effasement de la liste
        

        noeudDepart.GetComponent<Noeud>().depart = true;
        noeudDepart.GetComponent<Noeud>().utiliser = true;
        noeudArriver.GetComponent<Noeud>().arrivee = true;
        noeudArriver.GetComponent<Noeud>().utiliser = true;

        // Debut de la recherche du voisin        
        Noeud currentNode = noeudDepart.GetComponent<Noeud>();
        cheminCritique.Add(currentNode);
        Recursif2(currentNode);
    }

    public void CreeCheminCritique()
    {
        foreach (Noeud noeudCritique in cheminCritique)
        {
            noeudCritique.surCheminCritique = true;
            cheminCritique.Remove(noeudCritique);
        }
    }

    


}
;