using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //added this so we can actually change and reload scenes, used for restart button R

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb; //reference to the rigidbody2D
    public Transform target; // reference to the transform of the emty called "target"

    public SpriteRenderer defaultSprite; //to flip the sprite on x axis

    public Sprite newSprite; // the reference for the new sprite when gameover is reached, aka the failure sprite

    public GameObject gameOverScreen; //reference to the gameover text/gameobject
    public GameObject winScreen; //reference to the win text/gameobject

    


    private void Start()
    {
        defaultSprite = GetComponentInChildren<SpriteRenderer>(); //reference to the sprite renderer component of the player, to flip the sprite on x axis and change it
    }



    /*
     * 
     *So basically the code works as follows: if the player presses wasd, a gameobject called target (with the frogsprite) at the players position gets moved 1 increment in the direction the player chooses.
     * then the rigidbody of the playersprite gets moved to that position. that also means if you press 5 times against a wall, the target still gets moved even if the rigidbody has a collider and cant follow.
     * so possible "bugfixes" could be:
     * - change movement to direct movement with rigidbody (not with target gameobject)
     * - freeze/constrain ALL movement when game over or win is reached (atm some things can still move when timescale is 0)
     * - better sprites? colours, backgrounds, animations? sound?
     * 
     * hope i didnt confuse you too much :D
     * -Jonas
     * 
     */





    void Update()
    {

       
        

            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.transform.position += new Vector3(0, 1f, 0); //if we press w add 1 to the y value (up)
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.transform.position += new Vector3(-1f, 0, 0); //if we press a add -1 to the x value (left)
                defaultSprite.flipX = false; //to flip the sprite on x axis
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.transform.position += new Vector3(0, -1f, 0); //if we press s add -1 to the y value (down)
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.transform.position += new Vector3(1f, 0, 0); //if we press d add 1 to the x value (right)
                defaultSprite.flipX = true; //to flip the sprite on x axis
            }



        if (Input.GetKeyDown(KeyCode.R)) //restart button R
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //load the scene again, to get a clean scene
            gameOverScreen.SetActive(false); // deactivates the gameover screen
            Time.timeScale = 1; //sets timescale back to 1, so the game is playable again
            


        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(); //if we press escape, close the game (build)
           // UnityEditor.EditorApplication.ExitPlaymode(); //if we press escape, close the game (editor)

        }



    }



    private void OnTriggerEnter2D(Collider2D collision) //check if we collide with a collider/trigger
    {
        if (collision.gameObject.CompareTag("Enemy")) //if we hit a trigger object with the tag set to enemy
        {
            
            defaultSprite.sprite = newSprite; //the sprite gets changed to the fail sprite
            gameOverScreen.SetActive(true); //the gameoverscreen gets activated
            Time.timeScale = 0; //timescale gets set to 0, which means ingame time is stopped, this deactivates most stuff so the game isnt playable after we lose
        }

        else if (collision.gameObject.CompareTag("Finish")) //if we hit a trigger with the tag finish
        {
            winScreen.SetActive(true); //activates the winscreen object
            Time.timeScale = 0; //timescale gets set to 0, which means ingame time is stopped, this deactivates most stuff so the game isnt playable after we win
        }
    }




    void FixedUpdate() //fixedupdate for physics (rigidbody)
    {
        
        // rb.MovePosition(Vector3.Slerp(this.transform.position, target.position, 0.3f)); //moves the rigidbody of the player smooth (slerp) to the position of the target
        
    }

}