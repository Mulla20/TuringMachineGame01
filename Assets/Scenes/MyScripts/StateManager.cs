using UnityEngine;
using System.Collections;
using TMPro;



public class StateManager : MonoBehaviour
{

    public TapeManagement tapeManager;
    public TextMeshProUGUI configText;

    public string currentState = "q0";
    public bool isRunning = false;


    public void CreateMachine(){ //creates machine with given configuration
        Step(); //calls step() func to initialize machine
    }

    private void Step(){ //runs each transition step of machine

        //if (isRunning) return; //bug I created

        string symbol = tapeManager.ReadSymbol();

        // formal def of this machine: q0, q1, q2, q3, q4, q_accept, q_reject
        // Expected language = L = {10101}
        if(currentState == "q0" && symbol == "1" ){ //q0 state

            tapeManager.WriteSymbol("0");
            tapeManager.MoveHead(1);
            currentState = "q1";
            TMResult.finalState = currentState; //set final state to q1 for display in stateDiagram scene

            UpdateConfigurationDisplay();
            return;
        }

        if (currentState == "q1" && symbol == "0"){ //q1 state

            tapeManager.WriteSymbol("1");
            tapeManager.MoveHead(1);
            currentState = "q2";
            UpdateConfigurationDisplay();
            TMResult.finalState = currentState;//set final state to q1 for display in stateDiagram scene
            return;
        }

        if (currentState == "q2" && symbol == "1"){ //q2 state

            tapeManager.WriteSymbol("0");
            tapeManager.MoveHead(1);
            currentState = "q3";
            UpdateConfigurationDisplay();
            TMResult.finalState = currentState;
            return;
        }

        if (currentState == "q3" && symbol == "0"){ //q3 state

            tapeManager.WriteSymbol("1");
            tapeManager.MoveHead(1);
            currentState = "q4";
            UpdateConfigurationDisplay();
            TMResult.finalState = currentState;
            return;
        }

        if (currentState == "q4" && symbol == "1"){ //q4 state

            tapeManager.WriteSymbol("0");
            tapeManager.MoveHead(1);
            currentState = "Accept";
            UpdateConfigurationDisplay();
            TMResult.finalState = currentState;
            return;
        }

        if (currentState == "Accept"){ //accept state

            Debug.Log("Machine ACCEPTED the input.");
            isRunning = false;
            UpdateConfigurationDisplay();
            TMResult.finalState = currentState;
            return;
        }

        if (currentState == "Reject"){ //reject state

            Debug.Log("Machine REJECTED the input.");
            isRunning = false;
            UpdateConfigurationDisplay();
            TMResult.finalState = currentState;
            return;
        }


        Debug.Log("No rule found, Machine enter halts state.");
        isRunning = false;
        TMResult.finalState = currentState;

        UpdateConfigurationDisplay();

    }


    public void Run(){  //only runs if machine is not already running
        if(!isRunning)
            StartCoroutine(RunMachine());  //had to look this up, ref https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
    }                                      //had common errors with run method and routines stacking on each other,
                                           //other ref for method below: Youtuber: Digestible, https://www.youtube.com/watch?v=xea6rHdWKtY

    IEnumerator RunMachine(){ //runs machine until halts state
        isRunning = true;
        while(isRunning){
            Step();
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void ResetMachine(){ //resets machine to initial state
        currentState = "q0";
        tapeManager.ResetTape();
        isRunning = false;
        UpdateConfigurationDisplay();
    }


    void UpdateConfigurationDisplay()
    {
        string tapeString = "";

        for (int i = 0; i < tapeManager.cells.Length; i++)
        {
            string s = tapeManager.ReadSymbolAt(i);

            if (i == tapeManager.headIndex)
                tapeString += "[" + s + "] ";
            else
                tapeString += s + " ";
        }

        configText.text =
            "State: " + currentState + "\n" +
            "Head Position: " + tapeManager.headIndex + "\n" +
            "Tape: " + tapeString;
    }


}