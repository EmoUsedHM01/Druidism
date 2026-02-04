event_inherited()
ds_list_add(global.speech_text,
	"healing_grace", "Ghafar le Ghafar...!", "healing_grace_end",
	"MC_healing_grace", "Ghar la Gfer?", "MC_healing_grace_end"
)
child_skill = o_skill_healing_grace
event_perform_object(child_skill, ev_create, 0)
attributes_names_to_open = ["PRC", "Vitality", "WIL"]
attributes_value_to_open = 13
level_to_open = 18
tier_to_open = global.druidism_tier1
