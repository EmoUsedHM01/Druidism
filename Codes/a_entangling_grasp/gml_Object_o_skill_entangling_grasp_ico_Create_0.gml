event_inherited()
ds_list_add(global.speech_text,
	"entangling_grasp", "Verstrengel Daardie Teef!", "entangling_grasp_end",
	"MC_entangling_grasp", "Verstrengel Yarna?!?", "MC_entangling_grasp_end"
)
child_skill = o_skill_entangling_grasp
event_perform_object(child_skill, ev_create, 0)
attributes_names_to_open = ["STR", "PRC"]
attributes_value_to_open = 6
level_to_open = 6
tier_to_open = global.druidism_tier1