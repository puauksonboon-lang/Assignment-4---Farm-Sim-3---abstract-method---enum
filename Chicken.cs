using UnityEngine;

public class Chicken : Animal
{
    public int Eggs { get; private set; }

    public override void Init(string newName, FoodType fav = FoodType.Grain)
    {
        base.Init(newName, fav);
        Eggs = 0;
    }

    public override void MakeSound()
    {
        AdjustHappiness(+2);
        Debug.Log($"{Name} Cluck Cluck! (Happiness:{Happiness})");
    }

    public override string Produce()
    {
        int laid = 0;
        if (Happiness >= 80) laid = 3;
        else if (Happiness >= 51) laid = 2;

        Eggs += laid;
        return $"{Name} produced {laid} eggs. Total eggs: {Eggs}";
    }
}