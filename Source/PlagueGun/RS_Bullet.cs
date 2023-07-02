using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using Verse.AI;

namespace RS_PlagueGun
{
    public class Projectile_PlagueBullet : Bullet
    {
        public ModExtension_PlagueBullet Props => def.GetModExtension<ModExtension_PlagueBullet>();

        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            base.Impact(hitThing, blockedByShield);

            if (Props != null && hitThing != null && hitThing is Pawn hitPawn)
            {
                float rand = Rand.Value;
                if (rand <= Props.addHediffChance)
                {
                    Messages.Message("RS_PlagueBullet_SuccessMessage".Translate(
                        this.launcher.Label, hitPawn.Label
                    ), MessageTypeDefOf.NeutralEvent);
                    Hediff plagueOnPawn = hitPawn.health?.hediffSet?.GetFirstHediffOfDef(Props.hediffToAdd);
                    float randomSeverity = Rand.Range(0.15f, 0.30f);
                    if (plagueOnPawn != null)
                    {
                        plagueOnPawn.Severity += randomSeverity;
                    }
                    else
                    {
                        Hediff hediff = HediffMaker.MakeHediff(Props.hediffToAdd, hitPawn);
                        hediff.Severity = randomSeverity;
                        hitPawn.health.AddHediff(hediff);
                    }
                }

            }
        }
    }

    
   
    public class Projectile_FireBullet : Bullet
    {
        public ModExtension_FireBullet Props => def.GetModExtension<ModExtension_FireBullet>();

        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            base.Impact(hitThing, blockedByShield);

            if(Props != null)
            {
                if (hitThing != null && hitThing is Pawn hitPawn)
                {
                    Messages.Message("RS_FireBullet_SuccessMessage".Translate(
                    this.launcher.Label, hitPawn.Label
                ), MessageTypeDefOf.NeutralEvent);

                    hitPawn.TryAttachFire(Props.fireSize);
                    
                }
                //if it hits something thats not a pawn
                else if (hitThing != null) 
                {
                    FireUtility.TryAttachFire(hitThing, Props.fireSize);
                }
            }
            
            
            
        }
    }
    
    //add in xml and polish up
    public class Projectile_SleepBullet : Bullet
    {
        public ModExtension_SleepBullet Props => def.GetModExtension<ModExtension_SleepBullet>();

        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            
            base.Impact(hitThing, blockedByShield);
            
            if (Props != null && hitThing != null && hitThing is Pawn hitPawn)
            {
                
                Messages.Message("RS_SleepBullet_SuccessMessage".Translate(
                    this.launcher.Label, hitPawn.Label
                ), MessageTypeDefOf.NeutralEvent);
                
                
                HealthUtility.TryAnesthetize(hitPawn);
                    
                

            }
            
            
        }
    }
    
}
    
    
