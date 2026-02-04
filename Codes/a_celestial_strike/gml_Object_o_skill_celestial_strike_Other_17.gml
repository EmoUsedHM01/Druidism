var _currentHour = ds_map_find_value(global.timeDataMap, "hours")
var _night = abs((12 - _currentHour))
var _day = abs((12 - _night))
if instance_exists(owner)
{
    ds_map_replace(data, "Arcane_Damage", (math_round(((_night * owner.Magic_Power) / 100)) / 100))
    ds_map_replace(data, "Sacred_Damage", (math_round(((_day * owner.Magic_Power) / 100)) / 100))
}
event_inherited()
