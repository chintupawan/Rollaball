using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject Explosion;
    public GameObject PlayerExplosion;
    public int ScoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameObject = GameObject.FindWithTag("GameController");
        if(gameObject != null)
        {
            gameController = gameObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot fine game controller object");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
            return;
        Instantiate(Explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        gameController.AddScore(ScoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
