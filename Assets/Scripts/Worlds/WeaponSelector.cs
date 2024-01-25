using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public enum Weapon {
        ArmorRepair,
        AtomBlaster,
        DoomDisks,
        EnergyShield,
        FreonBomb,
        HyperJetBoosters,
        JetBoosters,
        JumpJets,
        LaserCannon,
        MagnetMine,
        OilDrum,
        QunatumAnnihilator,
        RipperWheels,
        Shotgun,
        SonicBoom,
        SuperZapper
    }

    public Weapon weapon;
}
