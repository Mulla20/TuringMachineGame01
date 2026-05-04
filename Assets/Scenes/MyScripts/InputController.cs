using UnityEngine;
using TMPro;
using System.Collections;

public class InputController: MonoBehaviour
{
    public TMP_InputField tapeInputField;
    public TapeManagement tapeManager;

        public void OnLoadTapePressed()
        {

        StartCoroutine(DelayedLoad());

        }

//            private IEnumerator DelayedLoad()
//            {
//                //had to add this because the input field was not being updated before the coroutine started
//                yield return new WaitForSeconds(0.1f);
//
//                string input = tapeInputField.text;
//                tapeManager.LoadTapeFromInput(input);
//            }

        private IEnumerator DelayedLoad() //had to add this because the input field was not being updated before the coroutine started
        {
            yield return new WaitForSeconds(0.1f);

            string raw = tapeInputField.text;
            // keep only 0s and 1s
            string cleaned = "";
            foreach (char c in raw)
            {
                if (c == '0' || c == '1')
                    cleaned += c;
            }

            tapeManager.LoadTapeFromInput(cleaned);
        }

}
