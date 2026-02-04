event_user(1)
var _currentHour = ds_map_find_value(global.timeDataMap, "hours")
var _night = abs((12 - _currentHour))
var _day = abs((12 - _night))
if instance_exists(owner)
{
    Arcane_Damage = math_round(((_night * owner.Magic_Power) / 100))
    Sacred_Damage = math_round(((_day * owner.Magic_Power) / 100))
    scr_temp_incr_atr("MP_Restoration", _night, 4, owner, owner)
    scr_temp_incr_atr("Block_Recovery", _day, 4, owner, owner)
}
event_inherited()
with (target)
    scr_audio_play_at(snd_AetherShield_loop)