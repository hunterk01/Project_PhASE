using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponSelectUI : MonoBehaviour
{
    public Text kineticText;
    public Text massText;
    public Text torqueText;
    public Text gravityText;

    public bool kineticEnabled = true;
    public bool massEnabled = false;
    public bool torqueEnabled = false;
    public bool gravityEnabled = false;

    public int activeWeapon = 1;

    private Color disabledColor = Color.gray;
    private Color enabledColor = Color.green;

    void Start()
    {
        kineticText.color = enabledColor;
        massText.color = disabledColor;
        torqueText.color = disabledColor;
        gravityText.color = disabledColor;
    }

    void Update()
    {
        SelectWeapon();
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
}
