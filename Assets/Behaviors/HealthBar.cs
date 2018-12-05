using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public IntReference health;
	public IntReference maxHealth;

	public BoolReference active;

	private Image healthimage;
	// Use this for initialization
	void Start () {
        SetHealthImage();
	}

    // Update is called once per frame
    void Update()
    {
        ActivateOrDeactivate();
        UpdateHealthImage();
    }

    public void SetHealthImage()
    {
        healthimage = GetComponentInChildren<Image>();
    }

    public void UpdateHealthImage()
    {
        healthimage.fillAmount = (float)health.Value / (float)maxHealth.Value;
    }

    public void ActivateOrDeactivate()
    {
        if (active.Value)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
