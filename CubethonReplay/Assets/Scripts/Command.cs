using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public Rigidbody comPlayer;
    public float timestamp;
    public abstract void Execute();

    public class MoveLeft : Command
    {
        private float comForce;

        public MoveLeft(Rigidbody player, float force)
        {
            comPlayer = player;
            comForce = force;
        }

        public override void Execute()
        {
            timestamp = Time.timeSinceLevelLoad;
            comPlayer.AddForce(-comForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    public class MoveRight : Command
    {
        private float comForce;

        public MoveRight(Rigidbody player, float force)
        {
            comPlayer = player;
            comForce = force;
        }

        public override void Execute()
        {
            timestamp = Time.timeSinceLevelLoad;
            comPlayer.AddForce(comForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

}
