if is_open
{
var _currentHour = ds_map_find_value(global.timeDataMap, "hours")
var _night = abs((12 - _currentHour))
var _day = abs((12 - _night))
    ds_map_replace(data, "Hunger_Resistance", _currentHour)
    ds_map_replace(data, "Fatigue_Gain",(24 - _currentHour))
	
    ds_map_replace(data, "Damage_Received", - _day)
    ds_map_replace(data, "Cooldown_Reduction", - _night)	
}
event_inherited()
