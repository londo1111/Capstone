using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
  
  public int level;
  public int health;
  public float[] position;

//Below script won't work until the player has level and health variables so it is commented out until that is done

/*
  public PlayerData (PlayerMovement player) //PlayerMovement will be the exact script name for where the health and level variables are held
  {
      level = player.level;             //accessing the level in the player script
      health = player.health;           //accessing the health in the player script

      position = new float[3];
      position[0] = player.transform.position.x;
      position[1] = player.transform.position.y;
      position[2] = player.transform.position.z;
  }
  */

}
