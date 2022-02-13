using UnityEngine;
using UnityEngine.SceneManagement;

public class TestMainCollision : MonoBehaviour
{

    public GameObject[] noeud;
    public GameObject[] ArriverPottentielle;
    public GameObject noeudPrefab;

    void Start()
    {

        PathfindingBruteForce p = new PathfindingBruteForce(noeud, noeudPrefab);
        p.setUp(0, 2, 2, 3);
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
