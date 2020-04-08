using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task
{
    // return on success (true) or failure (false)
    public abstract bool run();
}

public class Selector : Task
{
    List<Task> children;

    public Selector(List<Task> tasks)
    {
        children = tasks;
    }

    public override bool run()
    {
        foreach (Task c in children)
        {
            if (c.run())
            {
                return true;
            }
        }
        return false;
    }
}

public class Sequence : Task
{
    List<Task> children;

    public Sequence(List<Task> tasks)
    {
        children = tasks;
    }

    public override bool run()
    {
        foreach (Task c in children)
        {
            if (!c.run())
            {
                return false;
            }
        }
        return true;
    }
}

public class doorOpen : Task
{
    Door door;

    public doorOpen(Door d)
    {
        door = d;
    }

    public override bool run()
    {
        Debug.Log("Is the door open?" + door.open);
        return door.open;
    }
}

public class doorClosed : Task
{
    Door door;

    public doorClosed(Door d)
    {
        door = d;
    }

    public override bool run()
    {
        Debug.Log("Is the door open?" + !door.open);
        return !door.open;
    }
}

public class doorUnlocked : Task
{
    Door door;

    public doorUnlocked(Door d)
    {
        door = d;
    }

    public override bool run()
    {
        Debug.Log("Is the door unlocked?" + !door.locked);
        return !door.locked;
    }
}

public class CatInside : Task
{
    Cat cat;

    public CatInside(Cat c)
    {
        cat = c;
    }

    public override bool run()
    {
        Debug.Log("Is the cat inside? " + cat.inside);
        return cat.inside;
    }
}

public class RoomEmpty : Task
{
    Cat cat;

    public RoomEmpty(Cat c)
    {
        cat = c;
    }

    public override bool run()
    {
        Debug.Log("Is the room empty? " + !cat.inside);
        return !cat.inside;
    }
}

public class OpenDoor : Task
{
    Door door;

    public OpenDoor(Door d)
    {
        door = d;
    }

    public override bool run()
    {
        Debug.Log("door opening");
        return door.OpenSesame();
    }
}

public class BargeDoor : Task
{
    Rigidbody rb;

    public BargeDoor(Door d)
    {
        rb = d.GetComponent<Rigidbody>();
    }

    public override bool run()
    {
        Debug.Log("barging door");
        rb.AddForce(5f, 1f, 5f, ForceMode.VelocityChange);
        return true;
    }
}

public class StealthMode : Task
{
    Mouse go;

    public StealthMode(Mouse mouse)
    {
        go = mouse;
    }

    public override bool run()
    {
        Debug.Log("Activating stealth mode");
        return go.ActivateStealth();
    }
}

public class Wait : Task
{
    float waitDelay;

    public Wait(float time)
    {
        waitDelay = time;
    }

    public override bool run()
    {
        return true;
    }
}

public class MoveToDoor : Task
{
    Vector3 doorPosition;

    public MoveToDoor(GameObject player, Door d)
    {
        doorPosition = d.transform.position;
        player.transform.position = doorPosition - new Vector3(0, 0, 1);

    }

    public override bool run()
    {
        Debug.Log("moving to door");
        return true;
    }
}

public class MoveToTarget : Task
{
    Vector3 targetPosition;

    public MoveToTarget(GameObject player, GameObject target)
    {
        targetPosition = target.transform.position;
        player.transform.position = targetPosition - new Vector3(0, 0, 1);
    }

    public override bool run()
    {
        Debug.Log("moving to target");
        return true;
    }
}