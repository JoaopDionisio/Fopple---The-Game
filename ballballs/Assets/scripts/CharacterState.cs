using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterState : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color defaultColor;
    private Color transparentColor;
    private Collider2D characterCollider;
    private int defaultLayerMask;
    private bool camuflagemON = false;

    public AudioSource audioSource;
    public AudioClip [] pointSounds;


    public EnergyController energy_script;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
        transparentColor = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 0.5f);
        characterCollider = GetComponent<Collider2D>();
        defaultLayerMask = characterCollider.gameObject.layer;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && energy_script.energySlider.value > 0 && !energy_script.pauseEnergyDrain)
        {
            TurnOnCamouflage();
        }
        else
        {
            if(camuflagemON)
            {
                TurnOffCamouflage();
            }
        }
    }
    private void TurnOnCamouflage()
    {
        spriteRenderer.color = transparentColor;
        characterCollider.gameObject.layer = LayerMask.NameToLayer("Camuflagem");
        camuflagemON = true;

        energy_script.DrainEnergy();
        energy_script.pauseEnergyRegen = true;

        /*  PASSAR PARA COMER
         * 
         * 
         */
        float radius = 0.1f; // Muda isto como queiras
        int pointLayer = LayerMask.GetMask("Points"); // Assuming "Point" objects are on a separate layer
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, pointLayer);
        if (hit != null && hit.CompareTag("Point"))
        {
            // Collision detected with a GameObject tagged "Point"
            Debug.Log("Collided with a Point object");
            hit.gameObject.GetComponent<PointController>().Destroyer();
            PointGeneratorScript.OnPointDestroyed();

            scoreScript.score++;

            
            
            if (scoreScript.score % 10 == 1 || scoreScript.score % 10 == 2)
            {

                AudioSource.PlayClipAtPoint(pointSounds[0], gameObject.transform.position);
            }
            else if(scoreScript.score % 10 == 3 || scoreScript.score % 10 == 4)
            {
                AudioSource.PlayClipAtPoint(pointSounds[1], gameObject.transform.position);

            }
            else if (scoreScript.score % 10 == 5 || scoreScript.score % 10 == 6)
            {
                AudioSource.PlayClipAtPoint(pointSounds[2], gameObject.transform.position);

            }
            else if (scoreScript.score % 10 == 7 || scoreScript.score % 10 == 8)
            {
                AudioSource.PlayClipAtPoint(pointSounds[3], gameObject.transform.position);

            }
            else if (scoreScript.score % 10 == 9 || scoreScript.score % 10 == 0)
            {
                AudioSource.PlayClipAtPoint(pointSounds[4], gameObject.transform.position);

            }
            
        }
        /**/


    }

    public void TurnOffCamouflage()
    {
        camuflagemON = false;
        spriteRenderer.color = defaultColor;
        characterCollider.gameObject.layer = defaultLayerMask;

        /*  LARGAR PARA COMER
         *
        float radius = 0.1f; // Muda isto como queiras
        int pointLayer = LayerMask.GetMask("Points"); // Assuming "Point" objects are on a separate layer
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, pointLayer);
        if (hit != null && hit.CompareTag("Point"))
        {
            // Collision detected with a GameObject tagged "Point"
            Debug.Log("Collided with a Point object");
            Destroy(hit.gameObject);
            PointGeneratorScript.OnPointDestroyed();
            scoreScript.score++;
        }
        /**/
        energy_script.pauseEnergyRegen = false;

    }


}
