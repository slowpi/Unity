using UnityEngine;
using System.Collections;

public class DesroyByContact : MonoBehaviour
{
    public GameObject exposion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find GameController script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(exposion, other.transform.position, other.transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
