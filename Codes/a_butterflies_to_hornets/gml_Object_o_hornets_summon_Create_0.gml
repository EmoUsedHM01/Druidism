event_inherited()
scr_param("Forest Buzzer", true, "Neutral")
is_flying = true
unitAttackDiss = 1000
blood_ext = false
inside_particles = o_empty
scr_create_skill_passive(o_enemy_pass_hive)
isIdleAnimation = true
ds_list_clear(weapon_impact)
ds_list_clear(emo_sound)
corpse_type = o_ghost_corpse
ds_list_add(weapon_impact, snd_deathstinger_attack_1, snd_deathstinger_attack_2, snd_deathstinger_attack_3, snd_deathstinger_attack_4)
alert_snd = choose(snd_deathstinger_attack_1, snd_deathstinger_attack_2, snd_deathstinger_attack_3, snd_deathstinger_attack_4)
sound_animation_playing = false
shadow_spr = s_empty
image_speed = 1
DamageType = "Piercing_Damage"
image_index = irandom(image_number - 1)
alarmPercent = 100
netSize = "small"

// Follower additions
master = o_player
faction_key = "Neutral"
subfaction_key = "Neutral"
ai_script = scr_enemy_choose_state
can_talk = false
can_speak = false
occupation = "companion"
is_enemy = false
ai_is_on = true
follower_type = "hornets"
follower_owner = noone
if (instance_exists(o_player))
	follower_owner = o_player.id

// Need this to keep the animations
if (!variable_instance_exists(id, "c_index"))
    c_index = irandom(image_number - 1)

image_index = c_index
image_speed = 1