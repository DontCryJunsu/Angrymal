using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FireBar : MonoBehaviour
{

    public Image IMG;
    float total;
    public float plus;
    public Text tx;

    public GameObject chicUI;
    public GameObject dogUI;
    public GameObject bufUI;
    public GameObject jirUI;
    public GameObject lionUI;
    public GameObject elepUI;
    public GameObject mouUI;
    public GameObject wolfUI;
    public GameObject sheepUI;
    public GameObject pigUI;
    public GameObject snakUI;
    public GameObject catUI;
    public GameObject kanUI;

    public float costchicUI;
    public float costdogUI;
    public float costbufUI;
    public float costjirUI;
    public float costlionUI;
    public float costelepUI;
    public float costmouUI;
    public float costwolfUI;
    public float costsheepUI;
    public float costpigUI;
    public float costsnakUI;
    public float costcatUI;
    public float costkanUI;

    Button bchicUI;
    Button bdogUI;
    Button bbufUI;
    Button bjirUI;
    Button blionUI;
    Button belepUI;
    Button bmouUI;
    Button bwolfUI;
    Button bsheepUI;
    Button bpigUI;
    Button bsnakUI;
    Button bcatUI;
    Button bkanUI;

    public static int Gaze;

    // Use this for initialization
    void Start()
    {
        IMG = GetComponent<Image>();
        total = 100;
        plus = 0.05f;

        bchicUI = chicUI.GetComponent<Button>();
        bdogUI = dogUI.GetComponent<Button>();
        bbufUI = bufUI.GetComponent<Button>();
        bjirUI = jirUI.GetComponent<Button>();
        blionUI = lionUI.GetComponent<Button>();
        belepUI = elepUI.GetComponent<Button>();
        bmouUI = mouUI.GetComponent<Button>();
        bwolfUI = wolfUI.GetComponent<Button>();
        bsheepUI = sheepUI.GetComponent<Button>();
        bpigUI = pigUI.GetComponent<Button>();
        bsnakUI = snakUI.GetComponent<Button>();
        bcatUI = catUI.GetComponent<Button>();
        bkanUI = kanUI.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

        IMG.fillAmount += plus / total;
        tx.text = ((int)(IMG.fillAmount * 100f)).ToString();

        if (IMG.fillAmount * 100 < costchicUI && bchicUI.interactable)
        {
            bchicUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costchicUI && !bchicUI.interactable)
        {
            bchicUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costdogUI && bdogUI.interactable)
        {
            bdogUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costdogUI && !bdogUI.interactable)
        {
            bdogUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costbufUI && bbufUI.interactable)
        {
            bbufUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costbufUI && !bbufUI.interactable)
        {
            bbufUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costjirUI && bjirUI.interactable)
        {
            bjirUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costjirUI && !bjirUI.interactable)
        {
            bjirUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costlionUI && blionUI.interactable)
        {
            blionUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costlionUI && !blionUI.interactable)
        {
            blionUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costelepUI && belepUI.interactable)
        {
            belepUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costelepUI && !belepUI.interactable)
        {
            belepUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costmouUI && bmouUI.interactable)
        {
            bmouUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costmouUI && !bmouUI.interactable)
        {
            bmouUI.interactable = true;
        }
        ///////////////////////////////////
        if (IMG.fillAmount * 100 < costwolfUI && bwolfUI.interactable)
        {
            bwolfUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costwolfUI && !bwolfUI.interactable)
        {
            bwolfUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costsheepUI && bsheepUI.interactable)
        {
            bsheepUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costsheepUI && !bsheepUI.interactable)
        {
            bsheepUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costpigUI && bpigUI.interactable)
        {
            bpigUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costpigUI && !bpigUI.interactable)
        {
            bpigUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costsnakUI && bsnakUI.interactable)
        {
            bsnakUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costsnakUI && !bsnakUI.interactable)
        {
            bsnakUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costcatUI && bcatUI.interactable)
        {
            bcatUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costcatUI && !bcatUI.interactable)
        {
            bcatUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costkanUI && bkanUI.interactable)
        {
            bkanUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costkanUI && !bkanUI.interactable)
        {
            bkanUI.interactable = true;
        }

    }

    public void Cost(float cos)
    {
        IMG.fillAmount -= cos / 100f;
    }
}
