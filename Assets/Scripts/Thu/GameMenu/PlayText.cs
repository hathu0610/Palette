using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 
public class PlayText: MonoBehaviour {
  
 Text flashingText;
 string textToFlash = "Play!";
 string blankText = "";
 //flag to determine if you want the blinking to happen
 bool isBlinking = true;
  
 void Start(){
  //get the Text component
  flashingText = GetComponent<Text>();
  //Call coroutine BlinkText on Start
  StartCoroutine(BlinkText());

 }
  
 //function to blink the text 
 public IEnumerator BlinkText(){
  while(isBlinking){
   //set the Text's text to blank
   flashingText.text = blankText;
   //display blank text for 0.5 seconds
   yield return new WaitForSeconds(.5f);
   flashingText.text = textToFlash;
   yield return new WaitForSeconds(.5f); 
  }
 }

}