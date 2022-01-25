using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMainCollision : MonoBehaviour
{

    public GameObject[] noeud; 

    void Start()
    {
        Noeud n = noeud[20].GetComponent<Noeud>();
        n.DefinireArriver(2, 0);
        Pathfinding p = new Pathfinding(noeud);
        p.trouveChemin(0, 0, 2, 3);
    }

    
}
