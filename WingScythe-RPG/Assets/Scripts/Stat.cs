using System;

[Serializable]
public class Stat
{
    public enum BaseStatType { ATK, DEF, INT, AGI, DEX, LUC, WHT }

    public string stat { get; set; }
    public string type { get; set; }
    public int BASEVALUE {get; set;}
    public int value { get; set; }
    public string description { get; set; }

    public Stat(int base_value, string name, string desc)
    {
        BASEVALUE = base_value;
        value = base_value;
        stat = name;
        description = desc;
    }

}