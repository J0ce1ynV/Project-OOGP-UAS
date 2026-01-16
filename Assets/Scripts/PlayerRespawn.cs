using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
        //uiManager = FindFirstObjectByType<UIManager>();
    }

    public void CheckRespawn()
    {
        if (currentCheckpoint == null)
        {
            uiManager.GameOver();
            return;
        }

        playerHealth.Respawn(); //Restore player health and reset animation
        transform.position = currentCheckpoint.position; //Move player to checkpoint location

        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }


    //public void Respawn()
    //{
    //    playerHealth.Respawn(); //Untuk respawn nambah hp seperti awal game
    //    transform.position = currentCheckpoint.position; //Ini untuk respawn player balik ke checkpoint

    //    GetComponent<PlayerMovement>().enabled = true;

    //    //posisi kamera berubah lagi
    //    Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Checkpoint")
    //    {
    //        currentCheckpoint = collision.transform;;
    //        collision.GetComponent<Collider2D>().enabled = false;
    //        collision.GetComponent<Animator>().SetTrigger("appear");
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;

            Collider2D col = collision.GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;

            Animator anim = collision.GetComponent<Animator>();
            if (anim != null)
                anim.SetTrigger("appear");
        }
    }

}