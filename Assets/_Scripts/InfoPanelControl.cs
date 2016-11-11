using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoPanelControl : MonoBehaviour
{
    [TextArea]
    public string[] dialog;

    public GameObject infoPanel;
    public GameObject weaponPanel;
    public Text infoPanelText;

    public bool enableKinetic = true;
    public bool enableMass = false;
    public bool enableTorque = false;
    public bool enableGravity = false;
    
    private int dialogCount = 0;
    private bool isTriggered = false;
    private bool infoCompleted = false;

    WeaponSelectUI weaponUI;
    LaserController laserController;
    	
    void Start()
    {
        infoPanel.SetActive(false);

        weaponUI = weaponPanel.GetComponent<WeaponSelectUI>();

        laserController = GetComponent<LaserController>();
    }

	void Update ()
    {
        if (isTriggered && !infoCompleted)
            DisplayInfo();
	}

    void OnTriggerEnter()
    {
        isTriggered = true;
        gameObject.GetComponent<Collider>().enabled = false;

        EnableBeams();
        LaserEnabler();
    }

    void DisplayInfo()
    {
        if (dialog.Length != 0)
        {
            if (infoPanel.activeSelf == false)
                infoPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                dialogCount++;

            if (dialogCount < dialog.Length)
            {
                infoPanelText.text = dialog[dialogCount];
            }
            else
            {
                infoCompleted = true;
                infoPanel.SetActive(false);
            }
        }
    }

    void EnableBeams()
    {
        if (enableMass)
            weaponPanel.GetComponent<WeaponSelectUI>().massEnabled = true;
        if (enableTorque)   weaponUI.torqueEnabled = true;
        if (enableGravity)  weaponUI.gravityEnabled = true;
    }

   void LaserEnabler()
    {
        if (enableKinetic == true)
            {
            laserController.kineticActive = true;
            }
        if (enableMass == true)
            {
            laserController.massActive = true;
            }
        if (enableTorque == true)
            {
            laserController.torqueActive = true;
            }
        if (enableGravity == true)
            {
            laserController.gravityActive = true;
            }
    }
}
