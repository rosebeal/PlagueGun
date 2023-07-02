using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace RS_PlagueGun
{
    public class ModExtension_PlagueBullet : DefModExtension
    {
        public float addHediffChance = 0.05f;
        public HediffDef hediffToAdd;
    }
    
    public class ModExtension_FireBullet : DefModExtension
    {
        
        public int fireSize = 1;
    }
    
    public class ModExtension_SleepBullet : DefModExtension
    {
        /*
        public float addHediffChance = 0.05f;
        public HediffDef hediffToAdd;
        */
    }
    
}
