using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FireBar : MonoBehaviour
{

    public Image IMG;
    float total;
    public float plus;
    public Text tx;
    float cool = 0f;

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
    void FixedUpdate()
    {
        cool += Time.deltaTime;
        IMG.fillAmount += plus / total;
        tx.text = ((int)(IMG.fillAmount * 100f)).ToString();

        if (IMG.fillAmount * 100 < costchicUI && bchicUI.interactable || cool < 2f)
        {
            bchicUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costchicUI && !bchicUI.interactable&&cool>2f)
        {
            bchicUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costdogUI && bdogUI.interactable || cool < 2f)
        {
            bdogUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costdogUI && !bdogUI.interactable && cool > 2f)
        {
            bdogUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costbufUI && bbufUI.interactable || cool < 2f)
        {
            bbufUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costbufUI && !bbufUI.interactable && cool > 2f)
        {
            bbufUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costjirUI && bjirUI.interactable || cool < 2f)
        {
            bjirUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costjirUI && !bjirUI.interactable && cool > 2f)
        {
            bjirUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costlionUI && blionUI.interactable || cool < 2f)
        {
            blionUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costlionUI && !blionUI.interactable && cool > 2f)
        {
            blionUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costelepUI && belepUI.interactable || cool < 2f)
        {
            belepUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costelepUI && !belepUI.interactable && cool > 2f)
        {
            belepUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costmouUI && bmouUI.interactable || cool < 2f)
        {
            bmouUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costmouUI && !bmouUI.interactable && cool > 2f)
        {
            bmouUI.interactable = true;
        }
        ///////////////////////////////////
        if (IMG.fillAmount * 100 < costwolfUI && bwolfUI.interactable || cool < 2f)
        {
            bwolfUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costwolfUI && !bwolfUI.interactable && cool > 2f)
        {
            bwolfUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costsheepUI && bsheepUI.interactable || cool < 2f)
        {
            bsheepUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costsheepUI && !bsheepUI.interactable && cool > 2f)
        {
            bsheepUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costpigUI && bpigUI.interactable || cool < 2f)
        {
            bpigUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costpigUI && !bpigUI.interactable && cool > 3f)
        {
            bpigUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costsnakUI && bsnakUI.interactable || cool < 2f)
        {
            bsnakUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costsnakUI && !bsnakUI.interactable && cool > 3f)
        {
            bsnakUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costcatUI && bcatUI.interactable || cool < 2f)
        {
            bcatUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costcatUI && !bcatUI.interactable && cool > 2f)
        {
            bcatUI.interactable = true;
        }

        if (IMG.fillAmount * 100 < costkanUI && bkanUI.interactable || cool <2f)
        {
            bkanUI.interactable = false;
        }
        else if (IMG.fillAmount * 100 >= costkanUI && !bkanUI.interactable && cool > 2f)
        {
            bkanUI.interactable = true;
        }
    }

    public void Cost(float cos)
    {
        cool = 0f;
        IMG.fillAmount -= cos / 100f;
    }
}
