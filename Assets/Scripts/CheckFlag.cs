using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckFlag : MonoBehaviour
{
    public GameObject image;
    public GameObject player;
    public int nextScene;
    [SerializeField] private LevelLoadfer nextLevel;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            Invoke("NewScene", 1f);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
            image.SetActive(true);
    }

    private void NewScene()
    {
        nextLevel.LoadLevel(nextScene);
    }
}
