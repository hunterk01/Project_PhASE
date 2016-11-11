using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponSelectUI : MonoBehaviour
{
    Text kineticText;
    Text massText;
    Text torqueText;
    Text gravityText;

    public GameObject kineticUI;
    public GameObject massUI;
    public GameObject torqueUI;
    public GameObject gravityUI;

    public bool kineticEnabled = true;
    public bool massEnabled = false;
    public bool torqueEnabled = false;
    public bool gravityEnabled = false;

    public int activeWeapon = 1;

    private Color disabledColor = Color.gray;
    private Color enabledColor = Color.green;

    void Start()
    {
        kineticText = kineticUI.GetComponentInChildren<Text>();
        massText = massUI.GetComponentInChildren<Text>();
        torqueText = torqueUI.GetComponentInChildren<Text>();
        gravityText = gravityUI.GetComponentInChildren<Text>();

        kineticText.color = enabledColor;
        massText.color = disabledColor;
        torqueText.color = disabledColor;
        gravityText.color = disabledColor;
    }

    void Update()
    {
        SelectWeapon();
        EnableWeapon();
    }

    void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeWeapon = 1;
            UpdateWeaponUI();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && massEnabled)
        {
            activeWeapon = 2;
            UpdateWeaponUI();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && torqueEnabled)
        {
            activeWeapon = 3;
            UpdateWeaponUI();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && gravityEnabled)
        {
            activeWeapon = 4;
            UpdateWeaponUI();
        }
    }

    public void UpdateWeaponUI()
    {
        if (activeWeapon == 1)
        {
            kineticText.color = enabledColor;
            massText.color = disabledColor;
            torqueText.color = disabledColor;
            gravityText.color = disabledColor;
        }
        else if (activeWeapon == 2)
        {
            kineticText.color = disabledColor;
            massText.color = enabledColor;
            torqueText.color = disabledColor;
            gravityText.color = disabledColor;
        }
        else if (activeWeapon == 3)
        {
            kineticText.color = disabledColor;
            massText.color = disabledColor;
            torqueText.color = enabledColor;
            gravityText.color = disabledColor;
        }
        else if (activeWeapon == 4)
        {
            kineticText.color = disabledColor;
            massText.color = disabledColor;
            torqueText.color = disabledColor;
            gravityText.color = enabledColor;
        }
    }

    void EnableWeapon()
    {
        if (kineticEnabled)
            kineticUI.SetActive(true);
        else
            kineticUI.SetActive(false);

        if (massEnabled)
            massUI.SetActive(true);
        else
            massUI.SetActive(false);

        if (torqueEnabled)
            torqueUI.SetActive(true);
        else
            torqueUI.SetActive(false);

        if (gravityEnabled)
            gravityUI.SetActive(true);
        else
            gravityUI.SetActive(false);
    }
}
