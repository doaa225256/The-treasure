using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class PlayerStats : MonoBehaviour
{

    public int health = 6;
    public int lives = 3;
    private float flickerTime = 0f;
    private float flickerDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    private float immunityTime = 0f;
    private float immunityDuration = 1.5f;
    public int coinsCollected = 0;
    public TextMeshProUGUI ScoreUI;
    public UnityEngine.UI.Image healthbar;

    void OnTriggerEnter2D(Collider2D collider)
    {

        switch (collider.transform.tag)
        {
            case "Coin":
                coinsCollected+=10;
                Destroy(collider.gameObject);
                break;
            case "greenMedcine":
                this.health = this.health+1;
                healthbar.fillAmount = this.health / 6f;
                break;
            case "redMedcine":
                this.health = this.health -1;
                healthbar.fillAmount = this.health / 6f;
                break;
            case "Spike":
                this.health = this.health -1;
                healthbar.fillAmount = this.health / 6f;
                break;

            default:
                break;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }
        ScoreUI.text = "" + coinsCollected;

    }

    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime > this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            healthbar.fillAmount = this.health / 6f;
            if (this.health < 0)
                this.health = 0;
            if (this.lives > 0 && this.health == 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
            }
            else if (this.lives == 0 && this.health == 0)
            {
                //Debug.Log("Gameover");
                Destroy(this.gameObject);
            }
            //Debug.Log("Player Health:"+this.health.ToString());
            //Debug.Log("Player Lives:" + this.lives.ToString());
        }
        playHiReaction();
    }
    void playHiReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0;
    }
}
