using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForetGenerator : MonoBehaviour
{
    //L'ecartement entre tuille et route
    public float hauteurOffSet = 0.8f;
    public float largeurOffSet = 0.5f;

    public GameObject tuillePrefab;
    public GameObject tuilleVirtuel;
    public GameObject routePrefabHorizontal;
    public GameObject routePrefabMontante;
    public GameObject routePrefabDescendante;

    // La foret est un biome qui s'etend que vers les directions : droitHaut - droit - droitBas - gaucheBas 
    // Elle comporte 5 tuiles avec sa tuile de depart
    // Sa tuille de depart a une route vers le monde exterieur en gaucheHaut

    // Position de depart
    public Vector3 startPosition = new Vector3(0f,0f,0f);

    // Position sur laquelle on pose une tuille
    public Vector3 pos;

    // Annuaire des voisins, on renseigne une position est on regarde si il a un voisin    
    public Dictionary<Vector3, GameObject> annuaireVoisin = new Dictionary<Vector3, GameObject>();

    // Dicnionaire pour placer les tuilles
    public Dictionary<string, Vector3> directionToVector = new Dictionary<string, Vector3>();



    void Start()
    {
        remplirDirectionToVector();
        remplirAnnuaireVoisin();
        pos = startPosition;

        // Mise en place de la tuille 1
        GameObject newTuille = Instantiate(tuillePrefab, pos, Quaternion.identity);                
        //On change l'annuaire
        annuaireVoisin[pos] = newTuille;

        //On place la route vers le monde exterieur
        Vector3 posRoute = new Vector3(pos.x - largeurOffSet, pos.y + hauteurOffSet, 0f);
        Instantiate(routePrefabDescendante, posRoute, Quaternion.identity);





        //TEST DES VECTEUR DANS LES DICO        
        Dictionary<Vector3, GameObject> testDico = new Dictionary<Vector3, GameObject>();
        GameObject go = Instantiate(tuillePrefab, pos, Quaternion.identity);
        testDico.Add(new Vector3(-1.55f, 0f, 0f), go);
        testDico.Add(new Vector3(1.55f, 0f, 0f), null);


        Vector3 v3 = new Vector3(1.55f, 0f, 0f);
        if(testDico[v3] != null)
        {
            Debug.Log("yo");
        }
        else
        {
            Debug.Log("hello");
        }        
        //TEST DES VECTEUR DANS LES DICO  ---FIN---






        for (int i = 0; i < 5; i++)
        {
            // Mise en place des autres tuille
            rngTuille();
        }        
    }

    public void remplirAnnuaireVoisin()
    {
        // On met la pos en bas à gauche
        pos = startPosition + (directionToVector["gaucheBas"])*5;

        for (int e = 0; e < 9; e++)
        {
            annuaireVoisin.Add(pos, null);
            for (int i = 1; i < 6; i++)
            {
                annuaireVoisin.Add(new Vector3((pos + (directionToVector["droite"]) * i).x,
                                        (pos + (directionToVector["droite"]) * i).y,
                                        0f), null);
            }
            pos = pos + directionToVector["droiteHaut"];
        }
    }

    public void placerTuille(string newPos)
    {
        /*
         annuaireVoisin.Add(new Vector3(99f, 99f, 0f), null);

         Vector3 v = new Vector3(99f, 99f, 0f);

         if(annuaireVoisin[v] == null)
         {
             Debug.Log("La si ça marche je me coupe les couilles");
         }
         */

        pos = pos + directionToVector[newPos];



        foreach (var item in annuaireVoisin)
        {
            if(item.Key == pos)
            {
                Debug.Log("its okayy");
                Debug.Log(item.Key);
                Debug.Log(annuaireVoisin[item.Key]);

            }
        }


        Vector3 v = new Vector3(0f, 0f, 0f);
        Debug.Log(annuaireVoisin[v]);

        
        if(annuaireVoisin[v] != null)
        {
            rngTuille(); // appel recursif encapsulé de la fonction... alors benoit tu suis toujours ?  
        }
        else
        {
            //GameObject newT = Instantiate(tuillePrefab, pos, Quaternion.identity);
            //annuaireVoisin.Add(pos, newT);
        }
        
    }
        
    public void rngTuille()
    {
        int rng = Random.Range(1, 5);

        switch (rng)
        {
            case 1:
                placerTuille("droiteHaut");
                break;
            case 2:
                placerTuille("droite");
                break;
            case 3:
                placerTuille("droiteBas");
                break;
            case 4:
                placerTuille("gaucheBas");
                break;
        }
    }

    public void remplirDirectionToVector()
    {
        directionToVector.Add("droiteHaut", new Vector3(1f, 1.6f, 0f));
        directionToVector.Add("droite", new Vector3(2f, 0f, 0f));
        directionToVector.Add("droiteBas", new Vector3(1f, -1.6f, 0f));
        directionToVector.Add("gaucheHaut", new Vector3(-1f, 1.6f, 0f));
        directionToVector.Add("gauche", new Vector3(-2f, 0f, 0f));
        directionToVector.Add("gaucheBas", new Vector3(-1f, -1.6f, 0f));
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
