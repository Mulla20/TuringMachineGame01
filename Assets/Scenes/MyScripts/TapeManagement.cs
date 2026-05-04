using UnityEngine;
using TMPro;
using UnityEngine.UI;

//README
//Referece: Youtuber; Memory Leak; https://www.youtube.com/watch?v=OHJS44fIDCU
//          Sunny VAlley Studio; https://www.youtube.com/watch?v=l0emsAHIBjU
//
// This script demonstrates how to use TextMesh Pro to create a tape-like effect.
// It allows the user to move the tape head left and right using the arrow keys.
//

public class TapeManagement : MonoBehaviour

{
    public GameObject tapeCellPrefab;
    public int tapeLength = 15;
    public float cellSpacing = 50f;

    public GameObject[] cells;
    public int headIndex;

    void Start()
    {
        headIndex = 0; // tape head starts at the atmost left side
        cells = new GameObject[tapeLength]; // Create an array to hold the tape cells

        for (int i = 0; i < tapeLength; i++)
        {
            GameObject cell = Instantiate(tapeCellPrefab, transform); // Create a new tape cell
            RectTransform rt = cell.GetComponent<RectTransform>(); // Get the RectTransform component
            rt.anchoredPosition = new Vector2((i - headIndex) * cellSpacing, 0); // Position the cell

            TextMeshProUGUI text = cell.GetComponentInChildren<TextMeshProUGUI>(); // Get the TextMeshProUGUI component
            text.text = "_";

            cells[i] = cell;
        }

        HighlightHead();
    }

    void HighlightHead()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            Image img = cells[i].GetComponent<Image>(); // Get the Image component
            img.color = (i == headIndex) ? Color.yellow : Color.white; // Set the color of the cell
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // Check if the left arrow key is pressed
        {
            MoveHead(-1);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) // Check if the right arrow key is pressed
        {
            MoveHead(1);
        }
    }

    public void MoveHead(int direction)  //ref: pulled from Sunny VAlley Studio implemented in the video
    {
        headIndex = Mathf.Clamp(headIndex + direction, 0, tapeLength - 1); // Clamp the head index to the tape length, it moves the tape
                                                                           // head left or right, but makes sure it never goes off the tape
        for (int i = 0; i < cells.Length; i++)
        {
            RectTransform rt = cells[i].GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2((i - headIndex) * cellSpacing, 0);
        }

        HighlightHead();
    }


    public void LoadTapeFromInput(string input)
        {
            if (cells == null || cells.Length == 0)
                {
                    Debug.LogWarning("Tape not initialized yet.");
                    return;
                }

            // Clear tape first
            for (int i = 0; i < tapeLength; i++)
            {
                cells[i].GetComponentInChildren<TextMeshProUGUI>().text = "_"; // Set the text of each cell to "_"
            }

            // Write input starting at the left side
            for (int i = 0; i < input.Length && i < tapeLength; i++)
            {
                char c = input[i];
                if (c == '0' || c == '1')
                {
                    cells[i].GetComponentInChildren<TextMeshProUGUI>().text = c.ToString(); // Set the text of each cell to "0" or "1"
                }
            }
        }

    public string ReadSymbol() //reads the current symbol
        {
            return cells[headIndex].GetComponentInChildren<TextMeshProUGUI>().text; //returns the text of the current cell
        }


    public void WriteSymbol(string symbol) //writes a symbol to the tape
        {
            cells[headIndex].GetComponentInChildren<TextMeshProUGUI>().text = symbol; //sets the text of the current cell to the symbol
        }


    public void ResetTape() //resets the tape to the center
        {
            for (int i = 0; i < tapeLength; i++)
            {
                cells[i].GetComponentInChildren<TextMeshProUGUI>().text = "_"; // Set the text of each cell to "_"
            }

            headIndex = tapeLength / 2;
            HighlightHead();
        }


    public string ReadSymbolAt(int index) //reads the symbol at a specific index for update panel
    {
        return cells[index].GetComponentInChildren<TextMeshProUGUI>().text;
    }

}
