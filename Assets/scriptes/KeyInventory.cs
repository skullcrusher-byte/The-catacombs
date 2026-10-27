using UnityEngine;

public static class KeyInventory
{
    public static bool churchKey = false;
    public static bool room1Key = false;
    public static bool room2Key = false;

    public static int TotalKeys
    {
        get
        {
            int total = 0;

            if (churchKey) total++;
            if (room1Key) total++;
            if (room2Key) total++;

            return total;
        }
    }

    public static void ResetKeys()
    {
        churchKey = false;
        room1Key = false;
        room2Key = false;
    }
}