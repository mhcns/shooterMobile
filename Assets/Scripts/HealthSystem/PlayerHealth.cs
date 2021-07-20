using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : Health
{

    public Slider healthSlider;
    public Image damageImage;
    public Color damageColor;
    public float flashSpeed = 5;

    public AudioClip damageSound, deathSound;

    private bool damaged;
    private Animator anim;
    private PlayerMovement playerMovement;
    private AudioPlayer audioPlayer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        audioPlayer = GetComponent<AudioPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public override void TakeDamage(int damage, Vector3 hitPoint)
    {
        if (isDead)
            return;

        audioPlayer.PlaySound(damageSound);
        damaged = true;
        currentHealth -= damage;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    protected override void Death()
    {
        isDead = true;
        audioPlayer.PlaySound(deathSound);
        anim.SetTrigger("Death");
        playerMovement.enabled = false;
        LevelController.instance.GameOver();
    }

    protected override void Spawn()
    {
        currentHealth = startingHealth;
        isDead = false;
    }

   
}
