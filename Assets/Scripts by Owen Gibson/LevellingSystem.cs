using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwenGibson
{
    /// <summary>
    /// This class holds all the logic for our levelling system, so that includes logic to handle levelling up, gaining XP and detecting when we should level up.
    /// </summary>
    public class LevellingSystem : MonoBehaviour
    {
        // TODO XP 1/13 Declare a new variable to track the current amount of XP we have accumulated (our current XP).
        [SerializeField] private float currentXP;
        // TODO XP 2/13 Declare a new variable to track our current Level.
        [SerializeField] private float currentLevel;
        // TODO XP 3/13 Declare a new variable to track the amount of XP required to level-up (our current Level Up Threshold).
        [SerializeField] private float levelUpThreshold;

        // Variables for cross-script referencing
        private SimpleCharacterController characterControllerScript;

        private void Start()
        {
            characterControllerScript = gameObject.GetComponent<SimpleCharacterController>();
            // TODO XP 4/13: Set our current level to one.
            currentLevel = 1f;
            // TODO XP 5/13: Set our current XP to zero.
            currentXP = 0f;
            // TODO XP 6/13: Set our current XP Threshold to be our level multiplied by our 100.
            levelUpThreshold = currentLevel * 100;
            // TODO XP 7/13: Debug out our starting values of our level, XP and current XP threshold.
            Debug.Log("Current Level: " + currentLevel);
            Debug.Log("Current XP: " + currentXP);
            Debug.Log("Level Up Threshold: " + levelUpThreshold);
            // TODO XP 8/13: Increase the current XP by a random amount between 50 and 100.
            currentXP += Random.Range(50, 100);
            // TODO XP 9/13: Debug out our current XP.
            Debug.Log("Current XP: " + currentXP);
            
        }

        private void Update() {
            // TODO XP 10/13: Check if our current XP is more than our threshold.
            if (currentXP > levelUpThreshold)
            {
                // TODO XP 11/13: If it is, then let's increase out level by one.
                currentLevel += 1;
                // TODO XP 12/13: Let's also increase recalculate our current XP threshold as we've levelled up.
                levelUpThreshold = currentLevel * 100;

                // Adjusting character stats based on level
                characterControllerScript.jumpStrength += 1;
                characterControllerScript.runSpeed += 1;

                // TODO XP 13/13: Debug out our new level value, as well as our current XP and the next threshold we need to hit.
                Debug.Log("Current Level: " + currentLevel);
                Debug.Log("Current XP: " + currentXP);
                Debug.Log("Level Up Threshold: " + levelUpThreshold);
                Debug.Log("Jump Strength: " + characterControllerScript.jumpStrength);
                Debug.Log("Run Speed: " + characterControllerScript.runSpeed);
            }
            // TODO XP Final: Add code comments describing what you hope your code is doing throughout this script.
                /* This script will set up the system to store, and calculate XP and levels.
                * It will first add a random amount of XP (between 50 and 100).
                * Then it will determine whether or not the character has enough XP to level up. If it does then it will add a level and reset the level up threshold. */
            // TODO XP Bonus: Adjust our character's stats ("runSpeed" and/or "jumpStrength") based on their level. (Hint: You'll need a reference to the SimpleCharacterController script!)
                // DONE
        }
    }
}
