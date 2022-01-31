using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMainCollision : MonoBehaviour
{

    public GameObject[] noeud;
    public GameObject[] ArriverPottentielle;

    void Start()
    {
        //setRngArrivee();

        //Pathfinding p = new Pathfinding(noeud);
        //p.trouveChemin(0, 0, 2, 3);

        PathfindingFelix p = new PathfindingFelix(noeud);
        p.trouveChemin(0, 2, 2, 3);
    }


    public void setRngArrivee()
    {
        int rng = Random.Range(0, ArriverPottentielle.Length);
        ArriverPottentielle[rng].GetComponent<Noeud>().arrivee = true;
        ArriverPottentielle[rng].GetComponent<Noeud>().utiliser = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }        
    }


}
