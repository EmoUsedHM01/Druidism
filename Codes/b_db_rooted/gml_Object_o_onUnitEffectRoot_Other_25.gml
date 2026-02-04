event_inherited()
var _netSprite = s_empty
var _netSpriteStart = s_empty
var _netSpriteEnd = s_empty
var _netOffsetX = 0
var _netOffsetY = 0

with (owner)
{
    _netOffsetX = netOffset[0]
    _netOffsetY = netOffset[1]
    
    switch (netSize)
    {
        case "small":
            _netSprite = s_rootsmall_loop
            _netSpriteStart = s_rootsmall_start
            _netSpriteEnd = s_rootsmall_end
            break
        
        case "medium":
            _netSprite = s_rootmedium_loop
            _netSpriteStart = s_rootmedium_start
            _netSpriteEnd = s_rootmedium_end
            break
        
        case "big":
            _netSprite = s_rootbig_loop
            _netSpriteStart = s_rootbig_start
            _netSpriteEnd = s_rootbig_end
            break
        
        case "high":
            _netSprite = s_roothigh_loop
            _netSpriteStart = s_roothigh_start
            _netSpriteEnd = s_roothigh_end
            break
        
        default:
            _netSprite = s_root_loop
            _netSpriteStart = s_root_start
            _netSpriteEnd = s_root_end
            break
    }
}

spriteIndexStart = _netSpriteStart
spriteIndexLoop = _netSprite
spriteIndexEnd = _netSpriteEnd
offsetX = _netOffsetX
offsetY = _netOffsetY