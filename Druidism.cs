using ModShardLauncher;
using ModShardLauncher.Mods;
using UndertaleModLib.Models;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using UndertaleModLib;
using System.Text.RegularExpressions;
using UndertaleModLib.Compiler;

namespace Druidism
{
    public class ScriptSet
    {
        public string Name;
        public string File;
        public EventType Type;
        public uint Subtype;

        public ScriptSet(string myName, string myFile, EventType myType = EventType.Create, uint mySubtype = 0)
        {
            Name = myName;
            File = myFile;
            Type = myType;
            Subtype = mySubtype;
        }
    }

    public class Druidism : Mod
    {
        public override string Author => "iamyoyoman, CommissarAmethyst, Emo Used HM01";
        public override string Name => "Druidism";
        public override string Description => "Learn to be one with nature, or something like that.";
        public override string Version => "1.0.0";

        public override void PatchMod()
        {
            // To whom it may concern, my balls hang
            Msl.AddObject("o_skill_category_druidism", "", "o_sklill_category_magic", true, false, true, CollisionShapeFlags.Circle);                   // Weird typo in vanilla game code

            // Passive skills
            Msl.AddObject("o_pass_skill_animal_friendship", "s_animal_friendship", "o_skill_passive", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_pass_skill_attune_the_earth", "s_attune_the_earth", "o_skill_passive", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_pass_skill_attune_the_sky", "s_attune_the_sky", "o_skill_passive", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_pass_skill_feral_nature", "s_feral_nature", "o_skill_passive", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_pass_skill_bestial_vigor", "s_bestial_vigor", "o_skill_passive", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_pass_skill_bear_aspect", "s_bear_aspect", "o_skill_passive", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_pass_skill_circle_of_life", "s_circle_of_life", "o_skill_passive", true, false, true, CollisionShapeFlags.Circle);

            // Active skills
            Msl.AddObject("o_skill_stick_to_snake_ico", "s_stick_to_snake", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_skill_stick_to_snake", "s_stick_to_snake", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_stick_to_snake", "s_wraithsummon_cast", "o_spellbirth", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_skill_shadows_to_fox_ico", "s_shadows_to_fox", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_skill_shadows_to_fox", "s_shadows_to_fox", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_shadows_to_fox", "s_wraithsummon_cast", "o_spellbirth", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_skill_butterflies_to_hornets_ico", "s_butterflies_to_hornets", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_skill_butterflies_to_hornets", "s_butterflies_to_hornets", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_butterflies_to_hornets", "s_wraithsummon_cast", "o_spellbirth", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_skill_wild_shape_ico", "s_wild_shape", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_skill_wild_shape", "s_wild_shape", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_b_wild_shape", "s_b_wild_shape", "o_buff_stance", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_skill_entangling_grasp_ico", "s_entangling_grasp", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_skill_entangling_grasp", "s_entangling_grasp", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_entangling_grasp", "s_webthrow_cast", "o_target_spell", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_onUnitEffectRoot", "", "o_onUnitEffectSprite", true, false, false, CollisionShapeFlags.Box);
            Msl.AddObject("o_db_rooted", "s_db_rooted", "o_influence_debuff", true, false, false, CollisionShapeFlags.Circle);

            Msl.AddObject("o_skill_healing_grace_ico", "s_healing_grace", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_skill_healing_grace", "s_healing_grace", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_healing_grace", "s_darkblessing", "o_magic_pillar", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_healing_grace_birth", "s_darkbless_birth", "o_spellbirth", true, false, true, CollisionShapeFlags.Circle);

            Msl.AddObject("o_skill_celestial_strike_ico", "s_celestial_strike", "o_skill_ico", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_skill_celestial_strike", "s_celestial_strike", "o_skill", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_celestial_strike", "s_spell_celestial_strike", "o_shell_damage", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddObject("o_celestial_strike_birth", "s_spell_celestial_strike_birth", "o_spellbirth", true, false, true, CollisionShapeFlags.Circle);

            // The summons themselves
            // We use o_village_standing cuz it basically makes them braindead which we can then modify to do whatever we want with afterwards
            // If we inherited the original entity then we'd have to strip loads of shit out, I ain't doing all that, so we doing it this way
            Msl.AddObject("o_snake_summon", "s_snake01", "o_village_standing");
            Msl.AddObject("o_fox_summon", "s_fox", "o_village_standing");
            Msl.AddObject("o_hornets_summon", "s_hornets", "o_village_standing");

            // Summon mechanics + backend
            Msl.AddObject("o_b_druid_summon", "s_b_wild_shape", "o_invisible_buff", true, false, true, CollisionShapeFlags.Circle);
            Msl.AddFunction(ModFiles.GetCode("gml_GlobalScript_scr_druid_enemy_destroy.gml"), "scr_druid_enemydestroy");
            Msl.AddFunction(ModFiles.GetCode("gml_GlobalScript_scr_druid_summon_cleanup.gml"), "scr_druid_summon_cleanup");

            // Listing all the scripts to create
            ScriptSet[] scriptsToAdd = new ScriptSet[]
            {
                // Skill Tree
                new ScriptSet("o_skill_category_druidism", "gml_Object_o_skill_category_druidism_Create_0.gml"),
                new ScriptSet("o_skill_category_druidism", "gml_Object_o_skill_category_druidism_Other_24.gml", EventType.Other, 24),

                // Passive shit
                new ScriptSet("o_pass_skill_animal_friendship", "gml_Object_o_pass_skill_animal_friendship_Create_0.gml"),

                new ScriptSet("o_pass_skill_attune_the_earth", "gml_Object_o_pass_skill_attune_the_earth_Create_0.gml"),
                new ScriptSet("o_pass_skill_attune_the_earth", "gml_Object_o_pass_skill_attune_the_earth_Other_17.gml", EventType.Other, 17),

                new ScriptSet("o_pass_skill_attune_the_sky", "gml_Object_o_pass_skill_attune_the_sky_Create_0.gml"),
                new ScriptSet("o_pass_skill_attune_the_sky", "gml_Object_o_pass_skill_attune_the_sky_Other_17.gml", EventType.Other, 17),

                new ScriptSet("o_pass_skill_feral_nature", "gml_Object_o_pass_skill_feral_nature_Create_0.gml"),

                new ScriptSet("o_pass_skill_bestial_vigor", "gml_Object_o_pass_skill_bestial_vigor_Create_0.gml"),

                new ScriptSet("o_pass_skill_circle_of_life", "gml_Object_o_pass_skill_circle_of_life_Create_0.gml"),
                new ScriptSet("o_pass_skill_circle_of_life", "gml_Object_o_pass_skill_circle_of_life_Other_17.gml", EventType.Other, 17),

                new ScriptSet("o_pass_skill_bear_aspect", "gml_Object_o_pass_skill_bear_aspect_Create_0.gml"),

                // Active shit
                new ScriptSet("o_skill_stick_to_snake_ico", "gml_Object_o_skill_stick_to_snake_ico_Create_0.gml"),
                new ScriptSet("o_skill_stick_to_snake", "gml_Object_o_skill_stick_to_snake_Create_0.gml"),
                new ScriptSet("o_skill_stick_to_snake", "gml_Object_o_skill_stick_to_snake_Alarm_1.gml", EventType.Alarm, 1),
                new ScriptSet("o_skill_stick_to_snake", "gml_Object_o_skill_stick_to_snake_Other_17.gml", EventType.Other, 17),
                new ScriptSet("o_skill_stick_to_snake", "gml_Object_o_skill_stick_to_snake_Other_19.gml", EventType.Other, 19),
                new ScriptSet("o_skill_stick_to_snake", "gml_Object_o_skill_stick_to_snake_Other_13.gml", EventType.Other, 13),
                new ScriptSet("o_skill_stick_to_snake", "gml_Object_o_skill_stick_to_snake_Draw_0.gml", EventType.Draw, 0),
                new ScriptSet("o_stick_to_snake", "gml_Object_o_stick_to_snake_Create_0.gml"),
                new ScriptSet("o_stick_to_snake", "gml_Object_o_stick_to_snake_Destroy_0.gml", EventType.Destroy),
                new ScriptSet("o_stick_to_snake", "gml_Object_o_stick_to_snake_Alarm_0.gml", EventType.Alarm, 0),

                new ScriptSet("o_skill_shadows_to_fox_ico", "gml_Object_o_skill_shadows_to_fox_ico_Create_0.gml"),
                new ScriptSet("o_skill_shadows_to_fox", "gml_Object_o_skill_shadows_to_fox_Create_0.gml"),
                new ScriptSet("o_skill_shadows_to_fox", "gml_Object_o_skill_shadows_to_fox_Alarm_1.gml", EventType.Alarm, 1),
                new ScriptSet("o_skill_shadows_to_fox", "gml_Object_o_skill_shadows_to_fox_Other_17.gml", EventType.Other, 17),
                new ScriptSet("o_skill_shadows_to_fox", "gml_Object_o_skill_shadows_to_fox_Other_19.gml", EventType.Other, 19),
                new ScriptSet("o_skill_shadows_to_fox", "gml_Object_o_skill_shadows_to_fox_Other_13.gml", EventType.Other, 13),
                new ScriptSet("o_skill_shadows_to_fox", "gml_Object_o_skill_shadows_to_fox_Draw_0.gml", EventType.Draw, 0),
                new ScriptSet("o_shadows_to_fox", "gml_Object_o_shadows_to_fox_Create_0.gml"),
                new ScriptSet("o_shadows_to_fox", "gml_Object_o_shadows_to_fox_Destroy_0.gml", EventType.Destroy),
                new ScriptSet("o_shadows_to_fox", "gml_Object_o_shadows_to_fox_Alarm_0.gml", EventType.Alarm, 0),

                new ScriptSet("o_skill_butterflies_to_hornets_ico", "gml_Object_o_skill_butterflies_to_hornets_ico_Create_0.gml"),
                new ScriptSet("o_skill_butterflies_to_hornets", "gml_Object_o_skill_butterflies_to_hornets_Create_0.gml"),
                new ScriptSet("o_skill_butterflies_to_hornets", "gml_Object_o_skill_butterflies_to_hornets_Alarm_1.gml", EventType.Alarm, 1),
                new ScriptSet("o_skill_butterflies_to_hornets", "gml_Object_o_skill_butterflies_to_hornets_Other_17.gml", EventType.Other, 17),
                new ScriptSet("o_skill_butterflies_to_hornets", "gml_Object_o_skill_butterflies_to_hornets_Other_19.gml", EventType.Other, 19),
                new ScriptSet("o_skill_butterflies_to_hornets", "gml_Object_o_skill_butterflies_to_hornets_Other_14.gml", EventType.Other, 14),
                new ScriptSet("o_skill_butterflies_to_hornets", "gml_Object_o_skill_butterflies_to_hornets_Other_13.gml", EventType.Other, 13),
                new ScriptSet("o_skill_butterflies_to_hornets", "gml_Object_o_skill_butterflies_to_hornets_Draw_0.gml", EventType.Draw, 0),
                new ScriptSet("o_butterflies_to_hornets", "gml_Object_o_butterflies_to_hornets_Create_0.gml"),
                new ScriptSet("o_butterflies_to_hornets", "gml_Object_o_butterflies_to_hornets_Destroy_0.gml", EventType.Destroy),
                new ScriptSet("o_butterflies_to_hornets", "gml_Object_o_butterflies_to_hornets_Alarm_0.gml", EventType.Alarm, 0),

                new ScriptSet("o_skill_healing_grace_ico", "gml_Object_o_skill_healing_grace_ico_Create_0.gml"),
                new ScriptSet("o_skill_healing_grace", "gml_Object_o_skill_healing_grace_Create_0.gml"),
                new ScriptSet("o_skill_healing_grace", "gml_Object_o_skill_healing_grace_Other_17.gml", EventType.Other, 17),
                new ScriptSet("o_healing_grace", "gml_Object_o_healing_grace_Create_0.gml"),
                new ScriptSet("o_healing_grace", "gml_Object_o_healing_grace_Destroy_0.gml", EventType.Destroy),
                new ScriptSet("o_healing_grace", "gml_Object_o_healing_grace_Draw_0.gml", EventType.Draw, 0),
                new ScriptSet("o_healing_grace", "gml_Object_o_healing_grace_Other_7.gml", EventType.Other, 7),
                new ScriptSet("o_healing_grace_birth", "gml_Object_o_healing_grace_birth_Create_0.gml"),

                new ScriptSet("o_skill_entangling_grasp_ico", "gml_Object_o_skill_entangling_grasp_ico_Create_0.gml"),
                new ScriptSet("o_skill_entangling_grasp", "gml_Object_o_skill_entangling_grasp_Create_0.gml"),
                new ScriptSet("o_entangling_grasp", "gml_Object_o_entangling_grasp_Alarm_0.gml", EventType.Alarm, 0),
                new ScriptSet("o_entangling_grasp", "gml_Object_o_entangling_grasp_Alarm_10.gml", EventType.Alarm, 10),
                new ScriptSet("o_skill_entangling_grasp", "gml_Object_o_skill_entangling_grasp_Other_17.gml", EventType.Other, 17),
                new ScriptSet("o_onUnitEffectRoot", "gml_Object_o_onUnitEffectRoot_Other_25.gml", EventType.Other, 25),
                new ScriptSet("o_db_rooted", "gml_Object_o_db_rooted_Create_0.gml"),
                new ScriptSet("o_db_rooted", "gml_Object_o_db_rooted_Destroy_0.gml", EventType.Destroy),
                new ScriptSet("o_db_rooted", "gml_Object_o_db_rooted_Alarm_1.gml", EventType.Alarm, 1),
                new ScriptSet("o_db_rooted", "gml_Object_o_db_rooted_Alarm_2.gml", EventType.Alarm, 2),
                new ScriptSet("o_db_rooted", "gml_Object_o_db_rooted_Other_10.gml", EventType.Other, 10),

                new ScriptSet("o_skill_celestial_strike_ico", "gml_Object_o_skill_celestial_strike_ico_Create_0.gml"),
                new ScriptSet("o_skill_celestial_strike", "gml_Object_o_skill_celestial_strike_Create_0.gml"),
                new ScriptSet("o_skill_celestial_strike", "gml_Object_o_skill_celestial_strike_Other_17.gml", EventType.Other, 17),
                new ScriptSet("o_celestial_strike", "gml_Object_o_celestial_strike_Create_0.gml"),
                new ScriptSet("o_celestial_strike", "gml_Object_o_celestial_strike_Destroy_0.gml", EventType.Destroy),
                new ScriptSet("o_celestial_strike", "gml_Object_o_celestial_strike_Alarm_1.gml", EventType.Alarm, 1),
                new ScriptSet("o_celestial_strike", "gml_Object_o_celestial_strike_Alarm_2.gml", EventType.Alarm, 2),
                new ScriptSet("o_celestial_strike", "gml_Object_o_celestial_strike_Other_10.gml", EventType.Other, 10),
                new ScriptSet("o_celestial_strike", "gml_Object_o_celestial_strike_Other_11.gml", EventType.Other, 11),
                new ScriptSet("o_celestial_strike", "gml_Object_o_celestial_strike_PreCreate_0.gml", EventType.PreCreate),
                new ScriptSet("o_celestial_strike_birth", "gml_Object_o_celestial_strike_birth_Create_0.gml"),                  // The pew pew ball thing it summons
                new ScriptSet("o_celestial_strike_birth", "gml_Object_o_celestial_strike_birth_Draw_0.gml", EventType.Draw),
                new ScriptSet("o_celestial_strike_birth", "gml_Object_o_celestial_strike_birth_Other_10.gml", EventType.Other, 10),
                new ScriptSet("o_celestial_strike_birth", "gml_Object_o_celestial_strike_birth_PreCreate_0.gml", EventType.PreCreate),

                new ScriptSet("o_skill_wild_shape_ico", "gml_Object_o_skill_wild_shape_ico_Create_0.gml"),
                new ScriptSet("o_skill_wild_shape", "gml_Object_o_skill_wild_shape_Create_0.gml"),
                new ScriptSet("o_skill_wild_shape", "gml_Object_o_skill_wild_shape_Other_13.gml", EventType.Other, 13),
                new ScriptSet("o_b_wild_shape", "gml_Object_o_b_wild_shape_Create_0.gml"),                  // The buff the skill grants
                new ScriptSet("o_b_wild_shape", "gml_Object_o_b_wild_shape_Destroy_0.gml", EventType.Destroy),
                new ScriptSet("o_b_wild_shape", "gml_Object_o_b_wild_shape_Other_10.gml", EventType.Other, 10),
                new ScriptSet("o_b_wild_shape", "gml_Object_o_b_wild_shape_Alarm_1.gml", EventType.Alarm, 1),
                new ScriptSet("o_b_wild_shape", "gml_Object_o_b_wild_shape_Alarm_2.gml", EventType.Alarm, 2),

                // Summoned objects
                new ScriptSet("o_b_druid_summon", "gml_Object_o_b_druid_summon_Create_0.gml"),
                new ScriptSet("o_b_druid_summon", "gml_Object_o_b_druid_summon_Alarm_2.gml", EventType.Alarm, 2),
                new ScriptSet("o_b_druid_summon", "gml_Object_o_b_druid_summon_Alarm_6.gml", EventType.Alarm, 6),
                new ScriptSet("o_b_druid_summon", "gml_Object_o_b_druid_summon_Alarm_7.gml", EventType.Alarm, 7),
                new ScriptSet("o_b_druid_summon", "gml_Object_o_b_druid_summon_Step_0.gml", EventType.Step, 0),
                new ScriptSet("o_b_druid_summon", "gml_Object_o_b_druid_summon_Other_10.gml", EventType.Other, 10),
                new ScriptSet("o_b_druid_summon", "gml_Object_o_b_druid_summon_Other_15.gml", EventType.Other, 15),
                new ScriptSet("o_b_druid_summon", "gml_Object_o_b_druid_summon_Other_23.gml", EventType.Other, 23),

                new ScriptSet("o_snake_summon", "gml_Object_o_snake_summon_Create_0.gml"),
                new ScriptSet("o_snake_summon", "gml_Object_o_snake_summon_Destroy_0.gml", EventType.CleanUp, 0),

                new ScriptSet("o_fox_summon", "gml_Object_o_fox_summon_Create_0.gml"),
                new ScriptSet("o_fox_summon", "gml_Object_o_fox_summon_Destroy_0.gml", EventType.CleanUp, 0),

                new ScriptSet("o_hornets_summon", "gml_Object_o_hornets_summon_Create_0.gml"),
                new ScriptSet("o_hornets_summon", "gml_Object_o_hornets_summon_Alarm_2.gml", EventType.Alarm, 2),
                new ScriptSet("o_hornets_summon", "gml_Object_o_hornets_summon_Step_0.gml", EventType.Step, 0),                 // Need this cause we use o_village_standing as a parent
                new ScriptSet("o_hornets_summon", "gml_Object_o_hornets_summon_Destroy_0.gml", EventType.CleanUp, 0),
            };

            // Never gonna give you up
            foreach (var newScript in scriptsToAdd)
            {
                Msl.AddNewEvent(
                    newScript.Name,
                    ModFiles.GetCode(newScript.File),
                    newScript.Type,
                    newScript.Subtype
                );
            }

            // Never gonna let you down
            Msl.LoadGML("gml_GlobalScript_table_skills_stats")
                .Apply(SkillStats)
                .Save();
            static IEnumerable<string> SkillStats(IEnumerable<string> input)
            {
                const string anchor = "\"// BEASTS;";

                string statblocks =
                    "\"// DRUIDISM;;;;;;;;;;;;;;;;;;;;;;;;;;;;\", " +
                    "\"stick_to_snake;o_stick_to_snake;Target Point;2;150;30;0;0;0;0;0;normal;;spell;0;;druidism;0;1;;0;0;;;;;1;;\", " +
                    "\"shadows_to_fox;o_shadows_to_fox;Target Point;2;175;40;0;0;0;0;0;normal;;spell;0;;druidism;0;1;;0;0;;;;;1;;\", " +
                    "\"butterflies_to_hornets;o_butterflies_to_hornets;Target Point;2;200;50;0;0;0;0;0;normal;;spell;0;;druidism;0;1;;0;0;;;;;1;;\", " +
                    "\"celestial_strike;o_celestial_strike;Target Point;7;6;12;0;0;0;0;0;normal;;spell;0;s_spell_celestial_strike_cast_;druidism;0;1;;0;0;;;;;1;;\", " +
                    "\"wild_shape;o_b_wild_shape;No Target;0;1;25;0;9999;0;0;0;normal;;skill;0;;druidism;0;1;;0;0;;1;;;;;\", " +
                    "\"entangling_grasp;o_entangling_grasp;Target Object;5;45;45;0;0;0;0;1;normal;;spell;0;;druidism;0;;;0;0;1;;;;1;;\", " +
                    "\"healing_grace;o_healing_grace;Target Object;7;80;30;0;0;0;0;0;normal;;spell;0;;druidism;0;;;0;0;;;;;1;;\", " +
                    "";

                foreach (string line in input)
                {
                    int idx = line.IndexOf(anchor, StringComparison.Ordinal);
                    if (idx >= 0)
                    {
                        yield return line.Insert(idx, statblocks);
                    }
                    else
                    {
                        yield return line;
                    }
                }
            }

            // Never gonna run around and desert you
            Msl.LoadGML("gml_Object_o_skillmenu_Create_0")
                .MatchBelow("var _metaCategoriesArray =", 0)
                .InsertBelow(@"var _druid = []
                                for (var _kr = 0; _kr < array_length(_metaCategoriesArray[2]); _kr++)
                                {
                                    array_push(_druid, _metaCategoriesArray[2][_kr])
                                    if (_metaCategoriesArray[2][_kr] == o_skill_category_arcanistics)
                                        array_push(_druid, o_skill_category_druidism)
                                }
                                for (var _kj = 0; _kj < array_length(_druid); _kj++)
                                    array_set(_metaCategoriesArray[2], _kj, _druid[_kj])")
                .Save();

            // Never gonna make you cry
            Msl.LoadGML("gml_GlobalScript_table_mobs_stats")
                .Apply(MobsStats)
                .Save();
            static IEnumerable<string> MobsStats(IEnumerable<string> input)
            {
                const string anchor = "\"Bear;";

                string statblocks =
                    "\"Snake;1;o_snake_summon;beast;carnivore;Melee;;;;fangs;Light;tiny;flesh;8;;0;20;50;;;;;;75;75;;;;;;;;;;;;;;;25;;;5;;;;;;;-50;;;;;;;;;;;;;;;;;;;;;5;16;5;10;2;;;50;;;;1;1;;;;;;;0;;;;;;;2;;;;;10;;;;;;;;;;;;;;;;;;50;;;;;;;;;;;;;;;;;;;;1;1;0;\", " +
                    "\"Fox;1;o_fox;beast;omnivore;Melee;;;;claws;Light;medium;flesh;8;;0;50;100;;;;;;75;66;;;;;;;;;;;;;;;20;-75;;3;;;;;;;;;;;;;;;;;;;;;;;;;;;;5;15;5;10;3;;;;;;;1;1;2;2;;;;;0;;;;;;;;;10;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;1;1;0;\", " +
                    "\"Forest Buzzer;2;o_hornets_summon;beast;carnivore;Melee;;Expendable;;sting;Light;tiny;chitin;8;;0;20;20;;;;;;90;90;;;;;3;;33;30;;;;;;;10;;;5;;;;;200;200;200;200;;;;;;;;;;;40;;;;;;;;;5;5;5;5;2;;;;;;;;1;;;;;;999;0;;;;60;15;;5;;;;;10;;;;;;;;35;;;;;15;;;-33;33;75;-25;;;;;;;;;;;;;;;;;;;;99;;;\", " +
                    "";

                foreach (string line in input)
                {
                    int idx = line.IndexOf(anchor, StringComparison.Ordinal);
                    if (idx >= 0)
                    {
                        yield return line.Insert(idx, statblocks);
                    }
                    else
                    {
                        yield return line;
                    }
                }
            }

            // Never gonna say goodbye
            Msl.LoadGML("gml_GlobalScript_table_text")
                .Apply(TextIterator)
                .Save();
            static IEnumerable<string> TextIterator(IEnumerable<string> input)
            {
                string tier = "\"Druidism;Друидизм;Druidism;德鲁伊之道;Druidismus;Druidismo;Druidisme;Druidismo;Druidismo;Druidyzm;Druidizm;ドルイド信仰;드루이드주의;\", ";
                string hover =
                    "\"Druidism;Друидизм;Станьте единым с природой, постигая небеса и раскрывая свою звериную сущность.##~y~Основной фокус:~/~#~w~Поддержка~/~, ~w~Лечение~/~, ~w~Призыв~/~, ~w~Преображение.~/~;" +
                    "Be one with nature as you learn to attune to the skies and explore your animalistic nature.##~y~Main focus:~/~#~w~Support~/~, ~w~Healing~/~, ~w~Summoning~/~, ~w~Transformation.~/~;" +
                    "与自然融为一体，感悟天空之力，探索你内在的野性本质。##~y~主要侧重：~/~#~w~支援~/~, ~w~治疗~/~, ~w~召唤~/~, ~w~变形.~/~;" +
                    "Werde eins mit der Natur, während du dich den Himmeln anpasst und deine animalische Natur erforschst.##~y~Hauptfokus:~/~#~w~Unterstützung~/~, ~w~Heilung~/~, ~w~Beschwörung~/~, ~w~Verwandlung.~/~;" +
                    "Conviértete en uno con la naturaleza mientras te armonizas con los cielos y exploras tu lado animal.##~y~Enfoque principal:~/~#~w~Apoyo~/~, ~w~Curación~/~, ~w~Invocación~/~, ~w~Transformación.~/~;" +
                    "Ne faites qu’un avec la nature en vous accordant aux cieux et en explorant votre nature animale.##~y~Orientation principale:~/~#~w~Soutien~/~, ~w~Soins~/~, ~w~Invocation~/~, ~w~Transformation.~/~;" +
                    "Diventa tutt’uno con la natura mentre ti sintonizzi con i cieli ed esplori la tua natura animale.##~y~Focus principale:~/~#~w~Supporto~/~, ~w~Cura~/~, ~w~Evocazione~/~, ~w~Trasformazione.~/~;" +
                    "Torne-se um com a natureza ao se sintonizar com os céus e explorar sua natureza animal.##~y~Foco principal:~/~#~w~Suporte~/~, ~w~Cura~/~, ~w~Invocação~/~, ~w~Transformação.~/~;" +
                    "Stań się jednością z naturą, dostrajając się do niebios i odkrywając swoją zwierzęcą naturę.##~y~Główne skupienie:~/~#~w~Wsparcie~/~, ~w~Leczenie~/~, ~w~Przywoływanie~/~, ~w~Transformacja.~/~;" +
                    "Doğayla bir ol, göklere uyum sağlarken hayvani doğanı keşfet.##~y~Ana odak:~/~#~w~Destek~/~, ~w~İyileştirme~/~, ~w~Çağırma~/~, ~w~Dönüşüm.~/~;" +
                    "自然と一体となり、空の力に調和し、己の獣性を探求せよ。##~y~主な焦点:~/~#~w~支援~/~, ~w~回復~/~, ~w~召喚~/~, ~w~変身.~/~;" +
                    "자연과 하나가 되어 하늘의 힘에 동조하고 자신의 야성적인 본성을 탐구하십시오.##~y~주요 중점:~/~#~w~지원~/~, ~w~치유~/~, ~w~소환~/~, ~w~변신.~/~;\",";
                foreach (string item in input)
                {
                    if (item.Contains("Tier_name_end"))
                    {
                        string newItem = item;
                        newItem = newItem.Insert(newItem.IndexOf("\";Tier_name_end"), tier);
                        newItem = newItem.Insert(newItem.IndexOf("\";skilltree_hover_end"), hover);
                        yield return newItem;
                    }
                    else
                    {
                        yield return item;
                    }
                }
            }

            // Never gonna tell a lie and hurt you
            Msl.LoadGML("gml_GlobalScript_table_skills")
                .Apply(SkillNames)
                .Apply(SkillDescriptions)
                .Save();
            static IEnumerable<string> SkillNames(IEnumerable<string> input)
            {
                string skills =
                    "\"stick_to_snake;Палка в змею;Stick to Snake;木杖化蛇;Stock zur Schlange;Palo a Serpiente;Bâton en Serpent;Bastone in Serpente;Graveto em Serpente;Kij w Węża;Yılana Dönüş;棒を蛇へ;막대를 뱀으로;\"," +
                    "\"animal_friendship;Дружба с животными;Animal Friendship;动物亲和;Tierfreundschaft;Afinidad Animal;Amitié Animale;Affinità Animale;Afinidade Animal;Przyjaźń Zwierząt;Hayvan Dostluğu;動物との親和;동물 친화;\"," +
                    "\"celestial_strike;Небесный удар;Celestial Strike;天界打击;Himmlischer Schlag;Golpe Celestial;Frappe Céleste;Colpo Celestiale;Golpe Celestial;Niebiańskie Uderzenie;Göksel Darbe;天の一撃;천상의 일격;\"," +
                    "\"attune_the_sky;Настройка Неба;Attune to the Sky;调和天空;Einstimmung des Himmels;Sintonizar el Cielo;Accorder le Ciel;Sintonizzarsi al Cielo;Sintonizar o Céu;Dostrojenie Nieba;Gökyüzüyle Uyum;空との調和;하늘과의 조화;\"," +
                    "\"attune_the_earth;Настройка Земли;Attune to the Earth;调和大地;Einstimmung der Erde;Sintonizar la Tierra;Accorder la Terre;Sintonizzarsi alla Terra;Sintonizar a Terra;Dostrojenie Ziemi;Toprakla Uyum;大地との調和;대지와의 조화;\"," +
                    "\"entangling_grasp;Опутывающая хватка;Entangling Grasp;缠绕之握;Fesselnder Griff;Agarre Enredador;Poigne Entravante;Presa Avvolgente;Agarre Enredante;Krępujący Chwyt;Sarmalayan Kavrayış;絡みつく手;얽히는 손아귀;\"," +
                    "\"bestial_vigor;Звериная сила;Bestial Vigor;野兽活力;Bestiale Kraft;Vigor Bestial;Vigueur Bestiale;Vigore Bestiale;Vigor Bestial;Bestialska Witalność;Yabanıl Güç;獣の活力;야수의 활력;\"," +
                    "\"wild_shape;Звериная форма;Wild Shape;野性变形;Tiergestalt;Forma Salvaje;Forme Sauvage;Forma Selvatica;Forma Selvagem;Dzika Forma;Vahşi Biçim;野獣化;야성 변신;\"," +
                    "\"shadows_to_fox;Тень в лису;Shadows to Fox;暗影化狐;Schatten zur Füchsin;Sombras a Zorro;Ombres en Renard;Ombre in Volpe;Sombras em Raposa;Cienie w Lisa;Gölgeden Tilkiye;影より狐;그림자에서 여우로;\"," +
                    "\"butterflies_to_hornets;Бабочки в жалящих;Butterflies to Hornets;蝶化毒蜂;Schmetterlinge zu Hornissen;Mariposas a Avispones;Papillons en Frelons;Farfalle in Calabroni;Borboletas em Vespões;Motyle w Szerszenie;Kelebekten Eşek Arısına;蝶からスズメバチ;나비를 말벌로;\"," +
                    "\"circle_of_life;Круг жизни;Circle of Life;生命之环;Kreis des Lebens;Círculo de la Vida;Cercle de la Vie;Cerchio della Vita;Círculo da Vida;Krąg Życia;Yaşam Döngüsü;生命の輪;생명의 순환;\"," +
                    "\"healing_grace;Целительная благодать;Healing Grace;治愈恩典;Heilende Gnade;Gracia Sanadora;Grâce Curative;Grazia Curativa;Graça Curativa;Łaska Uzdrowienia;Şifa Lütfu;癒しの恩寵;치유의 은총;\"," +
                    "\"feral_nature;Дикая природа;Feral Nature;野性本质;Wilde Natur;Naturaleza Feral;Nature Sauvage;Natura Feroce;Natureza Feral;Dzika Natura;Yabanıl Doğa;獣性の本質;야성의 본질;\"," +
                    "\"bear_aspect;Аспект Медведя;Bear Aspect;熊之化身;Aspekt des Bären;Aspecto del Oso;Aspect de l’Ours;Aspetto dell’Orso;Aspecto do Urso;Aspekt Niedźwiedzia;Ayı Biçimi;熊の相;곰의 상;\",";

                foreach (string item in input)
                {
                    // Insert names
                    if (item.Contains("\";skill_name_end"))
                    {
                        string newItem = item.Insert(item.IndexOf("\";skill_name_end"), skills);
                        yield return newItem;
                        continue;
                    }

                    yield return item;
                }
            }
            static IEnumerable<string> SkillDescriptions(IEnumerable<string> input)
            {
                string skillsDesc =
                    "\"stick_to_snake;Бросьте палку и превратите её в ~y~Змею~/~, которая будет сражаться рядом с вами.\\nОдновременно может существовать только один уникальный ~w~призыв~/~.;Throw a stick, then transmute it into a ~y~Snake~/~ that will fight alongside you.\\nOnly one of each unique ~w~Summon~/~ may exist at a time.;Бросьте палку и превратите её в ~y~Змею~/~, которая будет сражаться рядом с вами.\\nОдновременно может существовать только один уникальный ~w~призыв~/~.;Wirf einen Stock und verwandle ihn in eine ~y~Schlange~/~, die an deiner Seite kämpft.\\nNur ein einzigartiger ~w~Beschwörung~/~ gleichzeitig.;Lanza un palo y transmutalo en una ~y~Serpiente~/~ que luchará a tu lado.\\nSolo puede existir una ~w~Invocación~/~ única a la vez.;Lancez un bâton et transmuez-le en ~y~Serpent~/~ qui combat à vos côtés.\\nUne seule ~w~Invocation~/~ unique peut exister à la fois.;Lancia un bastone e trasformalo in un ~y~Serpente~/~ che combatterà al tuo fianco.\\nPuò esistere solo una ~w~Evocazione~/~ unica alla volta.;Arremesse um graveto e transmute-o numa ~y~Serpente~/~ que lutará ao seu lado.\\nApenas uma ~w~Invocação~/~ única pode existir por vez.;Rzuć kij i przemień go w ~y~Węża~/~, który będzie walczył u twego boku.\\nMoże istnieć tylko jedno unikalne ~w~Przywołanie~/~ naraz.;Bir çubuğu fırlat ve onu seninle birlikte savaşacak bir ~y~Yılan~/~a dönüştür.\\nHer benzersiz ~w~Çağırma~/~dan aynı anda yalnızca biri var olabilir.;棒を投げて~y~蛇~/~に変え、共に戦わせる。\\n固有の~w~召喚~/~は同時に1体のみ。;막대를 던져 ~y~뱀~/~으로 변이시켜 함께 싸우게 합니다.\\n각 고유 ~w~소환~/~은 동시에 하나만 존재할 수 있습니다.;\"," +
                    "\"animal_friendship;Животные больше не будут убегать и не нападут первыми, если на них не напали.;Animals will no longer flee from your presence and never attack you unless attacked first.;动物不再因你而逃跑，且不会主动攻击，除非先遭到攻击。;Tiere fliehen nicht mehr vor dir und greifen nur an, wenn sie zuerst angegriffen werden.;Los animales ya no huirán de tu presencia y no atacarán a menos que los ataques primero.;Les animaux ne fuiront plus et n’attaqueront jamais, sauf si vous les attaquez d’abord.;Gli animali non fuggiranno più e non attaccheranno mai, a meno che non vengano attaccati per primi.;Os animais não fugirão mais e não atacarão, a menos que sejam atacados primeiro.;Zwierzęta nie będą już uciekać i nie zaatakują, chyba że zaatakujesz je pierwszy.;Hayvanlar artık senden kaçmayacak ve önce saldırılmadıkça saldırmayacak.;動物は逃げなくなり、先に攻撃しない限り襲ってこない。;동물은 더 이상 도망치지 않으며 먼저 공격하지 않으면 공격하지 않습니다.;\"," +
                    "\"celestial_strike;Выпускает заряд, который в зависимости от времени суток наносит от ~p~12~/~ Чародейского до ~y~12~/~ Священного урона.\\nУспешные применения дают от ~p~12%~/~ восстановления энергии до ~y~12%~/~ восстановления блока на ~w~4~/~ хода.;Launches a bolt that, depending on the time of day, deals between ~p~12~/~ Arcane and ~y~12~/~ Sacred damage.\\nSuccessful casts grant between ~p~12%~/~ Energy Restoration and ~y~12%~/~ Block Power Recovery for ~w~4~/~ turns.;根据时间发射能量弹，造成~p~12~/~奥术至~y~12~/~神圣伤害。\\n成功施放后获得~p~12%~/~精力恢复至~y~12%~/~格挡恢复，持续~w~4~/~回合。;Feuert je nach Tageszeit ein Geschoss ab, das zwischen ~p~12~/~ Arkanschaden und ~y~12~/~ Heiligschaden verursacht.\\nErfolgreiche Wirkungen gewähren zwischen ~p~12%~/~ Energieregeneration und ~y~12%~/~ Blockregeneration für ~w~4~/~ Runden.;Lanza un proyectil que, según la hora del día, inflige entre ~p~12~/~ de daño Arcano y ~y~12~/~ de daño Sagrado.\\nLos lanzamientos exitosos otorgan entre ~p~12%~/~ de Restauración de Energía y ~y~12%~/~ de Recuperación de Bloqueo durante ~w~4~/~ turnos.;Lance un projectile qui, selon l’heure du jour, inflige entre ~p~12~/~ dégâts Arcaniques et ~y~12~/~ dégâts Sacrés.\\nLes utilisations réussies confèrent entre ~p~12%~/~ Récup. d’Énergie et ~y~12%~/~ Récup. de Blocage pendant ~w~4~/~ tours.;Lancia un dardo che, in base all’ora del giorno, infligge tra ~p~12~/~ danni Arcani e ~y~12~/~ danni Sacri.\\nI lanci riusciti forniscono tra ~p~12%~/~ Recupero Energia e ~y~12%~/~ Recupero Blocco per ~w~4~/~ turni.;Dispara um projétil que, dependendo do horário, causa entre ~p~12~/~ de dano Arcano e ~y~12~/~ de dano Sagrado.\\nConjurações bem-sucedidas concedem entre ~p~12%~/~ Restauração de Energia e ~y~12%~/~ Recuperação de Bloqueio por ~w~4~/~ turnos.;Wystrzeliwuje pocisk, który zależnie od pory dnia zadaje od ~p~12~/~ obrażeń Arkanicznych do ~y~12~/~ Świętych.\\nUdane użycia zapewniają od ~p~12%~/~ Odzysku Energii do ~y~12%~/~ Odzysku Bloku na ~w~4~/~ tury.;Günün saatine bağlı olarak ~p~12~/~ Arkana ile ~y~12~/~ Kutsal hasar arasında hasar veren bir mermi fırlatır.\\nBaşarılı kullanım, ~w~4~/~ tur boyunca ~p~12%~/~ Enerji Yenilenmesi ile ~y~12%~/~ Blok Gücü Yenilenmesi sağlar.;時間帯に応じて~p~12~/~秘術～~y~12~/~聖なるダメージを与える魔弾を放つ。\\n成功時、~w~4~/~ターンの間~p~12%~/~エネルギー回復～~y~12%~/~ブロック回復を得る。;시간대에 따라 ~p~12~/~ 비전~y~12~/~ 신성 피해를 주는 탄환을 발사합니다.\\n성공 시 ~w~4~/~턴 동안 ~p~12%~/~ 에너지 회복~y~12%~/~ 막기 회복을 얻습니다.;\"," +
                    "\"attune_the_sky;В зависимости от времени суток даёт от ~p~24%~/~ сопротивления голоду и ~p~12%~/~ снижения урона, либо ~y~24%~/~ сопротивления усталости и ~y~12%~/~ снижения перезарядки.;Based on time of day, grant the player between ~p~24%~/~ Hunger Resistance and ~p~12%~/~ Damage Reduction, and ~y~24%~/~ Fatigue Resistance and ~y~12%~/~ Cooldown Reduction.;根据时间给予~p~24%~/~饥饿抗性与~p~12%~/~伤害减免，或~y~24%~/~疲劳抗性与~y~12%~/~冷却缩减。;Je nach Tageszeit erhältst du ~p~24%~/~ Hungerresistenz und ~p~12%~/~ Schadensreduktion oder ~y~24%~/~ Ermüdungsresistenz und ~y~12%~/~ Abklingzeitreduktion.;Según la hora del día, otorga ~p~24%~/~ Resistencia al Hambre y ~p~12%~/~ Reducción de Daño, o ~y~24%~/~ Resistencia a la Fatiga y ~y~12%~/~ Reducción de Enfriamiento.;Selon l’heure, confère ~p~24%~/~ Résistance à la Faim et ~p~12%~/~ Réduction des Dégâts, ou ~y~24%~/~ Résistance à la Fatigue et ~y~12%~/~ Réduction de Recharge.;A seconda dell’ora, conferisce ~p~24%~/~ Resistenza alla Fame e ~p~12%~/~ Riduzione Danni, oppure ~y~24%~/~ Resistenza alla Fatica e ~y~12%~/~ Riduzione Ricarica.;Conforme o horário, concede ~p~24%~/~ Resistência à Fome e ~p~12%~/~ Redução de Dano, ou ~y~24%~/~ Resistência à Fadiga e ~y~12%~/~ Redução de Recarga.;W zależności od pory dnia daje ~p~24%~/~ Odporności na Głód i ~p~12%~/~ Redukcji Obrażeń, albo ~y~24%~/~ Odporności na Zmęczenie i ~y~12%~/~ Redukcji Odnowienia.;Günün saatine bağlı olarak ~p~24%~/~ Açlık Direnci ve ~p~12%~/~ Hasar Azaltma veya ~y~24%~/~ Yorgunluk Direnci ve ~y~12%~/~ Bekleme Süresi Azaltma sağlar.;時間帯に応じて~p~24%~/~空腹耐性と~p~12%~/~被ダメ軽減、または~y~24%~/~疲労耐性と~y~12%~/~クールダウン短縮を得る。;시간대에 따라 ~p~24%~/~ 허기 저항 및 ~p~12%~/~ 피해 감소 또는 ~y~24%~/~ 피로 저항 및 ~y~12%~/~ 재사용 대기시간 감소를 얻습니다.;\"," +
                    "\"attune_the_earth;~lg~Удваивает~/~ эффекты всех трав.\\nДаёт ~lg~+20%~/~ к эффективности лечения и ~lg~+10%~/~ к восстановлению здоровья.;~lg~Double~/~ the effects of all herbs.\\nGrants ~lg~20%~/~ increased Healing Efficiency and ~lg~10%~/~ increased Health Restoration.;~lg~使所有草药效果翻倍~/~。\\n获得~lg~20%~/~治疗效率提升与~lg~10%~/~生命恢复提升。;~lg~Verdoppelt~/~ die Wirkung aller Kräuter.\\nGewährt ~lg~20%~/~ Heilungseffizienz und ~lg~10%~/~ Lebensregeneration.;~lg~Duplica~/~ los efectos de todas las hierbas.\\nOtorga ~lg~20%~/~ Eficiencia de Curación y ~lg~10%~/~ Recuperación de Vida.;~lg~Double~/~ les effets de toutes les herbes.\\nConfère ~lg~20%~/~ d’Efficacité de Soin et ~lg~10%~/~ de Restauration de Santé.;~lg~Raddoppia~/~ gli effetti di tutte le erbe.\\nConferisce ~lg~20%~/~ Efficienza Cura e ~lg~10%~/~ Recupero Salute.;~lg~Duplica~/~ os efeitos de todas as ervas.\\nConcede ~lg~20%~/~ Eficiência de Cura e ~lg~10%~/~ Restauração de Vida.;~lg~Podwaja~/~ działanie wszystkich ziół.\\nDaje ~lg~20%~/~ Skuteczności Leczenia i ~lg~10%~/~ Odnowy Zdrowia.;~lg~Tüm otların etkisini ikiye katlar~/~.\\n~lg~20%~/~ Şifa Verimliliği ve ~lg~10%~/~ Can Yenilenmesi sağlar.;~lg~すべての薬草効果を2倍に~/~。\\n~lg~20%~/~治療効率と~lg~10%~/~体力回復を得る。;~lg~모든 약초 효과를 두 배로~/~.\\n~lg~20%~/~ 치유 효율 및 ~lg~10%~/~ 체력 회복 증가.;\"," +
                    "\"entangling_grasp;Преобразует корни и лозы вокруг вас, ~lg~опутывая~/~ врага на расстоянии до двух клеток.\\nНе работает на врагах, невосприимчивых к ~w~Сетям~/~ или ~w~Паутинам~/~.;Transform the roots and vines around you, ~lg~Rooting~/~ an enemy up to two tiles away.\\nDoesn't work on enemies immune to ~w~Nets~/~ or ~w~Webbing~/~.;操纵周围根须藤蔓，使两格内一名敌人~lg~定身~/~。\\n对免疫~w~网~/~或~w~蛛网~/~的敌人无效。;Verwandle Wurzeln und Ranken um dich herum und ~lg~fessele~/~ einen Gegner bis zu zwei Felder entfernt.\\nWirkt nicht auf Gegner, die gegen ~w~Netze~/~ oder ~w~Spinnweben~/~ immun sind.;Transforma raíces y enredaderas cercanas, ~lg~Enraizando~/~ a un enemigo hasta dos casillas.\\nNo funciona contra enemigos inmunes a ~w~Redes~/~ o ~w~Telarañas~/~.;Transforme les racines et lianes proches, ~lg~Entravant~/~ un ennemi jusqu’à deux cases.\\nNe fonctionne pas sur les ennemis immunisés aux ~w~Filets~/~ ou aux ~w~Toiles~/~.;Trasforma radici e rampicanti vicini, ~lg~Radicando~/~ un nemico fino a due caselle.\\nNon funziona sui nemici immuni a ~w~Reti~/~ o ~w~Ragnatele~/~.;Transforma raízes e vinhas próximas, ~lg~Enraizando~/~ um inimigo até duas casas.\\nNão funciona em inimigos imunes a ~w~Redes~/~ ou ~w~Teias~/~.;Przekształca okoliczne korzenie i pnącza, ~lg~Unieruchamiając~/~ wroga do dwóch pól.\\nNie działa na wrogów odpornych na ~w~Sieci~/~ lub ~w~Pajęczynę~/~.;Yakındaki kökleri ve sarmaşıkları dönüştürerek iki kare uzaktaki bir düşmanı ~lg~Kökler~/~.\\n~w~Ağlar~/~ veya ~w~Ağ Örme~/~ bağışıklığı olanlarda çalışmaz.;周囲の根や蔓を変化させ、2マス先までの敵を~lg~拘束~/~する。\\n~w~網~/~や~w~蜘蛛の巣~/~に免疫の敵には無効。;주변의 뿌리와 덩굴을 변형해 두 칸 내의 적 하나를 ~lg~속박~/~합니다.\\n~w~그물~/~이나 ~w~거미줄~/~ 면역 적에게는 무효.;\"," +
                    "\"bestial_vigor;Сырая ~r~Плоть~/~ больше не даёт отрицательных эффектов и даёт ~lg~Бодрость~/~ на ~w~120~/~ ходов.;Eating raw ~r~Meat~/~ no longer has negative effects and grants the ~lg~Vigor~/~ buff for ~w~120~/~ turns.;食用生~r~肉~/~不再有负面效果，并获得~lg~活力~/~增益，持续~w~120~/~回合。;Rohes ~r~Fleisch~/~ hat keine negativen Effekte mehr und gewährt ~lg~Elan~/~ für ~w~120~/~ Züge.;Comer ~r~Carne~/~ cruda ya no tiene efectos negativos y otorga ~lg~Vigor~/~ por ~w~120~/~ turnos.;Manger de la ~r~Viande~/~ crue n’a plus d’effets négatifs et confère ~lg~Vigueur~/~ pendant ~w~120~/~ tours.;Mangiare ~r~Carne~/~ cruda non ha più effetti negativi e conferisce ~lg~Vigore~/~ per ~w~120~/~ turni.;Comer ~r~Carne~/~ crua não tem mais efeitos negativos e concede ~lg~Vigor~/~ por ~w~120~/~ turnos.;Jedzenie surowego ~r~Mięsa~/~ nie ma już negatywnych efektów i daje ~lg~Wigor~/~ na ~w~120~/~ tur.;Çiğ ~r~Et~/~ yemek artık olumsuz etki vermez ve ~w~120~/~ tur boyunca ~lg~Dinçlik~/~ sağlar.;生~r~肉~/~を食べても悪影響を受けず、~lg~活力~/~を~w~120~/~ターン得る。;생 ~r~고기~/~ 섭취 시 부정 효과가 사라지고 ~lg~활력~/~을 ~w~120~/~턴 획득.;\"," +
                    "\"wild_shape;Превратитесь в ~y~Волка~/~, получив мощный бонус к уклонению и рваному урону.\\nПреображение постоянно расходует ~b~Энергию~/~.\\nВы не можете использовать экипировку и умения, но можете использовать предметы.\\nЕсли ~b~Энергия~/~ закончится или вы примените умение снова, вы вернётесь человеком.;Transform into a ~y~Wolf~/~, gaining a large increase in Dodge Chance and Rending Damage.\\nThe transformation constantly drains ~b~Energy~/~ while active.\\nYou cannot use equipment or spells, but can use items.\\nRunning out of ~b~Energy~/~ or casting the skill again returns you to human form.;变身为~y~狼~/~，大幅提升闪避几率与撕裂伤害。\\n变形期间持续消耗~b~精力~/~。\\n无法使用装备与技能，但可使用物品。\\n~b~精力~/~耗尽或再次施放会恢复人形。;Verwandle dich in einen ~y~Wolf~/~, mit stark erhöhter Ausweichchance und Zerreißschaden.\\nDie Verwandlung verbraucht ständig ~b~Energie~/~.\\nKeine Ausrüstung oder Fähigkeiten, Items sind nutzbar.\\nOhne ~b~Energie~/~ oder bei erneutem Wirken kehrst du zurück.;Transfórmate en ~y~Lobo~/~, aumentando mucho la Esquiva y el Daño Desgarrador.\\nDrena ~b~Energía~/~ constantemente.\\nNo puedes usar equipo ni habilidades, pero sí objetos.\\nSin ~b~Energía~/~ o al lanzarla otra vez, vuelves a humano.;Transformez-vous en ~y~Loup~/~, gagnant beaucoup d’Esquive et de dégâts Déchirants.\\nLa forme draine constamment ~b~Énergie~/~.\\nPas d’équipement ni de compétences, mais objets utilisables.\\nÀ court de ~b~Énergie~/~ ou en relançant, retour humain.;Trasformati in ~y~Lupo~/~, con grande aumento di Schivata e Danni Laceranti.\\nConsuma costantemente ~b~Energia~/~.\\nNiente equipaggiamento o abilità, ma oggetti utilizzabili.\\nSe finisci ~b~Energia~/~ o la lanci di nuovo, torni umano.;Transforme-se em ~y~Lobo~/~, com grande aumento de Esquiva e Dano Dilacerante.\\nDrena ~b~Energia~/~ constantemente.\\nNão pode usar equipamento ou habilidades, mas pode usar itens.\\nSem ~b~Energia~/~ ou ao conjurar de novo, volta ao normal.;Zmień się w ~y~Wilka~/~, znacznie zwiększając Unik i Obrażenia Rozdarcia.\\nPrzemiana stale zużywa ~b~Energię~/~.\\nNie możesz używać ekwipunku ani umiejętności, ale możesz używać przedmiotów.\\nGdy zabraknie ~b~Energii~/~ lub użyjesz ponownie, wracasz do człowieka.;~y~Kurt~/~ formuna dönüş, Kaçınma ve Yırtma Hasarını arttır.\\nDönüşüm boyunca ~b~Enerji~/~ sürekli azalır.\\nEkipman ve yetenek kullanamazsın, eşya kullanabilirsin.\\n~b~Enerji~/~ biterse veya tekrar kullanırsan insana dönersin.;~y~狼~/~に変身し、回避率と裂傷ダメージが大きく増加する。\\n効果中は~b~エネルギー~/~を継続消費。\\n装備・スキルは使えないが、アイテムは使用可能。\\n~b~エネルギー~/~切れ、または再使用で人間に戻る。;~y~늑대~/~로 변신해 회피 확률과 찢기 피해가 크게 증가합니다.\\n변신 중 ~b~에너지~/~를 지속 소모합니다.\\n장비/기술 사용 불가, 아이템 사용 가능.\\n~b~에너지~/~가 소진되거나 다시 사용하면 인간으로 돌아옵니다.;\"," +
                    "\"shadows_to_fox;Сгустите ближайшие тени, создавая ~y~Лису~/~, которая будет сражаться рядом с вами.\\nОдновременно может существовать только один уникальный ~w~призыв~/~.;Condense nearby shadows, forming them into a ~y~Fox~/~ that will fight alongside you.\\nOnly one of each unique ~w~Summon~/~ may exist at a time.;凝聚附近暗影，形成~y~狐狸~/~协助作战。\\n每种~w~召唤物~/~同时只能存在一个。;Verdichte nahe Schatten zu einem ~y~Fuchs~/~, der an deiner Seite kämpft.\\nNur ein einzigartiger ~w~Beschwörung~/~ gleichzeitig.;Condensa sombras cercanas para formar un ~y~Zorro~/~ aliado.\\nSolo una ~w~Invocación~/~ única a la vez.;Condensez les ombres proches en ~y~Renard~/~ allié.\\nUne seule ~w~Invocation~/~ unique à la fois.;Condensa le ombre vicine in una ~y~Volpe~/~ alleata.\\nSolo una ~w~Evocazione~/~ unica alla volta.;Condense sombras próximas numa ~y~Raposa~/~ aliada.\\nApenas uma ~w~Invocação~/~ única por vez.;Skondensuj pobliskie cienie w ~y~Lisa~/~ sojusznika.\\nTylko jedno unikalne ~w~Przywołanie~/~ naraz.;Yakındaki gölgeleri yoğunlaştırıp ~y~Tilki~/~ oluştur.\\nHer benzersiz ~w~Çağırma~/~dan aynı anda yalnızca biri var olabilir.;近くの影を凝縮し、~y~狐~/~として形作る。\\n固有の~w~召喚~/~は1体のみ。;주변의 그림자를 응축해 ~y~여우~/~를 소환합니다.\\n각 고유 ~w~소환~/~은 하나만 존재.;\"," +
                    "\"butterflies_to_hornets;Раздавите только что вылупившуюся бабочку, превращая её останки в ~y~рой Смертожалів~/~, который будет сражаться рядом с вами.\\nОдновременно может существовать только один уникальный ~w~призыв~/~.;Crush a newly hatched butterfly, transforming its remains into a ~y~Swarm of Deathstingers~/~ that will fight alongside you.\\nOnly one of each unique ~w~Summon~/~ may exist at a time.;碾碎新孵化的蝴蝶，将其残骸化为~y~死亡刺蜂群~/~协助作战。\\n每种~w~召唤物~/~同时只能存在一个。;Zerquetsche einen frisch geschlüpften Schmetterling und verwandle die Überreste in einen ~y~Schwarm Todesstecher~/~, der an deiner Seite kämpft.\\nNur ein einzigartiger ~w~Beschwörung~/~ gleichzeitig.;Aplasta una mariposa recién nacida y transforma sus restos en un ~y~Enjambre de Aguijones Mortales~/~ aliado.\\nSolo una ~w~Invocación~/~ única a la vez.;Écrasez un papillon fraîchement éclos et transformez ses restes en ~y~Essaim de Pique-morts~/~ allié.\\nUne seule ~w~Invocation~/~ unique à la fois.;Schiaccia una farfalla appena nata e trasforma i resti in uno ~y~Sciame di Pungiglioni della Morte~/~ alleato.\\nSolo una ~w~Evocazione~/~ unica alla volta.;Esmague uma borboleta recém-nascida e transforme os restos num ~y~Enxame de Ferroadas da Morte~/~ aliado.\\nApenas uma ~w~Invocação~/~ única por vez.;Zgnieć świeżo wyklutego motyla i zamień szczątki w ~y~Rój Śmierciożądeł~/~ sojuszniczy.\\nTylko jedno unikalne ~w~Przywołanie~/~ naraz.;Yeni çıkmış bir kelebeği ezip kalıntılarını ~y~Ölüm İğneleri Sürüsü~/~ne dönüştür.\\nHer benzersiz ~w~Çağırma~/~dan aynı anda yalnızca biri var olabilir.;孵化したばかりの蝶を潰し、残骸を~y~デススティンガーの群れ~/~に変える。\\n固有の~w~召喚~/~は1体のみ。;갓 부화한 나비를 으깨 ~y~죽음침벌 떼~/~로 만듭니다.\\n각 고유 ~w~소환~/~은 동시에 하나만 존재.;\"," +
                    "\"circle_of_life;Даёт ~lg~+10~/~ к максимальному здоровью и ~lg~10%~/~ сопротивления усталости.\\nДаёт ~lg~2%~/~ восстановления здоровья за каждый недостающий ~r~процент~/~ здоровья.;Grants ~lg~+10~/~ Max Health and ~lg~10%~/~ Fatigue Resistance.\\nGrants ~lg~2%~/~ Health Restoration for each missing ~r~percent~/~ of Health.;获得~lg~+10~/~最大生命与~lg~10%~/~疲劳抗性。\\n每缺失~r~1%~/~生命，获得~lg~2%~/~生命恢复。;Gewährt ~lg~+10~/~ maximales Leben und ~lg~10%~/~ Ermüdungsresistenz.\\nGewährt ~lg~2%~/~ Lebensregeneration je fehlendem ~r~Prozent~/~ Leben.;Otorga ~lg~+10~/~ Vida Máx. y ~lg~10%~/~ Resistencia a la Fatiga.\\nOtorga ~lg~2%~/~ Regeneración por cada ~r~porcentaje~/~ de Vida faltante.;Confère ~lg~+10~/~ PV max et ~lg~10%~/~ Résistance à la Fatigue.\\nConfère ~lg~2%~/~ Restauration pour chaque ~r~pourcent~/~ de PV manquant.;Conferisce ~lg~+10~/~ Salute Massima e ~lg~10%~/~ Resistenza alla Fatica.\\nConferisce ~lg~2%~/~ Recupero Salute per ogni ~r~percento~/~ di Salute mancante.;Concede ~lg~+10~/~ Vida Máx. e ~lg~10%~/~ Resistência à Fadiga.\\nConcede ~lg~2%~/~ Restauração por cada ~r~porcento~/~ de Vida faltante.;Daje ~lg~+10~/~ Maks. Zdrowia i ~lg~10%~/~ Odporności na Zmęczenie.\\nDaje ~lg~2%~/~ Odnowy za każdy brakujący ~r~procent~/~ Zdrowia.;~lg~+10~/~ Maks. Can ve ~lg~10%~/~ Yorgunluk Direnci verir.\\nEksik her ~r~yüzde~/~ Can için ~lg~2%~/~ Can Yenilenmesi sağlar.;最大体力~lg~+10~/~、疲労耐性~lg~10%~/~を得る。\\n失った体力の~r~1%~/~ごとに~lg~2%~/~体力回復を得る。;최대 체력 ~lg~+10~/~, 피로 저항 ~lg~10%~/~.\\n부족한 체력 ~r~1%~/~마다 ~lg~2%~/~ 체력 회복.;\"," +
                    "\"healing_grace;Мгновенно стабилизирует все травмы и исцеляет цель на ~lg~30%~/~ от её максимального здоровья.;Immediately stabilise all injuries and heal the target by ~lg~30%~/~ of their Max Health.;立即稳定所有伤势，并治疗目标~lg~30%~/~最大生命。;Stabilisiert sofort alle Verletzungen und heilt ~lg~30%~/~ des max. Lebens.;Estabiliza heridas y cura ~lg~30%~/~ de la Vida Máx.;Stabilise les blessures et soigne ~lg~30%~/~ des PV max.;Stabilizza ferite e cura ~lg~30%~/~ della Salute Max.;Estabiliza ferimentos e cura ~lg~30%~/~ da Vida Máx.;Stabilizuje urazy i leczy ~lg~30%~/~ Maks. Zdrowia.;Yaraları sabitler ve maks. canın ~lg~30%~/~ kadarını iyileştirir.;負傷を安定化し、最大体力の~lg~30%~/~回復。;부상을 안정시키고 최대 체력의 ~lg~30%~/~ 치유.;\"," +
                    "\"feral_nature;Даёт ~lg~+5%~/~ к шансу крита и чуда.\\nУлучшает характеристики ~r~Звериной формы~/~ на ~lg~50%~/~ и позволяет колдовать в этой форме.;Grants ~lg~+5%~/~ Crit and Miracle chance.\\nImproves your ~r~Wild Shape~/~ stats by ~lg~50%~/~ and allows spell-casting while transformed.;获得~lg~+5%~/~暴击与奇迹几率。\\n~lg~50%~/~提升~r~野性变形~/~属性，并允许变形时施法。;Gewährt ~lg~+5%~/~ Krit- und Wunderchance.\\nVerbessert Tiergestalt-Werte um ~lg~50%~/~ und erlaubt Zaubern.;Otorga ~lg~+5%~/~ Prob. Crítico y Milagro.\\nMejora Forma Salvaje un ~lg~50%~/~ y permite lanzar hechizos.;Confère ~lg~+5%~/~ Critique et Miracle.\\nAméliore Forme Sauvage de ~lg~50%~/~ et permet de lancer des sorts.;Conferisce ~lg~+5%~/~ Critico e Miracolo.\\nMigliora Forma Selvatica del ~lg~50%~/~ e consente incantesimi.;Concede ~lg~+5%~/~ Crítico e Milagre.\\nMelhora Forma Selvagem em ~lg~50%~/~ e permite conjurar.;Daje ~lg~+5%~/~ Szansy Krytyka i Cudu.\\nPoprawia Dzika Forma o ~lg~50%~/~ i pozwala rzucać czary.;~lg~+5%~/~ Kritik ve Mucize Şansı.\\n~r~Vahşi Biçim~/~ istatistiklerini ~lg~50%~/~ artırır ve büyü yapmayı sağlar.;クリティカルと奇跡確率~lg~+5%~/~。\\n~r~野獣化~/~の能力が~lg~50%~/~向上し、変身中に魔法を使用可能。;치명타/기적 확률 ~lg~+5%~/~.\\n~r~야성 변신~/~ 능력치 ~lg~50%~/~ 증가 및 변신 중 주문 사용 가능.;\"," +
                    "\"bear_aspect;Заменяет ~r~Звериную форму~/~ на ~y~Медведя~/~, усиливая бонусы трансформации ещё на ~lg~100%~/~.;Turns your ~r~Wild Shape~/~ form into a ~y~Bear~/~, enhancing the stats gained from the transformation by an additional ~lg~100%~/~.;将~r~野性变形~/~替换为~y~熊~/~，额外提升~lg~100%~/~变形加成。;Ersetzt Tiergestalt durch einen ~y~Bären~/~ und erhöht die Transformationsboni um weitere ~lg~100%~/~.;Convierte Forma Salvaje en ~y~Oso~/~ y aumenta sus bonificaciones un ~lg~100%~/~ adicional.;Remplace Forme Sauvage par un ~y~Ours~/~ et augmente les bonus de ~lg~100%~/~.;Sostituisce Forma Selvatica con un ~y~Orso~/~ e aumenta i bonus di ~lg~100%~/~.;Substitui Forma Selvagem por um ~y~Urso~/~ e aumenta os bônus em mais ~lg~100%~/~.;Zastępuje Dziką Formę ~y~Niedźwiedziem~/~ i zwiększa premie o dodatkowe ~lg~100%~/~.;~r~Vahşi Biçim~/~ yerine ~y~Ayı~/~ olur ve bonusları ~lg~100%~/~ daha artırır.;~r~野獣化~/~を~y~熊~/~に置き換え、ボーナスをさらに~lg~100%~/~強化する。;~r~야성 변신~/~이 ~y~곰~/~으로 바뀌며 변신 보너스가 추가로 ~lg~100%~/~ 증가합니다.;\",";

                foreach (string item in input)
                {
                    // Insert descriptions
                    if (item.Contains("\";skill_desc_end"))
                    {
                        string newItem = item.Insert(item.IndexOf("\";skill_desc_end"), skillsDesc.Replace('\n', ' '));
                        yield return newItem;
                        continue;
                    }

                    yield return item;
                }
            }

            Msl.LoadGML("gml_GlobalScript_table_effects")
                .Apply(BuffsIterator)
                .Save();
            static IEnumerable<string> BuffsIterator(IEnumerable<string> input)
            {
                string name =
                    "\"o_b_wild_shape;Звериная форма;Wild Shape;野性变形;Tiergestalt;Forma Salvaje;Forme Sauvage;Forma Selvatica;Forma Selvagem;Dzika Forma;Vahşi Biçim;野獣化;야성 변신;\"," +
                    "\"o_db_rooted;Обездвижен;Rooted;定身;Verwurzelt;Enraizado;Enraciné;Radicato;Enraizado;Unieruchomiony;Kök Salmış;拘束;속박;\"," +
                    "";

                string desc =
                    "\"o_b_wild_shape;Вы находитесь в форме Дикого Облика. Вы не можете использовать ~r~Оружие~/~ или ~r~Заклинания~/~.\\nПри окончании ~b~Энергии~/~ или повторном применении навыка вы возвращаетесь в человеческую форму.;You are in your Wild Shape form. You cannot use your ~r~Weapons~/~ or ~r~Spells~/~.\\nRunning out of ~b~Energy~/~ or casting the skill again returns you to human form.;你处于野性变形状态，无法使用~r~武器~/~或~r~法术~/~。\\n当~b~能量~/~耗尽或再次施放该技能时，你将恢复为人形。;Du befindest dich in deiner Wildgestalt. Du kannst keine ~r~Waffen~/~ oder ~r~Zauber~/~ benutzen.\\nWenn deine ~b~Energie~/~ erschöpft ist oder du die Fähigkeit erneut wirkst, kehrst du in menschliche Gestalt zurück.;Te encuentras en tu forma de Forma Salvaje. No puedes usar ~r~Armas~/~ ni ~r~Hechizos~/~.\\nAl quedarte sin ~b~Energía~/~ o usar la habilidad de nuevo, vuelves a tu forma humana.;Vous êtes sous votre forme de Métamorphose Sauvage. Vous ne pouvez pas utiliser vos ~r~Armes~/~ ni vos ~r~Sorts~/~.\\nLorsque votre ~b~Énergie~/~ est épuisée ou si vous relancez la compétence, vous redevenez humain.;Sei nella tua forma di Metamorfosi Selvaggia. Non puoi usare ~r~Armi~/~ né ~r~Incantesimi~/~.\\nQuando l’~b~Energia~/~ si esaurisce o riusi l’abilità, torni umano.;Você está em sua forma de Forma Selvagem. Não pode usar ~r~Armas~/~ nem ~r~Feitiços~/~.\\nAo ficar sem ~b~Energia~/~ ou usar a habilidade novamente, retorna à forma humana.;Jesteś w formie Dzikiej Przemiany. Nie możesz używać ~r~Bróni~/~ ani ~r~Zaklęć~/~.\\nGdy skończy się ~b~Energia~/~ lub użyjesz umiejętności ponownie, wracasz do ludzkiej postaci.;Vahşi Biçimdesin. ~r~Silahları~/~ veya ~r~Büyüleri~/~ kullanamazsın.\\n~b~Enerji~/~ bittiğinde veya yeteneği tekrar kullandığında insan formuna dönersin.;野性形態になっている。~r~武器~/~や~r~魔法~/~は使用できない。\\n~b~エネルギー~/~が尽きるか、再度スキルを使用すると人間の姿に戻る。;야성 형태에 들어간 상태입니다. ~r~무기~/~ 및 ~r~주문~/~을 사용할 수 없습니다.\\n~b~에너지~/~가 소진되거나 스킬을 다시 사용하면 인간 형태로 돌아옵니다.;\"," +
                    "\"o_db_rooted;~r~Невозможность перемещения~/~##Пропуск хода ~lg~уменьшает~/~ длительность эффекта на несколько ходов (в зависимости от ~sy~силы~/~ и ~sy~ловкости~/~).;~r~Can't move to other tiles~/~.##Skipping a turn ~lg~reduces~/~ the effect's duration by a few turns (depending on ~sy~Strength~/~ and ~sy~Agility~/~).;~r~无法移动到其他方格~/~。##跳过一个回合会令这个效果存续时间 ~lg~缩短~/~若干回合（缩短幅度取决于你的~sy~力量~/~和~sy~敏捷~/~）;~r~Kann sich nicht auf andere Felder bewegen~/~##Überspringen einer Runde ~lg~reduziert ~/~ die Effektdauer um ein paar Runden (abhängig von ~sy~Stärke~/~ und ~sy~Beweglichkeit~/~).;~r~No te puedes mover a otras casillas~/~##Saltarse un turno ~lg~reduce~/~ la duración del efecto algunos turnos (cuántos dependerá de tu ~sy~Fuerza~/~ y tu ~sy~Agilidad~/~).;~r~Impossible de se déplacer sur d'autres cases~/~##Passer un tour ~lg~réduit~/~ la durée de l'effet de quelques tours (en fonction de la ~sy~Force~/~ et de ~sy~l'Agilité~/~).;~r~Impossibile compiere movimenti~/~##Saltare un turno ~lg~riduce~/~ la durata dell'effetto di alcuni turni (determinati dalla tua ~sy~Forza~/~ e ~sy~Agilità~/~). ;~r~Não pode se mover para outros espaços~/~##Pular um turno ~lg~reduz~/~ a duração do efeito em alguns turnos (dependendo da ~sy~Força~/~ e ~sy~Agilidade~/~).;~r~Uniemożliwia przemieszczanie się~/~##Pominięcie tury ~lg~skraca~/~ czas trwania efektu o kilka tur (w zależności od ~sy~siły~/~ i ~sy~zręczności~/~ postaci).;~r~Diğer karolara hareket edemez~/~##Tur atlamak, (~sy~Güç~/~ ve ~sy~Çeviklik~/~ seviyesine bağlı olarak) etkinin süresini birkaç tur ~lg~azaltır~/~.;~r~別のタイルに移動できない~/~##ターンをスキップすることで効果時間を数ターン~lg~短縮~/~することができる（短縮幅は~sy~筋力~/~と~sy~敏捷性~/~に依存する）;~r~다른 타일로 이동할 수 없습니다.~/~##턴을 건너뛰면 효과의 지속 시간이 (~sy~근력~/~ 및 ~sy~민첩성~/~에 따라) 몇 턴 정도 ~sy~감소합니다.~/~;\"" +
                    "";

                foreach (string item in input)
                {
                    if (item.Contains("buff_name_end"))
                    {
                        string newItem = item;
                        newItem = newItem.Insert(newItem.IndexOf("\";buff_name_end"), name);
                        newItem = newItem.Insert(newItem.IndexOf("\";buff_desc_end"), desc);
                        yield return newItem;
                    }
                    else
                    {
                        yield return item;
                    }
                }
            }

            Msl.LoadGML("gml_GlobalScript_table_lines")
                .Apply(CharDialogIterator)
                .Save();
            static IEnumerable<string> CharDialogIterator(IEnumerable<string> input)
            {
                const string anchor = "\"learn_geo_t1;";

                string druidism =
                    "\"learn_druidism_t1;;;;;;" +
                    "*Пройти начальный урок друидизма* ~y~[250 крон]~/~;" +
                    "*Take a beginner lesson in Druidism* ~y~[250 crowns]~/~;" +
                    "*学习德鲁伊学的入门课程* ~y~[250 克朗]~/~;" +
                    "*Eine Einführung in den Druidentum-Unterricht erhalten* ~y~[250 Kronen]~/~;" +
                    "*Tomar una lección inicial de Druismo* ~y~[250 coronas]~/~;" +
                    "*Suivre une leçon d’initiation au druidisme* ~y~[250 couronnes]~/~;" +
                    "*Seguire una lezione introduttiva di druidismo* ~y~[250 corone]~/~;" +
                    "*Fazer uma lição introdutória de Druidismo* ~y~[250 coroas]~/~;" +
                    "*Wziąć podstawową lekcję druidyzmu* ~y~[250 koron]~/~;" +
                    "*Druidizm için başlangıç dersi al* ~y~[250 taç]~/~;" +
                    "*ドルイドの初歩を学ぶ* ~y~[250 クラウン]~/~;" +
                    "*드루이드의 기초 수업을 받는다* ~y~[250 크라운]~/~;\", ";

                foreach (string line in input)
                {
                    if (line.Contains("\"learn_druidism_t1;"))
                    {
                        yield return line;
                        continue;
                    }

                    int idx = line.IndexOf(anchor, StringComparison.Ordinal);
                    if (idx >= 0)
                    {
                        yield return line.Insert(idx, druidism);
                    }
                    else
                    {
                        yield return line;
                    }
                }
            }

            Msl.LoadGML("gml_GlobalScript_table_lines")
                .Apply(HerbalistTrainer)
                .Save();
            static IEnumerable<string> HerbalistTrainer(IEnumerable<string> input)
            {
                const string anchor = "\"trainer_osbrook_carpenter;";

                const string fourtwentyblazeit = "\"trainer_osbrook_herbalist;"; // "Smoke weed everyday" - Snoop Dogg

                string herbalist =
                    "\"trainer_osbrook_herbalist;any;any;any;any;any;" +
                    "Я могу научить тебя кое-чему о растениях и животных,  знаниям, давно забытым. Я сохранил наши традиции. За небольшую плату я покажу тебе мир таким, каким ты его раньше не видел.;" +
                    "I can teach you a thing or two about plants and animals, knowledge long forgotten. I kept our traditions alive. For a small fee, I can show you parts of the world you never thought possible.;" +
                    "我可以教你、些关于植物和动物的知识、这些知识早已被遗忘。我保留了我们的传统。付出、点代价，我可以让你看到从未想象过的世界。;" +
                    "Ich kann dir einiges über Pflanzen und Tiere beibringen, längst vergessenes Wissen. Ich habe unsere Traditionen bewahrt. Für ein paar Münzen zeige ich dir Seiten der Welt, die du nie für möglich gehalten hast.;" +
                    "Puedo enseñarte algunas cosas sobre plantas y animales, conocimientos olvidados hace tiempo. He conservado nuestras tradiciones. Por unas monedas, te mostraré el mundo como nunca lo imaginaste.;" +
                    "Je peux t’enseigner certaines choses sur les plantes et les animaux,  un savoir oublié depuis longtemps. J’ai préservé nos traditions. Pour quelques pièces, je peux te montrer un monde que tu n’aurais jamais imaginé.;" +
                    "Posso insegnarti qualcosa su piante e animali, conoscenze dimenticate da tempo. Ho preservato le nostre tradizioni. Per qualche moneta, posso mostrarti un mondo che non avresti mai immaginato.;" +
                    "Posso te ensinar algumas coisas sobre plantas e animais, conhecimentos esquecidos há muito tempo. Preservei nossas tradições. Por algumas moedas, posso te mostrar um mundo que você nunca imaginou.;" +
                    "Mogę nauczyć cię czegoś o roślinach i zwierzętach, wiedzy dawno zapomnianej. Zachowałem nasze tradycje. Za kilka monet pokażę ci świat, jakiego nigdy sobie nie wyobrażałeś.;" +
                    "Sana bitkiler ve hayvanlar hakkında uzun zamandır unutulmuş bazı bilgiler öğretebilirim. Geleneklerimizi yaşattım. Birkaç sikke karşılığında sana hiç hayal etmediğin bir dünyayı gösterebilirim.;" +
                    "植物や動物について、長い間忘れ去られていた知識を教えてあげよう。私は我らの伝統を守ってきた。少しの対価で、想像もしなかった世界を見せてやる。;" +
                    "식물과 동물에 대해 오래전에 잊힌 지식을 가르쳐 줄 수 있어. 나는 우리의 전통을 지켜왔지. 약간의 대가만 치르면, 네가 상상도 못 했던 세상을 보여주마.;\",";

                foreach (var line in input)
                {
                    if (line.Contains(fourtwentyblazeit))
                    {
                        yield return line;
                        continue;
                    }

                    if (line.Contains(anchor))
                    {
                        int idx = line.IndexOf(anchor, StringComparison.Ordinal);
                        yield return line.Insert(idx, herbalist);
                        continue;
                    }

                    yield return line;
                }
            }

            Msl.LoadAssemblyAsString("gml_Object_o_enemy_Destroy_0") // Has to be done with Assembly or it gets super fucked idk why
               .MatchBelow("event_inherited", 1)
               .InsertBelow(
                    "pushi.e 2\r\n" +
                    "conv.i.v\r\n" +
                    "call.i gml_Script_scr_druid_enemy_destroy(argc=1)\r\n" +
                    "popz.v\r\n"
                )
               .Save();

            Msl.LoadGML("gml_Object_o_player_Draw_72")
                .MatchFrom("spr = sprite_index")
                .InsertAbove(
                    "var _wild = scr_instance_exists_in_list(o_b_wild_shape);\r\n" +
                    "if (_wild)\r\n" +
                    "{\r\n" +
                    "    if (instance_exists(o_pass_skill_bear_aspect) && o_pass_skill_bear_aspect.is_open)\r\n" +
                    "    {\r\n" +
                    "        sprite_index = s_bear;\r\n" +
                    "    }\r\n" +
                    "    else\r\n" +
                    "    {\r\n" +
                    "        sprite_index = s_wolf;\r\n" +
                    "    }\r\n" +
                    "}\r\n"
                )
                .Save();

            // Unarmed damage type adjuster for Wild Shape
            Msl.LoadGML("gml_GlobalScript_scr_atr_calc_combat")
                .MatchFrom("var _mainHandItem = o_inv_right_hand.children")
                .InsertBelow(
                    "var _offHandItem = o_inv_left_hand.children\r\n" +
                    "\r\n" +
                    "// Wild Shape: ignore equipped weapon stats\r\n" +
                    "var _ws = scr_instance_exists_in_list(o_b_wild_shape)\r\n" +
                    "if (_ws)\r\n" +
                    "{\r\n" +
                    "    _mainHandItem = o_inv_slot\r\n" +
                    "    _offHandItem  = o_inv_slot\r\n" +
                    "    _mainHandDebuff = 1\r\n" +
                    "    _offHandDebuff  = 1\r\n" +
                    "    _weapon_count = 0\r\n" +
                    "    _isTwoHand = false\r\n" +
                    "}\r\n"
                )
                .MatchFrom("melee_damage += dmg")
                .InsertBelow(
                    "\r\n" +
                    "if (_ws)\r\n" +
                    "{\r\n" +
                    "    inv_dmg = 0\r\n" +
                    "}\r\n"
                )
                .MatchFrom("DamageType = \"Blunt_Damage\"")
                .InsertBelow(
                    "if (_ws)\r\n" +
                    "{\r\n" +
                    "    // Wolf form: force damage type to rending (from buffs)\r\n" +
                    "    DMG = scr_buff_param(\"Rending_Damage\") * (Weapon_Damage / 100)\r\n" +
                    "    Rending_Damage = DMG\r\n" +
                    "    DamageType = \"Rending_Damage\"\r\n" +
                    "    offDMG = 0\r\n" +
                    "    Blunt_Damage = 0\r\n" +
                    "}\r\n"
                )
                .Save();

            // Need to replace the whole fucking function because for some reason the patching turns 'return' statements inside 'with' statements into 'var $$$$temp$$$$ = true'
            // Really wish there was a better way to do this, if there is I've got no idea how to do it, sorry guys
            Msl.SetStringGMLInFile(
                @"function scr_is_weapon_type(argument0) // gml_Script_scr_is_weapon_type
                {
                    // Wild Shape: treat as unarmed
                    if (scr_instance_exists_in_list(o_b_wild_shape))
                        return 0;

                    var _child = noone;

                    var _slot = instance_find(o_inv_right_hand, 0);
                    if (_slot != noone && variable_instance_exists(_slot, ""children""))
                        _child = _slot.children;


                    if (_child != noone && instance_exists(_child))
                    {
                        var _c = _child;
                        if (_c.equipped && (_c.type == argument0 || argument0 == ""all""))
                            return true;
                    }

                    return 0;
                }", "gml_GlobalScript_scr_is_weapon_type");

            Msl.SetStringGMLInFile(
                @"function scr_is_right_hand_type(argument0) // gml_Script_scr_is_right_hand_type
                {
                    if (scr_instance_exists_in_list(o_b_wild_shape))
                        return 0;

                    var _child = noone;

                    if (instance_exists(o_inv_left_hand))
                        _child = o_inv_left_hand.children;

                    if (_child != noone && instance_exists(_child))
                    {
                        var _c = _child;
                        if (_c.equipped && (_c.type == argument0 || argument0 == ""all""))
                            return true;
                    }

                    return 0;
                }", "gml_GlobalScript_scr_is_right_hand_type");

            Msl.SetStringGMLInFile(
                @"function scr_is_weapon_type_any_hand(argument0) // gml_Script_scr_is_weapon_type_any_hand
                {
                    if (scr_instance_exists_in_list(o_b_wild_shape))
                        return 0;

                    var _c1 = noone;
                    var _c2 = noone;

                    if (instance_exists(o_inv_right_hand))
                        _c1 = o_inv_right_hand.children;

                    if (_c1 != noone && instance_exists(_c1))
                    {
                        if (_c1.equipped && (_c1.type == argument0 || argument0 == ""all""))
                            return true;
                    }

                    if (instance_exists(o_inv_left_hand))
                        _c2 = o_inv_left_hand.children;

                    if (_c2 != noone && instance_exists(_c2))
                    {
                        if (_c2.equipped && (_c2.type == argument0 || argument0 == ""all""))
                            return true;
                    }

                    return 0;
                }", "gml_GlobalScript_scr_is_weapon_type_any_hand");

            Msl.SetStringGMLInFile(
                @"function scr_is_weapon_type_shooting() // gml_Script_scr_is_weapon_type_shooting
                {
                    if (scr_instance_exists_in_list(o_b_wild_shape))
                        return 0;

                    var _c1 = noone;
                    var _c2 = noone;

                    if (instance_exists(o_inv_right_hand))
                        _c1 = o_inv_right_hand.children;

                    if (_c1 != noone && instance_exists(_c1))
                    {
                        if (_c1.equipped && _c1.haveAmmunitionSlot)
                            return true;
                    }

                    if (instance_exists(o_inv_left_hand))
                        _c2 = o_inv_left_hand.children;

                    if (_c2 != noone && instance_exists(_c2))
                    {
                        if (_c2.equipped && _c2.haveAmmunitionSlot)
                            return true;
                    }

                    return 0;
                }", "gml_GlobalScript_scr_is_weapon_type_shooting");

            Msl.SetStringGMLInFile(
                @"function scr_instance_exists_in_list(argument0, argument1) // gml_Script_scr_instance_exists_in_list
                {
                    var _list = argument1;

                    // If caller didn't provide a list, default to PLAYER buffs (not the current instance).
                    if (_list == undefined)
                    {
                        var _p = instance_find(o_player, 0);
                        if (_p != noone && variable_instance_exists(_p, ""buffs""))
                            _list = _p.buffs;
                        else
                            return 0;
                    }

                    if (ds_exists(_list, 2))
                    {
                        var _listSize = ds_list_size(_list);
                        for (var _i = 0; _i < _listSize; _i++)
                        {
                            var _inst = ds_list_find_value(_list, _i);
                            if (instance_exists(_inst) && instance_is(_inst, argument0))
                                return _inst;
                        }
                    }

                    return 0;
                }", "gml_GlobalScript_scr_instance_exists_in_list");

            // For some reason this little hook takes the patcher like 9000 years to do, and everything else is basically instant
            // Just a little nugget of knowledge for all the curious people out there
            Msl.LoadGML("gml_Object_o_inv_consum_Other_24")
                .MatchFrom("    scr_consum_use()")
                .ReplaceBy(
                    "    // --- Attune to the Earth: double herb effects ---\r\n" +
                    "    var _double = 0\r\n" +
                    "    if (ds_list_find_index(category, \"herb\") >= 0)\r\n" +
                    "    {\r\n" +
                    "        with (o_pass_skill_attune_the_earth)\r\n" +
                    "        {\r\n" +
                    "            if (is_open)\r\n" +
                    "                _double = 1\r\n" +
                    "        }\r\n" +
                    "    }\r\n" +
                    "\r\n" +
                    "    // --- Bestial Vigor: raw meat safety + Vigor buff ---\r\n" +
                    "    var _bv_active = 0\r\n" +
                    "    with (o_pass_skill_bestial_vigor)\r\n" +
                    "    {\r\n" +
                    "        if (is_open)\r\n" +
                    "            _bv_active = 1\r\n" +
                    "    }\r\n" +
                    "\r\n" +
                    "    var _bv_rawmeat = 0\r\n" +
                    "    if (_bv_active)\r\n" +
                    "    {\r\n" +
                    "        switch (object_index)\r\n" +
                    "        {\r\n" +
                    "            case o_inv_meat_fat_raw:\r\n" +
                    "            case o_inv_chicken_raw:\r\n" +
                    "            case o_inv_toughmeat_raw:\r\n" +
                    "            case o_inv_tendermeat_raw:\r\n" +
                    "            case o_inv_sinewymeat_raw:\r\n" +
                    "            case o_inv_morsel_raw:\r\n" +
                    "            case o_inv_crabmeat_raw:\r\n" +
                    "            case o_inv_whitefish_raw:\r\n" +
                    "            case o_inv_bear_fat:\r\n" +
                    "            case o_inv_redfish_raw:\r\n" +
                    "            case o_inv_redfishalt_raw:\r\n" +
                    "            case o_inv_fishmorsel_raw:\r\n" +
                    "            case o_inv_gulon_liver:\r\n" +
                    "            case o_inv_harpy_stomach:\r\n" +
                    "            case o_inv_wolf_tongue:\r\n" +
                    "            case o_inv_moose_kidney:\r\n" +
                    "                _bv_rawmeat = 1\r\n" +
                    "                break\r\n" +
                    "        }\r\n" +
                    "    }\r\n" +
                    "\r\n" +
                    "    // Gate poison/nausea creation during this consume\r\n" +
                    "    global.__bv_rawmeat = (_bv_rawmeat == 1)\r\n" +
                    "\r\n" +
                    "    // Apply consume (and double if herb + attune)\r\n" +
                    "    scr_consum_use()\r\n" +
                    "    if (_double)\r\n" +
                    "        scr_consum_use()\r\n" +
                    "\r\n" +
                    "    // Apply Vigor once\r\n" +
                    "    if (_bv_rawmeat)\r\n" +
                    "        scr_effect_create(o_b_fresh, 120, id, id)\r\n" +
                    "\r\n" +
                    "    global.__bv_rawmeat = false\r\n"
                )
                .Save();

            Msl.LoadGML("gml_GlobalScript_scr_effect_create")
                .MatchFromUntil("function scr_effect_create", "{")
                .InsertBelow(
                    "\r\n" +
                    "// Bestial Vigor: suppress raw meat sickness (Poison/Nausea) during consume\r\n" +
                    "if (variable_global_exists(\"__bv_rawmeat\") && global.__bv_rawmeat)\r\n" +
                    "{\r\n" +
                    "    if (argument0 == o_db_poison || argument0 == o_db_nause)\r\n" +
                    "        exit\r\n" +
                    "}\r\n"
                )
                .Save();

            Msl.LoadGML("gml_GlobalScript_scr_param")
                .MatchFrom("var _id_index = -1")
                .InsertAbove(
                    "    // Animal Friendship: default OFF, safe for anything that calls scr_param\r\n" +
                    "    var _friendMode = false\r\n" +
                    "    var _playerHostile = false\r\n" +
                    "\r\n" +
                    "    if (instance_exists(o_pass_skill_animal_friendship) && o_pass_skill_animal_friendship.is_open)\r\n" +
                    "        _friendMode = true\r\n" +
                    "\r\n" +
                    "    // Only apply to non-human enemies (blacklist these factions/subfactions)\r\n" +
                    "    if (_friendMode)\r\n" +
                    "    {\r\n" +
                    "        if (subfaction_key == \"Brigand\" || subfaction_key == \"GrandMagistrate\" || subfaction_key == \"Neutral\" || subfaction_key == \"RottenWillow\" || subfaction_key == \"Undead\" || subfaction_key == \"Vampire\")\r\n" +
                    "            _friendMode = false\r\n" +
                    "    }\r\n" +
                    "\r\n" +
                    "    if (_friendMode)\r\n" +
                    "    {\r\n" +
                    "        // Persist hostility per creature once the player hits them\r\n" +
                    "        if (!variable_instance_exists(id, \"player_hostile\"))\r\n" +
                    "            player_hostile = false\r\n" +
                    "\r\n" +
                    "        if (variable_instance_exists(id, \"is_damage_taken\") && is_damage_taken)\r\n" +
                    "        {\r\n" +
                    "            if (variable_instance_exists(id, \"last_attacker\") && instance_exists(last_attacker) && is_player(last_attacker))\r\n" +
                    "                player_hostile = true\r\n" +
                    "        }\r\n" +
                    "\r\n" +
                    "        _playerHostile = player_hostile\r\n" +
                    "    }\r\n"
                )
                .MatchFrom("var _ai_number = string_to_real(global.animals_ai[_id_index][i])")
                .InsertBelow(
                    "            if (_friendMode && !_playerHostile && _mob_name == \"Player\")\r\n" +
                    "                continue\r\n"
                )
                .Save();

            UndertaleGameObject bear = Msl.GetObject("o_bear");
            bear.ParentId = Msl.GetObject("o_Carnivore");

            Msl.LoadGML("gml_Object_o_snake_trap_Create_0")
                .MatchAll()
                .InsertBelow(
                    "var _friend = 0\r\n" +
                    "with (o_pass_skill_animal_friendship)\r\n" +
                    "{\r\n" +
                    "    if is_open\r\n" +
                    "        _friend = 1\r\n" +
                    "}\r\n" +
                    "if _friend\r\n" +
                    "    instance_destroy()\r\n")
                .Save();

            Msl.LoadGML("gml_GlobalScript_scr_skill_tier_init")
                .MatchFrom("{")
                .InsertBelow(
                    "global.druidism_tier_all = [\"Druidism\", o_skill_stick_to_snake_ico, o_pass_skill_animal_friendship, o_skill_celestial_strike_ico, o_skill_wild_shape_ico, o_skill_butterflies_to_hornets_ico, o_pass_skill_attune_the_earth, o_pass_skill_feral_nature, o_pass_skill_attune_the_sky, o_pass_skill_bestial_vigor, o_skill_entangling_grasp_ico, o_skill_shadows_to_fox_ico, o_pass_skill_circle_of_life, o_skill_healing_grace_ico, o_pass_skill_bear_aspect]")
                .MatchFrom("{")
                .InsertBelow(
                    "global.druidism_tier1 = [\"Druidism\", o_skill_stick_to_snake_ico, o_skill_celestial_strike_ico, o_pass_skill_attune_the_earth, o_pass_skill_bestial_vigor]")
                .Save();

            Msl.LoadGML("gml_Object_o_inv_herbarium_Create_0")
                .MatchAll()
                .InsertBelow(
                    "sk" +
                    "ills_array = global.druidism_tier1")
                .Save();

            Msl.LoadGML("gml_Object_o_npc_herbalist_osbrook_Create_0")
                .MatchAll()
                .InsertBelow("skill_branch_array = [global.druidism_tier1]")
                .Save();

            Msl.LoadGML("gml_GlobalScript_scr_skill_branch_study")
                .MatchBelow("_tier = \"learn_geo_t1\"", 1)
                .InsertBelow(
                    "                case global.druidism_tier1:\r\n" +
                    "                    _tier = \"learn_druidism_t1\"\r\n" +
                    "                    break")
                .Save();

            Msl.LoadGML("gml_GlobalScript_scr_skill_branch_study")
                .MatchBelow("_story_text = \"trainer_osbrook_carpenter\"", 1)
                .InsertBelow(
                    "                case o_npc_herbalist_osbrook:\r\n" +
                    "                    _story_text = \"trainer_osbrook_herbalist\"\r\n" +
                    "                    break")
                .Save();

            Msl.LoadGML("gml_GlobalScript_scr_npc_dialogue_scripts")
                .MatchBelow("_tier = global.geomancy_tier1", 1)
                .InsertBelow(
                    "        case \"learn_druidism_t1\":\r\n" +
                    "            _tier = global.druidism_tier1\r\n" +
                    "            break")
                .Save();

            Msl.LoadGML("gml_Object_o_enemyTransitionsController_Other_10")
                .MatchAll()
                .InsertBelow(ModFiles, "gml_druid_transition_check.gml")
                .Save();

            // Necromancy compat check
            try 
            {
                Msl.LoadGML("gml_Object_o_enemyTransitionsController_Other_11")
                    .MatchFrom("else if instance_exists(o_player)")
                    .InsertBelow("")
                    .Save();
            }
            catch
            {
                Msl.LoadGML("gml_Object_o_enemyTransitionsController_Other_11")
                    .MatchBelow("ds_list_delete(_enemiesList, _i)", 1)
                    .InsertBelow(
                    "else if instance_exists(o_player)\r\n" + 
                    "{\r\n" + 
                    "    var _ppx = o_player.xstart\r\n" + 
                    "    var _ppy = o_player.ystart\r\n" + 
                    "    var _enemyDataMap = ds_map_find_value(_enemyMap, \"dataMap\")\r\n" + 
                    "    var _enemySelfDataMap = ds_map_find_value(_enemyDataMap, \"dataMap\")\r\n" + 
                    "    ds_map_set(_enemyDataMap, \"x\", _ppx)\r\n" + 
                    "    ds_map_set(_enemyDataMap, \"y\", _ppy)\r\n" + 
                    "    ds_map_set(_enemySelfDataMap, \"draw_x\", _ppx)\r\n" + 
                    "    ds_map_set(_enemySelfDataMap, \"draw_y\", _ppy)\r\n" + 
                    "    ds_map_set(_enemySelfDataMap, \"start_x\", _ppx)\r\n" + 
                    "    ds_map_set(_enemySelfDataMap, \"start_y\", _ppy)\r\n" + 
                    "    ds_map_set(_enemySelfDataMap, \"grid_x\", (_ppx div 26))\r\n" + 
                    "    ds_map_set(_enemySelfDataMap, \"grid_y\", (_ppy div 26))\r\n" + 
                    "    with (scr_locationRoomEntityMobsInstanceCreate(_enemyDataMap))\r\n" + 
                    "    {\r\n" + 
                    "        roomEntityIsLoaded = true\r\n" + 
                    "        scr_locationRoomEntityMobsSaveDataSet(id, _enemyDataMap)\r\n" + 
                    "        skip_turn = false\r\n" + 
                    "        scr_enemy_registration()\r\n" + 
                    "        repeat _turnsInitial\r\n" + 
                    "        {\r\n" + 
                    "            scr_states_duration_dec(id, false)\r\n" + 
                    "            scr_skills_duration_dec(id)\r\n" + 
                    "        }\r\n" + 
                    "    }\r\n" + 
                    "    __dsDebuggerMapDestroy(_enemyMap)\r\n" + 
                    "    ds_list_delete(_enemiesList, _i)\r\n}")
                    .Save();
            }

            Msl.LoadAssemblyAsString("gml_GlobalScript_scr_create_context_menu")
                .Apply(ContextMenuIterator)
                .Save();

            // For some fucking reason, you need to convert ASM to GML when you make skill trees
            // That's it, that's the only way it works, idk why
            Msl.LoadAssemblyAsString("gml_Object_o_skill_category_druidism_Other_24")
                .MatchFrom("popz.v")
                .InsertBelow(ModFiles, "gml_Object_o_skill_category_druidism_Other_24.asm")
                .Save();

            // Add the new sprites, mostly ability icons and some other shit
            UndertaleSprite
            tempSprite = Msl.GetSprite("s_stick_to_snake");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_shadows_to_fox");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_butterflies_to_hornets");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_animal_friendship");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_celestial_strike");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_wild_shape");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_attune_the_earth");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_feral_nature");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_attune_the_sky");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_bear_aspect");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_bestial_vigor");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_entangling_grasp");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_healing_grace");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;
            tempSprite = Msl.GetSprite("s_circle_of_life");
            tempSprite.OriginX = 12;
            tempSprite.OriginY = 12;

            tempSprite = Msl.GetSprite("s_b_wild_shape"); // Wild Shape buff
            tempSprite.OriginX = 13;
            tempSprite.OriginY = 13;
            tempSprite = Msl.GetSprite("s_db_rooted"); // Rooted debuff from Entangling Grasp
            tempSprite.OriginX = 13;
            tempSprite.OriginY = 13;

            tempSprite = Msl.GetSprite("s_hornets_shadow"); // Placeholder for the hornet summon hover placement
            tempSprite.OriginX = 15;
            tempSprite.OriginY = 21;
            tempSprite = Msl.GetSprite("s_fox_shadow"); // Placeholder for the fox summon hover placement
            tempSprite.OriginX = 27;
            tempSprite.OriginY = 23;

            // Animation insertions for the rooted effect
            tempSprite = Msl.GetSprite("s_root_cast");
            tempSprite.OriginX = 31;
            tempSprite.OriginY = 18;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_root_loop");
            tempSprite.OriginX = 20;
            tempSprite.OriginY = 37;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_root_start");
            tempSprite.OriginX = 20;
            tempSprite.OriginY = 37;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_root_end");
            tempSprite.OriginX = 20;
            tempSprite.OriginY = 37;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite = Msl.GetSprite("s_rootsmall_loop");
            tempSprite.OriginX = 24;
            tempSprite.OriginY = 25;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_rootsmall_start");
            tempSprite.OriginX = 24;
            tempSprite.OriginY = 25;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_rootsmall_end");
            tempSprite.OriginX = 24;
            tempSprite.OriginY = 25;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite = Msl.GetSprite("s_rootmedium_loop");
            tempSprite.OriginX = 24;
            tempSprite.OriginY = 25;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_rootmedium_start");
            tempSprite.OriginX = 24;
            tempSprite.OriginY = 25;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_rootmedium_end");
            tempSprite.OriginX = 24;
            tempSprite.OriginY = 25;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite = Msl.GetSprite("s_rootbig_loop");
            tempSprite.OriginX = 38;
            tempSprite.OriginY = 47;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_rootbig_start");
            tempSprite.OriginX = 38;
            tempSprite.OriginY = 47;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_rootbig_end");
            tempSprite.OriginX = 38;
            tempSprite.OriginY = 47;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite = Msl.GetSprite("s_roothigh_loop");
            tempSprite.OriginX = 31;
            tempSprite.OriginY = 34;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_roothigh_start");
            tempSprite.OriginX = 31;
            tempSprite.OriginY = 34;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_roothigh_end");
            tempSprite.OriginX = 31;
            tempSprite.OriginY = 34;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;

            // Animation insertions for our custom skills
            tempSprite = Msl.GetSprite("s_spell_celestial_strike");
            tempSprite.OriginX = 24;
            tempSprite.OriginY = 12;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.5f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_celestial_strike_hit");
            tempSprite.OriginX = 35;
            tempSprite.OriginY = 35;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.4f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_spell_celestial_strike_birth");
            tempSprite.OriginX = 38;
            tempSprite.OriginY = 25;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.3f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_spell_celestial_strike_cast_cancel");
            tempSprite.OriginX = 36;
            tempSprite.OriginY = 80;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.2f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_spell_celestial_strike_cast_cast");
            tempSprite.OriginX = 36;
            tempSprite.OriginY = 80;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.2f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_spell_celestial_strike_cast_loop");
            tempSprite.OriginX = 36;
            tempSprite.OriginY = 80;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.2f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
            tempSprite = Msl.GetSprite("s_spell_celestial_strike_cast_start");
            tempSprite.OriginX = 36;
            tempSprite.OriginY = 80;
            tempSprite.IsSpecialType = true;
            tempSprite.SVersion = 3;
            tempSprite.GMS2PlaybackSpeed = 0.2f;
            tempSprite.GMS2PlaybackSpeedType = AnimSpeedType.FramesPerGameFrame;
        }

        private static IEnumerable<string> ContextMenuIterator(IEnumerable<string> input)
        {
            // Materialize so we can scan for max label safely
            var lines = input.ToList();

            // Find the highest label number already present (":[123]")
            var labelDefRegex = new Regex(@":\[(\d+)\]");
            int maxLabel = -1;
            foreach (var l in lines)
            {
                var m = labelDefRegex.Match(l);
                if (m.Success && int.TryParse(m.Groups[1].Value, out int n))
                    maxLabel = Math.Max(maxLabel, n);
            }

            // Allocate fresh labels that won't collide
            int L0 = maxLabel + 1;
            int L1 = maxLabel + 2;
            int L2 = maxLabel + 3;

            // Build insert as individual ASM lines (NOT one multiline string cuz that was some sketchy fkin code)
            var insertLines = new[]
            {
                $"bt [{L1}]",
                $":[{L0}]",
                "push.v other.can_speak",
                "conv.v.b",
                "not.b",
                $"b [{L2}]",
                $":[{L1}]",
                "push.e 1",
                $":[{L2}]"
            };

            bool foundSwap = false;
            bool foundIndex = false;
            bool foundLabel = false;
            bool foundConv = false;
            bool done = false;

            string pattern = @"\[(\d+)\]";
            string index = "";

            foreach (string item in lines)
            {
                if (!foundSwap && item.Contains("Swap"))
                {
                    foundSwap = true;
                }
                else if (!foundIndex && foundSwap && item.Contains("bt"))
                {
                    foundIndex = true;
                    index = $":[{Regex.Match(item, pattern).Groups[1].Value}]";
                }
                else if (!foundLabel && foundIndex && item.Contains(index))
                {
                    foundLabel = true;
                }
                else if (!foundConv && foundLabel && item.Contains("conv"))
                {
                    foundConv = true;
                }
                else if (foundConv && !done)
                {
                    // Inject BEFORE the current line
                    foreach (var ins in insertLines)
                        yield return ins;

                    done = true;
                }

                yield return item;
            }
        }
    }
}