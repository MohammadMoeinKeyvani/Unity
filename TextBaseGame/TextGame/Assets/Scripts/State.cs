using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class State : ScriptableObject
{
     [TextArea(15,10)] [SerializeField] string storyText;
     [SerializeField] State[] nextState;

     public string getStateStory()
     {
          return storyText;
     }

     public State[] getNextStates()
     {
          return nextState;
     }
}
