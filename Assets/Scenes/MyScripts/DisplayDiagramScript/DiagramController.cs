using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Ref: https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/class-TextMeshProUGUI.html
//youtube: https://www.youtube.com/watch?v=RQd44qSaqww, https://www.youtube.com/watch?v=nnrOhb5UdRc
public class DiagramController : MonoBehaviour
{
    public GameObject q0Circle;
    public GameObject q1Circle;
    public GameObject q2Circle;
    public GameObject q3Circle;
    public GameObject q4Circle;
    public GameObject acceptCircle;
    public GameObject rejectCircle;

    public TextMeshProUGUI summaryText;

    void Start()
    {
        HighlightState(TMResult.finalState);
        ShowSummary();
    }

    void HighlightState(string state)
    {
        ResetColors();

        switch (state) // highlights the state in the diagram
        {
            case "q0": q0Circle.GetComponent<Image>().color = Color.yellow; break; // highlights the q0 circle
            case "q1": q1Circle.GetComponent<Image>().color = Color.yellow; break;
            case "q2": q2Circle.GetComponent<Image>().color = Color.yellow; break;
            case "q3": q3Circle.GetComponent<Image>().color = Color.yellow; break;
            case "q4": q4Circle.GetComponent<Image>().color = Color.yellow; break;
            case "Accept": acceptCircle.GetComponent<Image>().color = Color.green; break;
            case "Reject": rejectCircle.GetComponent<Image>().color = Color.red; break;
        }
    }

    void ResetColors()
    {
        // resets all circles (knobs) back to a base color of white
        q0Circle.GetComponent<Image>().color = Color.white;
        q1Circle.GetComponent<Image>().color = Color.white;
        q2Circle.GetComponent<Image>().color = Color.white;
        q3Circle.GetComponent<Image>().color = Color.white;
        q4Circle.GetComponent<Image>().color = Color.white;
        acceptCircle.GetComponent<Image>().color = Color.white;
        rejectCircle.GetComponent<Image>().color = Color.white;
    }

    void ShowSummary() // shows the final state and the path taken to get there
    {
        summaryText.text =
            "Final State: " + TMResult.finalState + "\n" +
            "Path: " + string.Join(" → ", TMResult.path);
    }
}
