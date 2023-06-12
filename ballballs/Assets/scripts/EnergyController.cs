using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyController : MonoBehaviour
{

    public float maxEnergy = 100f;
    public float energyDrainRate;
    public float energyRegenSpeed;
    public bool pauseEnergyRegen = false;
    public bool pauseEnergyDrain = false;

    private float currentEnergy;

    public Image energyBarImage;
    public Slider energySlider;

    public Color lowEnergyColor;
    public Color fullEnergyColor;



    // Start is called before the first frame update
    void Start()
    {
        energySlider = GetComponent<Slider>();

        lowEnergyColor = new Color32(255, 0, 0, 255);
        fullEnergyColor = new Color32(255, 237, 0, 255);

        currentEnergy = maxEnergy;
        energySlider.maxValue = maxEnergy;
        energySlider.value = currentEnergy;


    }

    // Update is called once per frame
    void Update()
    {

        float energyPercentage = currentEnergy / maxEnergy;
        energyBarImage.color = Color.Lerp(lowEnergyColor, fullEnergyColor, energyPercentage);

        if (currentEnergy >= 100)
        {
            currentEnergy = 100;
            if (pauseEnergyDrain)
            {
                pauseEnergyDrain = false;
                //mudar a cor do slider para amarelo
                
            }
            
        }
        else if(!pauseEnergyRegen)
        {
            currentEnergy += energyRegenSpeed * Time.deltaTime;
            energySlider.value = currentEnergy;
        }
    }
    public void DrainEnergy()
    {
        currentEnergy -= energyDrainRate * Time.deltaTime;
        energySlider.value = currentEnergy;

        if (currentEnergy <= 0)
        {
            currentEnergy = 0;
            pauseEnergyDrain = true;

            //mudar a cor do slider para cinzento
        }
    }
}
