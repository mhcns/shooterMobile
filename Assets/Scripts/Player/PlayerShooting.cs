using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour
{
    public AudioClip shootSound;

    public float fireRate = 0.5f;
    public float effectDisplay = 0.1f;
    public GameObject playerbullet;

    public Rigidbody granadePrefab;
    public Vector2 granadeImpulse;
    public Image granadeImage;
    public float granadeCD;
    private float granadeTimer;

    private float timer;
    private Light gunLight;
    private ParticleSystem gunEffect;
    private AudioPlayer audioPlayer;

    private void Awake()
    {
        gunLight = GetComponent<Light>();
        gunEffect = GetComponent<ParticleSystem>();
        audioPlayer = GetComponent<AudioPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        granadeTimer = granadeCD;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        granadeTimer += Time.deltaTime;
        granadeImage.fillAmount = granadeTimer / granadeCD;

        if (CrossPlatformInputManager.GetButtonDown("Granade"))
        {
            Granade();
        }

        if (timer > effectDisplay)
        {
            DisableEffects();
        }
    }

    public void Granade()
    {
        if(granadeTimer >= granadeCD)
        {
            granadeTimer = 0;
            Rigidbody newGranade = Instantiate(granadePrefab, transform.position, Quaternion.identity);
            newGranade.AddForce(transform.forward * granadeImpulse.x, ForceMode.Impulse);
            newGranade.AddForce(Vector3.up * granadeImpulse.y, ForceMode.Impulse);
        }
    }
    
    void DisableEffects()
    {
        gunLight.enabled = false;
    }

    public void Shoot()
    {
        if(timer > fireRate)
        {
            audioPlayer.PlaySound(shootSound);

            timer = 0;
            
            GameObject newBullet = Instantiate(playerbullet, transform.position, transform.rotation);
            
            gunLight.enabled = true;
            
            gunEffect.Stop();
            gunEffect.Play();
        }
    }
}
