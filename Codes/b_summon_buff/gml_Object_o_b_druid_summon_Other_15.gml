event_inherited()

if (!instance_exists(target)) exit

var _summoner = noone
if (variable_instance_exists(target, "owner") && instance_exists(target.owner))
    _summoner = target.owner
else if (instance_exists(owner))
    _summoner = owner
else if (instance_exists(o_player))
    _summoner = o_player

if (!instance_exists(_summoner)) exit

// Build deltas
var _hp_before  = target.HP
var _evs = ((_summoner.Vitality - 10) * 3)
var _dr = -((_summoner.Vitality - 10) * 3)
var _hit = ((_summoner.WIL - 10) * 3)
var _dmg = ((_summoner.WIL - 10) * 3)
var _fmb = -((_summoner.WIL - 10) * 3)

ds_map_clear(data)
ds_map_add(data, "EVS", _evs)
ds_map_add(data, "DMG_Rec", _dr)
ds_map_add(data, "max_hp", _summoner.Vitality)
ds_map_add(data, "Hit_Chance", _hit)
ds_map_add(data, "FMB", _fmb)
ds_map_add(data, "Weapon_Damage", _dmg)
ds_map_add(data, "Pure_Damage_Self", 1)

scr_atr_calc(target.id)

if (!druid_hp_fixed)
{
    target.HP = target.max_hp
    druid_hp_fixed = true
}
else
{
    target.HP = _hp_before
}